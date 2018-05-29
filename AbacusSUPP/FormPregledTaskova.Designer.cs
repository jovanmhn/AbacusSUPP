namespace AbacusSUPP
{
    partial class FormPregledTaskova
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
            this.colnaslov = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coldatum = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.gridControl1.Size = new System.Drawing.Size(401, 289);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // taskBindingSource
            // 
            this.taskBindingSource.DataSource = typeof(AbacusSUPP.Task);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colid_task,
            this.colnaslov,
            this.coldatum});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colid_task
            // 
            this.colid_task.Caption = "ID";
            this.colid_task.FieldName = "id_task";
            this.colid_task.Name = "colid_task";
            this.colid_task.Visible = true;
            this.colid_task.VisibleIndex = 0;
            this.colid_task.Width = 47;
            // 
            // colnaslov
            // 
            this.colnaslov.Caption = "Naslov";
            this.colnaslov.FieldName = "naslov";
            this.colnaslov.Name = "colnaslov";
            this.colnaslov.Visible = true;
            this.colnaslov.VisibleIndex = 1;
            this.colnaslov.Width = 235;
            // 
            // coldatum
            // 
            this.coldatum.Caption = "Datum";
            this.coldatum.FieldName = "datum";
            this.coldatum.Name = "coldatum";
            this.coldatum.Visible = true;
            this.coldatum.VisibleIndex = 2;
            this.coldatum.Width = 123;
            // 
            // FormPregledTaskova
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 289);
            this.Controls.Add(this.gridControl1);
            this.Name = "FormPregledTaskova";
            this.Text = "FormPregledTaskova";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.taskBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.BindingSource taskBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colid_task;
        private DevExpress.XtraGrid.Columns.GridColumn colnaslov;
        private DevExpress.XtraGrid.Columns.GridColumn coldatum;
    }
}