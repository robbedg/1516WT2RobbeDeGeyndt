namespace Game_AI
{
    partial class Start
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
            this.bStart = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbPlayer2 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nudSteps1 = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.nudSteps2 = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudSteps1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSteps2)).BeginInit();
            this.SuspendLayout();
            // 
            // bStart
            // 
            this.bStart.Location = new System.Drawing.Point(115, 86);
            this.bStart.Name = "bStart";
            this.bStart.Size = new System.Drawing.Size(75, 23);
            this.bStart.TabIndex = 0;
            this.bStart.Text = "Start";
            this.bStart.UseVisualStyleBackColor = true;
            this.bStart.Click += new System.EventHandler(this.bStart_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Player 2:";
            // 
            // cbPlayer2
            // 
            this.cbPlayer2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPlayer2.FormattingEnabled = true;
            this.cbPlayer2.Items.AddRange(new object[] {
            "User",
            "AI"});
            this.cbPlayer2.Location = new System.Drawing.Point(69, 33);
            this.cbPlayer2.Name = "cbPlayer2";
            this.cbPlayer2.Size = new System.Drawing.Size(121, 21);
            this.cbPlayer2.TabIndex = 2;
            this.cbPlayer2.SelectedIndexChanged += new System.EventHandler(this.cbPlayer2_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "AI:";
            // 
            // nudSteps1
            // 
            this.nudSteps1.Location = new System.Drawing.Point(69, 7);
            this.nudSteps1.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudSteps1.Name = "nudSteps1";
            this.nudSteps1.Size = new System.Drawing.Size(47, 20);
            this.nudSteps1.TabIndex = 4;
            this.nudSteps1.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(125, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "steps ahead";
            // 
            // nudSteps2
            // 
            this.nudSteps2.Location = new System.Drawing.Point(69, 60);
            this.nudSteps2.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudSteps2.Name = "nudSteps2";
            this.nudSteps2.Size = new System.Drawing.Size(47, 20);
            this.nudSteps2.TabIndex = 6;
            this.nudSteps2.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(125, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "steps ahead";
            // 
            // Start
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(202, 119);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.nudSteps2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nudSteps1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbPlayer2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Start";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Start";
            ((System.ComponentModel.ISupportInitialize)(this.nudSteps1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSteps2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbPlayer2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudSteps1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudSteps2;
        private System.Windows.Forms.Label label4;
    }
}