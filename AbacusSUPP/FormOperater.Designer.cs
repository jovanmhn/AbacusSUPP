namespace AbacusSUPP
{
    partial class FormOperater
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormOperater));
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.loginBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colusername = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colprezime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colid_sektor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colisAdmin = new DevExpress.XtraGrid.Columns.GridColumn();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton4 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loginBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.loginBindingSource;
            this.gridControl1.Location = new System.Drawing.Point(12, 12);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(636, 277);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // loginBindingSource
            // 
            this.loginBindingSource.DataSource = typeof(AbacusSUPP.Login);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colusername,
            this.colime,
            this.colprezime,
            this.colid_sektor,
            this.colisAdmin});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
            // 
            // colusername
            // 
            this.colusername.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colusername.AppearanceHeader.Options.UseFont = true;
            this.colusername.Caption = "Korisnicko ime";
            this.colusername.FieldName = "username";
            this.colusername.Name = "colusername";
            this.colusername.Visible = true;
            this.colusername.VisibleIndex = 0;
            // 
            // colime
            // 
            this.colime.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colime.AppearanceHeader.Options.UseFont = true;
            this.colime.Caption = "Ime";
            this.colime.FieldName = "ime";
            this.colime.Name = "colime";
            this.colime.Visible = true;
            this.colime.VisibleIndex = 1;
            // 
            // colprezime
            // 
            this.colprezime.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colprezime.AppearanceHeader.Options.UseFont = true;
            this.colprezime.Caption = "Prezime";
            this.colprezime.FieldName = "prezime";
            this.colprezime.Name = "colprezime";
            this.colprezime.Visible = true;
            this.colprezime.VisibleIndex = 2;
            // 
            // colid_sektor
            // 
            this.colid_sektor.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colid_sektor.AppearanceHeader.Options.UseFont = true;
            this.colid_sektor.Caption = "Sektor";
            this.colid_sektor.FieldName = "Sektor.naziv";
            this.colid_sektor.Name = "colid_sektor";
            this.colid_sektor.Visible = true;
            this.colid_sektor.VisibleIndex = 3;
            // 
            // colisAdmin
            // 
            this.colisAdmin.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colisAdmin.AppearanceHeader.Options.UseFont = true;
            this.colisAdmin.FieldName = "isAdmin";
            this.colisAdmin.Name = "colisAdmin";
            this.colisAdmin.Visible = true;
            this.colisAdmin.VisibleIndex = 4;
            // 
            // simpleButton1
            // 
            this.simpleButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(573, 295);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 1;
            this.simpleButton1.Text = "Dodaj";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // simpleButton2
            // 
            this.simpleButton2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton2.ImageOptions.Image")));
            this.simpleButton2.Location = new System.Drawing.Point(492, 295);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(75, 23);
            this.simpleButton2.TabIndex = 2;
            this.simpleButton2.Text = "Izmijeni";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // simpleButton3
            // 
            this.simpleButton3.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton3.ImageOptions.Image")));
            this.simpleButton3.Location = new System.Drawing.Point(411, 295);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(75, 23);
            this.simpleButton3.TabIndex = 3;
            this.simpleButton3.Text = "Obrisi";
            this.simpleButton3.Click += new System.EventHandler(this.simpleButton3_Click);
            // 
            // simpleButton4
            // 
            this.simpleButton4.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton4.ImageOptions.Image")));
            this.simpleButton4.Location = new System.Drawing.Point(298, 295);
            this.simpleButton4.Name = "simpleButton4";
            this.simpleButton4.Size = new System.Drawing.Size(107, 23);
            this.simpleButton4.TabIndex = 4;
            this.simpleButton4.Text = "Pregled taskova";
            this.simpleButton4.Click += new System.EventHandler(this.simpleButton4_Click);
            // 
            // FormOperater
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 327);
            this.Controls.Add(this.simpleButton4);
            this.Controls.Add(this.simpleButton3);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.gridControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormOperater";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormOperater";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loginBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.BindingSource loginBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colusername;
        private DevExpress.XtraGrid.Columns.GridColumn colisAdmin;
        private DevExpress.XtraGrid.Columns.GridColumn colime;
        private DevExpress.XtraGrid.Columns.GridColumn colprezime;
        private DevExpress.XtraGrid.Columns.GridColumn colid_sektor;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.SimpleButton simpleButton3;
        private DevExpress.XtraEditors.SimpleButton simpleButton4;
    }
}