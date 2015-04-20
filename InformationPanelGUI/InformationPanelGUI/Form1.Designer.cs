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
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.flightNameTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.label6 = new System.Windows.Forms.Label();
            this.timeLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.flightsGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cityComboBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.economTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vipTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.arrivalDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.arrivalDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.departureDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.departureDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.flightNameTextEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // flightsGridControl
            // 
            this.flightsGridControl.Cursor = System.Windows.Forms.Cursors.Default;
            this.flightsGridControl.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.flightsGridControl.Location = new System.Drawing.Point(4, 65);
            this.flightsGridControl.MainView = this.gridView1;
            this.flightsGridControl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.flightsGridControl.Name = "flightsGridControl";
            this.flightsGridControl.Size = new System.Drawing.Size(1161, 278);
            this.flightsGridControl.TabIndex = 0;
            this.flightsGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn6,
            this.gridColumn5,
            this.gridColumn7,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn8,
            this.gridColumn9});
            this.gridView1.GridControl = this.flightsGridControl;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Номер рейса";
            this.gridColumn6.FieldName = "FlightNumber";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 0;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Город назначения";
            this.gridColumn5.FieldName = "City";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 1;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Состояние";
            this.gridColumn7.FieldName = "Status";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 2;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Время прилета";
            this.gridColumn1.DisplayFormat.FormatString = "dd MMM HH:mm";
            this.gridColumn1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn1.FieldName = "ArriavalTime";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 3;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Время вылета";
            this.gridColumn2.DisplayFormat.FormatString = "dd MMM HH:mm";
            this.gridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn2.FieldName = "DepartureTime";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 4;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Начало регистрации";
            this.gridColumn3.DisplayFormat.FormatString = "dd MMM HH:mm";
            this.gridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn3.FieldName = "StartRegistration";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 5;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Окончание регистрации";
            this.gridColumn4.DisplayFormat.FormatString = "dd MMM HH:mm";
            this.gridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn4.FieldName = "EndRegistration";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 6;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Эконом класс";
            this.gridColumn8.FieldName = "PassengersStandart";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 7;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Бизнес Класс";
            this.gridColumn9.FieldName = "PassengersVip";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(362, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(342, 35);
            this.label1.TabIndex = 1;
            this.label1.Text = "Табло прилета/вылета";
            // 
            // cityComboBox
            // 
            this.cityComboBox.EditValue = "Город";
            this.cityComboBox.Location = new System.Drawing.Point(13, 391);
            this.cityComboBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cityComboBox.Name = "cityComboBox";
            this.cityComboBox.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cityComboBox.Size = new System.Drawing.Size(243, 26);
            this.cityComboBox.TabIndex = 4;
            // 
            // economTextEdit
            // 
            this.economTextEdit.Location = new System.Drawing.Point(724, 352);
            this.economTextEdit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.economTextEdit.Name = "economTextEdit";
            this.economTextEdit.Properties.Mask.EditMask = "[0-9]{1,4}";
            this.economTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.economTextEdit.Size = new System.Drawing.Size(112, 26);
            this.economTextEdit.TabIndex = 5;
            // 
            // vipTextEdit
            // 
            this.vipTextEdit.Location = new System.Drawing.Point(724, 392);
            this.vipTextEdit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.vipTextEdit.Name = "vipTextEdit";
            this.vipTextEdit.Properties.Mask.EditMask = "[0-9]{1,4}";
            this.vipTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.vipTextEdit.Size = new System.Drawing.Size(112, 26);
            this.vipTextEdit.TabIndex = 6;
            // 
            // createFlightButton
            // 
            this.createFlightButton.Location = new System.Drawing.Point(933, 357);
            this.createFlightButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.createFlightButton.Name = "createFlightButton";
            this.createFlightButton.Size = new System.Drawing.Size(186, 62);
            this.createFlightButton.TabIndex = 7;
            this.createFlightButton.Text = "Создать рейс";
            this.createFlightButton.Click += new System.EventHandler(this.createFlightButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(555, 357);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Эконом пассажиры";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(591, 397);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Vip пассажиры";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(294, 357);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "Прилет";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(302, 397);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "Вылет";
            // 
            // arrivalDateEdit
            // 
            this.arrivalDateEdit.EditValue = null;
            this.arrivalDateEdit.Location = new System.Drawing.Point(370, 354);
            this.arrivalDateEdit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.arrivalDateEdit.Name = "arrivalDateEdit";
            this.arrivalDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.arrivalDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.arrivalDateEdit.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Vista;
            this.arrivalDateEdit.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.True;
            this.arrivalDateEdit.Size = new System.Drawing.Size(176, 26);
            this.arrivalDateEdit.TabIndex = 12;
            // 
            // departureDateEdit
            // 
            this.departureDateEdit.EditValue = null;
            this.departureDateEdit.Location = new System.Drawing.Point(369, 394);
            this.departureDateEdit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.departureDateEdit.Name = "departureDateEdit";
            this.departureDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.departureDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.departureDateEdit.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Vista;
            this.departureDateEdit.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.True;
            this.departureDateEdit.Size = new System.Drawing.Size(176, 26);
            this.departureDateEdit.TabIndex = 13;
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(1024, 14);
            this.resetButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(128, 35);
            this.resetButton.TabIndex = 14;
            this.resetButton.Text = "Reset";
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // flightNameTextEdit
            // 
            this.flightNameTextEdit.Location = new System.Drawing.Point(128, 351);
            this.flightNameTextEdit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.flightNameTextEdit.Name = "flightNameTextEdit";
            this.flightNameTextEdit.Size = new System.Drawing.Size(128, 26);
            this.flightNameTextEdit.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 355);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 20);
            this.label6.TabIndex = 16;
            this.label6.Text = "Номер рейса";
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.Location = new System.Drawing.Point(9, 22);
            this.timeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(62, 20);
            this.timeLabel.TabIndex = 17;
            this.timeLabel.Text = "Время:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1170, 442);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.flightNameTextEdit);
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
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
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
            ((System.ComponentModel.ISupportInitialize)(this.flightNameTextEdit.Properties)).EndInit();
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
        private DevExpress.XtraEditors.TextEdit flightNameTextEdit;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private System.Windows.Forms.Label timeLabel;
    }
}

