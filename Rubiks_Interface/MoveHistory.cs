using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Rubiks_Interface
{
    public partial class MoveHistory : Form
    {
        public Manager ManagerRef;
        private int lastLenght = 0;

        public MoveHistory()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (ManagerRef.MovesHistory.Count > lastLenght || ManagerRef.MovesHistory.Count < lastLenght)
                {
                    LBMoves.Items.Clear();
                    LblMoves.Text = "Moves :(" + ManagerRef.MovesHistory.Count + ")";
                    foreach (string item in ManagerRef.MovesHistory)
                    {
                        LBMoves.Items.Add(item);
                    }
                    lastLenght = ManagerRef.MovesHistory.Count;
                }
                if (ManagerRef.MovesHistory.Count == 0)
                {
                    LblMoves.Text = "Moves :(0)";
                    LBMoves.Items.Clear();
                }
            }
            catch (Exception ex)
            { }
        }

        private void MoveHistory_Load(object sender, EventArgs e)
        {
            ManagerRef.IsHistoryActive = true;
            timer1.Start();
        }

        private void BtnSaveHistory_Click(object sender, EventArgs e)
        {
            SaveFileDialog SFD = new SaveFileDialog();
            if (SFD.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllLines(SFD.FileName+".txt", ManagerRef.MovesHistory.ToArray());
            }
        }

        private void MoveHistory_FormClosed(object sender, FormClosedEventArgs e)
        {
            ManagerRef.IsHistoryActive = false;
        }
    }
}
