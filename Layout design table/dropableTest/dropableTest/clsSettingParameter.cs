using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace dropableTest
{
    class clsSettingParameter:Form
    {
        private Label label1;
        private TextBox txtEQName;
        private Button btnGetDBinfo;
        private Button btnSave;

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtEQName = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnGetDBinfo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(10, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Equipment Name:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtEQName
            // 
            this.txtEQName.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtEQName.Location = new System.Drawing.Point(166, 27);
            this.txtEQName.Name = "txtEQName";
            this.txtEQName.Size = new System.Drawing.Size(163, 29);
            this.txtEQName.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(175, 76);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(155, 45);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnGetDBinfo
            // 
            this.btnGetDBinfo.Location = new System.Drawing.Point(12, 76);
            this.btnGetDBinfo.Name = "btnGetDBinfo";
            this.btnGetDBinfo.Size = new System.Drawing.Size(155, 45);
            this.btnGetDBinfo.TabIndex = 2;
            this.btnGetDBinfo.Text = "Get DB  Info";
            this.btnGetDBinfo.UseVisualStyleBackColor = true;
            // 
            // clsSettingParameter
            // 
            this.ClientSize = new System.Drawing.Size(354, 135);
            this.Controls.Add(this.btnGetDBinfo);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtEQName);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "clsSettingParameter";
            this.Text = " Setting Parameter";
            this.Load += new System.EventHandler(this.clsSettingParameter_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void clsSettingParameter_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
