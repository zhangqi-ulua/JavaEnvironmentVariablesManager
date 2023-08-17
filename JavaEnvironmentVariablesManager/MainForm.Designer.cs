namespace JavaEnvironmentVariablesManager
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.LblToolsTips = new System.Windows.Forms.Label();
            this.GrpSwitchJavaVersion = new System.Windows.Forms.GroupBox();
            this.LblJavaVersionCount = new System.Windows.Forms.Label();
            this.BtnSwitchJavaVersion = new System.Windows.Forms.Button();
            this.CboAvailableJavaVersion = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.LblCurrentJavaHomeValue = new System.Windows.Forms.Label();
            this.LblCurrentJavaVersion = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.GrpAddJavaVersion = new System.Windows.Forms.GroupBox();
            this.BtnBackToChooseNewJavaVersionDirPath = new System.Windows.Forms.Button();
            this.BtnAddJavaVersion = new System.Windows.Forms.Button();
            this.BtnToAddJavaVersionNextStep = new System.Windows.Forms.Button();
            this.TxtNewJavaEnvironmentVariablesName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.BtnChooseNewJavaVersionDirPath = new System.Windows.Forms.Button();
            this.TxtNewJavaVersionDirPath = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.GrpRemoveJavaEnvironmentVariables = new System.Windows.Forms.GroupBox();
            this.BtnOpenEnvironmentVariablesUI = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.BtnRemoveJavaEnvironmentVariables = new System.Windows.Forms.Button();
            this.BtnRemovePathValueItem = new System.Windows.Forms.Button();
            this.LstRemovePathValue = new System.Windows.Forms.ListBox();
            this.label10 = new System.Windows.Forms.Label();
            this.BtnRemoveKeyItem = new System.Windows.Forms.Button();
            this.LstRemoveKey = new System.Windows.Forms.ListBox();
            this.label9 = new System.Windows.Forms.Label();
            this.BtnAnalyzeJavaEnvironmentVariables = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.GrpSwitchJavaVersion.SuspendLayout();
            this.GrpAddJavaVersion.SuspendLayout();
            this.GrpRemoveJavaEnvironmentVariables.SuspendLayout();
            this.SuspendLayout();
            // 
            // LblToolsTips
            // 
            this.LblToolsTips.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblToolsTips.Location = new System.Drawing.Point(25, 22);
            this.LblToolsTips.Name = "LblToolsTips";
            this.LblToolsTips.Size = new System.Drawing.Size(1069, 113);
            this.LblToolsTips.TabIndex = 0;
            this.LblToolsTips.Text = resources.GetString("LblToolsTips.Text");
            // 
            // GrpSwitchJavaVersion
            // 
            this.GrpSwitchJavaVersion.Controls.Add(this.LblJavaVersionCount);
            this.GrpSwitchJavaVersion.Controls.Add(this.BtnSwitchJavaVersion);
            this.GrpSwitchJavaVersion.Controls.Add(this.CboAvailableJavaVersion);
            this.GrpSwitchJavaVersion.Controls.Add(this.label4);
            this.GrpSwitchJavaVersion.Controls.Add(this.LblCurrentJavaHomeValue);
            this.GrpSwitchJavaVersion.Controls.Add(this.LblCurrentJavaVersion);
            this.GrpSwitchJavaVersion.Controls.Add(this.label3);
            this.GrpSwitchJavaVersion.Controls.Add(this.label2);
            this.GrpSwitchJavaVersion.Controls.Add(this.label1);
            this.GrpSwitchJavaVersion.Location = new System.Drawing.Point(28, 175);
            this.GrpSwitchJavaVersion.Name = "GrpSwitchJavaVersion";
            this.GrpSwitchJavaVersion.Size = new System.Drawing.Size(1042, 143);
            this.GrpSwitchJavaVersion.TabIndex = 1;
            this.GrpSwitchJavaVersion.TabStop = false;
            this.GrpSwitchJavaVersion.Text = "切换系统中当前使用的Java版本";
            // 
            // LblJavaVersionCount
            // 
            this.LblJavaVersionCount.AutoSize = true;
            this.LblJavaVersionCount.Location = new System.Drawing.Point(535, 58);
            this.LblJavaVersionCount.Name = "LblJavaVersionCount";
            this.LblJavaVersionCount.Size = new System.Drawing.Size(191, 12);
            this.LblJavaVersionCount.TabIndex = 7;
            this.LblJavaVersionCount.Text = "本机中有0个不同Java版本可供切换";
            // 
            // BtnSwitchJavaVersion
            // 
            this.BtnSwitchJavaVersion.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnSwitchJavaVersion.Location = new System.Drawing.Point(942, 58);
            this.BtnSwitchJavaVersion.Name = "BtnSwitchJavaVersion";
            this.BtnSwitchJavaVersion.Size = new System.Drawing.Size(75, 62);
            this.BtnSwitchJavaVersion.TabIndex = 6;
            this.BtnSwitchJavaVersion.Text = "切换";
            this.BtnSwitchJavaVersion.UseVisualStyleBackColor = true;
            this.BtnSwitchJavaVersion.Click += new System.EventHandler(this.BtnSwitchJavaVersion_Click);
            // 
            // CboAvailableJavaVersion
            // 
            this.CboAvailableJavaVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboAvailableJavaVersion.FormattingEnabled = true;
            this.CboAvailableJavaVersion.ItemHeight = 12;
            this.CboAvailableJavaVersion.Location = new System.Drawing.Point(537, 82);
            this.CboAvailableJavaVersion.Name = "CboAvailableJavaVersion";
            this.CboAvailableJavaVersion.Size = new System.Drawing.Size(382, 20);
            this.CboAvailableJavaVersion.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(478, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "切换到：";
            // 
            // LblCurrentJavaHomeValue
            // 
            this.LblCurrentJavaHomeValue.AutoSize = true;
            this.LblCurrentJavaHomeValue.Location = new System.Drawing.Point(218, 95);
            this.LblCurrentJavaHomeValue.Name = "LblCurrentJavaHomeValue";
            this.LblCurrentJavaHomeValue.Size = new System.Drawing.Size(41, 12);
            this.LblCurrentJavaHomeValue.TabIndex = 3;
            this.LblCurrentJavaHomeValue.Text = "未获取";
            // 
            // LblCurrentJavaVersion
            // 
            this.LblCurrentJavaVersion.AutoSize = true;
            this.LblCurrentJavaVersion.Location = new System.Drawing.Point(218, 70);
            this.LblCurrentJavaVersion.Name = "LblCurrentJavaVersion";
            this.LblCurrentJavaVersion.Size = new System.Drawing.Size(41, 12);
            this.LblCurrentJavaVersion.TabIndex = 2;
            this.LblCurrentJavaVersion.Text = "未获取";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(191, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "当前“JAVA_HOME”对应的配置为：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "当前使用的Java版本为：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(413, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "本工具将从系统环境变量中读取符合上述规范的环境变量以供您选择进行切换";
            // 
            // GrpAddJavaVersion
            // 
            this.GrpAddJavaVersion.Controls.Add(this.BtnBackToChooseNewJavaVersionDirPath);
            this.GrpAddJavaVersion.Controls.Add(this.BtnAddJavaVersion);
            this.GrpAddJavaVersion.Controls.Add(this.BtnToAddJavaVersionNextStep);
            this.GrpAddJavaVersion.Controls.Add(this.TxtNewJavaEnvironmentVariablesName);
            this.GrpAddJavaVersion.Controls.Add(this.label7);
            this.GrpAddJavaVersion.Controls.Add(this.BtnChooseNewJavaVersionDirPath);
            this.GrpAddJavaVersion.Controls.Add(this.TxtNewJavaVersionDirPath);
            this.GrpAddJavaVersion.Controls.Add(this.label6);
            this.GrpAddJavaVersion.Controls.Add(this.label5);
            this.GrpAddJavaVersion.Location = new System.Drawing.Point(28, 340);
            this.GrpAddJavaVersion.Name = "GrpAddJavaVersion";
            this.GrpAddJavaVersion.Size = new System.Drawing.Size(1042, 183);
            this.GrpAddJavaVersion.TabIndex = 2;
            this.GrpAddJavaVersion.TabStop = false;
            this.GrpAddJavaVersion.Text = "为新安装的Java版本添加环境变量";
            // 
            // BtnBackToChooseNewJavaVersionDirPath
            // 
            this.BtnBackToChooseNewJavaVersionDirPath.Location = new System.Drawing.Point(876, 102);
            this.BtnBackToChooseNewJavaVersionDirPath.Name = "BtnBackToChooseNewJavaVersionDirPath";
            this.BtnBackToChooseNewJavaVersionDirPath.Size = new System.Drawing.Size(141, 49);
            this.BtnBackToChooseNewJavaVersionDirPath.TabIndex = 8;
            this.BtnBackToChooseNewJavaVersionDirPath.Text = "回退到上一步\r\n重新选择Java安装目录";
            this.BtnBackToChooseNewJavaVersionDirPath.UseVisualStyleBackColor = true;
            this.BtnBackToChooseNewJavaVersionDirPath.Click += new System.EventHandler(this.BtnBackToChooseNewJavaVersionDirPath_Click);
            // 
            // BtnAddJavaVersion
            // 
            this.BtnAddJavaVersion.Location = new System.Drawing.Point(480, 138);
            this.BtnAddJavaVersion.Name = "BtnAddJavaVersion";
            this.BtnAddJavaVersion.Size = new System.Drawing.Size(95, 23);
            this.BtnAddJavaVersion.TabIndex = 7;
            this.BtnAddJavaVersion.Text = "确认添加";
            this.BtnAddJavaVersion.UseVisualStyleBackColor = true;
            this.BtnAddJavaVersion.Click += new System.EventHandler(this.BtnAddJavaVersion_Click);
            // 
            // BtnToAddJavaVersionNextStep
            // 
            this.BtnToAddJavaVersionNextStep.Location = new System.Drawing.Point(876, 30);
            this.BtnToAddJavaVersionNextStep.Name = "BtnToAddJavaVersionNextStep";
            this.BtnToAddJavaVersionNextStep.Size = new System.Drawing.Size(141, 23);
            this.BtnToAddJavaVersionNextStep.TabIndex = 6;
            this.BtnToAddJavaVersionNextStep.Text = "确认并进行下一步";
            this.BtnToAddJavaVersionNextStep.UseVisualStyleBackColor = true;
            this.BtnToAddJavaVersionNextStep.Click += new System.EventHandler(this.BtnToAddJavaVersionNextStep_Click);
            // 
            // TxtNewJavaEnvironmentVariablesName
            // 
            this.TxtNewJavaEnvironmentVariablesName.Location = new System.Drawing.Point(27, 140);
            this.TxtNewJavaEnvironmentVariablesName.Name = "TxtNewJavaEnvironmentVariablesName";
            this.TxtNewJavaEnvironmentVariablesName.Size = new System.Drawing.Size(411, 21);
            this.TxtNewJavaEnvironmentVariablesName.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(25, 107);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(827, 12);
            this.label7.TabIndex = 4;
            this.label7.Text = "第2步：设置环境变量名“JAVA_HOME_”后版本号名称，建议用自动读取的大版本号，除非本机安装同一大版本号的多个Java小版本，才用更详细版本号区分";
            // 
            // BtnChooseNewJavaVersionDirPath
            // 
            this.BtnChooseNewJavaVersionDirPath.Location = new System.Drawing.Point(745, 30);
            this.BtnChooseNewJavaVersionDirPath.Name = "BtnChooseNewJavaVersionDirPath";
            this.BtnChooseNewJavaVersionDirPath.Size = new System.Drawing.Size(75, 23);
            this.BtnChooseNewJavaVersionDirPath.TabIndex = 3;
            this.BtnChooseNewJavaVersionDirPath.Text = "选择";
            this.BtnChooseNewJavaVersionDirPath.UseVisualStyleBackColor = true;
            this.BtnChooseNewJavaVersionDirPath.Click += new System.EventHandler(this.BtnChooseNewJavaVersionDirPath_Click);
            // 
            // TxtNewJavaVersionDirPath
            // 
            this.TxtNewJavaVersionDirPath.Location = new System.Drawing.Point(234, 32);
            this.TxtNewJavaVersionDirPath.Name = "TxtNewJavaVersionDirPath";
            this.TxtNewJavaVersionDirPath.Size = new System.Drawing.Size(494, 21);
            this.TxtNewJavaVersionDirPath.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(407, 12);
            this.label6.TabIndex = 1;
            this.label6.Text = "（默认会安装到C:\\Program Files\\Java目录下的以版本号命名的文件夹中）";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(203, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "第1步：选择该版本Java的安装目录：";
            // 
            // GrpRemoveJavaEnvironmentVariables
            // 
            this.GrpRemoveJavaEnvironmentVariables.Controls.Add(this.BtnOpenEnvironmentVariablesUI);
            this.GrpRemoveJavaEnvironmentVariables.Controls.Add(this.label11);
            this.GrpRemoveJavaEnvironmentVariables.Controls.Add(this.BtnRemoveJavaEnvironmentVariables);
            this.GrpRemoveJavaEnvironmentVariables.Controls.Add(this.BtnRemovePathValueItem);
            this.GrpRemoveJavaEnvironmentVariables.Controls.Add(this.LstRemovePathValue);
            this.GrpRemoveJavaEnvironmentVariables.Controls.Add(this.label10);
            this.GrpRemoveJavaEnvironmentVariables.Controls.Add(this.BtnRemoveKeyItem);
            this.GrpRemoveJavaEnvironmentVariables.Controls.Add(this.LstRemoveKey);
            this.GrpRemoveJavaEnvironmentVariables.Controls.Add(this.label9);
            this.GrpRemoveJavaEnvironmentVariables.Controls.Add(this.BtnAnalyzeJavaEnvironmentVariables);
            this.GrpRemoveJavaEnvironmentVariables.Controls.Add(this.label8);
            this.GrpRemoveJavaEnvironmentVariables.Location = new System.Drawing.Point(28, 546);
            this.GrpRemoveJavaEnvironmentVariables.Name = "GrpRemoveJavaEnvironmentVariables";
            this.GrpRemoveJavaEnvironmentVariables.Size = new System.Drawing.Size(1042, 350);
            this.GrpRemoveJavaEnvironmentVariables.TabIndex = 3;
            this.GrpRemoveJavaEnvironmentVariables.TabStop = false;
            this.GrpRemoveJavaEnvironmentVariables.Text = "移除系统中相关的Java环境变量";
            // 
            // BtnOpenEnvironmentVariablesUI
            // 
            this.BtnOpenEnvironmentVariablesUI.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnOpenEnvironmentVariablesUI.Location = new System.Drawing.Point(876, 269);
            this.BtnOpenEnvironmentVariablesUI.Name = "BtnOpenEnvironmentVariablesUI";
            this.BtnOpenEnvironmentVariablesUI.Size = new System.Drawing.Size(129, 48);
            this.BtnOpenEnvironmentVariablesUI.TabIndex = 10;
            this.BtnOpenEnvironmentVariablesUI.Text = "打开系统环境\r\n变量设置界面";
            this.BtnOpenEnvironmentVariablesUI.UseVisualStyleBackColor = true;
            this.BtnOpenEnvironmentVariablesUI.Click += new System.EventHandler(this.BtnOpenEnvironmentVariablesUI_Click);
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(871, 215);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(146, 51);
            this.label11.TabIndex = 9;
            this.label11.Text = "如果有其他未被检测到的相关环境变量，请在系统环境变量设置中手工删除";
            // 
            // BtnRemoveJavaEnvironmentVariables
            // 
            this.BtnRemoveJavaEnvironmentVariables.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnRemoveJavaEnvironmentVariables.Location = new System.Drawing.Point(876, 111);
            this.BtnRemoveJavaEnvironmentVariables.Name = "BtnRemoveJavaEnvironmentVariables";
            this.BtnRemoveJavaEnvironmentVariables.Size = new System.Drawing.Size(129, 62);
            this.BtnRemoveJavaEnvironmentVariables.TabIndex = 8;
            this.BtnRemoveJavaEnvironmentVariables.Text = "执行删除";
            this.BtnRemoveJavaEnvironmentVariables.UseVisualStyleBackColor = true;
            this.BtnRemoveJavaEnvironmentVariables.Click += new System.EventHandler(this.BtnRemoveJavaEnvironmentVariables_Click);
            // 
            // BtnRemovePathValueItem
            // 
            this.BtnRemovePathValueItem.Location = new System.Drawing.Point(617, 66);
            this.BtnRemovePathValueItem.Name = "BtnRemovePathValueItem";
            this.BtnRemovePathValueItem.Size = new System.Drawing.Size(120, 23);
            this.BtnRemovePathValueItem.TabIndex = 7;
            this.BtnRemovePathValueItem.Text = "排除选中的不删除";
            this.BtnRemovePathValueItem.UseVisualStyleBackColor = true;
            this.BtnRemovePathValueItem.Click += new System.EventHandler(this.BtnRemovePathValueItem_Click);
            // 
            // LstRemovePathValue
            // 
            this.LstRemovePathValue.FormattingEnabled = true;
            this.LstRemovePathValue.ItemHeight = 12;
            this.LstRemovePathValue.Location = new System.Drawing.Point(452, 97);
            this.LstRemovePathValue.Name = "LstRemovePathValue";
            this.LstRemovePathValue.Size = new System.Drawing.Size(400, 232);
            this.LstRemovePathValue.TabIndex = 6;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(450, 71);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(161, 12);
            this.label10.TabIndex = 5;
            this.label10.Text = "分析出疑似Path中要删的值：";
            // 
            // BtnRemoveKeyItem
            // 
            this.BtnRemoveKeyItem.Location = new System.Drawing.Point(234, 66);
            this.BtnRemoveKeyItem.Name = "BtnRemoveKeyItem";
            this.BtnRemoveKeyItem.Size = new System.Drawing.Size(120, 23);
            this.BtnRemoveKeyItem.TabIndex = 4;
            this.BtnRemoveKeyItem.Text = "排除选中的不删除";
            this.BtnRemoveKeyItem.UseVisualStyleBackColor = true;
            this.BtnRemoveKeyItem.Click += new System.EventHandler(this.BtnRemoveKeyItem_Click);
            // 
            // LstRemoveKey
            // 
            this.LstRemoveKey.FormattingEnabled = true;
            this.LstRemoveKey.ItemHeight = 12;
            this.LstRemoveKey.Location = new System.Drawing.Point(27, 97);
            this.LstRemoveKey.Name = "LstRemoveKey";
            this.LstRemoveKey.Size = new System.Drawing.Size(400, 232);
            this.LstRemoveKey.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(25, 71);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(203, 12);
            this.label9.TabIndex = 2;
            this.label9.Text = "分析出疑似环境变量中要删除的key：";
            // 
            // BtnAnalyzeJavaEnvironmentVariables
            // 
            this.BtnAnalyzeJavaEnvironmentVariables.Location = new System.Drawing.Point(844, 29);
            this.BtnAnalyzeJavaEnvironmentVariables.Name = "BtnAnalyzeJavaEnvironmentVariables";
            this.BtnAnalyzeJavaEnvironmentVariables.Size = new System.Drawing.Size(87, 23);
            this.BtnAnalyzeJavaEnvironmentVariables.TabIndex = 1;
            this.BtnAnalyzeJavaEnvironmentVariables.Text = "自动分析";
            this.BtnAnalyzeJavaEnvironmentVariables.UseVisualStyleBackColor = true;
            this.BtnAnalyzeJavaEnvironmentVariables.Click += new System.EventHandler(this.BtnAnalyzeJavaEnvironmentVariables_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(25, 34);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(797, 12);
            this.label8.TabIndex = 0;
            this.label8.Text = "如果当前系统中已经配置了不符合本工具规范要求的Java环境变量，建议先进行移除，然后重新通过本工具添加，以便之后通过本工具方便管理和切换";
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("宋体", 12F);
            this.label12.ForeColor = System.Drawing.Color.Red;
            this.label12.Location = new System.Drawing.Point(25, 124);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(1045, 48);
            this.label12.TabIndex = 4;
            this.label12.Text = "注意：本工具通过修改系统注册表来设置系统环境变量，由于Windows系统机制，修改成功后，只有新开的进程才能读取修改后的系统环境变量，这意味着只有重新打开本工具，" +
    "才能获取最新设置的Java版本，只有在系统中新打开的CMD窗口中执行的Java相关命令才是用新切换到的Java版本。";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1102, 918);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.GrpRemoveJavaEnvironmentVariables);
            this.Controls.Add(this.GrpAddJavaVersion);
            this.Controls.Add(this.GrpSwitchJavaVersion);
            this.Controls.Add(this.LblToolsTips);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Java环境变量自动设置工具 by 张齐 （https://github.com/zhangqi-ulua）";
            this.GrpSwitchJavaVersion.ResumeLayout(false);
            this.GrpSwitchJavaVersion.PerformLayout();
            this.GrpAddJavaVersion.ResumeLayout(false);
            this.GrpAddJavaVersion.PerformLayout();
            this.GrpRemoveJavaEnvironmentVariables.ResumeLayout(false);
            this.GrpRemoveJavaEnvironmentVariables.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LblToolsTips;
        private System.Windows.Forms.GroupBox GrpSwitchJavaVersion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CboAvailableJavaVersion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label LblCurrentJavaHomeValue;
        private System.Windows.Forms.Label LblCurrentJavaVersion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnSwitchJavaVersion;
        private System.Windows.Forms.Label LblJavaVersionCount;
        private System.Windows.Forms.GroupBox GrpAddJavaVersion;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button BtnChooseNewJavaVersionDirPath;
        private System.Windows.Forms.TextBox TxtNewJavaVersionDirPath;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button BtnBackToChooseNewJavaVersionDirPath;
        private System.Windows.Forms.Button BtnAddJavaVersion;
        private System.Windows.Forms.Button BtnToAddJavaVersionNextStep;
        private System.Windows.Forms.TextBox TxtNewJavaEnvironmentVariablesName;
        private System.Windows.Forms.GroupBox GrpRemoveJavaEnvironmentVariables;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button BtnAnalyzeJavaEnvironmentVariables;
        private System.Windows.Forms.ListBox LstRemoveKey;
        private System.Windows.Forms.Button BtnRemoveKeyItem;
        private System.Windows.Forms.ListBox LstRemovePathValue;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button BtnRemovePathValueItem;
        private System.Windows.Forms.Button BtnRemoveJavaEnvironmentVariables;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button BtnOpenEnvironmentVariablesUI;
        private System.Windows.Forms.Label label12;
    }
}

