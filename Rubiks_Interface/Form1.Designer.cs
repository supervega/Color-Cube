namespace Rubiks_Interface
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
            this.components = new System.ComponentModel.Container();
            this.PanelFront = new System.Windows.Forms.Panel();
            this.PanelBack = new System.Windows.Forms.Panel();
            this.LblFront = new System.Windows.Forms.Label();
            this.LblBack = new System.Windows.Forms.Label();
            this.LblRight = new System.Windows.Forms.Label();
            this.PanelRight = new System.Windows.Forms.Panel();
            this.LblUp = new System.Windows.Forms.Label();
            this.PanelUp = new System.Windows.Forms.Panel();
            this.LblDown = new System.Windows.Forms.Label();
            this.PanelDown = new System.Windows.Forms.Panel();
            this.LbLeft = new System.Windows.Forms.Label();
            this.PanelLeft = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.BtnMoveHistory = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.RBLayer = new System.Windows.Forms.RadioButton();
            this.RBCube = new System.Windows.Forms.RadioButton();
            this.BtnInverseRotate = new System.Windows.Forms.Button();
            this.RBRight = new System.Windows.Forms.RadioButton();
            this.RBLeft = new System.Windows.Forms.RadioButton();
            this.BtnRotate = new System.Windows.Forms.Button();
            this.RBBack = new System.Windows.Forms.RadioButton();
            this.RBFront = new System.Windows.Forms.RadioButton();
            this.RBDown = new System.Windows.Forms.RadioButton();
            this.RBUp = new System.Windows.Forms.RadioButton();
            this.BtnInitialize = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.NUDStepDuration = new System.Windows.Forms.NumericUpDown();
            this.BtnSolve = new System.Windows.Forms.Button();
            this.BtnScramble = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.Btn_ChangeFront = new System.Windows.Forms.Button();
            this.Btn_ChangeRight = new System.Windows.Forms.Button();
            this.Btn_ChangeUp = new System.Windows.Forms.Button();
            this.Btn_ChangeBack = new System.Windows.Forms.Button();
            this.Btn_ChangeLeft = new System.Windows.Forms.Button();
            this.Btn_ChangeDown = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Btn_LoadState = new System.Windows.Forms.Button();
            this.BtnSaveState = new System.Windows.Forms.Button();
            this.Btn_Close = new System.Windows.Forms.Button();
            this.Btn_Minimize = new System.Windows.Forms.Button();
            this.Btn_Execute = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDStepDuration)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelFront
            // 
            this.PanelFront.BackColor = System.Drawing.Color.White;
            this.PanelFront.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelFront.Location = new System.Drawing.Point(220, 62);
            this.PanelFront.Name = "PanelFront";
            this.PanelFront.Size = new System.Drawing.Size(250, 250);
            this.PanelFront.TabIndex = 0;
            // 
            // PanelBack
            // 
            this.PanelBack.BackColor = System.Drawing.Color.White;
            this.PanelBack.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelBack.Location = new System.Drawing.Point(220, 344);
            this.PanelBack.Name = "PanelBack";
            this.PanelBack.Size = new System.Drawing.Size(250, 250);
            this.PanelBack.TabIndex = 1;
            // 
            // LblFront
            // 
            this.LblFront.AutoSize = true;
            this.LblFront.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblFront.Location = new System.Drawing.Point(223, 40);
            this.LblFront.Name = "LblFront";
            this.LblFront.Size = new System.Drawing.Size(103, 19);
            this.LblFront.TabIndex = 2;
            this.LblFront.Text = "Front (Red)";
            // 
            // LblBack
            // 
            this.LblBack.AutoSize = true;
            this.LblBack.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblBack.Location = new System.Drawing.Point(223, 322);
            this.LblBack.Name = "LblBack";
            this.LblBack.Size = new System.Drawing.Size(126, 19);
            this.LblBack.TabIndex = 3;
            this.LblBack.Text = "Back (Orange)";
            // 
            // LblRight
            // 
            this.LblRight.AutoSize = true;
            this.LblRight.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblRight.Location = new System.Drawing.Point(488, 40);
            this.LblRight.Name = "LblRight";
            this.LblRight.Size = new System.Drawing.Size(120, 19);
            this.LblRight.TabIndex = 4;
            this.LblRight.Text = "Right (White)";
            // 
            // PanelRight
            // 
            this.PanelRight.BackColor = System.Drawing.Color.White;
            this.PanelRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelRight.Location = new System.Drawing.Point(485, 62);
            this.PanelRight.Name = "PanelRight";
            this.PanelRight.Size = new System.Drawing.Size(250, 250);
            this.PanelRight.TabIndex = 3;
            // 
            // LblUp
            // 
            this.LblUp.AutoSize = true;
            this.LblUp.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblUp.Location = new System.Drawing.Point(755, 40);
            this.LblUp.Name = "LblUp";
            this.LblUp.Size = new System.Drawing.Size(99, 19);
            this.LblUp.TabIndex = 4;
            this.LblUp.Text = "Up (Green)";
            // 
            // PanelUp
            // 
            this.PanelUp.BackColor = System.Drawing.Color.White;
            this.PanelUp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelUp.Location = new System.Drawing.Point(752, 62);
            this.PanelUp.Name = "PanelUp";
            this.PanelUp.Size = new System.Drawing.Size(250, 250);
            this.PanelUp.TabIndex = 3;
            // 
            // LblDown
            // 
            this.LblDown.AutoSize = true;
            this.LblDown.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblDown.Location = new System.Drawing.Point(755, 322);
            this.LblDown.Name = "LblDown";
            this.LblDown.Size = new System.Drawing.Size(110, 19);
            this.LblDown.TabIndex = 6;
            this.LblDown.Text = "Down (Blue)";
            // 
            // PanelDown
            // 
            this.PanelDown.BackColor = System.Drawing.Color.White;
            this.PanelDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelDown.Location = new System.Drawing.Point(752, 344);
            this.PanelDown.Name = "PanelDown";
            this.PanelDown.Size = new System.Drawing.Size(250, 250);
            this.PanelDown.TabIndex = 5;
            // 
            // LbLeft
            // 
            this.LbLeft.AutoSize = true;
            this.LbLeft.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbLeft.Location = new System.Drawing.Point(488, 322);
            this.LbLeft.Name = "LbLeft";
            this.LbLeft.Size = new System.Drawing.Size(115, 19);
            this.LbLeft.TabIndex = 6;
            this.LbLeft.Text = "Left (Yellow)";
            // 
            // PanelLeft
            // 
            this.PanelLeft.BackColor = System.Drawing.Color.White;
            this.PanelLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelLeft.Location = new System.Drawing.Point(485, 344);
            this.PanelLeft.Name = "PanelLeft";
            this.PanelLeft.Size = new System.Drawing.Size(250, 250);
            this.PanelLeft.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureBox2);
            this.groupBox1.Controls.Add(this.BtnMoveHistory);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.BtnInitialize);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.NUDStepDuration);
            this.groupBox1.Controls.Add(this.BtnSolve);
            this.groupBox1.Controls.Add(this.BtnScramble);
            this.groupBox1.Location = new System.Drawing.Point(12, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(202, 661);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Rubiks_Interface.Properties.Resources.Small_Logo;
            this.pictureBox2.Location = new System.Drawing.Point(18, 102);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(134, 127);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 12;
            this.pictureBox2.TabStop = false;
            // 
            // BtnMoveHistory
            // 
            this.BtnMoveHistory.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnMoveHistory.Location = new System.Drawing.Point(18, 338);
            this.BtnMoveHistory.Name = "BtnMoveHistory";
            this.BtnMoveHistory.Size = new System.Drawing.Size(134, 31);
            this.BtnMoveHistory.TabIndex = 6;
            this.BtnMoveHistory.Text = "Moves History";
            this.BtnMoveHistory.UseVisualStyleBackColor = true;
            this.BtnMoveHistory.Click += new System.EventHandler(this.BtnMoveHistory_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.BtnInverseRotate);
            this.groupBox2.Controls.Add(this.RBRight);
            this.groupBox2.Controls.Add(this.RBLeft);
            this.groupBox2.Controls.Add(this.BtnRotate);
            this.groupBox2.Controls.Add(this.RBBack);
            this.groupBox2.Controls.Add(this.RBFront);
            this.groupBox2.Controls.Add(this.RBDown);
            this.groupBox2.Controls.Add(this.RBUp);
            this.groupBox2.Location = new System.Drawing.Point(0, 425);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 231);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Manual Control";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.RBLayer);
            this.groupBox3.Controls.Add(this.RBCube);
            this.groupBox3.Location = new System.Drawing.Point(6, 124);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(188, 41);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            // 
            // RBLayer
            // 
            this.RBLayer.AutoSize = true;
            this.RBLayer.Checked = true;
            this.RBLayer.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RBLayer.Location = new System.Drawing.Point(12, 15);
            this.RBLayer.Name = "RBLayer";
            this.RBLayer.Size = new System.Drawing.Size(63, 20);
            this.RBLayer.TabIndex = 8;
            this.RBLayer.TabStop = true;
            this.RBLayer.Text = "Layer";
            this.RBLayer.UseVisualStyleBackColor = true;
            // 
            // RBCube
            // 
            this.RBCube.AutoSize = true;
            this.RBCube.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RBCube.Location = new System.Drawing.Point(101, 15);
            this.RBCube.Name = "RBCube";
            this.RBCube.Size = new System.Drawing.Size(58, 20);
            this.RBCube.TabIndex = 9;
            this.RBCube.Text = "Cube";
            this.RBCube.UseVisualStyleBackColor = true;
            // 
            // BtnInverseRotate
            // 
            this.BtnInverseRotate.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnInverseRotate.Location = new System.Drawing.Point(107, 175);
            this.BtnInverseRotate.Name = "BtnInverseRotate";
            this.BtnInverseRotate.Size = new System.Drawing.Size(77, 45);
            this.BtnInverseRotate.TabIndex = 7;
            this.BtnInverseRotate.Text = "Inverse Rotate";
            this.BtnInverseRotate.UseVisualStyleBackColor = true;
            this.BtnInverseRotate.Click += new System.EventHandler(this.BtnInverseRotate_Click);
            // 
            // RBRight
            // 
            this.RBRight.AutoSize = true;
            this.RBRight.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RBRight.Location = new System.Drawing.Point(107, 88);
            this.RBRight.Name = "RBRight";
            this.RBRight.Size = new System.Drawing.Size(60, 20);
            this.RBRight.TabIndex = 1;
            this.RBRight.Text = "Right";
            this.RBRight.UseVisualStyleBackColor = true;
            // 
            // RBLeft
            // 
            this.RBLeft.AutoSize = true;
            this.RBLeft.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RBLeft.Location = new System.Drawing.Point(18, 88);
            this.RBLeft.Name = "RBLeft";
            this.RBLeft.Size = new System.Drawing.Size(52, 20);
            this.RBLeft.TabIndex = 0;
            this.RBLeft.Text = "Left";
            this.RBLeft.UseVisualStyleBackColor = true;
            // 
            // BtnRotate
            // 
            this.BtnRotate.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRotate.Location = new System.Drawing.Point(6, 175);
            this.BtnRotate.Name = "BtnRotate";
            this.BtnRotate.Size = new System.Drawing.Size(77, 45);
            this.BtnRotate.TabIndex = 6;
            this.BtnRotate.Text = "Rotate";
            this.BtnRotate.UseVisualStyleBackColor = true;
            this.BtnRotate.Click += new System.EventHandler(this.BtnRotate_Click);
            // 
            // RBBack
            // 
            this.RBBack.AutoSize = true;
            this.RBBack.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RBBack.Location = new System.Drawing.Point(107, 33);
            this.RBBack.Name = "RBBack";
            this.RBBack.Size = new System.Drawing.Size(56, 20);
            this.RBBack.TabIndex = 5;
            this.RBBack.Text = "Back";
            this.RBBack.UseVisualStyleBackColor = true;
            // 
            // RBFront
            // 
            this.RBFront.AutoSize = true;
            this.RBFront.Checked = true;
            this.RBFront.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RBFront.Location = new System.Drawing.Point(18, 33);
            this.RBFront.Name = "RBFront";
            this.RBFront.Size = new System.Drawing.Size(60, 20);
            this.RBFront.TabIndex = 4;
            this.RBFront.TabStop = true;
            this.RBFront.Text = "Front";
            this.RBFront.UseVisualStyleBackColor = true;
            // 
            // RBDown
            // 
            this.RBDown.AutoSize = true;
            this.RBDown.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RBDown.Location = new System.Drawing.Point(107, 61);
            this.RBDown.Name = "RBDown";
            this.RBDown.Size = new System.Drawing.Size(62, 20);
            this.RBDown.TabIndex = 3;
            this.RBDown.Text = "Down";
            this.RBDown.UseVisualStyleBackColor = true;
            // 
            // RBUp
            // 
            this.RBUp.AutoSize = true;
            this.RBUp.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RBUp.Location = new System.Drawing.Point(18, 61);
            this.RBUp.Name = "RBUp";
            this.RBUp.Size = new System.Drawing.Size(42, 20);
            this.RBUp.TabIndex = 2;
            this.RBUp.Text = "Up";
            this.RBUp.UseVisualStyleBackColor = true;
            // 
            // BtnInitialize
            // 
            this.BtnInitialize.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnInitialize.Location = new System.Drawing.Point(18, 28);
            this.BtnInitialize.Name = "BtnInitialize";
            this.BtnInitialize.Size = new System.Drawing.Size(134, 31);
            this.BtnInitialize.TabIndex = 4;
            this.BtnInitialize.Text = "Initialize";
            this.BtnInitialize.UseVisualStyleBackColor = true;
            this.BtnInitialize.Click += new System.EventHandler(this.BtnInitialize_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(15, 287);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(137, 16);
            this.label7.TabIndex = 3;
            this.label7.Text = "Step Duration (ms):";
            // 
            // NUDStepDuration
            // 
            this.NUDStepDuration.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NUDStepDuration.Location = new System.Drawing.Point(36, 306);
            this.NUDStepDuration.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.NUDStepDuration.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUDStepDuration.Name = "NUDStepDuration";
            this.NUDStepDuration.Size = new System.Drawing.Size(87, 23);
            this.NUDStepDuration.TabIndex = 2;
            this.NUDStepDuration.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NUDStepDuration.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUDStepDuration.ValueChanged += new System.EventHandler(this.NUDStepDuration_ValueChanged);
            // 
            // BtnSolve
            // 
            this.BtnSolve.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSolve.Location = new System.Drawing.Point(18, 375);
            this.BtnSolve.Name = "BtnSolve";
            this.BtnSolve.Size = new System.Drawing.Size(134, 44);
            this.BtnSolve.TabIndex = 1;
            this.BtnSolve.Text = "Solve";
            this.BtnSolve.UseVisualStyleBackColor = true;
            this.BtnSolve.Click += new System.EventHandler(this.BtnSolve_Click);
            // 
            // BtnScramble
            // 
            this.BtnScramble.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnScramble.Location = new System.Drawing.Point(18, 65);
            this.BtnScramble.Name = "BtnScramble";
            this.BtnScramble.Size = new System.Drawing.Size(134, 31);
            this.BtnScramble.TabIndex = 0;
            this.BtnScramble.Text = "Scramble";
            this.BtnScramble.UseVisualStyleBackColor = true;
            this.BtnScramble.Click += new System.EventHandler(this.BtnScramble_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 713);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1024, 22);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(16, 17);
            this.toolStripStatusLabel1.Text = "...";
            // 
            // Btn_ChangeFront
            // 
            this.Btn_ChangeFront.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_ChangeFront.Location = new System.Drawing.Point(394, 36);
            this.Btn_ChangeFront.Name = "Btn_ChangeFront";
            this.Btn_ChangeFront.Size = new System.Drawing.Size(76, 25);
            this.Btn_ChangeFront.TabIndex = 9;
            this.Btn_ChangeFront.Text = "Change";
            this.Btn_ChangeFront.UseVisualStyleBackColor = true;
            this.Btn_ChangeFront.Click += new System.EventHandler(this.Btn_ChangeFront_Click);
            // 
            // Btn_ChangeRight
            // 
            this.Btn_ChangeRight.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_ChangeRight.Location = new System.Drawing.Point(659, 36);
            this.Btn_ChangeRight.Name = "Btn_ChangeRight";
            this.Btn_ChangeRight.Size = new System.Drawing.Size(76, 25);
            this.Btn_ChangeRight.TabIndex = 10;
            this.Btn_ChangeRight.Text = "Change";
            this.Btn_ChangeRight.UseVisualStyleBackColor = true;
            this.Btn_ChangeRight.Click += new System.EventHandler(this.Btn_ChangeRight_Click);
            // 
            // Btn_ChangeUp
            // 
            this.Btn_ChangeUp.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_ChangeUp.Location = new System.Drawing.Point(926, 36);
            this.Btn_ChangeUp.Name = "Btn_ChangeUp";
            this.Btn_ChangeUp.Size = new System.Drawing.Size(76, 25);
            this.Btn_ChangeUp.TabIndex = 11;
            this.Btn_ChangeUp.Text = "Change";
            this.Btn_ChangeUp.UseVisualStyleBackColor = true;
            this.Btn_ChangeUp.Click += new System.EventHandler(this.Btn_ChangeUp_Click);
            // 
            // Btn_ChangeBack
            // 
            this.Btn_ChangeBack.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_ChangeBack.Location = new System.Drawing.Point(394, 318);
            this.Btn_ChangeBack.Name = "Btn_ChangeBack";
            this.Btn_ChangeBack.Size = new System.Drawing.Size(76, 25);
            this.Btn_ChangeBack.TabIndex = 12;
            this.Btn_ChangeBack.Text = "Change";
            this.Btn_ChangeBack.UseVisualStyleBackColor = true;
            this.Btn_ChangeBack.Click += new System.EventHandler(this.Btn_ChangeBack_Click);
            // 
            // Btn_ChangeLeft
            // 
            this.Btn_ChangeLeft.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_ChangeLeft.Location = new System.Drawing.Point(659, 318);
            this.Btn_ChangeLeft.Name = "Btn_ChangeLeft";
            this.Btn_ChangeLeft.Size = new System.Drawing.Size(76, 25);
            this.Btn_ChangeLeft.TabIndex = 13;
            this.Btn_ChangeLeft.Text = "Change";
            this.Btn_ChangeLeft.UseVisualStyleBackColor = true;
            this.Btn_ChangeLeft.Click += new System.EventHandler(this.Btn_ChangeLeft_Click);
            // 
            // Btn_ChangeDown
            // 
            this.Btn_ChangeDown.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_ChangeDown.Location = new System.Drawing.Point(926, 318);
            this.Btn_ChangeDown.Name = "Btn_ChangeDown";
            this.Btn_ChangeDown.Size = new System.Drawing.Size(76, 25);
            this.Btn_ChangeDown.TabIndex = 14;
            this.Btn_ChangeDown.Text = "Change";
            this.Btn_ChangeDown.UseVisualStyleBackColor = true;
            this.Btn_ChangeDown.Click += new System.EventHandler(this.Btn_ChangeDown_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Rubiks_Interface.Properties.Resources.tran_logo2;
            this.pictureBox1.Location = new System.Drawing.Point(735, 600);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(267, 90);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(804, 669);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 16);
            this.label1.TabIndex = 15;
            this.label1.Text = "www.quanbyte.com";
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 692);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.label2.Size = new System.Drawing.Size(1024, 21);
            this.label2.TabIndex = 16;
            this.label2.Text = "https://www.facebook.com/QuanByte/";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Btn_LoadState
            // 
            this.Btn_LoadState.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_LoadState.Location = new System.Drawing.Point(220, 641);
            this.Btn_LoadState.Name = "Btn_LoadState";
            this.Btn_LoadState.Size = new System.Drawing.Size(134, 44);
            this.Btn_LoadState.TabIndex = 17;
            this.Btn_LoadState.Text = "Load State";
            this.Btn_LoadState.UseVisualStyleBackColor = true;
            this.Btn_LoadState.Click += new System.EventHandler(this.Btn_LoadState_Click);
            // 
            // BtnSaveState
            // 
            this.BtnSaveState.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSaveState.Location = new System.Drawing.Point(360, 641);
            this.BtnSaveState.Name = "BtnSaveState";
            this.BtnSaveState.Size = new System.Drawing.Size(134, 44);
            this.BtnSaveState.TabIndex = 18;
            this.BtnSaveState.Text = "Save State";
            this.BtnSaveState.UseVisualStyleBackColor = true;
            this.BtnSaveState.Click += new System.EventHandler(this.BtnSaveState_Click);
            // 
            // Btn_Close
            // 
            this.Btn_Close.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Close.Location = new System.Drawing.Point(984, 4);
            this.Btn_Close.Name = "Btn_Close";
            this.Btn_Close.Size = new System.Drawing.Size(38, 25);
            this.Btn_Close.TabIndex = 19;
            this.Btn_Close.Text = "X";
            this.Btn_Close.UseVisualStyleBackColor = true;
            this.Btn_Close.Click += new System.EventHandler(this.Btn_Close_Click);
            // 
            // Btn_Minimize
            // 
            this.Btn_Minimize.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Minimize.Location = new System.Drawing.Point(943, 4);
            this.Btn_Minimize.Name = "Btn_Minimize";
            this.Btn_Minimize.Size = new System.Drawing.Size(38, 25);
            this.Btn_Minimize.TabIndex = 20;
            this.Btn_Minimize.Text = "-";
            this.Btn_Minimize.UseVisualStyleBackColor = true;
            this.Btn_Minimize.Click += new System.EventHandler(this.Btn_Minimize_Click);
            // 
            // Btn_Execute
            // 
            this.Btn_Execute.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Execute.Location = new System.Drawing.Point(595, 641);
            this.Btn_Execute.Name = "Btn_Execute";
            this.Btn_Execute.Size = new System.Drawing.Size(134, 44);
            this.Btn_Execute.TabIndex = 21;
            this.Btn_Execute.Text = "Execute";
            this.Btn_Execute.UseVisualStyleBackColor = true;
            this.Btn_Execute.Click += new System.EventHandler(this.Btn_Execute_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(1024, 735);
            this.Controls.Add(this.Btn_Execute);
            this.Controls.Add(this.Btn_Minimize);
            this.Controls.Add(this.Btn_Close);
            this.Controls.Add(this.BtnSaveState);
            this.Controls.Add(this.Btn_LoadState);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Btn_ChangeDown);
            this.Controls.Add(this.Btn_ChangeLeft);
            this.Controls.Add(this.Btn_ChangeBack);
            this.Controls.Add(this.Btn_ChangeUp);
            this.Controls.Add(this.Btn_ChangeRight);
            this.Controls.Add(this.Btn_ChangeFront);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.LbLeft);
            this.Controls.Add(this.LblDown);
            this.Controls.Add(this.PanelLeft);
            this.Controls.Add(this.LblUp);
            this.Controls.Add(this.PanelDown);
            this.Controls.Add(this.PanelUp);
            this.Controls.Add(this.LblRight);
            this.Controls.Add(this.LblBack);
            this.Controls.Add(this.PanelRight);
            this.Controls.Add(this.LblFront);
            this.Controls.Add(this.PanelBack);
            this.Controls.Add(this.PanelFront);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(1024, 750);
            this.MinimumSize = new System.Drawing.Size(1024, 600);
            this.Name = "Form1";
            this.Opacity = 0.95D;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rubik\'s Cube Solver - Quantum Byte";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDStepDuration)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PanelFront;
        private System.Windows.Forms.Panel PanelBack;
        private System.Windows.Forms.Label LblFront;
        private System.Windows.Forms.Label LblBack;
        private System.Windows.Forms.Label LblRight;
        private System.Windows.Forms.Panel PanelRight;
        private System.Windows.Forms.Label LblUp;
        private System.Windows.Forms.Panel PanelUp;
        private System.Windows.Forms.Label LblDown;
        private System.Windows.Forms.Panel PanelDown;
        private System.Windows.Forms.Label LbLeft;
        private System.Windows.Forms.Panel PanelLeft;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button BtnScramble;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown NUDStepDuration;
        private System.Windows.Forms.Button BtnSolve;
        private System.Windows.Forms.Button BtnInitialize;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton RBBack;
        private System.Windows.Forms.RadioButton RBFront;
        private System.Windows.Forms.RadioButton RBDown;
        private System.Windows.Forms.RadioButton RBUp;
        private System.Windows.Forms.RadioButton RBRight;
        private System.Windows.Forms.RadioButton RBLeft;
        private System.Windows.Forms.Button BtnInverseRotate;
        private System.Windows.Forms.Button BtnRotate;
        private System.Windows.Forms.RadioButton RBCube;
        private System.Windows.Forms.RadioButton RBLayer;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button BtnMoveHistory;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button Btn_ChangeFront;
        private System.Windows.Forms.Button Btn_ChangeRight;
        private System.Windows.Forms.Button Btn_ChangeUp;
        private System.Windows.Forms.Button Btn_ChangeBack;
        private System.Windows.Forms.Button Btn_ChangeLeft;
        private System.Windows.Forms.Button Btn_ChangeDown;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Btn_LoadState;
        private System.Windows.Forms.Button BtnSaveState;
        private System.Windows.Forms.Button Btn_Close;
        private System.Windows.Forms.Button Btn_Minimize;
        private System.Windows.Forms.Button Btn_Execute;
    }
}

