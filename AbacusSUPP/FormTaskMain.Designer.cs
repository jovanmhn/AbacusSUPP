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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.komentarBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.layoutView1 = new DevExpress.XtraGrid.Views.Layout.LayoutView();
            this.coldatum = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.colsadrzaj = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.colLogin = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.memoEdit1 = new DevExpress.XtraEditors.MemoEdit();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.layoutViewCard1 = new DevExpress.XtraGrid.Views.Layout.LayoutViewCard();
            this.layoutViewField_coldatum = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.layoutViewField_colsadrzaj = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.layoutViewField_colLogin = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.komentarBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewCard1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_coldatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colsadrzaj)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colLogin)).BeginInit();
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
            this.layoutView1.CardHorzInterval = 0;
            this.layoutView1.CardMinSize = new System.Drawing.Size(180, 68);
            this.layoutView1.CardVertInterval = 0;
            this.layoutView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.LayoutViewColumn[] {
            this.coldatum,
            this.colsadrzaj,
            this.colLogin});
            this.layoutView1.GridControl = this.gridControl1;
            this.layoutView1.Name = "layoutView1";
            this.layoutView1.OptionsItemText.TextToControlDistance = 0;
            this.layoutView1.OptionsMultiRecordMode.StretchCardToViewWidth = true;
            this.layoutView1.OptionsView.CardArrangeRule = DevExpress.XtraGrid.Views.Layout.LayoutCardArrangeRule.AllowPartialCards;
            this.layoutView1.OptionsView.CardsAlignment = DevExpress.XtraGrid.Views.Layout.CardsAlignment.Near;
            this.layoutView1.OptionsView.ShowCardCaption = false;
            this.layoutView1.OptionsView.ShowCardExpandButton = false;
            this.layoutView1.OptionsView.ShowCardFieldBorders = true;
            this.layoutView1.OptionsView.ShowCardLines = false;
            this.layoutView1.OptionsView.ShowHeaderPanel = false;
            this.layoutView1.OptionsView.ViewMode = DevExpress.XtraGrid.Views.Layout.LayoutViewMode.MultiColumn;
            this.layoutView1.TemplateCard = this.layoutViewCard1;
            // 
            // coldatum
            // 
            this.coldatum.DisplayFormat.FormatString = "d";
            this.coldatum.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.coldatum.FieldName = "datum";
            this.coldatum.LayoutViewField = this.layoutViewField_coldatum;
            this.coldatum.Name = "coldatum";
            // 
            // colsadrzaj
            // 
            this.colsadrzaj.FieldName = "sadrzaj";
            this.colsadrzaj.LayoutViewField = this.layoutViewField_colsadrzaj;
            this.colsadrzaj.Name = "colsadrzaj";
            // 
            // colLogin
            // 
            this.colLogin.FieldName = "Login.username";
            this.colLogin.LayoutViewField = this.layoutViewField_colLogin;
            this.colLogin.Name = "colLogin";
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
            this.labelControl1.Location = new System.Drawing.Point(333, 65);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(228, 33);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "NEKI TASK INFO";
            // 
            // layoutViewCard1
            // 
            this.layoutViewCard1.CustomizationFormText = "TemplateCard";
            this.layoutViewCard1.GroupBordersVisible = false;
            this.layoutViewCard1.HeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText;
            this.layoutViewCard1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutViewField_coldatum,
            this.layoutViewField_colsadrzaj,
            this.layoutViewField_colLogin});
            this.layoutViewCard1.Name = "layoutViewCard1";
            this.layoutViewCard1.OptionsItemText.TextToControlDistance = 0;
            this.layoutViewCard1.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutViewCard1.Text = "TemplateCard";
            // 
            // layoutViewField_coldatum
            // 
            this.layoutViewField_coldatum.EditorPreferredWidth = 132;
            this.layoutViewField_coldatum.Location = new System.Drawing.Point(0, 0);
            this.layoutViewField_coldatum.Name = "layoutViewField_coldatum";
            this.layoutViewField_coldatum.Size = new System.Drawing.Size(216, 24);
            this.layoutViewField_coldatum.TextSize = new System.Drawing.Size(51, 13);
            // 
            // layoutViewField_colsadrzaj
            // 
            this.layoutViewField_colsadrzaj.EditorPreferredWidth = 319;
            this.layoutViewField_colsadrzaj.Location = new System.Drawing.Point(0, 24);
            this.layoutViewField_colsadrzaj.Name = "layoutViewField_colsadrzaj";
            this.layoutViewField_colsadrzaj.Size = new System.Drawing.Size(432, 72);
            this.layoutViewField_colsadrzaj.TextSize = new System.Drawing.Size(51, 13);
            // 
            // layoutViewField_colLogin
            // 
            this.layoutViewField_colLogin.EditorPreferredWidth = 132;
            this.layoutViewField_colLogin.Location = new System.Drawing.Point(216, 0);
            this.layoutViewField_colLogin.Name = "layoutViewField_colLogin";
            this.layoutViewField_colLogin.Size = new System.Drawing.Size(216, 24);
            this.layoutViewField_colLogin.TextSize = new System.Drawing.Size(51, 13);
            // 
            // FormTaskMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 674);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.memoEdit1);
            this.Controls.Add(this.panelControl1);
            this.Name = "FormTaskMain";
            this.Text = "FormTaskMain";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.komentarBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewCard1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_coldatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colsadrzaj)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colLogin)).EndInit();
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
    }
}