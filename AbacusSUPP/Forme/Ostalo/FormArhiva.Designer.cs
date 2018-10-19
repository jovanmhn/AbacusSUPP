namespace AbacusSUPP.Forme.Ostalo
{
    partial class FormArhiva
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.taskBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colid_task = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coldatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coldatum_zatv = new DevExpress.XtraGrid.Columns.GridColumn();
            this.partnerIme = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Opis = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.taskBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.taskBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(881, 374);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.DoubleClick += new System.EventHandler(this.gridControl1_DoubleClick);
            // 
            // taskBindingSource
            // 
            this.taskBindingSource.DataSource = typeof(AbacusSUPP.Task);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colid_task,
            this.coldatum,
            this.coldatum_zatv,
            this.partnerIme,
            this.Opis});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsPrint.EnableAppearanceEvenRow = true;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowIndicator = false;
            // 
            // colid_task
            // 
            this.colid_task.AppearanceCell.Options.UseTextOptions = true;
            this.colid_task.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colid_task.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colid_task.AppearanceHeader.Options.UseFont = true;
            this.colid_task.AppearanceHeader.Options.UseTextOptions = true;
            this.colid_task.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colid_task.Caption = "ID";
            this.colid_task.FieldName = "id_task";
            this.colid_task.Name = "colid_task";
            this.colid_task.Visible = true;
            this.colid_task.VisibleIndex = 0;
            this.colid_task.Width = 53;
            // 
            // coldatum
            // 
            this.coldatum.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.coldatum.AppearanceHeader.Options.UseFont = true;
            this.coldatum.Caption = "Datum otv.";
            this.coldatum.FieldName = "datum";
            this.coldatum.Name = "coldatum";
            this.coldatum.Visible = true;
            this.coldatum.VisibleIndex = 1;
            this.coldatum.Width = 72;
            // 
            // coldatum_zatv
            // 
            this.coldatum_zatv.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.coldatum_zatv.AppearanceHeader.Options.UseFont = true;
            this.coldatum_zatv.Caption = "Datum zatv.";
            this.coldatum_zatv.FieldName = "datum_zatv";
            this.coldatum_zatv.Name = "coldatum_zatv";
            this.coldatum_zatv.Visible = true;
            this.coldatum_zatv.VisibleIndex = 2;
            this.coldatum_zatv.Width = 74;
            // 
            // partnerIme
            // 
            this.partnerIme.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.partnerIme.AppearanceHeader.Options.UseFont = true;
            this.partnerIme.Caption = "Partner";
            this.partnerIme.FieldName = "Partneri.naziv";
            this.partnerIme.Name = "partnerIme";
            this.partnerIme.Visible = true;
            this.partnerIme.VisibleIndex = 3;
            this.partnerIme.Width = 165;
            // 
            // Opis
            // 
            this.Opis.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Opis.AppearanceHeader.Options.UseFont = true;
            this.Opis.Caption = "Opis";
            this.Opis.FieldName = "opis";
            this.Opis.Name = "Opis";
            this.Opis.Visible = true;
            this.Opis.VisibleIndex = 4;
            this.Opis.Width = 428;
            // 
            // FormArhiva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 374);
            this.Controls.Add(this.gridControl1);
            this.Name = "FormArhiva";
            this.Text = "FormArhiva";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.taskBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private System.Windows.Forms.BindingSource taskBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colid_task;
        private DevExpress.XtraGrid.Columns.GridColumn coldatum;
        private DevExpress.XtraGrid.Columns.GridColumn coldatum_zatv;
        private DevExpress.XtraGrid.Columns.GridColumn partnerIme;
        private DevExpress.XtraGrid.Columns.GridColumn Opis;
    }
}