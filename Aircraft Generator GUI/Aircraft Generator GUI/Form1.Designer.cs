namespace Aircraft_Generator_GUI
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
            this.planesGridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.nameTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.fuelNeedTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.maxStdPsnTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.maxVipPsnTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.typeListBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.createPlaneButton = new DevExpress.XtraEditors.SimpleButton();
            this.refreshButton = new DevExpress.XtraEditors.SimpleButton();
            this.label6 = new System.Windows.Forms.Label();
            this.baggageTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.bindPlaneToFlightButton = new DevExpress.XtraEditors.SimpleButton();
            this.resetButton = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.planesGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nameTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fuelNeedTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxStdPsnTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxVipPsnTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.baggageTextEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // planesGridControl
            // 
            this.planesGridControl.Cursor = System.Windows.Forms.Cursors.Default;
            this.planesGridControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.planesGridControl.Location = new System.Drawing.Point(0, 0);
            this.planesGridControl.MainView = this.gridView1;
            this.planesGridControl.Name = "planesGridControl";
            this.planesGridControl.Size = new System.Drawing.Size(890, 298);
            this.planesGridControl.TabIndex = 0;
            this.planesGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.planesGridControl;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsDetail.AllowOnlyOneMasterRowExpanded = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // nameTextEdit
            // 
            this.nameTextEdit.Location = new System.Drawing.Point(164, 321);
            this.nameTextEdit.Name = "nameTextEdit";
            this.nameTextEdit.Size = new System.Drawing.Size(232, 26);
            this.nameTextEdit.TabIndex = 1;
            // 
            // fuelNeedTextEdit
            // 
            this.fuelNeedTextEdit.Location = new System.Drawing.Point(611, 319);
            this.fuelNeedTextEdit.Name = "fuelNeedTextEdit";
            this.fuelNeedTextEdit.Properties.Mask.EditMask = "[0-9]{1,3}";
            this.fuelNeedTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.fuelNeedTextEdit.Size = new System.Drawing.Size(232, 26);
            this.fuelNeedTextEdit.TabIndex = 2;
            // 
            // maxStdPsnTextEdit
            // 
            this.maxStdPsnTextEdit.Location = new System.Drawing.Point(611, 351);
            this.maxStdPsnTextEdit.Name = "maxStdPsnTextEdit";
            this.maxStdPsnTextEdit.Properties.Mask.EditMask = "[0-9]{1,3}";
            this.maxStdPsnTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.maxStdPsnTextEdit.Size = new System.Drawing.Size(232, 26);
            this.maxStdPsnTextEdit.TabIndex = 3;
            // 
            // maxVipPsnTextEdit
            // 
            this.maxVipPsnTextEdit.Location = new System.Drawing.Point(611, 383);
            this.maxVipPsnTextEdit.Name = "maxVipPsnTextEdit";
            this.maxVipPsnTextEdit.Properties.Mask.EditMask = "[0-9]{1,3}";
            this.maxVipPsnTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.maxVipPsnTextEdit.Size = new System.Drawing.Size(232, 26);
            this.maxVipPsnTextEdit.TabIndex = 4;
            // 
            // typeListBox
            // 
            this.typeListBox.FormattingEnabled = true;
            this.typeListBox.ItemHeight = 20;
            this.typeListBox.Location = new System.Drawing.Point(164, 354);
            this.typeListBox.Name = "typeListBox";
            this.typeListBox.Size = new System.Drawing.Size(232, 44);
            this.typeListBox.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 324);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Название";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 357);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Тип";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(532, 327);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Топливо";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(423, 357);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(182, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "Кол-во эконом пас-ров";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(412, 386);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(193, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "Количество вип пас-ров";
            // 
            // createPlaneButton
            // 
            this.createPlaneButton.Location = new System.Drawing.Point(17, 454);
            this.createPlaneButton.Name = "createPlaneButton";
            this.createPlaneButton.Size = new System.Drawing.Size(282, 48);
            this.createPlaneButton.TabIndex = 12;
            this.createPlaneButton.Text = "Создать самолет";
            this.createPlaneButton.Click += new System.EventHandler(this.createPlaneButton_Click);
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(596, 454);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(282, 48);
            this.refreshButton.TabIndex = 13;
            this.refreshButton.Text = "Обновить";
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(447, 418);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(158, 20);
            this.label6.TabIndex = 15;
            this.label6.Text = "Количество багажа";
            // 
            // baggageTextEdit
            // 
            this.baggageTextEdit.Location = new System.Drawing.Point(611, 415);
            this.baggageTextEdit.Name = "baggageTextEdit";
            this.baggageTextEdit.Properties.Mask.EditMask = "[0-9]{1,3}";
            this.baggageTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.baggageTextEdit.Size = new System.Drawing.Size(232, 26);
            this.baggageTextEdit.TabIndex = 14;
            // 
            // bindPlaneToFlightButton
            // 
            this.bindPlaneToFlightButton.Location = new System.Drawing.Point(306, 454);
            this.bindPlaneToFlightButton.Name = "bindPlaneToFlightButton";
            this.bindPlaneToFlightButton.Size = new System.Drawing.Size(282, 48);
            this.bindPlaneToFlightButton.TabIndex = 16;
            this.bindPlaneToFlightButton.Text = "Привязать самолет к рейсу";
            this.bindPlaneToFlightButton.Click += new System.EventHandler(this.bindPlaneToFlightButton_Click);
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(17, 414);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(118, 27);
            this.resetButton.TabIndex = 17;
            this.resetButton.Text = "Reset";
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 514);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.bindPlaneToFlightButton);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.baggageTextEdit);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.createPlaneButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.typeListBox);
            this.Controls.Add(this.maxVipPsnTextEdit);
            this.Controls.Add(this.maxStdPsnTextEdit);
            this.Controls.Add(this.fuelNeedTextEdit);
            this.Controls.Add(this.nameTextEdit);
            this.Controls.Add(this.planesGridControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.planesGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nameTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fuelNeedTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxStdPsnTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxVipPsnTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.baggageTextEdit.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl planesGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.TextEdit nameTextEdit;
        private DevExpress.XtraEditors.TextEdit fuelNeedTextEdit;
        private DevExpress.XtraEditors.TextEdit maxStdPsnTextEdit;
        private DevExpress.XtraEditors.TextEdit maxVipPsnTextEdit;
        private System.Windows.Forms.ListBox typeListBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.SimpleButton createPlaneButton;
        private DevExpress.XtraEditors.SimpleButton refreshButton;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraEditors.TextEdit baggageTextEdit;
        private DevExpress.XtraEditors.SimpleButton bindPlaneToFlightButton;
        private DevExpress.XtraEditors.SimpleButton resetButton;
    }
}

