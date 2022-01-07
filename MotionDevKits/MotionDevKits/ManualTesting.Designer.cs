namespace MotionKits
{
    partial class ManualTesting
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanelTop = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelright = new System.Windows.Forms.TableLayoutPanel();
            this.registerGridView = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanelleft = new System.Windows.Forms.TableLayoutPanel();
            this.num_p4 = new System.Windows.Forms.NumericUpDown();
            this.num_p3 = new System.Windows.Forms.NumericUpDown();
            this.num_p2 = new System.Windows.Forms.NumericUpDown();
            this.label_p4 = new System.Windows.Forms.Label();
            this.label_p3 = new System.Windows.Forms.Label();
            this.label_p2 = new System.Windows.Forms.Label();
            this.label_p1 = new System.Windows.Forms.Label();
            this.lable_routine = new System.Windows.Forms.Label();
            this.combo_routine = new System.Windows.Forms.ComboBox();
            this.stop_btn = new System.Windows.Forms.Button();
            this.reset_btn = new System.Windows.Forms.Button();
            this.start_btn = new System.Windows.Forms.Button();
            this.num_p1 = new System.Windows.Forms.NumericUpDown();
            this.startusBar = new System.Windows.Forms.StatusStrip();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.dataGridHist = new System.Windows.Forms.DataGridView();
            this.combo_infofilter = new System.Windows.Forms.ComboBox();
            this.cfgAddressLable = new System.Windows.Forms.ToolStripStatusLabel();
            this.tableLayoutPanelTop.SuspendLayout();
            this.tableLayoutPanelright.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.registerGridView)).BeginInit();
            this.tableLayoutPanelleft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_p4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_p3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_p2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_p1)).BeginInit();
            this.startusBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridHist)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanelTop
            // 
            this.tableLayoutPanelTop.ColumnCount = 2;
            this.tableLayoutPanelTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelTop.Controls.Add(this.tableLayoutPanelright, 1, 0);
            this.tableLayoutPanelTop.Controls.Add(this.tableLayoutPanelleft, 0, 0);
            this.tableLayoutPanelTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelTop.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelTop.Name = "tableLayoutPanelTop";
            this.tableLayoutPanelTop.RowCount = 1;
            this.tableLayoutPanelTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelTop.Size = new System.Drawing.Size(1019, 561);
            this.tableLayoutPanelTop.TabIndex = 0;
            // 
            // tableLayoutPanelright
            // 
            this.tableLayoutPanelright.ColumnCount = 1;
            this.tableLayoutPanelright.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelright.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelright.Controls.Add(this.registerGridView, 0, 1);
            this.tableLayoutPanelright.Controls.Add(this.combo_infofilter, 0, 0);
            this.tableLayoutPanelright.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelright.Location = new System.Drawing.Point(512, 3);
            this.tableLayoutPanelright.Name = "tableLayoutPanelright";
            this.tableLayoutPanelright.RowCount = 2;
            this.tableLayoutPanelright.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanelright.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelright.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelright.Size = new System.Drawing.Size(504, 555);
            this.tableLayoutPanelright.TabIndex = 0;
            // 
            // registerGridView
            // 
            this.registerGridView.AllowUserToAddRows = false;
            this.registerGridView.AllowUserToDeleteRows = false;
            this.registerGridView.AllowUserToResizeColumns = false;
            this.registerGridView.AllowUserToResizeRows = false;
            this.registerGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.registerGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.registerGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.registerGridView.Location = new System.Drawing.Point(3, 33);
            this.registerGridView.Name = "registerGridView";
            this.registerGridView.ReadOnly = true;
            this.registerGridView.RowHeadersVisible = false;
            this.registerGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.registerGridView.Size = new System.Drawing.Size(498, 519);
            this.registerGridView.TabIndex = 0;
            // 
            // tableLayoutPanelleft
            // 
            this.tableLayoutPanelleft.AutoSize = true;
            this.tableLayoutPanelleft.ColumnCount = 3;
            this.tableLayoutPanelleft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanelleft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanelleft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanelleft.Controls.Add(this.num_p4, 1, 4);
            this.tableLayoutPanelleft.Controls.Add(this.num_p3, 1, 3);
            this.tableLayoutPanelleft.Controls.Add(this.num_p2, 1, 2);
            this.tableLayoutPanelleft.Controls.Add(this.label_p4, 0, 4);
            this.tableLayoutPanelleft.Controls.Add(this.label_p3, 0, 3);
            this.tableLayoutPanelleft.Controls.Add(this.label_p2, 0, 2);
            this.tableLayoutPanelleft.Controls.Add(this.label_p1, 0, 1);
            this.tableLayoutPanelleft.Controls.Add(this.lable_routine, 0, 0);
            this.tableLayoutPanelleft.Controls.Add(this.combo_routine, 1, 0);
            this.tableLayoutPanelleft.Controls.Add(this.stop_btn, 0, 5);
            this.tableLayoutPanelleft.Controls.Add(this.reset_btn, 1, 5);
            this.tableLayoutPanelleft.Controls.Add(this.start_btn, 2, 5);
            this.tableLayoutPanelleft.Controls.Add(this.num_p1, 1, 1);
            this.tableLayoutPanelleft.Controls.Add(this.dataGridHist, 0, 6);
            this.tableLayoutPanelleft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelleft.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanelleft.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanelleft.Name = "tableLayoutPanelleft";
            this.tableLayoutPanelleft.RowCount = 8;
            this.tableLayoutPanelleft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanelleft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanelleft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanelleft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanelleft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanelleft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanelleft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 95F));
            this.tableLayoutPanelleft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelleft.Size = new System.Drawing.Size(503, 555);
            this.tableLayoutPanelleft.TabIndex = 1;
            // 
            // num_p4
            // 
            this.tableLayoutPanelleft.SetColumnSpan(this.num_p4, 2);
            this.num_p4.DecimalPlaces = 2;
            this.num_p4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.num_p4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_p4.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.num_p4.Location = new System.Drawing.Point(170, 123);
            this.num_p4.Maximum = new decimal(new int[] {
            50000,
            0,
            0,
            0});
            this.num_p4.Minimum = new decimal(new int[] {
            50000,
            0,
            0,
            -2147483648});
            this.num_p4.Name = "num_p4";
            this.num_p4.Size = new System.Drawing.Size(330, 22);
            this.num_p4.TabIndex = 12;
            // 
            // num_p3
            // 
            this.tableLayoutPanelleft.SetColumnSpan(this.num_p3, 2);
            this.num_p3.DecimalPlaces = 2;
            this.num_p3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.num_p3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_p3.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.num_p3.Location = new System.Drawing.Point(170, 93);
            this.num_p3.Maximum = new decimal(new int[] {
            50000,
            0,
            0,
            0});
            this.num_p3.Minimum = new decimal(new int[] {
            50000,
            0,
            0,
            -2147483648});
            this.num_p3.Name = "num_p3";
            this.num_p3.Size = new System.Drawing.Size(330, 22);
            this.num_p3.TabIndex = 11;
            // 
            // num_p2
            // 
            this.tableLayoutPanelleft.SetColumnSpan(this.num_p2, 2);
            this.num_p2.DecimalPlaces = 2;
            this.num_p2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.num_p2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_p2.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.num_p2.Location = new System.Drawing.Point(170, 63);
            this.num_p2.Maximum = new decimal(new int[] {
            50000,
            0,
            0,
            0});
            this.num_p2.Minimum = new decimal(new int[] {
            50000,
            0,
            0,
            -2147483648});
            this.num_p2.Name = "num_p2";
            this.num_p2.Size = new System.Drawing.Size(330, 22);
            this.num_p2.TabIndex = 10;
            // 
            // label_p4
            // 
            this.label_p4.AutoSize = true;
            this.label_p4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_p4.Location = new System.Drawing.Point(3, 120);
            this.label_p4.Name = "label_p4";
            this.label_p4.Size = new System.Drawing.Size(161, 30);
            this.label_p4.TabIndex = 5;
            this.label_p4.Text = "p4";
            this.label_p4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_p3
            // 
            this.label_p3.AutoSize = true;
            this.label_p3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_p3.Location = new System.Drawing.Point(3, 90);
            this.label_p3.Name = "label_p3";
            this.label_p3.Size = new System.Drawing.Size(161, 30);
            this.label_p3.TabIndex = 4;
            this.label_p3.Text = "p3";
            this.label_p3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_p2
            // 
            this.label_p2.AutoSize = true;
            this.label_p2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_p2.Location = new System.Drawing.Point(3, 60);
            this.label_p2.Name = "label_p2";
            this.label_p2.Size = new System.Drawing.Size(161, 30);
            this.label_p2.TabIndex = 3;
            this.label_p2.Text = "p2";
            this.label_p2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_p1
            // 
            this.label_p1.AutoSize = true;
            this.label_p1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_p1.Location = new System.Drawing.Point(3, 30);
            this.label_p1.Name = "label_p1";
            this.label_p1.Size = new System.Drawing.Size(161, 30);
            this.label_p1.TabIndex = 2;
            this.label_p1.Text = "p1";
            this.label_p1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lable_routine
            // 
            this.lable_routine.AutoSize = true;
            this.lable_routine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lable_routine.Location = new System.Drawing.Point(3, 0);
            this.lable_routine.Name = "lable_routine";
            this.lable_routine.Size = new System.Drawing.Size(161, 30);
            this.lable_routine.TabIndex = 0;
            this.lable_routine.Text = "Routine:";
            this.lable_routine.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // combo_routine
            // 
            this.tableLayoutPanelleft.SetColumnSpan(this.combo_routine, 2);
            this.combo_routine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.combo_routine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_routine.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combo_routine.FormattingEnabled = true;
            this.combo_routine.Location = new System.Drawing.Point(170, 3);
            this.combo_routine.Name = "combo_routine";
            this.combo_routine.Size = new System.Drawing.Size(330, 24);
            this.combo_routine.TabIndex = 1;
            this.combo_routine.SelectedIndexChanged += new System.EventHandler(this.combo_routine_SelectedIndexChanged);
            // 
            // stop_btn
            // 
            this.stop_btn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stop_btn.Location = new System.Drawing.Point(3, 153);
            this.stop_btn.Name = "stop_btn";
            this.stop_btn.Size = new System.Drawing.Size(161, 54);
            this.stop_btn.TabIndex = 6;
            this.stop_btn.Text = "Stop";
            this.stop_btn.UseVisualStyleBackColor = true;
            this.stop_btn.Click += new System.EventHandler(this.stop_btn_Click);
            // 
            // reset_btn
            // 
            this.reset_btn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reset_btn.Location = new System.Drawing.Point(170, 153);
            this.reset_btn.Name = "reset_btn";
            this.reset_btn.Size = new System.Drawing.Size(161, 54);
            this.reset_btn.TabIndex = 7;
            this.reset_btn.Text = "Clear Fault";
            this.reset_btn.UseVisualStyleBackColor = true;
            this.reset_btn.Click += new System.EventHandler(this.reset_btn_Click);
            // 
            // start_btn
            // 
            this.start_btn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.start_btn.Location = new System.Drawing.Point(337, 153);
            this.start_btn.Name = "start_btn";
            this.start_btn.Size = new System.Drawing.Size(163, 54);
            this.start_btn.TabIndex = 8;
            this.start_btn.Text = "Start";
            this.start_btn.UseVisualStyleBackColor = true;
            this.start_btn.Click += new System.EventHandler(this.start_btn_Click);
            // 
            // num_p1
            // 
            this.tableLayoutPanelleft.SetColumnSpan(this.num_p1, 2);
            this.num_p1.DecimalPlaces = 2;
            this.num_p1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.num_p1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_p1.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.num_p1.Location = new System.Drawing.Point(170, 33);
            this.num_p1.Maximum = new decimal(new int[] {
            50000,
            0,
            0,
            0});
            this.num_p1.Minimum = new decimal(new int[] {
            50000,
            0,
            0,
            -2147483648});
            this.num_p1.Name = "num_p1";
            this.num_p1.Size = new System.Drawing.Size(330, 22);
            this.num_p1.TabIndex = 9;
            // 
            // startusBar
            // 
            this.startusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cfgAddressLable});
            this.startusBar.Location = new System.Drawing.Point(0, 539);
            this.startusBar.Name = "startusBar";
            this.startusBar.Size = new System.Drawing.Size(1019, 22);
            this.startusBar.TabIndex = 1;
            this.startusBar.Text = "statusStrip1";
            // 
            // timer
            // 
            this.timer.Interval = 500;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // dataGridHist
            // 
            this.dataGridHist.AllowUserToAddRows = false;
            this.dataGridHist.AllowUserToDeleteRows = false;
            this.dataGridHist.AllowUserToResizeColumns = false;
            this.dataGridHist.AllowUserToResizeRows = false;
            this.dataGridHist.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridHist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableLayoutPanelleft.SetColumnSpan(this.dataGridHist, 3);
            this.dataGridHist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridHist.Location = new System.Drawing.Point(3, 213);
            this.dataGridHist.Name = "dataGridHist";
            this.dataGridHist.ReadOnly = true;
            this.dataGridHist.RowHeadersVisible = false;
            this.dataGridHist.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridHist.Size = new System.Drawing.Size(497, 89);
            this.dataGridHist.TabIndex = 13;
            // 
            // combo_infofilter
            // 
            this.combo_infofilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.combo_infofilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_infofilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combo_infofilter.FormattingEnabled = true;
            this.combo_infofilter.Location = new System.Drawing.Point(3, 3);
            this.combo_infofilter.Name = "combo_infofilter";
            this.combo_infofilter.Size = new System.Drawing.Size(498, 24);
            this.combo_infofilter.TabIndex = 1;
            this.combo_infofilter.SelectedIndexChanged += new System.EventHandler(this.combo_infofilter_SelectedIndexChanged);
            // 
            // cfgAddressLable
            // 
            this.cfgAddressLable.Name = "cfgAddressLable";
            this.cfgAddressLable.Size = new System.Drawing.Size(100, 17);
            this.cfgAddressLable.Text = "unknown address";
            // 
            // ManualTesting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1019, 561);
            this.Controls.Add(this.startusBar);
            this.Controls.Add(this.tableLayoutPanelTop);
            this.MinimumSize = new System.Drawing.Size(1000, 600);
            this.Name = "ManualTesting";
            this.Text = "Motion Control Manual Testing";
            this.Load += new System.EventHandler(this.ManualTesting_Load);
            this.tableLayoutPanelTop.ResumeLayout(false);
            this.tableLayoutPanelTop.PerformLayout();
            this.tableLayoutPanelright.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.registerGridView)).EndInit();
            this.tableLayoutPanelleft.ResumeLayout(false);
            this.tableLayoutPanelleft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_p4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_p3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_p2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_p1)).EndInit();
            this.startusBar.ResumeLayout(false);
            this.startusBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridHist)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelTop;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelright;
        private System.Windows.Forms.DataGridView registerGridView;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelleft;
        private System.Windows.Forms.Label lable_routine;
        private System.Windows.Forms.ComboBox combo_routine;
        private System.Windows.Forms.Label label_p4;
        private System.Windows.Forms.Label label_p3;
        private System.Windows.Forms.Label label_p2;
        private System.Windows.Forms.Label label_p1;
        private System.Windows.Forms.Button stop_btn;
        private System.Windows.Forms.Button reset_btn;
        private System.Windows.Forms.Button start_btn;
        private System.Windows.Forms.StatusStrip startusBar;
        private System.Windows.Forms.NumericUpDown num_p1;
        private System.Windows.Forms.NumericUpDown num_p4;
        private System.Windows.Forms.NumericUpDown num_p3;
        private System.Windows.Forms.NumericUpDown num_p2;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.DataGridView dataGridHist;
        private System.Windows.Forms.ComboBox combo_infofilter;
        private System.Windows.Forms.ToolStripStatusLabel cfgAddressLable;
    }
}
