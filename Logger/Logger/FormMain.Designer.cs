namespace Logger
{
    partial class FormMain
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnclean = new System.Windows.Forms.Button();
            this.btnStopThread = new System.Windows.Forms.Button();
            this.btnStartThread = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_total = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button_unloadfilters = new System.Windows.Forms.Button();
            this.textBox_sort = new System.Windows.Forms.TextBox();
            this.textBox_filter = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.bindingSource_main = new System.Windows.Forms.BindingSource(this.components);
            this.advancedDataGridView_main = new Zuby.ADGV.AdvancedDataGridView();
            this.advancedDataGridViewSearchToolBar_main = new Zuby.ADGV.AdvancedDataGridViewSearchToolBar();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_main)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView_main)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnclean);
            this.panel1.Controls.Add(this.btnStopThread);
            this.panel1.Controls.Add(this.btnStartThread);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.textBox_total);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.button_unloadfilters);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1215, 162);
            this.panel1.TabIndex = 0;
            // 
            // btnclean
            // 
            this.btnclean.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnclean.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnclean.Location = new System.Drawing.Point(839, 14);
            this.btnclean.Name = "btnclean";
            this.btnclean.Size = new System.Drawing.Size(247, 43);
            this.btnclean.TabIndex = 19;
            this.btnclean.Text = "Очистить лог";
            this.btnclean.UseVisualStyleBackColor = true;
            this.btnclean.Click += new System.EventHandler(this.btnclean_Click);
            // 
            // btnStopThread
            // 
            this.btnStopThread.Enabled = false;
            this.btnStopThread.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnStopThread.Location = new System.Drawing.Point(141, 58);
            this.btnStopThread.Name = "btnStopThread";
            this.btnStopThread.Size = new System.Drawing.Size(247, 43);
            this.btnStopThread.TabIndex = 18;
            this.btnStopThread.Text = "Остановить логирование";
            this.btnStopThread.Click += new System.EventHandler(this.btnStopThread_Click);
            // 
            // btnStartThread
            // 
            this.btnStartThread.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnStartThread.Location = new System.Drawing.Point(141, 9);
            this.btnStartThread.Name = "btnStartThread";
            this.btnStartThread.Size = new System.Drawing.Size(247, 43);
            this.btnStartThread.TabIndex = 17;
            this.btnStartThread.Text = "Запустить логирование";
            this.btnStartThread.Click += new System.EventHandler(this.btnStartThread_Click);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(569, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 20);
            this.label5.TabIndex = 16;
            this.label5.Text = "Всего строк:";
            // 
            // textBox_total
            // 
            this.textBox_total.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textBox_total.Location = new System.Drawing.Point(573, 58);
            this.textBox_total.Name = "textBox_total";
            this.textBox_total.ReadOnly = true;
            this.textBox_total.Size = new System.Drawing.Size(100, 20);
            this.textBox_total.TabIndex = 15;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.advancedDataGridViewSearchToolBar_main);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 134);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1215, 28);
            this.panel3.TabIndex = 10;
            // 
            // button_unloadfilters
            // 
            this.button_unloadfilters.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_unloadfilters.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_unloadfilters.Location = new System.Drawing.Point(839, 65);
            this.button_unloadfilters.Name = "button_unloadfilters";
            this.button_unloadfilters.Size = new System.Drawing.Size(247, 43);
            this.button_unloadfilters.TabIndex = 9;
            this.button_unloadfilters.Text = "Сбросить фильтры";
            this.button_unloadfilters.UseVisualStyleBackColor = true;
            this.button_unloadfilters.Click += new System.EventHandler(this.button_unloadfilters_Click);
            // 
            // textBox_sort
            // 
            this.textBox_sort.Location = new System.Drawing.Point(712, 26);
            this.textBox_sort.Multiline = true;
            this.textBox_sort.Name = "textBox_sort";
            this.textBox_sort.ReadOnly = true;
            this.textBox_sort.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_sort.Size = new System.Drawing.Size(180, 80);
            this.textBox_sort.TabIndex = 14;
            this.textBox_sort.Visible = false;
            // 
            // textBox_filter
            // 
            this.textBox_filter.Location = new System.Drawing.Point(526, 26);
            this.textBox_filter.Multiline = true;
            this.textBox_filter.Name = "textBox_filter";
            this.textBox_filter.ReadOnly = true;
            this.textBox_filter.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_filter.Size = new System.Drawing.Size(180, 80);
            this.textBox_filter.TabIndex = 13;
            this.textBox_filter.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(709, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Sort string:";
            this.label4.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(523, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Filter string:";
            this.label3.Visible = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.advancedDataGridView_main);
            this.panel2.Controls.Add(this.textBox_sort);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.textBox_filter);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 162);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1215, 458);
            this.panel2.TabIndex = 1;
            // 
            // bindingSource_main
            // 
            this.bindingSource_main.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bindingSource_main_ListChanged);
            // 
            // advancedDataGridView_main
            // 
            this.advancedDataGridView_main.AllowUserToAddRows = false;
            this.advancedDataGridView_main.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.advancedDataGridView_main.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.advancedDataGridView_main.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.advancedDataGridView_main.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.advancedDataGridView_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.advancedDataGridView_main.FilterAndSortEnabled = true;
            this.advancedDataGridView_main.Location = new System.Drawing.Point(0, 0);
            this.advancedDataGridView_main.Name = "advancedDataGridView_main";
            this.advancedDataGridView_main.ReadOnly = true;
            this.advancedDataGridView_main.RowHeadersVisible = false;
            this.advancedDataGridView_main.Size = new System.Drawing.Size(1215, 458);
            this.advancedDataGridView_main.TabIndex = 0;
            this.advancedDataGridView_main.SortStringChanged += new System.EventHandler(this.advancedDataGridView_main_SortStringChanged);
            this.advancedDataGridView_main.FilterStringChanged += new System.EventHandler(this.advancedDataGridView_main_FilterStringChanged);
            // 
            // advancedDataGridViewSearchToolBar_main
            // 
            this.advancedDataGridViewSearchToolBar_main.AllowMerge = false;
            this.advancedDataGridViewSearchToolBar_main.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.advancedDataGridViewSearchToolBar_main.Location = new System.Drawing.Point(0, 0);
            this.advancedDataGridViewSearchToolBar_main.MaximumSize = new System.Drawing.Size(0, 27);
            this.advancedDataGridViewSearchToolBar_main.MinimumSize = new System.Drawing.Size(0, 27);
            this.advancedDataGridViewSearchToolBar_main.Name = "advancedDataGridViewSearchToolBar_main";
            this.advancedDataGridViewSearchToolBar_main.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.advancedDataGridViewSearchToolBar_main.Size = new System.Drawing.Size(1215, 27);
            this.advancedDataGridViewSearchToolBar_main.TabIndex = 0;
            this.advancedDataGridViewSearchToolBar_main.Text = "advancedDataGridViewSearchToolBar_main";
            this.advancedDataGridViewSearchToolBar_main.Search += new Zuby.ADGV.AdvancedDataGridViewSearchToolBarSearchEventHandler(this.advancedDataGridViewSearchToolBar_main_Search);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1215, 620);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MinimumSize = new System.Drawing.Size(1000, 500);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Логгер";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_main)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView_main)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.BindingSource bindingSource_main;
        private System.Windows.Forms.Button button_unloadfilters;
        private Zuby.ADGV.AdvancedDataGridView advancedDataGridView_main;
        private System.Windows.Forms.Panel panel3;
        private Zuby.ADGV.AdvancedDataGridViewSearchToolBar advancedDataGridViewSearchToolBar_main;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_total;
        private System.Windows.Forms.TextBox textBox_sort;
        private System.Windows.Forms.TextBox textBox_filter;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnclean;
        private System.Windows.Forms.Button btnStopThread;
        private System.Windows.Forms.Button btnStartThread;
    }
}

