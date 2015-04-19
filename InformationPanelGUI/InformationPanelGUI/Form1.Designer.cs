namespace InformationPanelGUI
{
    partial class Form1
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
            this.flightsGridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.cityComboBox = new DevExpress.XtraEditors.ComboBoxEdit();
            this.economTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.vipTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.createFlightButton = new DevExpress.XtraEditors.SimpleButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.arrivalDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.departureDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.resetButton = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.flightsGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cityComboBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.economTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vipTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.arrivalDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.arrivalDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.departureDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.departureDateEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // flightsGridControl
            // 
            this.flightsGridControl.Cursor = System.Windows.Forms.Cursors.Default;
            this.flightsGridControl.Location = new System.Drawing.Point(3, 42);
            this.flightsGridControl.MainView = this.gridView1;
            this.flightsGridControl.Name = "flightsGridControl";
            this.flightsGridControl.Size = new System.Drawing.Size(774, 181);
            this.flightsGridControl.TabIndex = 0;
            this.flightsGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn5,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4});
            this.gridView1.GridControl = this.flightsGridControl;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Город назначения";
            this.gridColumn5.FieldName = "city";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 0;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Время прилета";
            this.gridColumn1.DisplayFormat.FormatString = "dd.MM hh:mm";
            this.gridColumn1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn1.FieldName = "arrivalTime";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Время вылета";
            this.gridColumn2.DisplayFormat.FormatString = "dd.MM hh:mm";
            this.gridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn2.FieldName = "takeoffTime";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Начало регистрации";
            this.gridColumn3.DisplayFormat.FormatString = "dd.MM hh:mm";
            this.gridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn3.FieldName = "StartRegistrationTime";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 3;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Окончание регистрации";
            this.gridColumn4.DisplayFormat.FormatString = "dd.MM hh:mm";
            this.gridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn4.FieldName = "EndRegistrationTime";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(241, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(239, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Табло прилета/вылета";
            // 
            // cityComboBox
            // 
            this.cityComboBox.EditValue = "Город";
            this.cityComboBox.Location = new System.Drawing.Point(12, 229);
            this.cityComboBox.Name = "cityComboBox";
            this.cityComboBox.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cityComboBox.Size = new System.Drawing.Size(162, 20);
            this.cityComboBox.TabIndex = 4;
            // 
            // economTextEdit
            // 
            this.economTextEdit.Location = new System.Drawing.Point(483, 229);
            this.economTextEdit.Name = "economTextEdit";
            this.economTextEdit.Properties.Mask.EditMask = "[0-9]{1,4}";
            this.economTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.economTextEdit.Size = new System.Drawing.Size(75, 20);
            this.economTextEdit.TabIndex = 5;
            // 
            // vipTextEdit
            // 
            this.vipTextEdit.Location = new System.Drawing.Point(483, 255);
            this.vipTextEdit.Name = "vipTextEdit";
            this.vipTextEdit.Properties.Mask.EditMask = "[0-9]{1,4}";
            this.vipTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.vipTextEdit.Size = new System.Drawing.Size(75, 20);
            this.vipTextEdit.TabIndex = 6;
            // 
            // createFlightButton
            // 
            this.createFlightButton.Location = new System.Drawing.Point(622, 232);
            this.createFlightButton.Name = "createFlightButton";
            this.createFlightButton.Size = new System.Drawing.Size(124, 40);
            this.createFlightButton.TabIndex = 7;
            this.createFlightButton.Text = "Создать рейс";
            this.createFlightButton.Click += new System.EventHandler(this.createFlightButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(370, 232);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Эконом пассажиры";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(394, 258);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Vip пассажиры";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(196, 232);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Прилет";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(201, 258);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Вылет";
            // 
            // arrivalDateEdit
            // 
            this.arrivalDateEdit.EditValue = null;
            this.arrivalDateEdit.Location = new System.Drawing.Point(247, 230);
            this.arrivalDateEdit.Name = "arrivalDateEdit";
            this.arrivalDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.arrivalDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.arrivalDateEdit.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Vista;
            this.arrivalDateEdit.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.True;
            this.arrivalDateEdit.Size = new System.Drawing.Size(117, 20);
            this.arrivalDateEdit.TabIndex = 12;
            // 
            // departureDateEdit
            // 
            this.departureDateEdit.EditValue = null;
            this.departureDateEdit.Location = new System.Drawing.Point(246, 256);
            this.departureDateEdit.Name = "departureDateEdit";
            this.departureDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.departureDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.departureDateEdit.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Vista;
            this.departureDateEdit.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.True;
            this.departureDateEdit.Size = new System.Drawing.Size(117, 20);
            this.departureDateEdit.TabIndex = 13;
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(683, 9);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(85, 23);
            this.resetButton.TabIndex = 14;
            this.resetButton.Text = "Reset";
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 287);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.departureDateEdit);
            this.Controls.Add(this.arrivalDateEdit);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.createFlightButton);
            this.Controls.Add(this.vipTextEdit);
            this.Controls.Add(this.economTextEdit);
            this.Controls.Add(this.cityComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.flightsGridControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.Text = "Табло прилета-вылета";
            ((System.ComponentModel.ISupportInitialize)(this.flightsGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cityComboBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.economTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vipTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.arrivalDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.arrivalDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.departureDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.departureDateEdit.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl flightsGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.ComboBoxEdit cityComboBox;
        private DevExpress.XtraEditors.TextEdit economTextEdit;
        private DevExpress.XtraEditors.TextEdit vipTextEdit;
        private DevExpress.XtraEditors.SimpleButton createFlightButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraEditors.DateEdit arrivalDateEdit;
        private DevExpress.XtraEditors.DateEdit departureDateEdit;
        private DevExpress.XtraEditors.SimpleButton resetButton;
    }
}

