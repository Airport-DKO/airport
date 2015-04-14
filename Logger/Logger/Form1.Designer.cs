namespace Logger
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnclean = new System.Windows.Forms.Button();
            this.logGridView = new System.Windows.Forms.DataGridView();
            this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priority = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.component = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.content = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnStopThread = new System.Windows.Forms.Button();
            this.btnStartThread = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.logGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // btnclean
            // 
            this.btnclean.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnclean.Location = new System.Drawing.Point(694, 320);
            this.btnclean.Name = "btnclean";
            this.btnclean.Size = new System.Drawing.Size(260, 47);
            this.btnclean.TabIndex = 10;
            this.btnclean.Text = "Очистить лог";
            this.btnclean.UseVisualStyleBackColor = true;
            this.btnclean.Click += new System.EventHandler(this.btnclean_Click);
            // 
            // logGridView
            // 
            this.logGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.logGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.date,
            this.time,
            this.priority,
            this.component,
            this.content});
            this.logGridView.Location = new System.Drawing.Point(0, 0);
            this.logGridView.Name = "logGridView";
            this.logGridView.Size = new System.Drawing.Size(967, 309);
            this.logGridView.TabIndex = 9;
            // 
            // date
            // 
            this.date.HeaderText = "Дата";
            this.date.Name = "date";
            this.date.ReadOnly = true;
            this.date.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // time
            // 
            this.time.HeaderText = "Время";
            this.time.Name = "time";
            this.time.ReadOnly = true;
            this.time.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // priority
            // 
            this.priority.HeaderText = "Тип";
            this.priority.Name = "priority";
            this.priority.ReadOnly = true;
            this.priority.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // component
            // 
            this.component.HeaderText = "Компонента";
            this.component.Name = "component";
            this.component.ReadOnly = true;
            // 
            // content
            // 
            this.content.HeaderText = "Содержание";
            this.content.Name = "content";
            this.content.ReadOnly = true;
            this.content.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.content.Width = 500;
            // 
            // btnStopThread
            // 
            this.btnStopThread.Enabled = false;
            this.btnStopThread.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnStopThread.Location = new System.Drawing.Point(268, 320);
            this.btnStopThread.Name = "btnStopThread";
            this.btnStopThread.Size = new System.Drawing.Size(239, 47);
            this.btnStopThread.TabIndex = 8;
            this.btnStopThread.Text = "Остановить логирование";
            this.btnStopThread.Click += new System.EventHandler(this.btnStopThread_Click);
            // 
            // btnStartThread
            // 
            this.btnStartThread.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnStartThread.Location = new System.Drawing.Point(12, 320);
            this.btnStartThread.Name = "btnStartThread";
            this.btnStartThread.Size = new System.Drawing.Size(250, 47);
            this.btnStartThread.TabIndex = 7;
            this.btnStartThread.Text = "Запустить логирование";
            this.btnStartThread.Click += new System.EventHandler(this.btnStartThread_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(967, 394);
            this.Controls.Add(this.btnclean);
            this.Controls.Add(this.logGridView);
            this.Controls.Add(this.btnStopThread);
            this.Controls.Add(this.btnStartThread);
            this.Name = "Form1";
            this.Text = "Логгер";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.logGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnclean;
        private System.Windows.Forms.DataGridView logGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn date;
        private System.Windows.Forms.DataGridViewTextBoxColumn time;
        private System.Windows.Forms.DataGridViewTextBoxColumn priority;
        private System.Windows.Forms.DataGridViewTextBoxColumn component;
        private System.Windows.Forms.DataGridViewTextBoxColumn content;
        private System.Windows.Forms.Button btnStopThread;
        private System.Windows.Forms.Button btnStartThread;
    }
}

