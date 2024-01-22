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
            this.speedBar = new System.Windows.Forms.TrackBar();
            this.speedLabel = new System.Windows.Forms.Label();
            this.speed = new System.Windows.Forms.TextBox();
            this.moveLabel = new System.Windows.Forms.Label();
            this.moveX = new System.Windows.Forms.TextBox();
            this.moveY = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.scaleY = new System.Windows.Forms.TextBox();
            this.scaleX = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.speedBar)).BeginInit();
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
            // speedBar
            // 
            this.speedBar.LargeChange = 2;
            this.speedBar.Location = new System.Drawing.Point(12, 60);
            this.speedBar.Maximum = 8;
            this.speedBar.Name = "speedBar";
            this.speedBar.Size = new System.Drawing.Size(225, 45);
            this.speedBar.TabIndex = 1;
            this.speedBar.Value = 2;
            this.speedBar.Scroll += new System.EventHandler(this.speedBar_Scroll);
            // 
            // speedLabel
            // 
            this.speedLabel.AutoSize = true;
            this.speedLabel.Location = new System.Drawing.Point(9, 44);
            this.speedLabel.Name = "speedLabel";
            this.speedLabel.Size = new System.Drawing.Size(55, 13);
            this.speedLabel.TabIndex = 2;
            this.speedLabel.Text = "Speed: 1x";
            // 
            // speed
            // 
            this.speed.Location = new System.Drawing.Point(122, 41);
            this.speed.Name = "speed";
            this.speed.Size = new System.Drawing.Size(115, 20);
            this.speed.TabIndex = 3;
            this.speed.Text = "1.0";
            this.speed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.speed.TextChanged += new System.EventHandler(this.speed_TextChanged);
            // 
            // moveLabel
            // 
            this.moveLabel.AutoSize = true;
            this.moveLabel.Location = new System.Drawing.Point(9, 108);
            this.moveLabel.Name = "moveLabel";
            this.moveLabel.Size = new System.Drawing.Size(66, 13);
            this.moveLabel.TabIndex = 4;
            this.moveLabel.Text = "Move offset:";
            // 
            // moveX
            // 
            this.moveX.Location = new System.Drawing.Point(12, 124);
            this.moveX.Name = "moveX";
            this.moveX.Size = new System.Drawing.Size(100, 20);
            this.moveX.TabIndex = 5;
            this.moveX.Text = "0";
            this.moveX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.moveX.TextChanged += new System.EventHandler(this.moveX_TextChanged);
            // 
            // moveY
            // 
            this.moveY.Location = new System.Drawing.Point(137, 124);
            this.moveY.Name = "moveY";
            this.moveY.Size = new System.Drawing.Size(100, 20);
            this.moveY.TabIndex = 6;
            this.moveY.Text = "0";
            this.moveY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.moveY.TextChanged += new System.EventHandler(this.moveY_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(119, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(10, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = ",";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(119, 157);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(10, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = ",";
            // 
            // scaleY
            // 
            this.scaleY.Location = new System.Drawing.Point(137, 150);
            this.scaleY.Name = "scaleY";
            this.scaleY.Size = new System.Drawing.Size(100, 20);
            this.scaleY.TabIndex = 9;
            this.scaleY.Text = "1";
            this.scaleY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.scaleY.TextChanged += new System.EventHandler(this.scaleY_TextChanged);
            // 
            // scaleX
            // 
            this.scaleX.Location = new System.Drawing.Point(12, 150);
            this.scaleX.Name = "scaleX";
            this.scaleX.Size = new System.Drawing.Size(100, 20);
            this.scaleX.TabIndex = 8;
            this.scaleX.Text = "1";
            this.scaleX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.scaleX.TextChanged += new System.EventHandler(this.scaleX_TextChanged);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(249, 246);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.scaleY);
            this.Controls.Add(this.scaleX);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.moveY);
            this.Controls.Add(this.moveX);
            this.Controls.Add(this.moveLabel);
            this.Controls.Add(this.speed);
            this.Controls.Add(this.speedLabel);
            this.Controls.Add(this.speedBar);
            this.Controls.Add(this.lightMode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form2";
            this.ShowInTaskbar = false;
            this.Text = "Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.speedBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.CheckBox lightMode;
        public System.Windows.Forms.TrackBar speedBar;
        public System.Windows.Forms.Label speedLabel;
        public System.Windows.Forms.TextBox speed;
        public System.Windows.Forms.Label moveLabel;
        public System.Windows.Forms.TextBox moveX;
        public System.Windows.Forms.TextBox moveY;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox scaleY;
        public System.Windows.Forms.TextBox scaleX;
    }
}