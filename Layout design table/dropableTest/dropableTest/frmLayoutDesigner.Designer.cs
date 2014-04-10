namespace dropableTest
{
    partial class frmDesignLayout
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.plMain = new System.Windows.Forms.Panel();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.plEdit = new System.Windows.Forms.Panel();
            this.pbLayout = new System.Windows.Forms.PictureBox();
            this.eq2 = new dropableTest.EQ();
            this.eq1 = new dropableTest.EQ();
            this.plMain.SuspendLayout();
            this.plEdit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLayout)).BeginInit();
            this.SuspendLayout();
            // 
            // plMain
            // 
            this.plMain.AllowDrop = true;
            this.plMain.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.plMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.plMain.Controls.Add(this.btnLoad);
            this.plMain.Controls.Add(this.btnSave);
            this.plMain.Controls.Add(this.eq2);
            this.plMain.Controls.Add(this.eq1);
            this.plMain.Controls.Add(this.plEdit);
            this.plMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plMain.Location = new System.Drawing.Point(0, 0);
            this.plMain.Name = "plMain";
            this.plMain.Size = new System.Drawing.Size(1089, 597);
            this.plMain.TabIndex = 0;
            // 
            // btnLoad
            // 
            this.btnLoad.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnLoad.Location = new System.Drawing.Point(11, 498);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(158, 44);
            this.btnLoad.TabIndex = 4;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnSave.Location = new System.Drawing.Point(11, 548);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(158, 44);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // plEdit
            // 
            this.plEdit.AllowDrop = true;
            this.plEdit.AutoScroll = true;
            this.plEdit.BackColor = System.Drawing.Color.Honeydew;
            this.plEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.plEdit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.plEdit.Controls.Add(this.pbLayout);
            this.plEdit.Location = new System.Drawing.Point(175, 3);
            this.plEdit.Name = "plEdit";
            this.plEdit.Size = new System.Drawing.Size(913, 593);
            this.plEdit.TabIndex = 2;
            // 
            // pbLayout
            // 
            this.pbLayout.Location = new System.Drawing.Point(-1, -1);
            this.pbLayout.Name = "pbLayout";
            this.pbLayout.Size = new System.Drawing.Size(1024, 768);
            this.pbLayout.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbLayout.TabIndex = 0;
            this.pbLayout.TabStop = false;
            // 
            // eq2
            // 
            this.eq2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.eq2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.eq2.Location = new System.Drawing.Point(11, 177);
            this.eq2.Name = "eq2";
            this.eq2.Size = new System.Drawing.Size(148, 148);
            this.eq2.TabIndex = 3;
            // 
            // eq1
            // 
            this.eq1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.eq1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.eq1.Location = new System.Drawing.Point(11, 11);
            this.eq1.Name = "eq1";
            this.eq1.Size = new System.Drawing.Size(148, 148);
            this.eq1.TabIndex = 3;
            // 
            // frmDesignLayout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1089, 597);
            this.Controls.Add(this.plMain);
            this.Name = "frmDesignLayout";
            this.Text = "LayoutDesigner";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.plMain.ResumeLayout(false);
            this.plEdit.ResumeLayout(false);
            this.plEdit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLayout)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel plMain;
        private EQ eq1;
        private EQ eq2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Panel plEdit;
        private System.Windows.Forms.PictureBox pbLayout;
    }
}

