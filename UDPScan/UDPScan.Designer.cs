namespace UDPScan
{
    partial class UDPScan
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbend = new System.Windows.Forms.TextBox();
            this.tbstart = new System.Windows.Forms.TextBox();
            this.tbipFrom = new System.Windows.Forms.TextBox();
            this.listViewRes = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonUdp = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonTcp = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 13;
            this.label2.Text = "PORT:  ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 12);
            this.label1.TabIndex = 12;
            this.label1.Text = "IP:";
            // 
            // tbend
            // 
            this.tbend.Location = new System.Drawing.Point(237, 61);
            this.tbend.Name = "tbend";
            this.tbend.Size = new System.Drawing.Size(49, 21);
            this.tbend.TabIndex = 11;
            this.tbend.Text = "8085";
            // 
            // tbstart
            // 
            this.tbstart.Location = new System.Drawing.Point(134, 60);
            this.tbstart.Name = "tbstart";
            this.tbstart.Size = new System.Drawing.Size(41, 21);
            this.tbstart.TabIndex = 10;
            this.tbstart.Text = "8080";
            // 
            // tbipFrom
            // 
            this.tbipFrom.Location = new System.Drawing.Point(83, 33);
            this.tbipFrom.Name = "tbipFrom";
            this.tbipFrom.Size = new System.Drawing.Size(92, 21);
            this.tbipFrom.TabIndex = 9;
            this.tbipFrom.Text = "222.198.38.78";
            // 
            // listViewRes
            // 
            this.listViewRes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader1,
            this.columnHeader2});
            this.listViewRes.FullRowSelect = true;
            this.listViewRes.GridLines = true;
            this.listViewRes.Location = new System.Drawing.Point(14, 20);
            this.listViewRes.Name = "listViewRes";
            this.listViewRes.Size = new System.Drawing.Size(343, 159);
            this.listViewRes.TabIndex = 6;
            this.listViewRes.UseCompatibleStateImageBehavior = false;
            this.listViewRes.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "序号";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 40;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "端口";
            this.columnHeader1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader1.Width = 150;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "状态";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 130;
            // 
            // buttonUdp
            // 
            this.buttonUdp.Location = new System.Drawing.Point(223, 304);
            this.buttonUdp.Name = "buttonUdp";
            this.buttonUdp.Size = new System.Drawing.Size(75, 23);
            this.buttonUdp.TabIndex = 16;
            this.buttonUdp.Text = "Udp Scan";
            this.buttonUdp.UseVisualStyleBackColor = true;
            this.buttonUdp.Click += new System.EventHandler(this.buttonUdpStart_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listViewRes);
            this.groupBox1.Location = new System.Drawing.Point(22, 87);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(377, 199);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Port Status";
            // 
            // buttonTcp
            // 
            this.buttonTcp.Location = new System.Drawing.Point(100, 304);
            this.buttonTcp.Name = "buttonTcp";
            this.buttonTcp.Size = new System.Drawing.Size(75, 23);
            this.buttonTcp.TabIndex = 0;
            this.buttonTcp.Text = "Tcp Scan";
            this.buttonTcp.UseVisualStyleBackColor = true;
            this.buttonTcp.Click += new System.EventHandler(this.buttonTcp_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(93, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 17;
            this.label3.Text = "From:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(208, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 12);
            this.label4.TabIndex = 18;
            this.label4.Text = "To:";
            // 
            // UDPScan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 354);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbend);
            this.Controls.Add(this.tbstart);
            this.Controls.Add(this.tbipFrom);
            this.Controls.Add(this.buttonUdp);
            this.Controls.Add(this.buttonTcp);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(437, 393);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(437, 393);
            this.Name = "UDPScan";
            this.Text = "Portscan";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UDPScan_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbend;
        private System.Windows.Forms.TextBox tbstart;
        private System.Windows.Forms.TextBox tbipFrom;
        private System.Windows.Forms.ListView listViewRes;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button buttonUdp;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonTcp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

