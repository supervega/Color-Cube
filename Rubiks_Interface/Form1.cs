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
    public partial class Form1 : Form
    {
        Manager ManagerRef;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ManagerRef = new Manager();
            ManagerRef.status = toolStripStatusLabel1;
            timer1.Start();
        }

        private void BtnScramble_Click(object sender, EventArgs e)
        {
            BtnSolve.Enabled = true;
            NUDStepDuration.Enabled = true;
            ManagerRef.Scramble();
            DrawCube();
        }

        private void DrawCube()
        {
            int SquareUnit = PanelBack.Width / 5;
            for (int i = 0; i < 6; i++)
            {
                Graphics g=null;
                switch (i)
                {
                    case 0: g = PanelFront.CreateGraphics();
                        break;
                    case 1: g = PanelLeft.CreateGraphics();
                        break;
                    case 2: g = PanelBack.CreateGraphics();
                        break;
                    case 3: g = PanelRight.CreateGraphics();
                        break;
                    case 4: g = PanelUp.CreateGraphics();
                        break;
                    case 5: g = PanelDown.CreateGraphics();
                        break;
                }
                g.Clear(Color.Black);
                for (int j = 0; j < 9; j++)
                {
                    try
                    {
                        Dictionary<Direction, Color>.Enumerator ColorsEnum = ManagerRef.Faces[i, j].Colors.GetEnumerator();
                        while (ColorsEnum.MoveNext())
                        {
                            switch(ColorsEnum.Current.Key)
                            {
                                case Direction.Front:
                                    g.FillRectangle(new Pen(ColorsEnum.Current.Value).Brush, ManagerRef.Faces[i, j].X * SquareUnit + SquareUnit, ManagerRef.Faces[i, j].Y * SquareUnit + SquareUnit, SquareUnit - 1, SquareUnit - 1);
                                    break;
                                case Direction.Up:
                                    g.FillRectangle(new Pen(ColorsEnum.Current.Value).Brush, ManagerRef.Faces[i, j].X * SquareUnit + SquareUnit, ManagerRef.Faces[i, j].Y * SquareUnit, SquareUnit - 1, SquareUnit - 1);
                                    break;
                                case Direction.Left:
                                    g.FillRectangle(new Pen(ColorsEnum.Current.Value).Brush, ManagerRef.Faces[i, j].X * SquareUnit, ManagerRef.Faces[i, j].Y * SquareUnit + SquareUnit, SquareUnit - 1, SquareUnit - 1);
                                    break;
                                case Direction.Right:
                                    g.FillRectangle(new Pen(ColorsEnum.Current.Value).Brush, ManagerRef.Faces[i, j].X * SquareUnit + 2*SquareUnit, ManagerRef.Faces[i, j].Y * SquareUnit + SquareUnit, SquareUnit - 1, SquareUnit - 1);
                                    break;
                                case Direction.Down:
                                    g.FillRectangle(new Pen(ColorsEnum.Current.Value).Brush, ManagerRef.Faces[i, j].X * SquareUnit + SquareUnit, ManagerRef.Faces[i, j].Y * SquareUnit + 2*SquareUnit, SquareUnit - 1, SquareUnit - 1);
                                    break;
                            }
                        }
                    }
                    catch (Exception ex)
                    { }
                }
                LblBack.Text = "Back ("+ManagerRef.Faces[2,4].Colors[Direction.Front].Name+")";
                LblDown.Text = "Down (" + ManagerRef.Faces[5, 4].Colors[Direction.Front].Name + ")";
                LbLeft.Text = "Left ("+ManagerRef.Faces[1,4].Colors[Direction.Front].Name+")";
                LblFront.Text = "Front (" + ManagerRef.Faces[0, 4].Colors[Direction.Front].Name + ")";
                LblRight.Text = "Right (" + ManagerRef.Faces[3, 4].Colors[Direction.Front].Name + ")";
                LblUp.Text = "Up (" + ManagerRef.Faces[4, 4].Colors[Direction.Front].Name + ")"; 
            }
            if(ManagerRef.IsCubeSolved && !ManagerRef.IsHistoryActive)
            {
                MoveHistory MH = new MoveHistory();
                MH.ManagerRef = ManagerRef;
                MH.Show();
                ManagerRef.IsCubeSolved = false;
            }
        }

        private void BtnInitialize_Click(object sender, EventArgs e)
        {
            BtnSolve.Enabled = true;
            NUDStepDuration.Enabled = true;
            ManagerRef.Initialize();
            ManagerRef.SetColors();
            DrawCube();
        }

        private void BtnRotate_Click(object sender, EventArgs e)
        {
            if (RBLayer.Checked)
            {
                if(RBFront.Checked)
                    ManagerRef.Rotate(0,false);
                if (RBLeft.Checked)
                    ManagerRef.Rotate(1, false);
                if (RBBack.Checked)
                    ManagerRef.Rotate(2, false);
                if (RBRight.Checked)
                    ManagerRef.Rotate(3, false);
                if (RBUp.Checked)
                    ManagerRef.Rotate(4, false);
                if (RBDown.Checked)
                    ManagerRef.Rotate(5, false);
            }
            if (RBCube.Checked)
            {
                if (RBFront.Checked)
                    ManagerRef.RotateCube(Direction.Front, false);
                if (RBLeft.Checked)
                    ManagerRef.RotateCube(Direction.Right, true);
                if (RBBack.Checked)
                    ManagerRef.RotateCube(Direction.Front, true);
                if (RBRight.Checked)
                    ManagerRef.RotateCube(Direction.Right, false);
                if (RBUp.Checked)
                    ManagerRef.RotateCube(Direction.Up, false);
                if (RBDown.Checked)
                    ManagerRef.RotateCube(Direction.Up, true);
            }
            DrawCube();
        }

        private void BtnInverseRotate_Click(object sender, EventArgs e)
        {
            if (RBLayer.Checked)
            {
                if (RBFront.Checked)
                    ManagerRef.Rotate(0, true);
                if (RBLeft.Checked)
                    ManagerRef.Rotate(1, true);
                if (RBBack.Checked)
                    ManagerRef.Rotate(2, true);
                if (RBRight.Checked)
                    ManagerRef.Rotate(3, true);
                if (RBUp.Checked)
                    ManagerRef.Rotate(4, true);
                if (RBDown.Checked)
                    ManagerRef.Rotate(5, true);
            }
            if (RBCube.Checked)
            {
                if (RBFront.Checked)
                    ManagerRef.RotateCube(Direction.Front, true);
                if (RBLeft.Checked)
                    ManagerRef.RotateCube(Direction.Right, false);
                if (RBBack.Checked)
                    ManagerRef.RotateCube(Direction.Front, false);
                if (RBRight.Checked)
                    ManagerRef.RotateCube(Direction.Right, true);
                if (RBUp.Checked)
                    ManagerRef.RotateCube(Direction.Up, true);
                if (RBDown.Checked)
                    ManagerRef.RotateCube(Direction.Up, false);
            }
            DrawCube();
        }

        private void BtnMoveHistory_Click(object sender, EventArgs e)
        {
            MoveHistory MH = new MoveHistory();
            MH.ManagerRef = ManagerRef;
            MH.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DrawCube();
        }

        private void NUDStepDuration_ValueChanged(object sender, EventArgs e)
        {
            ManagerRef.SolveSleep = Convert.ToInt32(NUDStepDuration.Value);
        }

        private void BtnSolve_Click(object sender, EventArgs e)
        {
            BtnSolve.Enabled = false;
            NUDStepDuration.Enabled = false;
            ManagerRef.Solve();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (ManagerRef != null)
                ManagerRef.Dispose();
        }

        private void Btn_ChangeFront_Click(object sender, EventArgs e)
        {
            ColorSelect_Form ColSelect = new ColorSelect_Form();
            ColSelect.ManagerRef = ManagerRef;
            ColSelect.CurrentFaceIndex = 0;
            ColSelect.Show();
        }

        private void Btn_ChangeLeft_Click(object sender, EventArgs e)
        {
            ColorSelect_Form ColSelect = new ColorSelect_Form();
            ColSelect.ManagerRef = ManagerRef;
            ColSelect.CurrentFaceIndex = 1;
            ColSelect.Show();
        }

        private void Btn_ChangeBack_Click(object sender, EventArgs e)
        {
            ColorSelect_Form ColSelect = new ColorSelect_Form();
            ColSelect.ManagerRef = ManagerRef;
            ColSelect.CurrentFaceIndex = 2;
            ColSelect.Show();
        }

        private void Btn_ChangeRight_Click(object sender, EventArgs e)
        {
            ColorSelect_Form ColSelect = new ColorSelect_Form();
            ColSelect.ManagerRef = ManagerRef;
            ColSelect.CurrentFaceIndex = 3;
            ColSelect.Show();
        }

        private void Btn_ChangeUp_Click(object sender, EventArgs e)
        {
            ColorSelect_Form ColSelect = new ColorSelect_Form();
            ColSelect.ManagerRef = ManagerRef;
            ColSelect.CurrentFaceIndex = 4;
            ColSelect.Show();
        }

        private void Btn_ChangeDown_Click(object sender, EventArgs e)
        {
            ColorSelect_Form ColSelect = new ColorSelect_Form();
            ColSelect.ManagerRef = ManagerRef;
            ColSelect.CurrentFaceIndex = 5;
            ColSelect.Show();
        }

        private void Btn_Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Btn_Minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Btn_LoadState_Click(object sender, EventArgs e)
        {
            OpenFileDialog OFD = new OpenFileDialog();
            if(OFD.ShowDialog()==DialogResult.OK)
            {
                string content = File.ReadAllText(OFD.FileName);
                string[] faces = content.Split(new string[] { "FACE" }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < faces.Length; i++)
                {
                    string[] colors = faces[i].Trim().Split(new char[] { ',' },StringSplitOptions.RemoveEmptyEntries);
                    for (int j = 0; j < colors.Length; j++)
                    {
                        ManagerRef.Faces[i, j].Colors[Direction.Front] = Color.FromName(colors[j]);
                    }
                }
                ManagerRef.SetColors();
                BtnSolve.Enabled = true;
            }
        }

        private void BtnSaveState_Click(object sender, EventArgs e)
        {
            string content = "";
            for (int i = 0; i < 6; i++)
            {
                content += "FACE\n";
                for (int j = 0; j < 9; j++)
                {
                    content += ManagerRef.Faces[i, j].Colors[Direction.Front].ToKnownColor().ToString()+",";
                }                
            }
            SaveFileDialog SFD = new SaveFileDialog();
            if(SFD.ShowDialog()==DialogResult.OK)
            {
                File.WriteAllText(SFD.FileName, content);
            }            
        }

        private void Btn_Execute_Click(object sender, EventArgs e)
        {
            OpenFileDialog OFD = new OpenFileDialog();
            if(OFD.ShowDialog()==DialogResult.OK)
            {
                string[] instructions = File.ReadAllLines(OFD.FileName);
                for (int i = 0; i < instructions.Length; i++)
                {
                    if(!instructions[i].StartsWith("Phase"))
                    {
                        switch(instructions[i])
                        {
                            case "Cube Up":ManagerRef.RotateCube(Direction.Up, false);
                                break;
                            case "Cube Up Inverted":
                                ManagerRef.RotateCube(Direction.Up, true);
                                break;
                            case "Cube Front":
                                ManagerRef.RotateCube(Direction.Front, false);
                                break;
                            case "Cube Front Inverted":
                                ManagerRef.RotateCube(Direction.Front, true);
                                break;
                            case "Front":
                                ManagerRef.Rotate(0, false);
                                break;
                            case "Front Inverted":
                                ManagerRef.Rotate(0, true);
                                break;
                            case "Left":
                                ManagerRef.Rotate(01, false);
                                break;
                            case "Left Inverted":
                                ManagerRef.Rotate(1, true);
                                break;
                            case "Right":
                                ManagerRef.Rotate(3, false);
                                break;
                            case "Right Inverted":
                                ManagerRef.Rotate(3, true);
                                break;
                            case "Back":
                                ManagerRef.Rotate(2, false);
                                break;
                            case "Back Inverted":
                                ManagerRef.Rotate(2, true);
                                break;
                            case "Up":
                                ManagerRef.Rotate(4, false);
                                break;
                            case "Up Inverted":
                                ManagerRef.Rotate(4, true);
                                break;
                            case "Down":
                                ManagerRef.Rotate(5, false);
                                break;
                            case "Down Inverted":
                                ManagerRef.Rotate(5, true);
                                break;
                            default:MessageBox.Show(instructions[i]);break;
                        }
                    }
                }
            }
        }
    }
}
