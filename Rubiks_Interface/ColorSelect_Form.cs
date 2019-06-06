using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Rubiks_Interface
{
    public partial class ColorSelect_Form : Form
    {
        public Manager ManagerRef = null;
        public int CurrentFaceIndex = -1;

        public ColorSelect_Form()
        {
            InitializeComponent();
        }

        private void ColorSelect_Form_Load(object sender, EventArgs e)
        {
            if (ManagerRef != null && CurrentFaceIndex > -1)
            {
                Btn_00.BackColor = ManagerRef.Faces[CurrentFaceIndex, 0].Colors[Direction.Front];
                Btn_01.BackColor = ManagerRef.Faces[CurrentFaceIndex, 1].Colors[Direction.Front];
                Btn_02.BackColor = ManagerRef.Faces[CurrentFaceIndex, 2].Colors[Direction.Front];
                Btn_10.BackColor = ManagerRef.Faces[CurrentFaceIndex, 3].Colors[Direction.Front];
                Btn_11.BackColor = ManagerRef.Faces[CurrentFaceIndex, 4].Colors[Direction.Front];
                Btn_12.BackColor = ManagerRef.Faces[CurrentFaceIndex, 5].Colors[Direction.Front];
                Btn_20.BackColor = ManagerRef.Faces[CurrentFaceIndex, 6].Colors[Direction.Front];
                Btn_21.BackColor = ManagerRef.Faces[CurrentFaceIndex, 7].Colors[Direction.Front];
                Btn_22.BackColor = ManagerRef.Faces[CurrentFaceIndex, 8].Colors[Direction.Front];
            }
        }

        private void Pick_Event(object sender,EventArgs e)
        {
            if (ManagerRef != null && CurrentFaceIndex>-1)
            {
                string name = ((Button)sender).Name;
                int col=Convert.ToInt32(name[5].ToString());
                int row=Convert.ToInt32(name[4].ToString());
                if(col==1 && row==1)
                {
                    MessageBox.Show("لا يمكن تغيير المنتصف");
                    return;
                }
                ColorDialog CD = new ColorDialog();
                CD.AnyColor = false;
                CD.AllowFullOpen = false;
                CD.FullOpen = false;
                //CD.SolidColorOnly = true;
                Button btn = (Button)tableLayoutPanel1.GetControlFromPosition(col,row );
                if (CD.ShowDialog() == DialogResult.OK)
                {
                    if (CD.Color != Color.White && CD.Color != Color.Red && CD.Color != Color.Green &&
                        CD.Color.Name != "ffff8000" && CD.Color != Color.Blue && CD.Color != Color.Yellow)
                    {
                        ManagerRef.status.Text = "Pick Only available colors: White, Red, Green, Orange, Blue, Yellow";
                    }
                    else
                    {
                        btn.BackColor = CD.Color;
                        ManagerRef.Faces[CurrentFaceIndex, row * 3 + col].Colors[Direction.Front] = CD.Color;
                    }
                }
                
            }
        }
    }
}
