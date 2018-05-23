namespace AbacusSUPP
{
    partial class FormTaskMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTaskMain));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.komentarBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.layoutView1 = new DevExpress.XtraGrid.Views.Layout.LayoutView();
            this.coldatum = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_coldatum = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.colsadrzaj = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_colsadrzaj = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.colLogin = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_colLogin = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.layoutViewCard1 = new DevExpress.XtraGrid.Views.Layout.LayoutViewCard();
            this.memoEdit1 = new DevExpress.XtraEditors.MemoEdit();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.memoEdit2 = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.komentarBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_coldatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colsadrzaj)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colLogin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewCard1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit2.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl1.Controls.Add(this.gridControl1);
            this.panelControl1.Location = new System.Drawing.Point(0, 234);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(933, 303);
            this.panelControl1.TabIndex = 0;
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.komentarBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(2, 2);
            this.gridControl1.MainView = this.layoutView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(929, 299);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.layoutView1});
            // 
            // komentarBindingSource
            // 
            this.komentarBindingSource.DataSource = typeof(AbacusSUPP.Komentar);
            // 
            // layoutView1
            // 
            this.layoutView1.Appearance.CardCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutView1.Appearance.CardCaption.Options.UseFont = true;
            this.layoutView1.Appearance.FieldValue.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Italic);
            this.layoutView1.Appearance.FieldValue.Options.UseFont = true;
            this.layoutView1.Appearance.ViewCaption.BackColor = System.Drawing.Color.Transparent;
            this.layoutView1.Appearance.ViewCaption.Options.UseBackColor = true;
            this.layoutView1.CardCaptionFormat = "Komentar";
            this.layoutView1.CardHorzInterval = 0;
            this.layoutView1.CardMinSize = new System.Drawing.Size(152, 90);
            this.layoutView1.CardVertInterval = 1;
            this.layoutView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.LayoutViewColumn[] {
            this.coldatum,
            this.colsadrzaj,
            this.colLogin});
            this.layoutView1.DetailAutoHeight = false;
            this.layoutView1.GridControl = this.gridControl1;
            this.layoutView1.Name = "layoutView1";
            this.layoutView1.OptionsBehavior.AllowRuntimeCustomization = false;
            this.layoutView1.OptionsBehavior.Editable = false;
            this.layoutView1.OptionsItemText.TextToControlDistance = 0;
            this.layoutView1.OptionsMultiRecordMode.StretchCardToViewWidth = true;
            this.layoutView1.OptionsView.CardArrangeRule = DevExpress.XtraGrid.Views.Layout.LayoutCardArrangeRule.AllowPartialCards;
            this.layoutView1.OptionsView.CardsAlignment = DevExpress.XtraGrid.Views.Layout.CardsAlignment.Near;
            this.layoutView1.OptionsView.ShowCardFieldBorders = true;
            this.layoutView1.OptionsView.ShowHeaderPanel = false;
            this.layoutView1.OptionsView.ViewMode = DevExpress.XtraGrid.Views.Layout.LayoutViewMode.MultiColumn;
            this.layoutView1.TemplateCard = this.layoutViewCard1;
            // 
            // coldatum
            // 
            this.coldatum.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.coldatum.AppearanceHeader.Options.UseFont = true;
            this.coldatum.Caption = "Datum";
            this.coldatum.DisplayFormat.FormatString = "g";
            this.coldatum.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.coldatum.FieldName = "datum";
            this.coldatum.LayoutViewField = this.layoutViewField_coldatum;
            this.coldatum.Name = "coldatum";
            // 
            // layoutViewField_coldatum
            // 
            this.layoutViewField_coldatum.EditorPreferredWidth = 172;
            this.layoutViewField_coldatum.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("layoutViewField_coldatum.ImageOptions.Image")));
            this.layoutViewField_coldatum.Location = new System.Drawing.Point(243, 0);
            this.layoutViewField_coldatum.Name = "layoutViewField_coldatum";
            this.layoutViewField_coldatum.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutViewField_coldatum.Size = new System.Drawing.Size(243, 30);
            this.layoutViewField_coldatum.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutViewField_coldatum.TextSize = new System.Drawing.Size(61, 16);
            // 
            // colsadrzaj
            // 
            this.colsadrzaj.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colsadrzaj.AppearanceHeader.Options.UseFont = true;
            this.colsadrzaj.Caption = "Sadržaj";
            this.colsadrzaj.FieldName = "sadrzaj";
            this.colsadrzaj.LayoutViewField = this.layoutViewField_colsadrzaj;
            this.colsadrzaj.Name = "colsadrzaj";
            this.colsadrzaj.OptionsColumn.AllowShowHide = false;
            this.colsadrzaj.OptionsColumn.AllowSize = false;
            // 
            // layoutViewField_colsadrzaj
            // 
            this.layoutViewField_colsadrzaj.EditorPreferredWidth = 415;
            this.layoutViewField_colsadrzaj.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("layoutViewField_colsadrzaj.ImageOptions.Image")));
            this.layoutViewField_colsadrzaj.Location = new System.Drawing.Point(0, 30);
            this.layoutViewField_colsadrzaj.Name = "layoutViewField_colsadrzaj";
            this.layoutViewField_colsadrzaj.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutViewField_colsadrzaj.Size = new System.Drawing.Size(486, 30);
            this.layoutViewField_colsadrzaj.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutViewField_colsadrzaj.TextSize = new System.Drawing.Size(61, 16);
            // 
            // colLogin
            // 
            this.colLogin.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colLogin.AppearanceHeader.Options.UseFont = true;
            this.colLogin.Caption = "Korisnik";
            this.colLogin.FieldName = "Login.username";
            this.colLogin.LayoutViewField = this.layoutViewField_colLogin;
            this.colLogin.Name = "colLogin";
            // 
            // layoutViewField_colLogin
            // 
            this.layoutViewField_colLogin.EditorPreferredWidth = 172;
            this.layoutViewField_colLogin.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("layoutViewField_colLogin.ImageOptions.Image")));
            this.layoutViewField_colLogin.Location = new System.Drawing.Point(0, 0);
            this.layoutViewField_colLogin.Name = "layoutViewField_colLogin";
            this.layoutViewField_colLogin.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutViewField_colLogin.Size = new System.Drawing.Size(243, 30);
            this.layoutViewField_colLogin.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutViewField_colLogin.TextSize = new System.Drawing.Size(61, 16);
            // 
            // layoutViewCard1
            // 
            this.layoutViewCard1.CustomizationFormText = "TemplateCard";
            this.layoutViewCard1.HeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText;
            this.layoutViewCard1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutViewField_coldatum,
            this.layoutViewField_colsadrzaj,
            this.layoutViewField_colLogin});
            this.layoutViewCard1.Name = "layoutViewTemplateCard";
            this.layoutViewCard1.OptionsItemText.TextToControlDistance = 0;
            this.layoutViewCard1.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutViewCard1.Text = "TemplateCard";
            this.layoutViewCard1.TextLocation = DevExpress.Utils.Locations.Default;
            // 
            // memoEdit1
            // 
            this.memoEdit1.Location = new System.Drawing.Point(12, 552);
            this.memoEdit1.Name = "memoEdit1";
            this.memoEdit1.Size = new System.Drawing.Size(472, 100);
            this.memoEdit1.TabIndex = 1;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(490, 601);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(99, 51);
            this.simpleButton1.TabIndex = 2;
            this.simpleButton1.Text = "Dodaj komentar";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(39, 36);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(40, 33);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "BR";
            // 
            // groupControl1
            // 
            this.groupControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupControl1.Appearance.Options.UseFont = true;
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl1.AppearanceCaption.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Location = new System.Drawing.Point(12, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(124, 93);
            this.groupControl1.TabIndex = 4;
            this.groupControl1.Text = "TASK ID";
            // 
            // memoEdit2
            // 
            this.memoEdit2.Enabled = false;
            this.memoEdit2.Location = new System.Drawing.Point(214, 32);
            this.memoEdit2.Name = "memoEdit2";
            this.memoEdit2.Properties.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
            this.memoEdit2.Properties.Appearance.Options.UseBackColor = true;
            this.memoEdit2.Properties.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.memoEdit2.Size = new System.Drawing.Size(448, 181);
            this.memoEdit2.TabIndex = 5;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(700, 48);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(63, 13);
            this.labelControl2.TabIndex = 6;
            this.labelControl2.Text = "labelControl2";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(700, 104);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(63, 13);
            this.labelControl3.TabIndex = 7;
            this.labelControl3.Text = "labelControl3";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(700, 159);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(63, 13);
            this.labelControl4.TabIndex = 8;
            this.labelControl4.Text = "labelControl4";
            // 
            // simpleButton2
            // 
            this.simpleButton2.Location = new System.Drawing.Point(632, 608);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(95, 37);
            this.simpleButton2.TabIndex = 9;
            this.simpleButton2.Text = "Zatvori task";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // FormTaskMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 674);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.memoEdit2);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.memoEdit1);
            this.Controls.Add(this.panelControl1);
            this.Name = "FormTaskMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Task";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.komentarBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_coldatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colsadrzaj)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colLogin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewCard1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit2.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Layout.LayoutView layoutView1;
        private DevExpress.XtraEditors.MemoEdit memoEdit1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private System.Windows.Forms.BindingSource komentarBindingSource;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn coldatum;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colsadrzaj;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colLogin;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_coldatum;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colsadrzaj;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colLogin;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewCard layoutViewCard1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.MemoEdit memoEdit2;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
    }
}