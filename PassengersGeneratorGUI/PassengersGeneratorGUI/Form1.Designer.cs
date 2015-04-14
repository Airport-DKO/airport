namespace PassengersGeneratorGUI
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
            this.categingComboBox = new DevExpress.XtraEditors.ComboBoxEdit();
            this.baggageTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.createSinglePassengerButton = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.simulationToggle = new DevExpress.XtraEditors.ToggleSwitch();
            this.simulateButton = new DevExpress.XtraEditors.SimpleButton();
            this.label3 = new System.Windows.Forms.Label();
            this.createMultiplePassengersButton = new DevExpress.XtraEditors.SimpleButton();
            this.countOfRandomTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.passengersGrid = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.resetButton = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.categingComboBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.baggageTextEdit.Properties)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.simulationToggle.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.countOfRandomTextEdit.Properties)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.passengersGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // categingComboBox
            // 
            this.categingComboBox.EditValue = "Еда";
            this.categingComboBox.Location = new System.Drawing.Point(62, 10);
            this.categingComboBox.Name = "categingComboBox";
            this.categingComboBox.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.categingComboBox.Size = new System.Drawing.Size(127, 20);
            this.categingComboBox.TabIndex = 0;
            // 
            // baggageTextEdit
            // 
            this.baggageTextEdit.Location = new System.Drawing.Point(271, 10);
            this.baggageTextEdit.Name = "baggageTextEdit";
            this.baggageTextEdit.Properties.Mask.EditMask = "[0-9]{1,3}";
            this.baggageTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.baggageTextEdit.Size = new System.Drawing.Size(100, 20);
            this.baggageTextEdit.TabIndex = 1;
            // 
            // createSinglePassengerButton
            // 
            this.createSinglePassengerButton.Location = new System.Drawing.Point(420, 8);
            this.createSinglePassengerButton.Name = "createSinglePassengerButton";
            this.createSinglePassengerButton.Size = new System.Drawing.Size(126, 23);
            this.createSinglePassengerButton.TabIndex = 2;
            this.createSinglePassengerButton.Text = "Создать пассажира";
            this.createSinglePassengerButton.Click += new System.EventHandler(this.createSinglePassengerButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Питание";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(226, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Багаж";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(579, 209);
            this.tabControl1.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.resetButton);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.simulationToggle);
            this.tabPage1.Controls.Add(this.simulateButton);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.createMultiplePassengersButton);
            this.tabPage1.Controls.Add(this.countOfRandomTextEdit);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.categingComboBox);
            this.tabPage1.Controls.Add(this.baggageTextEdit);
            this.tabPage1.Controls.Add(this.createSinglePassengerButton);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(571, 183);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Создание пассажиов";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(296, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(149, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Автоматическая симуляция";
            // 
            // simulationToggle
            // 
            this.simulationToggle.Location = new System.Drawing.Point(451, 121);
            this.simulationToggle.Name = "simulationToggle";
            this.simulationToggle.Properties.OffText = "Off";
            this.simulationToggle.Properties.OnText = "On";
            this.simulationToggle.Size = new System.Drawing.Size(95, 24);
            this.simulationToggle.TabIndex = 9;
            // 
            // simulateButton
            // 
            this.simulateButton.Location = new System.Drawing.Point(271, 83);
            this.simulateButton.Name = "simulateButton";
            this.simulateButton.Size = new System.Drawing.Size(275, 23);
            this.simulateButton.TabIndex = 8;
            this.simulateButton.Text = "Симуляция деятельности пассажиров";
            this.simulateButton.Click += new System.EventHandler(this.simulateButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(78, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(187, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Количество случайных пассажиров";
            // 
            // createMultiplePassengersButton
            // 
            this.createMultiplePassengersButton.Location = new System.Drawing.Point(420, 43);
            this.createMultiplePassengersButton.Name = "createMultiplePassengersButton";
            this.createMultiplePassengersButton.Size = new System.Drawing.Size(126, 23);
            this.createMultiplePassengersButton.TabIndex = 6;
            this.createMultiplePassengersButton.Text = "Создать пассажиров";
            this.createMultiplePassengersButton.Click += new System.EventHandler(this.createMultiplePassengersButton_Click);
            // 
            // countOfRandomTextEdit
            // 
            this.countOfRandomTextEdit.Location = new System.Drawing.Point(271, 45);
            this.countOfRandomTextEdit.Name = "countOfRandomTextEdit";
            this.countOfRandomTextEdit.Properties.Mask.EditMask = "[0-9]{1,3}";
            this.countOfRandomTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.countOfRandomTextEdit.Size = new System.Drawing.Size(100, 20);
            this.countOfRandomTextEdit.TabIndex = 5;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.passengersGrid);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(571, 183);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Список пассажиров";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // passengersGrid
            // 
            this.passengersGrid.Cursor = System.Windows.Forms.Cursors.Default;
            this.passengersGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.passengersGrid.Location = new System.Drawing.Point(3, 3);
            this.passengersGrid.MainView = this.gridView1;
            this.passengersGrid.Name = "passengersGrid";
            this.passengersGrid.Size = new System.Drawing.Size(565, 177);
            this.passengersGrid.TabIndex = 0;
            this.passengersGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.passengersGrid;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(9, 154);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(68, 23);
            this.resetButton.TabIndex = 11;
            this.resetButton.Text = "Reset";
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 209);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.Text = "Генератор пассажиров";
            ((System.ComponentModel.ISupportInitialize)(this.categingComboBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.baggageTextEdit.Properties)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.simulationToggle.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.countOfRandomTextEdit.Properties)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.passengersGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.ComboBoxEdit categingComboBox;
        private DevExpress.XtraEditors.TextEdit baggageTextEdit;
        private DevExpress.XtraEditors.SimpleButton createSinglePassengerButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.ToggleSwitch simulationToggle;
        private DevExpress.XtraEditors.SimpleButton simulateButton;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.SimpleButton createMultiplePassengersButton;
        private DevExpress.XtraEditors.TextEdit countOfRandomTextEdit;
        private System.Windows.Forms.TabPage tabPage2;
        private DevExpress.XtraGrid.GridControl passengersGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.SimpleButton resetButton;
    }
}

