using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Data.SqlClient;
using System.Data.OleDb;
using Microsoft.ApplicationBlocks.Data;

namespace ModelCreator
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class ModelCreator : System.Windows.Forms.Form
	{
		private string SQL_CONN_STRING = string.Empty;
		private System.Windows.Forms.TextBox textBoxServer;
		private System.Windows.Forms.TextBox textBoxUserName;
		private System.Windows.Forms.TextBox textBoxPassword;
		private System.Windows.Forms.Button lbtnConnect;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ProgressBar progressBarMain;
		private System.Windows.Forms.TextBox textBoxDbName;
		private System.Windows.Forms.Label label4;
        private Label label5;
        private ComboBox cboDBMS;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ModelCreator()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.textBoxServer = new System.Windows.Forms.TextBox();
            this.textBoxUserName = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.lbtnConnect = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.progressBarMain = new System.Windows.Forms.ProgressBar();
            this.textBoxDbName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cboDBMS = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // textBoxServer
            // 
            this.textBoxServer.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBoxServer.Location = new System.Drawing.Point(153, 50);
            this.textBoxServer.Name = "textBoxServer";
            this.textBoxServer.Size = new System.Drawing.Size(287, 29);
            this.textBoxServer.TabIndex = 0;
            this.textBoxServer.Text = "PRD-01";
            // 
            // textBoxUserName
            // 
            this.textBoxUserName.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBoxUserName.Location = new System.Drawing.Point(153, 126);
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.Size = new System.Drawing.Size(287, 29);
            this.textBoxUserName.TabIndex = 1;
            this.textBoxUserName.Text = "sa";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBoxPassword.Location = new System.Drawing.Point(153, 164);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(287, 29);
            this.textBoxPassword.TabIndex = 2;
            this.textBoxPassword.Text = "d7972";
            // 
            // lbtnConnect
            // 
            this.lbtnConnect.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbtnConnect.Location = new System.Drawing.Point(256, 236);
            this.lbtnConnect.Name = "lbtnConnect";
            this.lbtnConnect.Size = new System.Drawing.Size(184, 41);
            this.lbtnConnect.TabIndex = 3;
            this.lbtnConnect.Text = "Connect and Create";
            this.lbtnConnect.Click += new System.EventHandler(this.lbtnConnect_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(8, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 35);
            this.label1.TabIndex = 4;
            this.label1.Text = "Server IP";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(8, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 35);
            this.label2.TabIndex = 5;
            this.label2.Text = "User Name";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Black;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(8, 161);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 35);
            this.label3.TabIndex = 6;
            this.label3.Text = "Password";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // progressBarMain
            // 
            this.progressBarMain.Location = new System.Drawing.Point(5, 208);
            this.progressBarMain.Name = "progressBarMain";
            this.progressBarMain.Size = new System.Drawing.Size(435, 18);
            this.progressBarMain.Step = 100;
            this.progressBarMain.TabIndex = 7;
            this.progressBarMain.Click += new System.EventHandler(this.progressBarMain_Click);
            // 
            // textBoxDbName
            // 
            this.textBoxDbName.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBoxDbName.Location = new System.Drawing.Point(153, 88);
            this.textBoxDbName.Name = "textBoxDbName";
            this.textBoxDbName.Size = new System.Drawing.Size(287, 29);
            this.textBoxDbName.TabIndex = 8;
            this.textBoxDbName.Text = "ManGoDB";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Black;
            this.label4.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(8, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 35);
            this.label4.TabIndex = 9;
            this.label4.Text = "Database Name";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Black;
            this.label5.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(8, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(140, 35);
            this.label5.TabIndex = 4;
            this.label5.Text = "DBMS";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboDBMS
            // 
            this.cboDBMS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDBMS.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cboDBMS.FormattingEnabled = true;
            this.cboDBMS.Items.AddRange(new object[] {
            "MSSQL",
            "ORACLE"});
            this.cboDBMS.Location = new System.Drawing.Point(153, 12);
            this.cboDBMS.Name = "cboDBMS";
            this.cboDBMS.Size = new System.Drawing.Size(121, 29);
            this.cboDBMS.TabIndex = 10;
            this.cboDBMS.SelectedIndexChanged += new System.EventHandler(this.cboDBMS_SelectedIndexChanged);
            // 
            // ModelCreator
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 15);
            this.ClientSize = new System.Drawing.Size(452, 289);
            this.Controls.Add(this.cboDBMS);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxDbName);
            this.Controls.Add(this.progressBarMain);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbtnConnect);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.textBoxUserName);
            this.Controls.Add(this.textBoxServer);
            this.Name = "ModelCreator";
            this.Text = "Model Creator v1.0 Modified By Thor Lin";
            this.Load += new System.EventHandler(this.ModelCreator_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		[STAThread]
		static void Main() 
		{
			Application.Run(new ModelCreator());
		}

		private void lbtnConnect_Click(object sender, System.EventArgs e)
		{
			if (CreateConnectionString())
				CreateModelClassFiles(tcGetDataReader());
		}

		private bool CreateConnectionString()
		{
		    try	
			{
				System.Text.StringBuilder sb = new System.Text.StringBuilder();
                if (cboDBMS.Text == "ORACLE")
                {
                    sb.AppendFormat("Provider=MSDAORA;Data Source={0};User ID={1};Password={2};", new object[] { this.textBoxServer.Text, this.textBoxUserName.Text, this.textBoxPassword.Text });
                }
                else
                {
                    sb.AppendFormat("Provider=SQLOLEDB;Server={0};Database={1};Uid={2};Pwd={3};", new object[] { this.textBoxServer.Text, this.textBoxDbName.Text, this.textBoxUserName.Text, this.textBoxPassword.Text });
                }

                SQL_CONN_STRING = sb.ToString();
				return true;
			}
			catch (System.Exception e)
			{
				MessageBox.Show(e.Message);
				return false;
			}
		}

        //這邊是參考使用原作者的寫法
        private void CreateModelClassFiles(OleDbDataReader dr)
		{
            try
            {
                if (dr != null)
                {
                    string lstrOldTableName = string.Empty;
                    StreamWriter sw = null;
                    System.Text.StringBuilder sb = null;
                    System.Text.StringBuilder sbAttr = null;
                    while (dr.Read())
                    {
                        string lstrTableName = dr.GetString(0);
                        string lstrAttributeName = dr.GetString(1);
                        string lstrAttributeType = GetSystemType(dr.GetString(2));
                        if (lstrOldTableName != lstrTableName)
                        {
                            if (sw != null)
                            {
                                this.CreateClassBottom(sw, sb.ToString().TrimEnd(new char[] { ',', ' ', '\r', '\t', '\n' }), sbAttr.ToString());
                                sw.Close();
                            }
                            sb = new System.Text.StringBuilder(lstrTableName);
                            sb.Append(".cs");
                            FileInfo lobjFileInfo = new FileInfo(sb.ToString());
                            sw = lobjFileInfo.CreateText();
                            this.CreateClassTop(sw, lstrTableName);
                            sb = new System.Text.StringBuilder("\r\n\t/// <summary>\r\n\t/// User defined Contructor\r\n\t/// <summary>\r\n\tpublic ");
                            sbAttr = new System.Text.StringBuilder();
                            sb.Append(lstrTableName);
                            sb.Append("(");

                            //第一次建立表,但是第一欄的資訊還是要印 fix  by Thor lin
                            this.CreateClassBody(sw, lstrAttributeType, lstrAttributeName);
                            sb.AppendFormat("{0} {1}, \r\n\t\t", new object[] { lstrAttributeType, lstrAttributeName });
                            sbAttr.AppendFormat("\r\n\t\tthis._{0} = {0};", new object[] { lstrAttributeName });
                        }
                        else
                        {
                            this.CreateClassBody(sw, lstrAttributeType, lstrAttributeName);
                            sb.AppendFormat("{0} {1}, \r\n\t\t", new object[] { lstrAttributeType, lstrAttributeName });
                            sbAttr.AppendFormat("\r\n\t\tthis._{0} = {0};", new object[] { lstrAttributeName });
                        }
                        lstrOldTableName = lstrTableName;
                        this.progressBarMain.Increment(1);
                    }
                    MessageBox.Show("Done !!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
		}


        public OleDbDataReader tcGetDataReader()
		{
			OleDbConnection conn = new System.Data.OleDb.OleDbConnection();

			try
			{
				conn.ConnectionString = SQL_CONN_STRING;
				conn.Open();


                string strGetData = "";

                if (cboDBMS.Text == "ORACLE")
                {
                    strGetData = string.Format(@"select TABLE_NAME,COLUMN_NAME,DATA_TYPE from all_tab_columns Where owner ='{0}' and substr(TABLE_NAME,1,4) <> 'BIN$'", textBoxUserName.Text);
                }
                else
                {
                    strGetData = @"select table_name, column_name, data_type
                                    from information_schema.columns
                                    where table_name in
                                    (
                                    select table_name
                                    from Information_Schema.Tables
                                    where Table_Type='Base Table'
                                    ) order by table_name";
                }

                OleDbCommand cmd = new System.Data.OleDb.OleDbCommand(strGetData, conn);
				if (conn == null)
					return null;

                OleDbDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
					return dr;
				else
					return null;
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
				return null;
			}
		}

		/// <summary>
		/// Create the body of each Model Class
		/// </summary>
		/// <param name="sw">Stream Writer of the current file</param>
		/// <param name="tstrAttributeType">Property Item Data Type</param>
		/// <param name="tstrAttributeName">Property Item Name</param>
		private void CreateClassBody(StreamWriter sw, string tstrAttributeType, string tstrAttributeName)
		{
			System.Text.StringBuilder sb = new System.Text.StringBuilder("\r\n");
			sb.AppendFormat("\r\n\tpublic {0} {1}\r\n\t{2} \r\n\t\tget {2} return _{1}; {3}\r\n\t\tset {2} _{1} = value; {3}\r\n\t{3}\r\n\tprivate {0} _{1};", new object[]{tstrAttributeType, tstrAttributeName, "{", "}"}); 
			sw.WriteLine(sb.ToString());
		}

		/// <summary>
		/// Create the Top part of the current file
		/// </summary>
		/// <param name="sw">Stream Writer of the current file</param>
		/// <param name="tstrClassName">Name of the Current Class</param>
		private void CreateClassTop(StreamWriter sw, string tstrClassName)
		{
			System.Text.StringBuilder sb = new System.Text.StringBuilder("public class ");
			sb.Append(tstrClassName);
			sb.Append("\r\n{\r\n\t/// <summary>\r\n\t/// Default Contructor\r\n\t/// <summary>\r\n\tpublic ");
			sb.Append(tstrClassName);
			sb.Append("()\r\n\t{}");
			sw.WriteLine(sb.ToString());
		}

		/// <summary>
		/// Create the Bottom part of the current file
		/// </summary>
		/// <param name="sw">Stream Writer of the current file</param>
		/// <param name="tstrAttrbuteList">List of variables to be used with the user defined contructor</param>
		private void CreateClassBottom(StreamWriter sw, string tstrAttrbuteList, string tstrVariableList)
		{
			sw.WriteLine(tstrAttrbuteList + ")\r\n\t{" + tstrVariableList + "\r\n\t}");
			sw.WriteLine("}");
		}

		/// <summary>
		/// Create data base conection
		/// </summary>
		/// <param name="connectionString"></param>
		/// <returns></returns>
		private SqlConnection GetConnection(string connectionString)
		{
			try
			{
				SqlConnection dbconnection = new SqlConnection(connectionString);
				dbconnection.Open();
				return dbconnection;
			}
			catch
			{
				return null;
			}			
		}

		/// <summary>
		/// Get the System Type of the SQL ariable type
		/// </summary>
		private string GetSystemType(string tstrSqlType)
		{
			string _Type = string.Empty;

			switch (tstrSqlType) 
			{
				case "biginit":
				{
					_Type = "long";
				}break;
				case "smallint":
				{
					_Type = "short";
				}break;
				case "tinyint":
				{
					_Type = "byte";
				}break;
				case "int":
				{
					_Type = "int";
				}break;
				case "bit":
				{
					_Type = "bool";
				}break;
				case "decimal":
				case "numeric":
                case "NUMBER":
				{ 
					_Type = "decimal";
				}break;
				case "money":
				case "smallmoney":
				{
					_Type = "decimal";
				}break;
				case "float":
				case "real":
				{
					_Type = "float";
				}break;
				case "datetime":
				case "smalldatetime":
				{
					_Type = "System.DateTime";
				}break;
				case "char":
				{
					_Type = "char";
				}break;
				case "sql_variant":
				{
					_Type = "object";
				}break;
				case "varchar":
				case "text":
				case "nchar" :
				case "nvarchar" :
				case "ntext":
                case "VARCHAR2":
				{
					_Type = "string";
				}break;
				case "binary":
				case "varbinary":
				{
					_Type = "byte[]";
				}break;
				case "image":
				{
					_Type = "System.Drawing.Image";
				}break;
				case "timestamp":
				case "uniqueidentifier":
				{
					_Type = "string";
				}break;
				default:
				{
					_Type = "unknown";
				}break;
			}
			return _Type;
		}

        private void ModelCreator_Load(object sender, EventArgs e)
        {

        }

        private void progressBarMain_Click(object sender, EventArgs e)
        {

        }

        private void cboDBMS_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
	}
}
