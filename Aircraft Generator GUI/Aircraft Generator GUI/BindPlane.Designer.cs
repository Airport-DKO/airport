namespace Aircraft_Generator_GUI
{
    partial class BindPlane
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
            this.guidTextBox = new System.Windows.Forms.TextBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.fuelTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.flightsGrid = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.baggageTextBox = new System.Windows.Forms.TextBox();
            this.standartTextBox = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.vipTextBox = new System.Windows.Forms.Label();
            this.bindButton = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.flightsGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // guidTextBox
            // 
            this.guidTextBox.Enabled = false;
            this.guidTextBox.Location = new System.Drawing.Point(64, 12);
            this.guidTextBox.Name = "guidTextBox";
            this.guidTextBox.Size = new System.Drawing.Size(259, 20);
            this.guidTextBox.TabIndex = 0;
            // 
            // nameTextBox
            // 
            this.nameTextBox.Enabled = false;
            this.nameTextBox.Location = new System.Drawing.Point(64, 38);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(155, 20);
            this.nameTextBox.TabIndex = 1;
            // 
            // fuelTextBox
            // 
            this.fuelTextBox.Enabled = false;
            this.fuelTextBox.Location = new System.Drawing.Point(400, 12);
            this.fuelTextBox.Name = "fuelTextBox";
            this.fuelTextBox.Size = new System.Drawing.Size(84, 20);
            this.fuelTextBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "GUID:";
            // 
            // flightsGrid
            // 
            this.flightsGrid.Cursor = System.Windows.Forms.Cursors.Default;
            this.flightsGrid.Location = new System.Drawing.Point(0, 94);
            this.flightsGrid.MainView = this.gridView1;
            this.flightsGrid.Name = "flightsGrid";
            this.flightsGrid.Size = new System.Drawing.Size(654, 139);
            this.flightsGrid.TabIndex = 4;
            this.flightsGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.flightsGrid;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Имя:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(344, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Топливо:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(352, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Багаж:";
            // 
            // baggageTextBox
            // 
            this.baggageTextBox.Enabled = false;
            this.baggageTextBox.Location = new System.Drawing.Point(400, 38);
            this.baggageTextBox.Name = "baggageTextBox";
            this.baggageTextBox.Size = new System.Drawing.Size(84, 20);
            this.baggageTextBox.TabIndex = 8;
            // 
            // standartTextBox
            // 
            this.standartTextBox.Enabled = false;
            this.standartTextBox.Location = new System.Drawing.Point(559, 12);
            this.standartTextBox.Name = "standartTextBox";
            this.standartTextBox.Size = new System.Drawing.Size(84, 20);
            this.standartTextBox.TabIndex = 9;
            // 
            // textBox6
            // 
            this.textBox6.Enabled = false;
            this.textBox6.Location = new System.Drawing.Point(559, 41);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(84, 20);
            this.textBox6.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(504, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Эконом:";
            // 
            // vipTextBox
            // 
            this.vipTextBox.AutoSize = true;
            this.vipTextBox.Location = new System.Drawing.Point(528, 45);
            this.vipTextBox.Name = "vipTextBox";
            this.vipTextBox.Size = new System.Drawing.Size(27, 13);
            this.vipTextBox.TabIndex = 12;
            this.vipTextBox.Text = "VIP:";
            // 
            // bindButton
            // 
            this.bindButton.Location = new System.Drawing.Point(263, 239);
            this.bindButton.Name = "bindButton";
            this.bindButton.Size = new System.Drawing.Size(120, 23);
            this.bindButton.TabIndex = 13;
            this.bindButton.Text = "Выбрать рейс";
            this.bindButton.Click += new System.EventHandler(this.bindButton_Click);
            // 
            // BindPlane
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 265);
            this.Controls.Add(this.bindButton);
            this.Controls.Add(this.vipTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.standartTextBox);
            this.Controls.Add(this.baggageTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.flightsGrid);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fuelTextBox);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.guidTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "BindPlane";
            this.Text = "BindPlane";
            ((System.ComponentModel.ISupportInitialize)(this.flightsGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox guidTextBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox fuelTextBox;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraGrid.GridControl flightsGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox baggageTextBox;
        private System.Windows.Forms.TextBox standartTextBox;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label vipTextBox;
        private DevExpress.XtraEditors.SimpleButton bindButton;
    }
}