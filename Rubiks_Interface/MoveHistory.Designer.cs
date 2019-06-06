namespace Rubiks_Interface
{
    partial class MoveHistory
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
            this.LBMoves = new System.Windows.Forms.ListBox();
            this.LblMoves = new System.Windows.Forms.Label();
            this.BtnSaveHistory = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // LBMoves
            // 
            this.LBMoves.FormattingEnabled = true;
            this.LBMoves.Location = new System.Drawing.Point(12, 32);
            this.LBMoves.Name = "LBMoves";
            this.LBMoves.Size = new System.Drawing.Size(226, 381);
            this.LBMoves.TabIndex = 0;
            // 
            // LblMoves
            // 
            this.LblMoves.AutoSize = true;
            this.LblMoves.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblMoves.Location = new System.Drawing.Point(12, 9);
            this.LblMoves.Name = "LblMoves";
            this.LblMoves.Size = new System.Drawing.Size(71, 19);
            this.LblMoves.TabIndex = 1;
            this.LblMoves.Text = "Moves :";
            // 
            // BtnSaveHistory
            // 
            this.BtnSaveHistory.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSaveHistory.Location = new System.Drawing.Point(12, 419);
            this.BtnSaveHistory.Name = "BtnSaveHistory";
            this.BtnSaveHistory.Size = new System.Drawing.Size(106, 23);
            this.BtnSaveHistory.TabIndex = 2;
            this.BtnSaveHistory.Text = "Save History";
            this.BtnSaveHistory.UseVisualStyleBackColor = true;
            this.BtnSaveHistory.Click += new System.EventHandler(this.BtnSaveHistory_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // MoveHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(250, 448);
            this.Controls.Add(this.BtnSaveHistory);
            this.Controls.Add(this.LblMoves);
            this.Controls.Add(this.LBMoves);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MoveHistory";
            this.ShowIcon = false;
            this.Text = "Move History";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MoveHistory_FormClosed);
            this.Load += new System.EventHandler(this.MoveHistory_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox LBMoves;
        private System.Windows.Forms.Label LblMoves;
        private System.Windows.Forms.Button BtnSaveHistory;
        private System.Windows.Forms.Timer timer1;
    }
}