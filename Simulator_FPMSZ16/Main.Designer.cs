namespace Simulator_FPMSZ16
{
    partial class Main
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.通道管理ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_AddChannel = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_AlarmZone = new System.Windows.Forms.ToolStripMenuItem();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.labelX_Time = new DevComponents.DotNetBar.LabelX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.Bt_Start = new DevComponents.DotNetBar.ButtonX();
            this.label_chanelNums = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.ipAddressInput = new DevComponents.Editors.IpAddressInput();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.tabControl = new DevComponents.DotNetBar.TabControl();
            this.tabControlPanel1 = new DevComponents.DotNetBar.TabControlPanel();
            this.tabItem1 = new DevComponents.DotNetBar.TabItem(this.components);
            this.DGV_EquipInfo = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.端口号 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.menuStrip1.SuspendLayout();
            this.groupPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ipAddressInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tabControlPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_EquipInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.通道管理ToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(695, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 通道管理ToolStripMenuItem1
            // 
            this.通道管理ToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_AddChannel,
            this.Menu_AlarmZone});
            this.通道管理ToolStripMenuItem1.Name = "通道管理ToolStripMenuItem1";
            this.通道管理ToolStripMenuItem1.Size = new System.Drawing.Size(68, 21);
            this.通道管理ToolStripMenuItem1.Text = "设备管理";
            // 
            // Menu_AddChannel
            // 
            this.Menu_AddChannel.Name = "Menu_AddChannel";
            this.Menu_AddChannel.Size = new System.Drawing.Size(124, 22);
            this.Menu_AddChannel.Text = "添加";
            this.Menu_AddChannel.Click += new System.EventHandler(this.Menu_AddChannel_Click);
            // 
            // Menu_AlarmZone
            // 
            this.Menu_AlarmZone.Name = "Menu_AlarmZone";
            this.Menu_AlarmZone.Size = new System.Drawing.Size(124, 22);
            this.Menu_AlarmZone.Text = "防区管理";
            this.Menu_AlarmZone.Click += new System.EventHandler(this.Menu_AlarmZone_Click);
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.labelX_Time);
            this.groupPanel1.Controls.Add(this.labelX6);
            this.groupPanel1.Controls.Add(this.Bt_Start);
            this.groupPanel1.Controls.Add(this.label_chanelNums);
            this.groupPanel1.Controls.Add(this.labelX3);
            this.groupPanel1.Controls.Add(this.labelX1);
            this.groupPanel1.Controls.Add(this.ipAddressInput);
            this.groupPanel1.Location = new System.Drawing.Point(0, 23);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(695, 38);
            // 
            // 
            // 
            this.groupPanel1.Style.BackColor = System.Drawing.Color.AliceBlue;
            this.groupPanel1.Style.BackColor2 = System.Drawing.Color.Snow;
            this.groupPanel1.Style.BackColorGradientAngle = 90;
            this.groupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderBottomWidth = 1;
            this.groupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderLeftWidth = 1;
            this.groupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderRightWidth = 1;
            this.groupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderTopWidth = 1;
            this.groupPanel1.Style.CornerDiameter = 4;
            this.groupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel1.TabIndex = 3;
            // 
            // labelX_Time
            // 
            this.labelX_Time.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX_Time.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX_Time.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX_Time.ForeColor = System.Drawing.Color.Black;
            this.labelX_Time.Location = new System.Drawing.Point(543, 5);
            this.labelX_Time.Name = "labelX_Time";
            this.labelX_Time.Size = new System.Drawing.Size(153, 23);
            this.labelX_Time.TabIndex = 9;
            this.labelX_Time.Text = "0";
            this.labelX_Time.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // labelX6
            // 
            this.labelX6.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.ForeColor = System.Drawing.Color.Black;
            this.labelX6.Location = new System.Drawing.Point(503, 6);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(44, 23);
            this.labelX6.TabIndex = 8;
            this.labelX6.Text = "时间：";
            this.labelX6.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // Bt_Start
            // 
            this.Bt_Start.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.Bt_Start.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.Bt_Start.Location = new System.Drawing.Point(256, 0);
            this.Bt_Start.Name = "Bt_Start";
            this.Bt_Start.Size = new System.Drawing.Size(93, 32);
            this.Bt_Start.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.Bt_Start.TabIndex = 7;
            this.Bt_Start.Text = "启 动";
            this.Bt_Start.Click += new System.EventHandler(this.Bt_Start_Click);
            // 
            // label_chanelNums
            // 
            this.label_chanelNums.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.label_chanelNums.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.label_chanelNums.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_chanelNums.ForeColor = System.Drawing.Color.Black;
            this.label_chanelNums.Location = new System.Drawing.Point(445, 6);
            this.label_chanelNums.Name = "label_chanelNums";
            this.label_chanelNums.Size = new System.Drawing.Size(28, 23);
            this.label_chanelNums.TabIndex = 5;
            this.label_chanelNums.Text = "0";
            this.label_chanelNums.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // labelX3
            // 
            this.labelX3.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.ForeColor = System.Drawing.Color.Black;
            this.labelX3.Location = new System.Drawing.Point(379, 6);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(71, 23);
            this.labelX3.TabIndex = 4;
            this.labelX3.Text = "设备个数：";
            this.labelX3.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // labelX1
            // 
            this.labelX1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.ForeColor = System.Drawing.Color.Black;
            this.labelX1.Location = new System.Drawing.Point(11, 5);
            this.labelX1.Name = "labelX1";
            this.labelX1.SingleLineColor = System.Drawing.Color.Transparent;
            this.labelX1.Size = new System.Drawing.Size(54, 23);
            this.labelX1.TabIndex = 1;
            this.labelX1.Text = "IP 地址";
            this.labelX1.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // ipAddressInput
            // 
            this.ipAddressInput.AllowEmptyState = false;
            this.ipAddressInput.AutoOverwrite = true;
            // 
            // 
            // 
            this.ipAddressInput.BackgroundStyle.Class = "DateTimeInputBackground";
            this.ipAddressInput.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ipAddressInput.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.ipAddressInput.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.ipAddressInput.Location = new System.Drawing.Point(66, 6);
            this.ipAddressInput.Name = "ipAddressInput";
            this.ipAddressInput.Size = new System.Drawing.Size(169, 21);
            this.ipAddressInput.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ipAddressInput.TabIndex = 0;
            this.ipAddressInput.WatermarkEnabled = false;
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // tabControl
            // 
            this.tabControl.CanReorderTabs = true;
            this.tabControl.ColorScheme.TabBackground = System.Drawing.Color.Transparent;
            this.tabControl.ColorScheme.TabBackground2 = System.Drawing.Color.Transparent;
            this.tabControl.ColorScheme.TabItemBackground = System.Drawing.Color.WhiteSmoke;
            this.tabControl.ColorScheme.TabItemBackground2 = System.Drawing.SystemColors.Control;
            this.tabControl.ColorScheme.TabItemBackgroundColorBlend.AddRange(new DevComponents.DotNetBar.BackgroundColorBlend[] {
            new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(230)))), ((int)(((byte)(249))))), 0F),
            new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(220)))), ((int)(((byte)(248))))), 0.45F),
            new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(208)))), ((int)(((byte)(245))))), 0.45F),
            new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(229)))), ((int)(((byte)(247))))), 1F)});
            this.tabControl.ColorScheme.TabItemBorder = System.Drawing.Color.LightCyan;
            this.tabControl.ColorScheme.TabItemBorderDark = System.Drawing.Color.Transparent;
            this.tabControl.ColorScheme.TabItemHotBackgroundColorBlend.AddRange(new DevComponents.DotNetBar.BackgroundColorBlend[] {
            new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(253)))), ((int)(((byte)(235))))), 0F),
            new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(236)))), ((int)(((byte)(168))))), 0.45F),
            new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(218)))), ((int)(((byte)(89))))), 0.45F),
            new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(141))))), 1F)});
            this.tabControl.ColorScheme.TabItemSelectedBackgroundColorBlend.AddRange(new DevComponents.DotNetBar.BackgroundColorBlend[] {
            new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.White, 0F),
            new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(254))))), 0.45F),
            new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(254))))), 0.45F),
            new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(254))))), 1F)});
            this.tabControl.ColorScheme.TabPanelBackground = System.Drawing.Color.Transparent;
            this.tabControl.ColorScheme.TabPanelBackground2 = System.Drawing.SystemColors.InactiveBorder;
            this.tabControl.ColorScheme.TabPanelBorder = System.Drawing.Color.Transparent;
            this.tabControl.Controls.Add(this.tabControlPanel1);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabControl.Location = new System.Drawing.Point(0, 64);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedTabFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.tabControl.SelectedTabIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(695, 324);
            this.tabControl.TabIndex = 4;
            this.tabControl.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            this.tabControl.Tabs.Add(this.tabItem1);
            this.tabControl.Text = "1";
            // 
            // tabControlPanel1
            // 
            this.tabControlPanel1.Controls.Add(this.DGV_EquipInfo);
            this.tabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel1.Location = new System.Drawing.Point(0, 26);
            this.tabControlPanel1.Name = "tabControlPanel1";
            this.tabControlPanel1.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel1.Size = new System.Drawing.Size(695, 298);
            this.tabControlPanel1.Style.BackColor1.Color = System.Drawing.Color.Transparent;
            this.tabControlPanel1.Style.BackColor2.Color = System.Drawing.SystemColors.InactiveBorder;
            this.tabControlPanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel1.Style.BorderColor.Color = System.Drawing.Color.Transparent;
            this.tabControlPanel1.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel1.Style.GradientAngle = 90;
            this.tabControlPanel1.TabIndex = 1;
            this.tabControlPanel1.TabItem = this.tabItem1;
            // 
            // tabItem1
            // 
            this.tabItem1.AttachedControl = this.tabControlPanel1;
            this.tabItem1.Name = "tabItem1";
            this.tabItem1.Text = "FPMS:1";
            // 
            // DGV_EquipInfo
            // 
            this.DGV_EquipInfo.AllowUserToAddRows = false;
            this.DGV_EquipInfo.AllowUserToResizeColumns = false;
            this.DGV_EquipInfo.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DGV_EquipInfo.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DGV_EquipInfo.BackgroundColor = System.Drawing.SystemColors.Control;
            this.DGV_EquipInfo.CausesValidation = false;
            this.DGV_EquipInfo.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_EquipInfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DGV_EquipInfo.ColumnHeadersHeight = 25;
            this.DGV_EquipInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGV_EquipInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.端口号,
            this.Column3,
            this.Column4,
            this.Column5});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV_EquipInfo.DefaultCellStyle = dataGridViewCellStyle4;
            this.DGV_EquipInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV_EquipInfo.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.DGV_EquipInfo.Location = new System.Drawing.Point(1, 1);
            this.DGV_EquipInfo.MultiSelect = false;
            this.DGV_EquipInfo.Name = "DGV_EquipInfo";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_EquipInfo.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.DGV_EquipInfo.RowHeadersWidth = 40;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DGV_EquipInfo.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.DGV_EquipInfo.RowTemplate.Height = 25;
            this.DGV_EquipInfo.Size = new System.Drawing.Size(693, 296);
            this.DGV_EquipInfo.TabIndex = 1;
            // 
            // Column1
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column1.HeaderText = "防区编号";
            this.Column1.Name = "Column1";
            this.Column1.Width = 120;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "触碰";
            this.Column2.Name = "Column2";
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column2.Width = 110;
            // 
            // 端口号
            // 
            this.端口号.HeaderText = "入侵";
            this.端口号.Name = "端口号";
            this.端口号.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.端口号.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.端口号.Width = 110;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "断裂";
            this.Column3.Name = "Column3";
            this.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column3.Width = 110;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "手动";
            this.Column4.Name = "Column4";
            this.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "自动";
            this.Column5.Name = "Column5";
            this.Column5.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 388);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.groupPanel1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Main";
            this.Text = "FPMS模拟器";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ipAddressInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tabControlPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_EquipInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 通道管理ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem Menu_AddChannel;
        private System.Windows.Forms.ToolStripMenuItem Menu_AlarmZone;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.LabelX labelX_Time;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.ButtonX Bt_Start;
        private DevComponents.DotNetBar.LabelX label_chanelNums;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.Editors.IpAddressInput ipAddressInput;
        private System.Windows.Forms.Timer timer;
        private DevComponents.DotNetBar.TabControl tabControl;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel1;
        private DevComponents.DotNetBar.TabItem tabItem1;
        private DevComponents.DotNetBar.Controls.DataGridViewX DGV_EquipInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewButtonColumn Column2;
        private System.Windows.Forms.DataGridViewButtonColumn 端口号;
        private System.Windows.Forms.DataGridViewButtonColumn Column3;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column4;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column5;
    }
}

