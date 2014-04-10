using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace dropableTest
{
    public partial class EQ : UserControl
    {
        public string strEQNo = "EQ No";

        public EQ()
        {
            InitializeComponent();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to remove this Equipment?", "Remove Equipment", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ((EQ)((Button)sender).Parent).Parent.Controls.Remove((EQ)((Button)sender).Parent);
            }
        }
        private void btnSetting_Click(object sender, EventArgs e)
        {
            Form f = new Form();
            f.Size = new System.Drawing.Size(360, 160);
            f.WindowState = FormWindowState.Normal;
            f.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Controls.Add(new Label());

            f.Controls[0].Font = new System.Drawing.Font("微軟正黑體", 12, FontStyle.Bold);
            f.Controls[0].Location = new Point(10, 20);
            f.Controls[0].Text = "Equipment Name";
            ((Label)f.Controls[0]).AutoSize = true;

            f.Controls.Add(new TextBox());
            f.Controls[1].Name = "txtEQName";
            f.Controls[1].Font = new System.Drawing.Font("微軟正黑體", 12);
            f.Controls[1].Location = new Point(f.Controls[0].Location.X + f.Controls[0].Width + 5, f.Controls[0].Location.Y - 5);
            f.Controls[1].Size = new System.Drawing.Size(180, 120);

            f.Controls.Add(new Button());
            f.Controls[2].Font = new System.Drawing.Font("微軟正黑體", 12);
            f.Controls[2].Location = new Point(20, 70);
            f.Controls[2].Size = new System.Drawing.Size(80, 30);
            f.Controls[2].Text = "Save";
            f.Controls[2].Click += new EventHandler(Save_Click);

            f.Show();
        }

        void Save_Click(object sender, EventArgs e)
        {
            strEQNo = ((Control)((Button)sender).Parent).Controls[1].Text;
            labEQNo.Text = strEQNo;
            ((Form)((Button)sender).Parent).Close();
        }
    }
}
