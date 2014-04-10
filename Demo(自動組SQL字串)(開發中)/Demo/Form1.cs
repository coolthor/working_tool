using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace Demo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static Dictionary<string, string> dicRuleAndName;
        public static Dictionary<string, string> dicRuleIndex  =new Dictionary<string,string>();

        private void button1_Click(object sender, EventArgs e)
        {
            //Create Mapping Record In DataGridView

            dgvRuleIndex.Rows.Add();
            DataGridViewRow dgvr = dgvRuleIndex.Rows[dgvRuleIndex.Rows.Count-1];
            dgvr.Cells[0].Value = false;
            dgvr.Cells[1].Value = string.Format("{0}.{1}",txtTableName.Text,txtColumnName.Text);

            DataGridViewComboBoxColumn dgvcboc = (DataGridViewComboBoxColumn)dgvRuleIndex.Columns["Mapping"];
            dgvcboc.Items.Add(string.Format("{0}.{1}", txtTableName.Text, txtColumnName.Text));

            dgvRuleIndex.Update();

            Panel currentTable;

            if (pnlRule.Controls.Count > 0)
            {
                int iCnt = 0;
                foreach (Control c in pnlRule.Controls)
                {
                    if (c.GetType() == typeof(Panel) && c.Name == txtTableName.Text)
                    {
                        iCnt++;
                        currentTable = c as Panel;

                        if (currentTable.Size.Height + 40 <= c.Parent.Size.Height - 8)
                        {
                            currentTable.Size = new System.Drawing.Size(200, 40 + 40 * currentTable.Controls.Count/3);
                        }
                        else
                        {
                            int n = 0;
                            n = (currentTable.Size.Width * currentTable.Size.Height) / (200 * 40);
                            if (n < (currentTable.Controls.Count/3)+1)
                            {
                                n = n / 4 + 1;
                                currentTable.Size = new System.Drawing.Size(200 * n, currentTable.Size.Height);
                            }
                        }

                        currentTable.BorderStyle = BorderStyle.FixedSingle;

                        AddNewRule(currentTable);

                    }
                }

                if (iCnt == 0)
                {
                    pnlRule.Controls.Add(new Panel());
                    currentTable = pnlRule.Controls[pnlRule.Controls.Count - 1] as Panel;
                    currentTable.Name = txtTableName.Text;
                    currentTable.Location = new Point(pnlRule.Controls[pnlRule.Controls.Count - 2].Location.X+pnlRule.Controls[pnlRule.Controls.Count - 2].Size.Width + 1, 4);
                    currentTable.Size = new System.Drawing.Size(200, 40);
                    currentTable.BorderStyle = BorderStyle.FixedSingle;

                    AddNewRule(currentTable);
                }
            }
            else
            {
                pnlRule.Controls.Add(new Panel());
                currentTable = pnlRule.Controls[pnlRule.Controls.Count - 1] as Panel;
                currentTable.Name = txtTableName.Text;
                currentTable.Location = new Point(4, 4);
                currentTable.Size = new System.Drawing.Size(200, 40);
                currentTable.BorderStyle = BorderStyle.FixedSingle;

                AddNewRule(currentTable);
            }
        }

        private void btnClearConfig_Click(object sender, EventArgs e)
        {
            pnlRule.Controls.Clear();
            
        }

        private void btnSaveConfig_Click(object sender, EventArgs e)
        {
            foreach (Control ctrlPanel in pnlResult.Controls)
            {

            }
        }

        private void AddNewRule(Panel p)
        {
            try
            {

                if (dicRuleAndName == null)  dicRuleAndName = new Dictionary<string, string>();

                Label labColumnName;
                Label labRuleName;
                int n = 0;
                n = p.Controls.Count / 3;

                p.Controls.Add(new Label());
                labColumnName = (Label)p.Controls[p.Controls.Count - 1];
                labColumnName.Name = txtColumnName.Text.Trim();
                labColumnName.Text = txtDisplayName.Text;

                labColumnName.Location = new Point(4 + 200*(p.Size.Width/200 - 1), 13 + (40 * (n%4)));
               

                labColumnName.AutoSize = true;

                p.Controls.Add(new Label());
                labRuleName = (Label)p.Controls[p.Controls.Count - 1];
                labRuleName.Text = cboRule.Text;
                labRuleName.AutoSize = true;
                labRuleName.Location = new Point(labColumnName.Location.X + labColumnName.Size.Width + 1, labColumnName.Location.Y);

                if (cboType.Text == "TextBox")
                {
                    p.Controls.Add(new TextBox());
                }
                else
                {
                    p.Controls.Add(new ComboBox());
                }

                p.Controls[p.Controls.Count - 1].Name = txtColumnName.Text;
                p.Controls[p.Controls.Count - 1].Location = new Point(labRuleName.Location.X + labRuleName.Size.Width + 1, labRuleName.Location.Y-5);

                dicRuleAndName.Add( txtColumnName.Text,cboRule.Text);
                //作為紀錄，TextBox 無法直接以GetType取得type
                //Type myType1 = Type.GetType("System.Windows.Forms.TextBox, System.Windows.Forms,Version=1.0.5000.0, Culture=neutral, PublicKeyToken=b77a5c561934e089");
                //object o = Activator.CreateInstance(cboType.GetType());
            }
            catch (Exception ex)
            {
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dgvRuleIndex.RowHeadersDefaultCellStyle.Padding = new Padding(dgvRuleIndex.RowHeadersWidth);
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            string strSql = "";
            string strRule = "";
            string strTables = "";

            foreach (Control pnl in pnlRule.Controls)
            {
                foreach (Control ctrl in pnl.Controls)
                {
                    if ((ctrl.GetType() == typeof(TextBox) && ctrl.Text.Length > 0) ||
                        (ctrl.GetType() == typeof(ComboBox) && ctrl.Text.Length > 0))
                    {
                        //當規則一個以上的時候,自動補and
                        if (strRule.Length > 0)
                        {
                            strRule += " AND ";
                        }
                        string strValue = "";

                        if (ctrl.GetType() == typeof(ComboBox) && ctrl.Text.Contains('-'))
                        {
                            strValue = ctrl.Text.Remove(ctrl.Text.IndexOf('-'));
                        }
                        else
                        {
                            strValue = ctrl.Text;
                        }
                        strRule += string.Format(" {0}.{1} {2}'{3}' ", pnl.Name,ctrl.Name,dicRuleAndName[ctrl.Name], strValue);
                    }
                }
                if (strTables.Length > 0)
                {
                    strTables += " , ";
                }
                strTables += pnl.Name + " ";
            }
            if (strRule.Length == 0)
                strRule = "1=1";
            else
                foreach (string key in dicRuleIndex.Keys) strRule += string.Format(" AND {0} = {1}", key, dicRuleIndex[key]);
                
            //建立要撈的table 列表
            if (strTables.Length == 0) return;

            strSql = string.Format("Select distinct * from {0} Where {1}",strTables,strRule);

            listBox1.Items.Add(strSql);

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (dgvRuleIndex.Rows.Count == 0) return;

            //if (dicRuleIndex == null)
            //    dicRuleIndex = new Dictionary<string, string>();
            //else
            //    dicRuleIndex.Clear();

            //for (int i = 0; i < dgvRuleIndex.Rows.Count; i++)
            //{
            //    if ((bool)dgvRuleIndex.Rows[0].Cells["chk"].Value == true) 
            //        dicRuleIndex.Add(dgvRuleIndex.Rows[0].Cells[1].Value.ToString(), dgvRuleIndex.Rows[0].Cells[2].Value.ToString());
            //}
           
        }

        private void dgvRuleIndex_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvRuleIndex.Rows.Count == 0 || dgvRuleIndex.CurrentRow.Cells[2].Value == null) return;

            //if (dicRuleIndex.Keys.Contains<string>(dgvRuleIndex.CurrentRow.Cells[2].Value.ToString())) return;

            dicRuleIndex.Clear();

            for (int i = 0; i < dgvRuleIndex.Rows.Count; i++)
            {
                if ((bool)dgvRuleIndex.Rows[i].Cells["chk"].Value == true)
                {
                    if (dicRuleIndex.ContainsKey(dgvRuleIndex.Rows[i].Cells[1].Value.ToString())) return;

                    dicRuleIndex.Add(dgvRuleIndex.Rows[i].Cells[1].Value.ToString(), dgvRuleIndex.Rows[i].Cells[2].Value.ToString());
                }
            }
        }
    }
}
