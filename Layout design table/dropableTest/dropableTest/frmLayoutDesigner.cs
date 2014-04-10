using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace dropableTest
{
    public partial class frmDesignLayout : Form
    {
        public frmDesignLayout()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            eq1.btnRemove.Enabled = false;
            eq1.btnSetting.Enabled = false;
            eq2.btnRemove.Enabled = false;
            eq2.btnSetting.Enabled = false;

            foreach (Control ctrl in plMain.Controls)
            {
                if (ctrl.GetType() == typeof(EQ))
                {
                    ctrl.MouseMove += ctrl_MouseMove;
                    ctrl.MouseDown += ctrl_MouseDown;
                    ctrl.MouseUp += ctrl_MouseUp;
                }
            }
            
        }

        private MouseEventArgs _pos = null;
        private int iOriginX = 0;
        private int iOriginY = 0;

        void ctrl_MouseDown(object sender, MouseEventArgs e)
        {
            iOriginX = ((Control)sender).Location.X;
            iOriginY = ((Control)sender).Location.Y;

            if (e.Button == MouseButtons.Right)
            {
                _pos = e;//按下時記錄位置
                
            }
        }

        void ctrl_MouseMove(object sender, MouseEventArgs e)
        {
            Control ctrl = sender as Control;

            if (ctrl.Capture && e.Button == MouseButtons.Right)
            {
                if(e.Y + ctrl.Location.Y - _pos.Y < 0)
                {
                    ctrl.Top = 0;

                    if (e.X + ctrl.Location.X - _pos.X < 0)
                    {
                        ctrl.Left =0;
                    }
                    else
                    {
                        ctrl.Left = e.X + ctrl.Location.X - _pos.X;
                    }
                }
                else if (e.X + ctrl.Location.X - _pos.X < 0)
                {
                    
                    ctrl.Left = 0;

                    if (e.Y + ctrl.Location.Y - _pos.Y < 0)
                    {
                        ctrl.Top = 0;
                    }
                    else
                    {
                        ctrl.Top = e.Y + ctrl.Location.Y - _pos.Y;
                    }
                }
                else if (e.Y + ctrl.Location.Y - _pos.Y > 0 && e.X + ctrl.Location.X - _pos.X > 0)
                {
                    ctrl.Top = e.Y + ctrl.Location.Y - _pos.Y;
                    ctrl.Left = e.X + ctrl.Location.X - _pos.X;
                }
            }
        }


        void ctrl_MouseUp(object sender, MouseEventArgs e)
        {
            Control ctrl = sender as Control;

            if (ctrl.Location.X > plEdit.Location.X && ctrl.Location.Y > plEdit.Location.Y)
            {
                object o = System.Activator.CreateInstance(sender.GetType());
                plEdit.Controls.Add((Control)o);

                ((Control)o).MouseMove += ctrl_MouseMove;
                ((Control)o).MouseDown += ctrl_MouseDown;

                foreach (Control c in plEdit.Controls)
                {
                    int iplX = ctrl.Location.X - plEdit.Location.X;
                    int iplY = ctrl.Location.Y - plEdit.Location.Y;
                    
                    plEdit.Controls[plEdit.Controls.Count - 1].Location = new Point(iplX, iplY);
                    
                }
                plEdit.Controls.SetChildIndex(plEdit.Controls[plEdit.Controls.Count - 1], 0);
            }
            ((Control)sender).Location = new Point(iOriginX, iOriginY);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists("config.ini"))
                {
                    File.Delete("config.ini");
                }

                StreamWriter sw = new StreamWriter("config.ini");
                

                foreach (Control c in plEdit.Controls)
                {
                    if (c.GetType() == typeof(EQ))
                    {
                        string strLine = "";
                        strLine = string.Format("{0};{1};{2};{3};{4};{5}", typeof(EQ), c.Location.X, c.Location.Y, c.Size.Height, c.Size.Width,((EQ)c).labEQNo.Text);
                        sw.WriteLine(strLine);
                    }
                }
                sw.Close();
            }
            catch (Exception ex)
            {
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            btnLoad.Enabled = false;
            StreamReader sr = new StreamReader("config.ini");
            string strLine = "";

            plEdit.Controls.Clear();
            

            while ((strLine = sr.ReadLine()) != null)
            {
                string[] strPara = strLine.Split(';');
                object o = System.Activator.CreateInstance(typeof(EQ));
                plEdit.Controls.Add((Control)o);
                
                ((Control)o).MouseMove += ctrl_MouseMove;
                ((Control)o).MouseDown += ctrl_MouseDown;

                plEdit.Controls[plEdit.Controls.Count - 1].Location = new Point(Convert.ToInt32(strPara[1]), Convert.ToInt32(strPara[2]));
                ((EQ)o).labEQNo.Text = strPara[5];
            }
            sr.Close();
            //重新載入picturebox
            {
                this.pbLayout = new System.Windows.Forms.PictureBox();
                plEdit.Controls.Add(pbLayout);
                this.pbLayout.Image = global::dropableTest.Properties.Resources.Penguins;
                this.pbLayout.Location = new System.Drawing.Point(-1, -1);
                this.pbLayout.Name = "pbLayout";
                this.pbLayout.Size = new System.Drawing.Size(pbLayout.Image.Size.Width, pbLayout.Size.Height);
                this.pbLayout.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
                this.pbLayout.TabIndex = 0;
                this.pbLayout.TabStop = false;
            }

            btnLoad.Enabled = true;
        }
 
    }
}
