namespace Macro_Recorder
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.lightMode = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lightMode
            // 
            this.lightMode.AutoSize = true;
            this.lightMode.Location = new System.Drawing.Point(12, 12);
            this.lightMode.Name = "lightMode";
            this.lightMode.Size = new System.Drawing.Size(79, 17);
            this.lightMode.TabIndex = 0;
            this.lightMode.Text = "Light Mode";
            this.lightMode.UseVisualStyleBackColor = true;
            this.lightMode.CheckedChanged += new System.EventHandler(this.lightMode_CheckedChanged);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(249, 246);
            this.ControlBox = false;
            this.Controls.Add(this.lightMode);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form2";
            this.ShowInTaskbar = false;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox lightMode;
    }
}