namespace AbacusSUPP
{
    partial class FormTest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTest));
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.layoutView1 = new DevExpress.XtraGrid.Views.Layout.LayoutView();
            this.coldatum = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_coldatum = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.colLogin = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_colLogin = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.UnboundKomentar = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.repositoryItemRichTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemRichTextEdit();
            this.layoutViewField_layoutViewColumn1 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.layoutViewCard1 = new DevExpress.XtraGrid.Views.Layout.LayoutViewCard();
            this.item2 = new DevExpress.XtraLayout.SimpleSeparator();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.richEditControl1 = new DevExpress.XtraRichEdit.RichEditControl();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_coldatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colLogin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRichTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewCard1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.item2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gridControl1.BackgroundImage")));
            this.gridControl1.Location = new System.Drawing.Point(803, 346);
            this.gridControl1.MainView = this.layoutView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemRichTextEdit1});
            this.gridControl1.Size = new System.Drawing.Size(100, 80);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.layoutView1});
            // 
            // layoutView1
            // 
            this.layoutView1.Appearance.Card.BorderColor = System.Drawing.Color.Red;
            this.layoutView1.Appearance.Card.Options.UseBorderColor = true;
            this.layoutView1.Appearance.CardCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutView1.Appearance.CardCaption.Options.UseFont = true;
            this.layoutView1.Appearance.FieldValue.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Italic);
            this.layoutView1.Appearance.FieldValue.Options.UseFont = true;
            this.layoutView1.Appearance.SeparatorLine.BackColor = System.Drawing.Color.White;
            this.layoutView1.Appearance.SeparatorLine.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.layoutView1.Appearance.ViewCaption.BackColor = System.Drawing.Color.Transparent;
            this.layoutView1.Appearance.ViewCaption.Options.UseBackColor = true;
            this.layoutView1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.layoutView1.CardCaptionFormat = "Komentar {0}/{1}";
            this.layoutView1.CardHorzInterval = 0;
            this.layoutView1.CardMinSize = new System.Drawing.Size(0, 0);
            this.layoutView1.CardVertInterval = 1;
            this.layoutView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.LayoutViewColumn[] {
            this.coldatum,
            this.colLogin,
            this.UnboundKomentar});
            this.layoutView1.GridControl = this.gridControl1;
            this.layoutView1.Name = "layoutView1";
            this.layoutView1.OptionsBehavior.AllowRuntimeCustomization = false;
            this.layoutView1.OptionsBehavior.AutoFocusCardOnScrolling = true;
            this.layoutView1.OptionsHeaderPanel.EnableCarouselModeButton = false;
            this.layoutView1.OptionsHeaderPanel.EnableColumnModeButton = false;
            this.layoutView1.OptionsHeaderPanel.EnableCustomizeButton = false;
            this.layoutView1.OptionsHeaderPanel.EnableMultiColumnModeButton = false;
            this.layoutView1.OptionsHeaderPanel.EnableMultiRowModeButton = false;
            this.layoutView1.OptionsHeaderPanel.EnableRowModeButton = false;
            this.layoutView1.OptionsHeaderPanel.EnableSingleModeButton = false;
            this.layoutView1.OptionsHeaderPanel.ShowCarouselModeButton = false;
            this.layoutView1.OptionsHeaderPanel.ShowColumnModeButton = false;
            this.layoutView1.OptionsHeaderPanel.ShowCustomizeButton = false;
            this.layoutView1.OptionsHeaderPanel.ShowMultiColumnModeButton = false;
            this.layoutView1.OptionsHeaderPanel.ShowMultiRowModeButton = false;
            this.layoutView1.OptionsHeaderPanel.ShowRowModeButton = false;
            this.layoutView1.OptionsHeaderPanel.ShowSingleModeButton = false;
            this.layoutView1.OptionsItemText.TextToControlDistance = 0;
            this.layoutView1.OptionsMultiRecordMode.StretchCardToViewWidth = true;
            this.layoutView1.OptionsView.AllowHotTrackFields = false;
            this.layoutView1.OptionsView.CardArrangeRule = DevExpress.XtraGrid.Views.Layout.LayoutCardArrangeRule.AllowPartialCards;
            this.layoutView1.OptionsView.CardsAlignment = DevExpress.XtraGrid.Views.Layout.CardsAlignment.Near;
            this.layoutView1.OptionsView.FocusRectStyle = DevExpress.XtraGrid.Views.Layout.FocusRectStyle.None;
            this.layoutView1.OptionsView.PartialCardsSimpleScrolling = DevExpress.Utils.DefaultBoolean.True;
            this.layoutView1.OptionsView.ShowCardBorderIfCaptionHidden = false;
            this.layoutView1.OptionsView.ShowFieldHints = false;
            this.layoutView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.layoutView1.OptionsView.ViewMode = DevExpress.XtraGrid.Views.Layout.LayoutViewMode.MultiColumn;
            this.layoutView1.TemplateCard = this.layoutViewCard1;
            this.layoutView1.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.layoutView1_CustomUnboundColumnData);
            // 
            // coldatum
            // 
            this.coldatum.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F);
            this.coldatum.AppearanceCell.Options.UseFont = true;
            this.coldatum.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.coldatum.AppearanceHeader.Options.UseFont = true;
            this.coldatum.Caption = "Datum";
            this.coldatum.CustomizationCaption = "Datum ";
            this.coldatum.DisplayFormat.FormatString = "g";
            this.coldatum.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.coldatum.FieldName = "datum";
            this.coldatum.LayoutViewField = this.layoutViewField_coldatum;
            this.coldatum.Name = "coldatum";
            this.coldatum.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.coldatum.OptionsColumn.ReadOnly = true;
            this.coldatum.OptionsFilter.AllowFilter = false;
            // 
            // layoutViewField_coldatum
            // 
            this.layoutViewField_coldatum.EditorPreferredWidth = 148;
            this.layoutViewField_coldatum.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("layoutViewField_coldatum.ImageOptions.Image")));
            this.layoutViewField_coldatum.Location = new System.Drawing.Point(220, 0);
            this.layoutViewField_coldatum.Name = "layoutViewField_coldatum";
            this.layoutViewField_coldatum.Size = new System.Drawing.Size(223, 24);
            this.layoutViewField_coldatum.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutViewField_coldatum.TextSize = new System.Drawing.Size(71, 16);
            // 
            // colLogin
            // 
            this.colLogin.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.colLogin.AppearanceCell.Options.UseFont = true;
            this.colLogin.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colLogin.AppearanceHeader.Options.UseFont = true;
            this.colLogin.Caption = "Korisnik";
            this.colLogin.CustomizationCaption = "Korisnik ";
            this.colLogin.FieldName = "Login.username";
            this.colLogin.LayoutViewField = this.layoutViewField_colLogin;
            this.colLogin.Name = "colLogin";
            this.colLogin.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colLogin.OptionsColumn.ReadOnly = true;
            this.colLogin.OptionsFilter.AllowFilter = false;
            // 
            // layoutViewField_colLogin
            // 
            this.layoutViewField_colLogin.EditorPreferredWidth = 145;
            this.layoutViewField_colLogin.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("layoutViewField_colLogin.ImageOptions.Image")));
            this.layoutViewField_colLogin.Location = new System.Drawing.Point(0, 0);
            this.layoutViewField_colLogin.Name = "layoutViewField_colLogin";
            this.layoutViewField_colLogin.Size = new System.Drawing.Size(220, 24);
            this.layoutViewField_colLogin.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutViewField_colLogin.TextSize = new System.Drawing.Size(71, 16);
            // 
            // UnboundKomentar
            // 
            this.UnboundKomentar.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 12F);
            this.UnboundKomentar.AppearanceCell.Options.UseFont = true;
            this.UnboundKomentar.AppearanceHeader.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.UnboundKomentar.AppearanceHeader.Options.UseFont = true;
            this.UnboundKomentar.Caption = "Komentar";
            this.UnboundKomentar.ColumnEdit = this.repositoryItemRichTextEdit1;
            this.UnboundKomentar.FieldName = "UnboundKomentar";
            this.UnboundKomentar.LayoutViewField = this.layoutViewField_layoutViewColumn1;
            this.UnboundKomentar.Name = "UnboundKomentar";
            this.UnboundKomentar.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.UnboundKomentar.OptionsFilter.AllowFilter = false;
            this.UnboundKomentar.UnboundType = DevExpress.Data.UnboundColumnType.String;
            // 
            // repositoryItemRichTextEdit1
            // 
            this.repositoryItemRichTextEdit1.AppearanceReadOnly.Font = new System.Drawing.Font("Tahoma", 12F);
            this.repositoryItemRichTextEdit1.AppearanceReadOnly.Options.UseFont = true;
            this.repositoryItemRichTextEdit1.DocumentFormat = DevExpress.XtraRichEdit.DocumentFormat.Rtf;
            this.repositoryItemRichTextEdit1.MaxHeight = 5000;
            this.repositoryItemRichTextEdit1.Name = "repositoryItemRichTextEdit1";
            this.repositoryItemRichTextEdit1.OptionsExport.Rtf.WrapContentInGroup = true;
            this.repositoryItemRichTextEdit1.OptionsHorizontalScrollbar.Visibility = DevExpress.XtraRichEdit.RichEditScrollbarVisibility.Visible;
            this.repositoryItemRichTextEdit1.OptionsVerticalScrollbar.Visibility = DevExpress.XtraRichEdit.RichEditScrollbarVisibility.Visible;
            this.repositoryItemRichTextEdit1.ReadOnly = true;
            this.repositoryItemRichTextEdit1.ShowCaretInReadOnly = false;
            this.repositoryItemRichTextEdit1.EditValueChanged += new System.EventHandler(this.repositoryItemRichTextEdit1_EditValueChanged);
            // 
            // layoutViewField_layoutViewColumn1
            // 
            this.layoutViewField_layoutViewColumn1.BestFitWeight = -1;
            this.layoutViewField_layoutViewColumn1.EditorPreferredWidth = 439;
            this.layoutViewField_layoutViewColumn1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("layoutViewField_layoutViewColumn1.ImageOptions.Image")));
            this.layoutViewField_layoutViewColumn1.Location = new System.Drawing.Point(0, 25);
            this.layoutViewField_layoutViewColumn1.Name = "layoutViewField_layoutViewColumn1";
            this.layoutViewField_layoutViewColumn1.Size = new System.Drawing.Size(443, 39);
            this.layoutViewField_layoutViewColumn1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.SupportHorzAlignment;
            this.layoutViewField_layoutViewColumn1.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutViewField_layoutViewColumn1.TextSize = new System.Drawing.Size(71, 16);
            // 
            // layoutViewCard1
            // 
            this.layoutViewCard1.BestFitWeight = -1;
            this.layoutViewCard1.CustomizationFormText = "TemplateCard";
            this.layoutViewCard1.HeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText;
            this.layoutViewCard1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutViewField_coldatum,
            this.layoutViewField_colLogin,
            this.item2,
            this.layoutViewField_layoutViewColumn1});
            this.layoutViewCard1.Name = "layoutViewTemplateCard";
            this.layoutViewCard1.OptionsItemText.TextToControlDistance = 0;
            this.layoutViewCard1.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutViewCard1.Text = "TemplateCard";
            this.layoutViewCard1.TextLocation = DevExpress.Utils.Locations.Default;
            // 
            // item2
            // 
            this.item2.AllowHotTrack = false;
            this.item2.CustomizationFormText = "item2";
            this.item2.Location = new System.Drawing.Point(0, 24);
            this.item2.Name = "item2";
            this.item2.Size = new System.Drawing.Size(443, 1);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(451, 488);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 2;
            this.simpleButton1.Text = "simpleButton1";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // richEditControl1
            // 
            this.richEditControl1.Location = new System.Drawing.Point(12, 12);
            this.richEditControl1.Name = "richEditControl1";
            this.richEditControl1.Size = new System.Drawing.Size(767, 370);
            this.richEditControl1.TabIndex = 3;
            this.richEditControl1.Text = "richEditControl1";
            this.richEditControl1.DragDrop += new System.Windows.Forms.DragEventHandler(this.richEditControl1_DragDrop);
            this.richEditControl1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.richEditControl1_KeyDown);
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.Images.SetKeyName(0, "apply_32x32.png");
            // 
            // simpleButton2
            // 
            this.simpleButton2.Location = new System.Drawing.Point(815, 75);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(75, 23);
            this.simpleButton2.TabIndex = 4;
            this.simpleButton2.Text = "simpleButton2";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // FormTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 539);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.richEditControl1);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.gridControl1);
            this.Name = "FormTest";
            this.Text = "FormTest";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_coldatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colLogin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRichTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewCard1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.item2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Layout.LayoutView layoutView1;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn coldatum;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_coldatum;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colLogin;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colLogin;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn UnboundKomentar;
        private DevExpress.XtraEditors.Repository.RepositoryItemRichTextEdit repositoryItemRichTextEdit1;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_layoutViewColumn1;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewCard layoutViewCard1;
        private DevExpress.XtraLayout.SimpleSeparator item2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraRichEdit.RichEditControl richEditControl1;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
    }
}