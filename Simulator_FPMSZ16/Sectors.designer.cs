namespace Simulator_FPMSZ16
{
    partial class Sectors
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.cmb_ChooseChannel = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.DGV_ZoneInfos = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_ZoneInfos)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(5, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "选择通道:";
            // 
            // cmb_ChooseChannel
            // 
            this.cmb_ChooseChannel.DisplayMember = "Text";
            this.cmb_ChooseChannel.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmb_ChooseChannel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmb_ChooseChannel.FormattingEnabled = true;
            this.cmb_ChooseChannel.ItemHeight = 17;
            this.cmb_ChooseChannel.Location = new System.Drawing.Point(82, 12);
            this.cmb_ChooseChannel.Name = "cmb_ChooseChannel";
            this.cmb_ChooseChannel.Size = new System.Drawing.Size(194, 23);
            this.cmb_ChooseChannel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmb_ChooseChannel.TabIndex = 1;
            this.cmb_ChooseChannel.SelectedIndexChanged += new System.EventHandler(this.cmb_ChooseChannel_SelectedIndexChanged);
            // 
            // DGV_ZoneInfos
            // 
            this.DGV_ZoneInfos.AllowUserToAddRows = false;
            this.DGV_ZoneInfos.AllowUserToResizeColumns = false;
            this.DGV_ZoneInfos.AllowUserToResizeRows = false;
            this.DGV_ZoneInfos.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_ZoneInfos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DGV_ZoneInfos.ColumnHeadersHeight = 25;
            this.DGV_ZoneInfos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGV_ZoneInfos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column7,
            this.Column1,
            this.Column2,
            this.Column3});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV_ZoneInfos.DefaultCellStyle = dataGridViewCellStyle2;
            this.DGV_ZoneInfos.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.DGV_ZoneInfos.Location = new System.Drawing.Point(1, 40);
            this.DGV_ZoneInfos.Name = "DGV_ZoneInfos";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_ZoneInfos.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.DGV_ZoneInfos.RowHeadersVisible = false;
            this.DGV_ZoneInfos.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DGV_ZoneInfos.RowTemplate.Height = 25;
            this.DGV_ZoneInfos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DGV_ZoneInfos.Size = new System.Drawing.Size(363, 246);
            this.DGV_ZoneInfos.TabIndex = 2;
            this.DGV_ZoneInfos.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.DGV_ZoneInfos_RowPostPaint);
            // 
            // Column7
            // 
            this.Column7.HeaderText = "防区编号";
            this.Column7.Name = "Column7";
            this.Column7.Width = 90;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "触碰";
            this.Column1.Name = "Column1";
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column1.Width = 90;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "入侵";
            this.Column2.Name = "Column2";
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column2.Width = 90;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "断裂";
            this.Column3.Name = "Column3";
            this.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column3.Width = 90;
            // 
            // Sectors
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 291);
            this.Controls.Add(this.DGV_ZoneInfos);
            this.Controls.Add(this.cmb_ChooseChannel);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Sectors";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "报警分区";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AlarmZones_FormClosed);
            this.Load += new System.EventHandler(this.AlarmZones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_ZoneInfos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmb_ChooseChannel;
        private DevComponents.DotNetBar.Controls.DataGridViewX DGV_ZoneInfos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column3;
    }
}