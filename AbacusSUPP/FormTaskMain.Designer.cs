﻿namespace AbacusSUPP
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
            this.colLogin = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.UnboundKomentar = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.repositoryItemRichTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemRichTextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.memoEdit2 = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.richEditControl1 = new DevExpress.XtraRichEdit.RichEditControl();
            this.layoutViewCard1 = new DevExpress.XtraGrid.Views.Layout.LayoutViewCard();
            this.layoutViewField_coldatum = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.layoutViewField_colLogin = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.item2 = new DevExpress.XtraLayout.SimpleSeparator();
            this.layoutViewField_layoutViewColumn1 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.komentarBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRichTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewCard1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_coldatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colLogin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.item2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl1.Controls.Add(this.gridControl1);
            this.panelControl1.Location = new System.Drawing.Point(0, 163);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(933, 393);
            this.panelControl1.TabIndex = 0;
            // 
            // gridControl1
            // 
            this.gridControl1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gridControl1.BackgroundImage")));
            this.gridControl1.DataSource = this.komentarBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(2, 2);
            this.gridControl1.MainView = this.layoutView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemRichTextEdit1});
            this.gridControl1.Size = new System.Drawing.Size(929, 389);
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
            this.layoutView1.CardMinSize = new System.Drawing.Size(234, 98);
            this.layoutView1.CardVertInterval = 1;
            this.layoutView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.LayoutViewColumn[] {
            this.coldatum,
            this.colLogin,
            this.UnboundKomentar});
            this.layoutView1.GridControl = this.gridControl1;
            this.layoutView1.Name = "layoutView1";
            this.layoutView1.OptionsBehavior.AllowRuntimeCustomization = false;
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
            this.layoutView1.OptionsView.PartialCardsSimpleScrolling = DevExpress.Utils.DefaultBoolean.False;
            this.layoutView1.OptionsView.ShowCardBorderIfCaptionHidden = false;
            this.layoutView1.OptionsView.ShowFieldHints = false;
            this.layoutView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.layoutView1.OptionsView.ViewMode = DevExpress.XtraGrid.Views.Layout.LayoutViewMode.MultiColumn;
            this.layoutView1.TemplateCard = this.layoutViewCard1;
            this.layoutView1.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.layoutView1_CustomUnboundColumnData);
            this.layoutView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.layoutView1_MouseDown);
            this.layoutView1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.layoutView1_MouseUp);
            this.layoutView1.DoubleClick += new System.EventHandler(this.layoutView1_DoubleClick);
            // 
            // coldatum
            // 
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
            // colLogin
            // 
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
            // UnboundKomentar
            // 
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
            this.repositoryItemRichTextEdit1.DocumentFormat = DevExpress.XtraRichEdit.DocumentFormat.Rtf;
            this.repositoryItemRichTextEdit1.MaxHeight = 5000;
            this.repositoryItemRichTextEdit1.Name = "repositoryItemRichTextEdit1";
            this.repositoryItemRichTextEdit1.OptionsHorizontalScrollbar.Visibility = DevExpress.XtraRichEdit.RichEditScrollbarVisibility.Auto;
            this.repositoryItemRichTextEdit1.ReadOnly = true;
            this.repositoryItemRichTextEdit1.ShowCaretInReadOnly = false;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(43, 38);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(40, 33);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "BR";
            this.labelControl1.Click += new System.EventHandler(this.labelControl1_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupControl1.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("groupControl1.Appearance.Image")));
            this.groupControl1.Appearance.Options.UseFont = true;
            this.groupControl1.Appearance.Options.UseImage = true;
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl1.AppearanceCaption.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.ContentImage = ((System.Drawing.Image)(resources.GetObject("groupControl1.ContentImage")));
            this.groupControl1.ContentImageAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Location = new System.Drawing.Point(12, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(124, 100);
            this.groupControl1.TabIndex = 4;
            this.groupControl1.Text = "TASK ID";
            // 
            // memoEdit2
            // 
            this.memoEdit2.Enabled = false;
            this.memoEdit2.Location = new System.Drawing.Point(141, 42);
            this.memoEdit2.Name = "memoEdit2";
            this.memoEdit2.Properties.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
            this.memoEdit2.Properties.Appearance.Options.UseBackColor = true;
            this.memoEdit2.Properties.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.memoEdit2.Size = new System.Drawing.Size(520, 115);
            this.memoEdit2.TabIndex = 5;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("labelControl2.Appearance.Image")));
            this.labelControl2.Appearance.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Appearance.Options.UseImage = true;
            this.labelControl2.Appearance.Options.UseImageAlign = true;
            this.labelControl2.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.labelControl2.Location = new System.Drawing.Point(667, 43);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(106, 20);
            this.labelControl2.TabIndex = 6;
            this.labelControl2.Text = "labelControl2";
            this.labelControl2.Click += new System.EventHandler(this.labelControl2_Click);
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labelControl3.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("labelControl3.Appearance.Image")));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Appearance.Options.UseImage = true;
            this.labelControl3.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.labelControl3.Location = new System.Drawing.Point(667, 85);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(106, 20);
            this.labelControl3.TabIndex = 7;
            this.labelControl3.Text = "labelControl3";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labelControl4.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("labelControl4.Appearance.Image")));
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Appearance.Options.UseImage = true;
            this.labelControl4.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.labelControl4.Location = new System.Drawing.Point(667, 133);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(106, 20);
            this.labelControl4.TabIndex = 8;
            this.labelControl4.Text = "labelControl4";
            // 
            // simpleButton2
            // 
            this.simpleButton2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton2.ImageOptions.Image")));
            this.simpleButton2.Location = new System.Drawing.Point(12, 118);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(124, 39);
            this.simpleButton2.TabIndex = 9;
            this.simpleButton2.Text = "Zatvori task";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(142, 12);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(133, 24);
            this.labelControl5.TabIndex = 10;
            this.labelControl5.Text = "labelControl5";
            // 
            // simpleButton3
            // 
            this.simpleButton3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.simpleButton3.Location = new System.Drawing.Point(533, 629);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(98, 42);
            this.simpleButton3.TabIndex = 12;
            this.simpleButton3.Text = "Dodaj komentar";
            this.simpleButton3.Click += new System.EventHandler(this.simpleButton3_Click);
            // 
            // richEditControl1
            // 
            this.richEditControl1.ActiveViewType = DevExpress.XtraRichEdit.RichEditViewType.Simple;
            this.richEditControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.richEditControl1.LayoutUnit = DevExpress.XtraRichEdit.DocumentLayoutUnit.Pixel;
            this.richEditControl1.Location = new System.Drawing.Point(2, 560);
            this.richEditControl1.Name = "richEditControl1";
            this.richEditControl1.Size = new System.Drawing.Size(525, 111);
            this.richEditControl1.TabIndex = 13;
            // 
            // layoutViewCard1
            // 
            this.layoutViewCard1.CustomizationFormText = "TemplateCard";
            this.layoutViewCard1.HeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText;
            this.layoutViewCard1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutViewField_coldatum,
            this.layoutViewField_colLogin,
            this.item2,
            this.layoutViewField_layoutViewColumn1});
            this.layoutViewCard1.Name = "layoutViewCard1";
            this.layoutViewCard1.OptionsItemText.TextToControlDistance = 0;
            this.layoutViewCard1.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutViewCard1.Text = "TemplateCard";
            this.layoutViewCard1.TextLocation = DevExpress.Utils.Locations.Default;
            // 
            // layoutViewField_coldatum
            // 
            this.layoutViewField_coldatum.EditorPreferredWidth = 151;
            this.layoutViewField_coldatum.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("layoutViewField1.ImageOptions.Image")));
            this.layoutViewField_coldatum.Location = new System.Drawing.Point(239, 0);
            this.layoutViewField_coldatum.Name = "layoutViewField_coldatum";
            this.layoutViewField_coldatum.Size = new System.Drawing.Size(243, 24);
            this.layoutViewField_coldatum.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutViewField_coldatum.TextSize = new System.Drawing.Size(87, 16);
            // 
            // layoutViewField_colLogin
            // 
            this.layoutViewField_colLogin.EditorPreferredWidth = 147;
            this.layoutViewField_colLogin.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("layoutViewField1.ImageOptions.Image1")));
            this.layoutViewField_colLogin.Location = new System.Drawing.Point(0, 0);
            this.layoutViewField_colLogin.Name = "layoutViewField_colLogin";
            this.layoutViewField_colLogin.Size = new System.Drawing.Size(239, 24);
            this.layoutViewField_colLogin.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutViewField_colLogin.TextSize = new System.Drawing.Size(87, 16);
            // 
            // item2
            // 
            this.item2.AllowHotTrack = false;
            this.item2.CustomizationFormText = "item2";
            this.item2.Location = new System.Drawing.Point(0, 24);
            this.item2.Name = "item2";
            this.item2.Size = new System.Drawing.Size(482, 1);
            // 
            // layoutViewField_layoutViewColumn1
            // 
            this.layoutViewField_layoutViewColumn1.EditorPreferredWidth = 389;
            this.layoutViewField_layoutViewColumn1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("layoutViewField1.ImageOptions.Image2")));
            this.layoutViewField_layoutViewColumn1.Location = new System.Drawing.Point(0, 25);
            this.layoutViewField_layoutViewColumn1.Name = "layoutViewField_layoutViewColumn1";
            this.layoutViewField_layoutViewColumn1.Size = new System.Drawing.Size(482, 40);
            this.layoutViewField_layoutViewColumn1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.SupportHorzAlignment;
            this.layoutViewField_layoutViewColumn1.TextSize = new System.Drawing.Size(87, 32);
            // 
            // FormTaskMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 674);
            this.Controls.Add(this.richEditControl1);
            this.Controls.Add(this.simpleButton3);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.memoEdit2);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.panelControl1);
            this.LookAndFeel.SkinName = "The Bezier";
            this.Name = "FormTaskMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Task";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.komentarBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRichTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewCard1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_coldatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colLogin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.item2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Layout.LayoutView layoutView1;
        private System.Windows.Forms.BindingSource komentarBindingSource;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn coldatum;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colLogin;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.MemoEdit memoEdit2;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.Repository.RepositoryItemRichTextEdit repositoryItemRichTextEdit1;
        private DevExpress.XtraEditors.SimpleButton simpleButton3;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn UnboundKomentar;
        private DevExpress.XtraRichEdit.RichEditControl richEditControl1;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_coldatum;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colLogin;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_layoutViewColumn1;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewCard layoutViewCard1;
        private DevExpress.XtraLayout.SimpleSeparator item2;
    }
}