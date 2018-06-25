namespace AbacusSUPP
{
    partial class FormSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSettings));
            this.checkEdit1 = new DevExpress.XtraEditors.CheckEdit();
            this.PodesavanjaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.checkEdit4 = new DevExpress.XtraEditors.CheckEdit();
            this.checkEdit3 = new DevExpress.XtraEditors.CheckEdit();
            this.checkEdit2 = new DevExpress.XtraEditors.CheckEdit();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PodesavanjaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit4.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit2.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // checkEdit1
            // 
            this.checkEdit1.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.PodesavanjaBindingSource, "minimize_tray", true));
            this.checkEdit1.Location = new System.Drawing.Point(5, 30);
            this.checkEdit1.Name = "checkEdit1";
            this.checkEdit1.Properties.Caption = "Minimizuj u tray";
            this.checkEdit1.Size = new System.Drawing.Size(103, 20);
            this.checkEdit1.TabIndex = 0;
            this.checkEdit1.CheckedChanged += new System.EventHandler(this.checkEdit1_CheckedChanged);
            // 
            // PodesavanjaBindingSource
            // 
            this.PodesavanjaBindingSource.DataSource = typeof(AbacusSUPP.Podesavanja);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.checkEdit4);
            this.groupControl1.Controls.Add(this.checkEdit3);
            this.groupControl1.Controls.Add(this.checkEdit2);
            this.groupControl1.Controls.Add(this.checkEdit1);
            this.groupControl1.Location = new System.Drawing.Point(12, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(501, 299);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "Podesavanja";
            // 
            // checkEdit4
            // 
            this.checkEdit4.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.PodesavanjaBindingSource, "novikom_notif", true));
            this.checkEdit4.Location = new System.Drawing.Point(5, 108);
            this.checkEdit4.Name = "checkEdit4";
            this.checkEdit4.Properties.Caption = "Novi komentar notifikacija";
            this.checkEdit4.Size = new System.Drawing.Size(149, 20);
            this.checkEdit4.TabIndex = 5;
            // 
            // checkEdit3
            // 
            this.checkEdit3.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.PodesavanjaBindingSource, "novitask_notif", true));
            this.checkEdit3.Location = new System.Drawing.Point(5, 82);
            this.checkEdit3.Name = "checkEdit3";
            this.checkEdit3.Properties.Caption = "Novi task notifikacija";
            this.checkEdit3.Size = new System.Drawing.Size(122, 20);
            this.checkEdit3.TabIndex = 4;
            // 
            // checkEdit2
            // 
            this.checkEdit2.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.PodesavanjaBindingSource, "minimize_notif", true));
            this.checkEdit2.Location = new System.Drawing.Point(5, 56);
            this.checkEdit2.Name = "checkEdit2";
            this.checkEdit2.Properties.Caption = "Minimize notifikacija";
            this.checkEdit2.Size = new System.Drawing.Size(122, 20);
            this.checkEdit2.TabIndex = 1;
            // 
            // simpleButton1
            // 
            this.simpleButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(347, 317);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(80, 23);
            this.simpleButton1.TabIndex = 2;
            this.simpleButton1.Text = "Sacuvaj";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // simpleButton2
            // 
            this.simpleButton2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton2.ImageOptions.Image")));
            this.simpleButton2.Location = new System.Drawing.Point(433, 317);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(80, 23);
            this.simpleButton2.TabIndex = 3;
            this.simpleButton2.Text = "Otkazi";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 352);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.groupControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Podesavanja";
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PodesavanjaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit4.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit2.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.CheckEdit checkEdit1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.CheckEdit checkEdit2;
        private DevExpress.XtraEditors.CheckEdit checkEdit3;
        private System.Windows.Forms.BindingSource PodesavanjaBindingSource;
        private DevExpress.XtraEditors.CheckEdit checkEdit4;
    }
}