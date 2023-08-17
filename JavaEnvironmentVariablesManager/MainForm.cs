using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace JavaEnvironmentVariablesManager
{
    public partial class MainForm : Form
    {
        const int HWND_BROADCAST = 0xffff;
        const uint WM_SETTINGCHANGE = 0x001a;

        const string JAVA_HOME_STRING = "JAVA_HOME";
        const string DIFF_VERSION_JAVA_HOME_PREFIX = "JAVA_HOME_";
        const string JAVA_HOME_IN_PATH_VALUE = "%JAVA_HOME%\\bin";

        const string PATH_ENVIRONMENT_VARIABLES_NAME = "Path";
        const string DEFAULT_JAVA_INSTALL_ROOT_DIR_PATH = "C:\\Program Files\\Java";
        readonly Regex REGEX_JAVA_VERSION_STRING = new Regex("java version \"(.*?)\"");

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern bool SendNotifyMessage(IntPtr hWnd, uint Msg,
        UIntPtr wParam, string lParam);

        public MainForm()
        {
            InitializeComponent();

            _SetAddNewJavaVersionStep(true);

            _RefreshJavaEnvironmentVariablesState();
        }

        #region 工具类函数

        /// <summary>
        /// 打开设置系统环境变量界面
        /// </summary>
        private void _OpenSetEnvironmentVariablesUI()
        {
            try
            {
                // 打开“系统属性”，并切换到“高级”选项卡，最下面有“环境变量”按钮
                //Process.Start("SystemPropertiesAdvanced.exe", "Environment Variables");

                // 直接打开“环境变量”设置界面
                Process.Start("rundll32.exe", "sysdm.cpl,EditEnvironmentVariables");
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $"无法正常打开系统环境变量设置界面，异常信息为：\n{ex}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 发出Windows系统通知，刷新系统环境变量
        /// </summary>
        private void _RefreshEnvironmentVariables()
        {
            // 这种方法不好，需要打开设置系统环境变量界面，由用户手工点击“确定”的妥协方案来使修改后的环境变量立即生效
            //MessageBox.Show(this, "下面将弹出设置环境变量界面，请您手工点击“确定”按钮，使刚才的修改立即生效，注意必须是点击“确定”而不能是“取消”或者右上角的叉号关闭按钮", "注意", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //_OpenSetEnvironmentVariablesUI();

            SendNotifyMessage((IntPtr)HWND_BROADCAST, WM_SETTINGCHANGE, (UIntPtr)0, "Environment");
        }

        /// <summary>
        /// 通过调用CMD命令获取java版本
        /// </summary>
        /// <returns>能获取到返回版本号，否则返回null</returns>
        private string _GetCurrentJavaVersion()
        {
            try
            {
                Process process = new Process();

                process.StartInfo.FileName = "java";
                process.StartInfo.Arguments = "-version";

                // 不弹出CMD窗口而是静默执行
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;

                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;

                process.Start();
                process.WaitForExit();

                // 这里比较奇怪的是，版本信息是在StandardError中读到而不是StandardOutput中
                string standardOutputString = process.StandardOutput.ReadToEnd();
                string standardErrorString = process.StandardError.ReadToEnd();

                process.Close();

                string versionString = standardErrorString.StartsWith("java version") ? standardErrorString : standardOutputString;
                if (string.IsNullOrEmpty(versionString) == false)
                {
                    Match match = REGEX_JAVA_VERSION_STRING.Match(versionString);
                    if (match.Success == true)
                        return match.Groups[1].Value;
                }
            }
            catch
            {
            }

            return null;
        }

        /// <summary>
        /// 对指定的java.exe通过调用CMD命令获取java版本
        /// </summary>
        /// <param name="javaExeFilePath">java.exe的路径</param>
        /// <returns>能获取到返回版本号，否则返回null</returns>
        private string _GetJavaExeVersion(string javaExeFilePath)
        {
            try
            {
                Process process = new Process();

                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.WorkingDirectory = Path.GetDirectoryName(javaExeFilePath);

                // 不弹出CMD窗口而是静默执行
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;

                process.StartInfo.RedirectStandardInput = true;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;

                process.Start();
                process.StandardInput.WriteLine("java -version&exit");

                process.WaitForExit();

                // 这里在StandardError中输出命令本身，而在StandardOutput中输出版本结果
                string standardOutputString = process.StandardOutput.ReadToEnd();
                string standardErrorString = process.StandardError.ReadToEnd();

                process.Close();

                string versionString = standardErrorString.StartsWith("java version") ? standardErrorString : standardOutputString;
                if (string.IsNullOrEmpty(versionString) == false)
                {
                    Match match = REGEX_JAVA_VERSION_STRING.Match(versionString);
                    if (match.Success == true)
                        return match.Groups[1].Value;
                }
            }
            catch
            {
            }

            return null;
        }

        /// <summary>
        /// 获取注册表中记录系统环境变量的注册表子键（以可读写方法打开）
        /// </summary>
        private RegistryKey _GetEnvironmentVariablesRegistryKey()
        {
            return Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Control\Session Manager\Environment", true);
        }

        /// <summary>
        /// 获取系统环境变量中Path中的所有值
        /// </summary>
        /// <param name="environmentVariablesRegistryKey">注册表中记录系统环境变量的注册表子键</param>
        /// <returns>无法获取返回null</returns>
        private string[] _GetPathEnvironmentVariablesValues(RegistryKey environmentVariablesRegistryKey)
        {
            string value = environmentVariablesRegistryKey.GetValue(PATH_ENVIRONMENT_VARIABLES_NAME, null, RegistryValueOptions.DoNotExpandEnvironmentNames)?.ToString();
            if (string.IsNullOrEmpty(value) == true)
                return null;
            else
                return value.Split(';');
        }

        #endregion

        #region 切换系统中当前使用的Java版本

        private void _RefreshJavaEnvironmentVariablesState()
        {
            CboAvailableJavaVersion.Items.Clear();

            string javaVersionString = _GetCurrentJavaVersion();
            LblCurrentJavaVersion.Text = string.IsNullOrEmpty(javaVersionString) ? "未获取" : javaVersionString;

            RegistryKey registryKey = _GetEnvironmentVariablesRegistryKey();
            if (registryKey != null)
            {
                string currentJavaVersionValue = null;

                string[] allValueNames = registryKey.GetValueNames();
                foreach (string name in allValueNames)
                {
                    if (name == JAVA_HOME_STRING)
                        currentJavaVersionValue = registryKey.GetValue(name, null, RegistryValueOptions.DoNotExpandEnvironmentNames)?.ToString();
                    else if (name.StartsWith(DIFF_VERSION_JAVA_HOME_PREFIX) == true)
                    {
                        string pathValue = registryKey.GetValue(name, null, RegistryValueOptions.None)?.ToString();
                        CboAvailableJavaVersion.Items.Add($"{name}({pathValue})");
                    }
                }

                LblCurrentJavaHomeValue.Text = string.IsNullOrEmpty(currentJavaVersionValue) ? "未获取" : currentJavaVersionValue;

                registryKey.Close();
            }

            LblJavaVersionCount.Text = $"本机中有{CboAvailableJavaVersion.Items.Count}个不同Java版本可供切换";
        }

        private void BtnSwitchJavaVersion_Click(object sender, System.EventArgs e)
        {
            if (CboAvailableJavaVersion.Items.Count == 0)
            {
                MessageBox.Show(this, "当前没有任何可供切换的版本，您可点击“刷新”按钮重新获取本机中Java系统环境变量状态，如果仍旧不能获取，请检查是否按本工具上述规范要求配置了环境变量，如果没有，建议使用最下面的移除功能删除环境变量后用本工具重建", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (CboAvailableJavaVersion.SelectedIndex >= 0)
            {
                string selectedItemString = CboAvailableJavaVersion.SelectedItem.ToString();
                int bracketIndex = selectedItemString.IndexOf('(');
                string javaEnvironmentVariablesName = selectedItemString.Substring(0, bracketIndex);

                RegistryKey registryKey = _GetEnvironmentVariablesRegistryKey();
                if (registryKey != null)
                {
                    try
                    {
                        // 将“JAVA_HOME”的值设为选中的版本
                        registryKey.SetValue(JAVA_HOME_STRING, $"%{javaEnvironmentVariablesName}%", RegistryValueKind.ExpandString);
                        registryKey.Flush();

                        // 确保Path中含有“%JAVA_HOME%\bin”并且在最前
                        string[] pathValues = _GetPathEnvironmentVariablesValues(registryKey);
                        if (pathValues != null && pathValues.Length > 0)
                        {
                            // 如果最前面的不是“%JAVA_HOME%\bin”，查找是不是配置在了中间位置
                            if (pathValues[0] != JAVA_HOME_IN_PATH_VALUE)
                            {
                                for (int index = 0; index < pathValues.Length; index++)
                                {
                                    if (pathValues[index] == JAVA_HOME_IN_PATH_VALUE)
                                        pathValues[index] = null;
                                }

                                StringBuilder sb = new StringBuilder();
                                sb.Append(JAVA_HOME_IN_PATH_VALUE).Append(";");
                                foreach (string value in pathValues)
                                {
                                    if (string.IsNullOrEmpty(value) == false)
                                        sb.Append(value).Append(";");
                                }
                                registryKey.SetValue(PATH_ENVIRONMENT_VARIABLES_NAME, sb.ToString(), RegistryValueKind.ExpandString);
                            }
                        }
                        else
                            registryKey.SetValue(PATH_ENVIRONMENT_VARIABLES_NAME, $"{JAVA_HOME_IN_PATH_VALUE};", RegistryValueKind.ExpandString);

                        MessageBox.Show(this, "切换成功", "恭喜", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _RefreshEnvironmentVariables();
                        _RefreshJavaEnvironmentVariablesState();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(this, $"执行中引发异常，操作未能成功完成，异常信息为：\n{ex}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        registryKey.Close();
                    }
                }
                else
                {
                    MessageBox.Show(this, "无法在注册表中访问系统环境变量设置，此功能无法使用", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                MessageBox.Show(this, "未选择要切换到哪个Java版本", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        #endregion

        #region 为新安装的Java版本添加环境变量

        private void _SetAddNewJavaVersionStep(bool isBackToChooseNewJavaVersionDirPath)
        {
            TxtNewJavaVersionDirPath.ReadOnly = !isBackToChooseNewJavaVersionDirPath;
            BtnChooseNewJavaVersionDirPath.Enabled = isBackToChooseNewJavaVersionDirPath;
            BtnToAddJavaVersionNextStep.Visible = isBackToChooseNewJavaVersionDirPath;
            BtnBackToChooseNewJavaVersionDirPath.Visible = !isBackToChooseNewJavaVersionDirPath;
            TxtNewJavaEnvironmentVariablesName.Enabled = !isBackToChooseNewJavaVersionDirPath;
            BtnAddJavaVersion.Enabled = !isBackToChooseNewJavaVersionDirPath;
        }

        private void BtnChooseNewJavaVersionDirPath_Click(object sender, System.EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择要添加系统环境变量的Java版本的安装目录";
            // 默认选择的文件夹逻辑为，如果输入框中已有已存在的合法路径则用这个，否则如果Java默认安装目录存在则用这个
            string inputNewJavaVersionDirPath = TxtNewJavaVersionDirPath.Text.Trim();
            if (string.IsNullOrEmpty(inputNewJavaVersionDirPath) == false && Directory.Exists(inputNewJavaVersionDirPath) == true)
                dialog.SelectedPath = inputNewJavaVersionDirPath;
            else if (Directory.Exists(DEFAULT_JAVA_INSTALL_ROOT_DIR_PATH) == true)
                dialog.SelectedPath = DEFAULT_JAVA_INSTALL_ROOT_DIR_PATH;

            if (dialog.ShowDialog() == DialogResult.OK)
                TxtNewJavaVersionDirPath.Text = dialog.SelectedPath;
        }

        private void BtnToAddJavaVersionNextStep_Click(object sender, System.EventArgs e)
        {
            string inputNewJavaVersionDirPath = TxtNewJavaVersionDirPath.Text.Trim();
            if (string.IsNullOrEmpty(inputNewJavaVersionDirPath) == true)
            {
                MessageBox.Show(this, "请先选择或者输入要添加系统环境变量的Java版本的安装目录", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (Directory.Exists(inputNewJavaVersionDirPath) == false)
            {
                MessageBox.Show(this, "选择的Java安装目录不存在", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // 如果路径最后有“\”要去掉
            inputNewJavaVersionDirPath = Path.GetFullPath(inputNewJavaVersionDirPath);
            if (inputNewJavaVersionDirPath.EndsWith("\\") == true)
                inputNewJavaVersionDirPath = inputNewJavaVersionDirPath.Substring(0, inputNewJavaVersionDirPath.Length - 1);

            // 验证该目录是否正确，即必须含有bin子文件夹，并且其中有java.exe
            string binDirPath = Path.Combine(inputNewJavaVersionDirPath, "bin");
            string javaExeFilePath = Path.Combine(inputNewJavaVersionDirPath, "bin\\java.exe");
            if (Directory.Exists(binDirPath) == true && File.Exists(javaExeFilePath) == true)
            {
                // 废弃通过调用对应版本java.exe执行“java -version”返回版本号的方法，因为返回格式不够统一，JDK8为“1.8.0_301”，JDK17则为“17.0.7”
                //string javaVersion = _GetJavaExeVersion(javaExeFilePath);
                //if (javaVersion == null)
                //{
                //    MessageBox.Show(this, $"无法对“{javaExeFilePath}”执行“java -version”命令获取Java版本号，请确认是否为正确的java.exe", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}

                // 通过java.exe的文件属性，获取版本信息
                FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(javaExeFilePath);
                // 完整版本号形如“8.0.3010.9”“17.0.7.0”
                string javaVersion = fileVersionInfo.FileVersion;

                // 提取前面的大版本号
                int dotIndex = javaVersion.IndexOf('.');
                if (dotIndex == -1)
                {
                    MessageBox.Show(this, $"对“{javaExeFilePath}”执行“java -version”命令获取的Java版本号为：{javaVersion}，无法从中提取大版本号", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string mainVersion = javaVersion.Substring(0, dotIndex);
                string javaEnvironmentVariablesNameUseMainVersion = $"{DIFF_VERSION_JAVA_HOME_PREFIX}{mainVersion}";
                // 判断是否存在以“JAVA_HOME_大版本号”为名的环境变量，如果已存在则用完整版本号命名
                RegistryKey registryKey = _GetEnvironmentVariablesRegistryKey();
                if (registryKey != null)
                {
                    string existValue = registryKey.GetValue(javaEnvironmentVariablesNameUseMainVersion, null)?.ToString();
                    if (existValue != null)
                    {
                        string javaEnvironmentVariablesNameUseFullVersion = $"{DIFF_VERSION_JAVA_HOME_PREFIX}{javaVersion}";
                        TxtNewJavaEnvironmentVariablesName.Text = javaEnvironmentVariablesNameUseFullVersion;
                        MessageBox.Show(this, $"当前系统环境变量中已存在名为“{javaEnvironmentVariablesNameUseMainVersion}”（值为：{existValue}）的环境变量，故新建环境变量名默认以完整版本号填充，您可以自行修改", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                        TxtNewJavaEnvironmentVariablesName.Text = javaEnvironmentVariablesNameUseMainVersion;

                    registryKey.Close();
                }
                else
                    TxtNewJavaEnvironmentVariablesName.Text = javaEnvironmentVariablesNameUseMainVersion;

                TxtNewJavaVersionDirPath.Text = inputNewJavaVersionDirPath;
                _SetAddNewJavaVersionStep(false);
            }
            else
            {
                MessageBox.Show(this, "选择的Java安装目录错误，正确的Java安装目录下应有bin子文件夹，并且bin子文件夹中含有java.exe", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void BtnBackToChooseNewJavaVersionDirPath_Click(object sender, System.EventArgs e)
        {
            _SetAddNewJavaVersionStep(true);
        }

        private void BtnAddJavaVersion_Click(object sender, System.EventArgs e)
        {
            string inputNewJavaEnvironmentVariablesName = TxtNewJavaEnvironmentVariablesName.Text.Trim();
            if (string.IsNullOrEmpty(inputNewJavaEnvironmentVariablesName) == true)
            {
                MessageBox.Show(this, "必须指定环境变量名", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (inputNewJavaEnvironmentVariablesName == DIFF_VERSION_JAVA_HOME_PREFIX || inputNewJavaEnvironmentVariablesName.StartsWith(DIFF_VERSION_JAVA_HOME_PREFIX) == false)
            {
                MessageBox.Show(this, $"指定的环境变量名必须以“{DIFF_VERSION_JAVA_HOME_PREFIX}开头，后面跟版本号区分，只有按此规范命名才能被本工具正确管理”", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // 判断是否存在以此为名的环境变量，如果已存在则需要询问用户是否替代
            RegistryKey registryKey = _GetEnvironmentVariablesRegistryKey();
            if (registryKey != null)
            {
                string existValue = registryKey.GetValue(inputNewJavaEnvironmentVariablesName, null)?.ToString();
                if (existValue != null)
                {
                    if (DialogResult.No == MessageBox.Show(this, $"当前系统环境变量中已存在名为“{inputNewJavaEnvironmentVariablesName}”（值为：{existValue}）的环境变量，是否要覆盖原值？\n点击“是”覆盖原值，点击“否”返回修改环境变量名", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                    {
                        registryKey.Close();
                        return;
                    }
                }
                // 执行添加
                try
                {
                    string newJavaVersionDirPath = TxtNewJavaVersionDirPath.Text;
                    // 1、新增该版本的环境变量
                    registryKey.SetValue(inputNewJavaEnvironmentVariablesName, newJavaVersionDirPath, RegistryValueKind.String);
                    // 2、确保Path中含有“%JAVA_HOME%\bin”并且在最前
                    string[] pathValues = _GetPathEnvironmentVariablesValues(registryKey);
                    if (pathValues != null && pathValues.Length > 0)
                    {
                        // 如果最前面的不是“%JAVA_HOME%\bin”，查找是不是配置在了中间位置
                        if (pathValues[0] != JAVA_HOME_IN_PATH_VALUE)
                        {
                            for (int index = 0; index < pathValues.Length; index++)
                            {
                                if (pathValues[index] == JAVA_HOME_IN_PATH_VALUE)
                                    pathValues[index] = null;
                            }

                            StringBuilder sb = new StringBuilder();
                            sb.Append(JAVA_HOME_IN_PATH_VALUE).Append(";");
                            foreach (string value in pathValues)
                            {
                                if (string.IsNullOrEmpty(value) == false)
                                    sb.Append(value).Append(";");
                            }
                            registryKey.SetValue(PATH_ENVIRONMENT_VARIABLES_NAME, sb.ToString(), RegistryValueKind.ExpandString);
                        }
                    }
                    else
                        registryKey.SetValue(PATH_ENVIRONMENT_VARIABLES_NAME, $"{JAVA_HOME_IN_PATH_VALUE};", RegistryValueKind.ExpandString);
                    // 3、如果当前存在“JAVA_HOME”的环境变量且与本次配置值不同，询问用户是否将“JAVA_HOME”设为当前版本，否则直接新建
                    string javaHomeValue = registryKey.GetValue(JAVA_HOME_STRING, null)?.ToString();
                    if (javaHomeValue != null)
                    {
                        if (javaHomeValue != newJavaVersionDirPath)
                        {
                            if (DialogResult.Yes == MessageBox.Show(this, $"当前系统环境变量“{JAVA_HOME_STRING}的值为“{javaHomeValue}”，是否将其改为此次新增版本对应的“{newJavaVersionDirPath}”？", "请选择", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                                registryKey.SetValue(JAVA_HOME_STRING, $"%{inputNewJavaEnvironmentVariablesName}%", RegistryValueKind.ExpandString);
                        }
                    }
                    else
                        registryKey.SetValue(JAVA_HOME_STRING, $"%{inputNewJavaEnvironmentVariablesName}%", RegistryValueKind.ExpandString);

                    registryKey.Flush();
                    MessageBox.Show(this, "添加成功", "恭喜", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshEnvironmentVariables();
                    _RefreshJavaEnvironmentVariablesState();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, $"执行中引发异常，操作未能成功完成，异常信息为：\n{ex}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    registryKey.Close();
                }
            }
            else
            {
                MessageBox.Show(this, "无法在注册表中访问系统环境变量设置，此功能无法使用", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _SetAddNewJavaVersionStep(true);
        }

        #endregion

        #region 移除系统中相关的Java环境变量

        private void BtnAnalyzeJavaEnvironmentVariables_Click(object sender, System.EventArgs e)
        {
            LstRemoveKey.Items.Clear();
            LstRemovePathValue.Items.Clear();
            List<string> addRemoveKeys = new List<string>();
            List<string> addRemovePathValues = new List<string>();
            RegistryKey registryKey = _GetEnvironmentVariablesRegistryKey();
            if (registryKey == null)
            {
                MessageBox.Show(this, "无法在注册表中访问系统环境变量设置，此功能无法使用", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string[] allValueNames = registryKey.GetValueNames();
            foreach (string name in allValueNames)
            {
                if (name.IndexOf("java", StringComparison.CurrentCultureIgnoreCase) != -1)
                    addRemoveKeys.Add($"{name}({registryKey.GetValue(name, null, RegistryValueOptions.DoNotExpandEnvironmentNames)?.ToString()})");
            }
            addRemoveKeys.Sort();
            foreach (string key in addRemoveKeys)
                LstRemoveKey.Items.Add(key);

            string[] pathValues = _GetPathEnvironmentVariablesValues(registryKey);
            if (pathValues != null)
            {
                foreach (string value in pathValues)
                {
                    // 注意默认的“C:\Program Files (x86)\Common Files\Oracle\Java\javapath”不要删除
                    if (value.IndexOf("java", StringComparison.CurrentCultureIgnoreCase) != -1 && value.IndexOf("javapath") == -1)
                        addRemovePathValues.Add(value);
                }
            }
            addRemovePathValues.Sort();
            foreach (string value in addRemovePathValues)
                LstRemovePathValue.Items.Add(value);

            registryKey.Close();
        }

        private void BtnRemoveKeyItem_Click(object sender, System.EventArgs e)
        {
            if (LstRemoveKey.SelectedIndex >= 0)
                LstRemoveKey.Items.RemoveAt(LstRemoveKey.SelectedIndex);
        }

        private void BtnRemovePathValueItem_Click(object sender, System.EventArgs e)
        {
            if (LstRemovePathValue.SelectedIndex >= 0)
                LstRemovePathValue.Items.RemoveAt(LstRemovePathValue.SelectedIndex);
        }

        private void BtnRemoveJavaEnvironmentVariables_Click(object sender, System.EventArgs e)
        {
            if (LstRemoveKey.Items.Count == 0 && LstRemovePathValue.Items.Count == 0)
            {
                MessageBox.Show(this, "左边列表中没有任何要删除的环境变量或Path下的值，请先点击“自动分析”，如果未能分析出，应该没有疑似Java的环境变量", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (DialogResult.Cancel == MessageBox.Show(this, "执行删除操作将无法恢复，请确认左边列表中的项目均要删除\n点击“确认”执行删除操作，点击“取消”放弃操作", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning))
                return;

            RegistryKey registryKey = _GetEnvironmentVariablesRegistryKey();
            if (registryKey == null)
            {
                MessageBox.Show(this, "无法在注册表中访问系统环境变量设置，此功能无法使用", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // 删除独立的环境变量
                foreach (string item in LstRemoveKey.Items)
                {
                    // 括号前的为环境变量名称
                    int bracketIndex = item.IndexOf('(');
                    string valueName = item.Substring(0, bracketIndex);
                    // 注意环境变量RegistryKey下属的都是一个个value而不是SubKey
                    registryKey.DeleteValue(valueName, false);
                }
                // 删除Path中的value
                if (LstRemovePathValue.Items.Count > 0)
                {
                    HashSet<string> needDeleteValues = new HashSet<string>();
                    foreach (string item in LstRemovePathValue.Items)
                        needDeleteValues.Add(item);

                    string[] values = _GetPathEnvironmentVariablesValues(registryKey);
                    StringBuilder sb = new StringBuilder();
                    foreach (string value in values)
                    {
                        if (string.IsNullOrEmpty(value) == false && needDeleteValues.Contains(value) == false)
                            sb.Append(value).Append(";");
                    }

                    // 最后的一个“;”并不多余，不用去掉
                    string newPathValue = sb.ToString();

                    registryKey.SetValue(PATH_ENVIRONMENT_VARIABLES_NAME, newPathValue, RegistryValueKind.ExpandString);
                }

                registryKey.Flush();

                MessageBox.Show(this, "删除成功", "恭喜", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BtnAnalyzeJavaEnvironmentVariables_Click(null, EventArgs.Empty);
                _RefreshEnvironmentVariables();
                _RefreshJavaEnvironmentVariablesState();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $"执行中引发异常，操作未能成功完成，异常信息为：\n{ex}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                registryKey.Close();
            }
        }

        private void BtnOpenEnvironmentVariablesUI_Click(object sender, EventArgs e)
        {
            _OpenSetEnvironmentVariablesUI();
        }

        #endregion
    }
}
