namespace GUI
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
            this.display = new System.Windows.Forms.PictureBox();
            this.startButton = new System.Windows.Forms.Button();
            this.updateButton = new System.Windows.Forms.Button();
            this.checkCollision = new System.Windows.Forms.CheckBox();
            this.checkStopped = new System.Windows.Forms.CheckBox();
            this.checkOutframe = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.numericAngle = new System.Windows.Forms.NumericUpDown();
            this.numericDistance = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numericPPM = new System.Windows.Forms.NumericUpDown();
            this.textBoxDistance = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.numericRectangleMass = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.numericCircleMass = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.numericStaticFriction = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.numericKineticFriction = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxTime = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.textBoxRectAcc = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textBoxSpeedRect = new System.Windows.Forms.TextBox();
            this.textBoxAccCircle = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBoxCircleSpeed = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.numericStandGrav = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.display)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericAngle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericDistance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericPPM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericRectangleMass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCircleMass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericStaticFriction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericKineticFriction)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericStandGrav)).BeginInit();
            this.SuspendLayout();
            // 
            // display
            // 
            this.display.Location = new System.Drawing.Point(12, 12);
            this.display.Name = "display";
            this.display.Size = new System.Drawing.Size(500, 500);
            this.display.TabIndex = 0;
            this.display.TabStop = false;
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(518, 12);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 1;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // updateButton
            // 
            this.updateButton.Location = new System.Drawing.Point(599, 12);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(75, 23);
            this.updateButton.TabIndex = 2;
            this.updateButton.Text = "Update";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // checkCollision
            // 
            this.checkCollision.AutoSize = true;
            this.checkCollision.Enabled = false;
            this.checkCollision.Location = new System.Drawing.Point(680, 16);
            this.checkCollision.Name = "checkCollision";
            this.checkCollision.Size = new System.Drawing.Size(64, 17);
            this.checkCollision.TabIndex = 3;
            this.checkCollision.Text = "Collision";
            this.checkCollision.UseVisualStyleBackColor = true;
            // 
            // checkStopped
            // 
            this.checkStopped.AutoSize = true;
            this.checkStopped.Enabled = false;
            this.checkStopped.Location = new System.Drawing.Point(750, 16);
            this.checkStopped.Name = "checkStopped";
            this.checkStopped.Size = new System.Drawing.Size(66, 17);
            this.checkStopped.TabIndex = 4;
            this.checkStopped.Text = "Stopped";
            this.checkStopped.UseVisualStyleBackColor = true;
            // 
            // checkOutframe
            // 
            this.checkOutframe.AutoSize = true;
            this.checkOutframe.Enabled = false;
            this.checkOutframe.Location = new System.Drawing.Point(822, 16);
            this.checkOutframe.Name = "checkOutframe";
            this.checkOutframe.Size = new System.Drawing.Size(84, 17);
            this.checkOutframe.TabIndex = 5;
            this.checkOutframe.Text = "Out of frame";
            this.checkOutframe.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(518, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Slope (°):";
            // 
            // numericAngle
            // 
            this.numericAngle.DecimalPlaces = 1;
            this.numericAngle.Location = new System.Drawing.Point(680, 41);
            this.numericAngle.Maximum = new decimal(new int[] {
            45,
            0,
            0,
            0});
            this.numericAngle.Name = "numericAngle";
            this.numericAngle.Size = new System.Drawing.Size(226, 20);
            this.numericAngle.TabIndex = 8;
            this.numericAngle.Value = new decimal(new int[] {
            100,
            0,
            0,
            65536});
            // 
            // numericDistance
            // 
            this.numericDistance.Location = new System.Drawing.Point(680, 67);
            this.numericDistance.Maximum = new decimal(new int[] {
            900,
            0,
            0,
            0});
            this.numericDistance.Name = "numericDistance";
            this.numericDistance.Size = new System.Drawing.Size(226, 20);
            this.numericDistance.TabIndex = 9;
            this.numericDistance.Value = new decimal(new int[] {
            460,
            0,
            0,
            0});
            this.numericDistance.ValueChanged += new System.EventHandler(this.numericDistance_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(518, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Distance (pixels):";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(518, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Pixels per meter (pixels/m):";
            // 
            // numericPPM
            // 
            this.numericPPM.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericPPM.Location = new System.Drawing.Point(680, 93);
            this.numericPPM.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericPPM.Name = "numericPPM";
            this.numericPPM.Size = new System.Drawing.Size(226, 20);
            this.numericPPM.TabIndex = 12;
            this.numericPPM.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericPPM.ValueChanged += new System.EventHandler(this.numericDistance_ValueChanged);
            // 
            // textBoxDistance
            // 
            this.textBoxDistance.Location = new System.Drawing.Point(680, 119);
            this.textBoxDistance.Name = "textBoxDistance";
            this.textBoxDistance.ReadOnly = true;
            this.textBoxDistance.Size = new System.Drawing.Size(226, 20);
            this.textBoxDistance.TabIndex = 13;
            this.textBoxDistance.Text = "46";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(518, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Distance (m):";
            // 
            // numericRectangleMass
            // 
            this.numericRectangleMass.DecimalPlaces = 1;
            this.numericRectangleMass.Location = new System.Drawing.Point(680, 145);
            this.numericRectangleMass.Name = "numericRectangleMass";
            this.numericRectangleMass.Size = new System.Drawing.Size(226, 20);
            this.numericRectangleMass.TabIndex = 15;
            this.numericRectangleMass.Value = new decimal(new int[] {
            2,
            0,
            0,
            65536});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(518, 147);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Mass rectangle (kg):";
            // 
            // numericCircleMass
            // 
            this.numericCircleMass.DecimalPlaces = 1;
            this.numericCircleMass.Location = new System.Drawing.Point(680, 171);
            this.numericCircleMass.Name = "numericCircleMass";
            this.numericCircleMass.Size = new System.Drawing.Size(226, 20);
            this.numericCircleMass.TabIndex = 17;
            this.numericCircleMass.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(518, 173);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Mass circle (kg):";
            // 
            // numericStaticFriction
            // 
            this.numericStaticFriction.DecimalPlaces = 3;
            this.numericStaticFriction.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericStaticFriction.Location = new System.Drawing.Point(680, 197);
            this.numericStaticFriction.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericStaticFriction.Name = "numericStaticFriction";
            this.numericStaticFriction.Size = new System.Drawing.Size(226, 20);
            this.numericStaticFriction.TabIndex = 19;
            this.numericStaticFriction.Value = new decimal(new int[] {
            74,
            0,
            0,
            131072});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(518, 199);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Static friction:";
            // 
            // numericKineticFriction
            // 
            this.numericKineticFriction.DecimalPlaces = 3;
            this.numericKineticFriction.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericKineticFriction.Location = new System.Drawing.Point(680, 223);
            this.numericKineticFriction.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericKineticFriction.Name = "numericKineticFriction";
            this.numericKineticFriction.Size = new System.Drawing.Size(226, 20);
            this.numericKineticFriction.TabIndex = 21;
            this.numericKineticFriction.Value = new decimal(new int[] {
            42,
            0,
            0,
            131072});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(518, 225);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "Kinetic friction:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxTime);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.textBoxRectAcc);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.textBoxSpeedRect);
            this.groupBox1.Controls.Add(this.textBoxAccCircle);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.textBoxCircleSpeed);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Location = new System.Drawing.Point(521, 367);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(385, 144);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Values";
            // 
            // textBoxTime
            // 
            this.textBoxTime.Location = new System.Drawing.Point(159, 117);
            this.textBoxTime.Name = "textBoxTime";
            this.textBoxTime.ReadOnly = true;
            this.textBoxTime.Size = new System.Drawing.Size(220, 20);
            this.textBoxTime.TabIndex = 9;
            this.textBoxTime.Text = "0";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 120);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(55, 13);
            this.label14.TabIndex = 8;
            this.label14.Text = "Time (ms):";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 94);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(146, 13);
            this.label13.TabIndex = 7;
            this.label13.Text = "Acceleration rectangle (m/s²):";
            // 
            // textBoxRectAcc
            // 
            this.textBoxRectAcc.Location = new System.Drawing.Point(159, 91);
            this.textBoxRectAcc.Name = "textBoxRectAcc";
            this.textBoxRectAcc.ReadOnly = true;
            this.textBoxRectAcc.Size = new System.Drawing.Size(220, 20);
            this.textBoxRectAcc.TabIndex = 6;
            this.textBoxRectAcc.Text = "0";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 68);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(115, 13);
            this.label12.TabIndex = 5;
            this.label12.Text = "Speed rectangle (m/s):";
            // 
            // textBoxSpeedRect
            // 
            this.textBoxSpeedRect.Location = new System.Drawing.Point(159, 65);
            this.textBoxSpeedRect.Name = "textBoxSpeedRect";
            this.textBoxSpeedRect.ReadOnly = true;
            this.textBoxSpeedRect.Size = new System.Drawing.Size(220, 20);
            this.textBoxSpeedRect.TabIndex = 4;
            this.textBoxSpeedRect.Text = "0";
            // 
            // textBoxAccCircle
            // 
            this.textBoxAccCircle.Location = new System.Drawing.Point(159, 39);
            this.textBoxAccCircle.Name = "textBoxAccCircle";
            this.textBoxAccCircle.ReadOnly = true;
            this.textBoxAccCircle.Size = new System.Drawing.Size(220, 20);
            this.textBoxAccCircle.TabIndex = 3;
            this.textBoxAccCircle.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 42);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(127, 13);
            this.label11.TabIndex = 2;
            this.label11.Text = "Acceleration circle (m/s²):";
            // 
            // textBoxCircleSpeed
            // 
            this.textBoxCircleSpeed.Location = new System.Drawing.Point(159, 13);
            this.textBoxCircleSpeed.Name = "textBoxCircleSpeed";
            this.textBoxCircleSpeed.ReadOnly = true;
            this.textBoxCircleSpeed.Size = new System.Drawing.Size(220, 20);
            this.textBoxCircleSpeed.TabIndex = 1;
            this.textBoxCircleSpeed.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(96, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Speed circle (m/s):";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(518, 251);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(117, 13);
            this.label10.TabIndex = 24;
            this.label10.Text = "Standard gravity (m/s²):";
            // 
            // numericStandGrav
            // 
            this.numericStandGrav.DecimalPlaces = 2;
            this.numericStandGrav.Location = new System.Drawing.Point(680, 249);
            this.numericStandGrav.Name = "numericStandGrav";
            this.numericStandGrav.Size = new System.Drawing.Size(226, 20);
            this.numericStandGrav.TabIndex = 25;
            this.numericStandGrav.Value = new decimal(new int[] {
            981,
            0,
            0,
            131072});
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(923, 523);
            this.Controls.Add(this.numericStandGrav);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.numericKineticFriction);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.numericStaticFriction);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.numericCircleMass);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.numericRectangleMass);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxDistance);
            this.Controls.Add(this.numericPPM);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericDistance);
            this.Controls.Add(this.numericAngle);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkOutframe);
            this.Controls.Add(this.checkStopped);
            this.Controls.Add(this.checkCollision);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.display);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "2D computer graphics";
            ((System.ComponentModel.ISupportInitialize)(this.display)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericAngle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericDistance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericPPM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericRectangleMass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCircleMass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericStaticFriction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericKineticFriction)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericStandGrav)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox display;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.CheckBox checkCollision;
        private System.Windows.Forms.CheckBox checkStopped;
        private System.Windows.Forms.CheckBox checkOutframe;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericAngle;
        private System.Windows.Forms.NumericUpDown numericDistance;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericPPM;
        private System.Windows.Forms.TextBox textBoxDistance;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericRectangleMass;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericCircleMass;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numericStaticFriction;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numericKineticFriction;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown numericStandGrav;
        private System.Windows.Forms.TextBox textBoxCircleSpeed;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBoxAccCircle;
        private System.Windows.Forms.TextBox textBoxSpeedRect;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBoxRectAcc;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBoxTime;
    }
}

