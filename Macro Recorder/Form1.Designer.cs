
namespace Macro_Recorder
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.cboType = new System.Windows.Forms.ComboBox();
            this.txtTypeInfo = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnUndo = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.txtRepeat = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.txtDelayBTW = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.lblMacroInfo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.settingsPic = new System.Windows.Forms.PictureBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.settingsPic)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.button1.Cursor = System.Windows.Forms.Cursors.Default;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button1.Location = new System.Drawing.Point(397, 292);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(194, 64);
            this.button1.TabIndex = 0;
            this.button1.Text = "Get Cursor Position";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_ClickAsync);
            // 
            // cboType
            // 
            this.cboType.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cboType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboType.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.cboType.FormattingEnabled = true;
            this.cboType.Items.AddRange(new object[] {
            "SmoothType",
            "SmoothMove",
            "LeftClick",
            "RightClick",
            "Wait",
            "KeyDown",
            "KeyUp",
            "Keyboard",
            "Move"});
            this.cboType.Location = new System.Drawing.Point(9, 10);
            this.cboType.Margin = new System.Windows.Forms.Padding(2);
            this.cboType.Name = "cboType";
            this.cboType.Size = new System.Drawing.Size(92, 21);
            this.cboType.TabIndex = 1;
            this.cboType.Text = "Action";
            this.cboType.SelectedIndexChanged += new System.EventHandler(this.cboType_SelectedIndexChanged);
            // 
            // txtTypeInfo
            // 
            this.txtTypeInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTypeInfo.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.txtTypeInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTypeInfo.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.txtTypeInfo.Location = new System.Drawing.Point(105, 11);
            this.txtTypeInfo.Margin = new System.Windows.Forms.Padding(2);
            this.txtTypeInfo.Name = "txtTypeInfo";
            this.txtTypeInfo.Size = new System.Drawing.Size(487, 13);
            this.txtTypeInfo.TabIndex = 2;
            this.txtTypeInfo.Text = "Unused";
            this.txtTypeInfo.DoubleClick += new System.EventHandler(this.txtTpeInfo_Click);
            this.txtTypeInfo.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtTypeInfo_PreviewKeyDown);
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.btnSubmit.FlatAppearance.BorderSize = 0;
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSubmit.Location = new System.Drawing.Point(9, 35);
            this.btnSubmit.Margin = new System.Windows.Forms.Padding(2);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(91, 24);
            this.btnSubmit.TabIndex = 4;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnUndo
            // 
            this.btnUndo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUndo.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.btnUndo.FlatAppearance.BorderSize = 0;
            this.btnUndo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUndo.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnUndo.Location = new System.Drawing.Point(289, 292);
            this.btnUndo.Margin = new System.Windows.Forms.Padding(2);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(104, 64);
            this.btnUndo.TabIndex = 5;
            this.btnUndo.Text = "Clear";
            this.btnUndo.UseVisualStyleBackColor = false;
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnStart.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.btnStart.FlatAppearance.BorderSize = 0;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnStart.Location = new System.Drawing.Point(9, 292);
            this.btnStart.Margin = new System.Windows.Forms.Padding(2);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(91, 64);
            this.btnStart.TabIndex = 6;
            this.btnStart.Text = "Start / Stop\r\n(CTRL + F6)";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // txtRepeat
            // 
            this.txtRepeat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRepeat.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.txtRepeat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtRepeat.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.txtRepeat.Location = new System.Drawing.Point(48, 26);
            this.txtRepeat.Margin = new System.Windows.Forms.Padding(2);
            this.txtRepeat.Name = "txtRepeat";
            this.txtRepeat.Size = new System.Drawing.Size(132, 13);
            this.txtRepeat.TabIndex = 7;
            this.txtRepeat.Text = "inf";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(-1, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Repeat:";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Macro files|*.macro|All files|*.*";
            this.openFileDialog1.Title = "Select macro file";
            // 
            // btnImport
            // 
            this.btnImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnImport.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.btnImport.FlatAppearance.BorderSize = 0;
            this.btnImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImport.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnImport.Location = new System.Drawing.Point(9, 228);
            this.btnImport.Margin = new System.Windows.Forms.Padding(2);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(91, 59);
            this.btnImport.TabIndex = 9;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = false;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExport.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.btnExport.FlatAppearance.BorderSize = 0;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnExport.Location = new System.Drawing.Point(105, 228);
            this.btnExport.Margin = new System.Windows.Forms.Padding(2);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(91, 59);
            this.btnExport.TabIndex = 9;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // txtDelayBTW
            // 
            this.txtDelayBTW.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtDelayBTW.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.txtDelayBTW.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDelayBTW.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.txtDelayBTW.Location = new System.Drawing.Point(201, 268);
            this.txtDelayBTW.Margin = new System.Windows.Forms.Padding(2);
            this.txtDelayBTW.Name = "txtDelayBTW";
            this.txtDelayBTW.Size = new System.Drawing.Size(84, 13);
            this.txtDelayBTW.TabIndex = 10;
            this.txtDelayBTW.Text = "1000";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(201, 249);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Delay (ms):";
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBox1.AutoSize = true;
            this.checkBox1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.checkBox1.Location = new System.Drawing.Point(203, 227);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(75, 17);
            this.checkBox1.TabIndex = 12;
            this.checkBox1.Text = "Safeguard";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // lblMacroInfo
            // 
            this.lblMacroInfo.AllowDrop = true;
            this.lblMacroInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMacroInfo.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.lblMacroInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblMacroInfo.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblMacroInfo.Location = new System.Drawing.Point(289, 36);
            this.lblMacroInfo.Margin = new System.Windows.Forms.Padding(2);
            this.lblMacroInfo.Multiline = true;
            this.lblMacroInfo.Name = "lblMacroInfo";
            this.lblMacroInfo.Size = new System.Drawing.Size(303, 251);
            this.lblMacroInfo.TabIndex = 13;
            this.lblMacroInfo.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.lblMacroInfo.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Location = new System.Drawing.Point(103, 41);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(159, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Copyright © 2023 ThatLukeDev";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.panel1.Controls.Add(this.txtRepeat);
            this.panel1.Controls.Add(this.label1);
            this.panel1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.panel1.Location = new System.Drawing.Point(105, 292);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(180, 64);
            this.panel1.TabIndex = 8;
            // 
            // settingsPic
            // 
            this.settingsPic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.settingsPic.Image = global::Macro_Recorder.Properties.Resources._126472;
            this.settingsPic.Location = new System.Drawing.Point(254, 250);
            this.settingsPic.Margin = new System.Windows.Forms.Padding(2);
            this.settingsPic.Name = "settingsPic";
            this.settingsPic.Size = new System.Drawing.Size(31, 13);
            this.settingsPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.settingsPic.TabIndex = 16;
            this.settingsPic.TabStop = false;
            this.settingsPic.Click += new System.EventHandler(this.settingsPic_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileName = "New Macro";
            this.saveFileDialog1.Filter = "Macro files|*.macro|All files|*.*";
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.settingsPic);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblMacroInfo);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDelayBTW);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnUndo);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.txtTypeInfo);
            this.Controls.Add(this.cboType);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Macro Recorder";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.settingsPic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cboType;
        private System.Windows.Forms.TextBox txtTypeInfo;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnUndo;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox txtRepeat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox txtDelayBTW;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox lblMacroInfo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox settingsPic;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}

