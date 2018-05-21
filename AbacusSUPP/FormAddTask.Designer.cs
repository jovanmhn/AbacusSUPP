namespace AbacusSUPP
{
    partial class FormAddTask
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAddTask));
            this.memoEdit1 = new DevExpress.XtraEditors.MemoEdit();
            this.taskbindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lookUpEdit1 = new DevExpress.XtraEditors.LookUpEdit();
            this.partneriBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lookUpEdit2 = new DevExpress.XtraEditors.LookUpEdit();
            this.statusBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lookUpEdit3 = new DevExpress.XtraEditors.LookUpEdit();
            this.prioritetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.taskbindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.partneriBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prioritetBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // memoEdit1
            // 
            this.memoEdit1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.taskbindingSource, "opis", true));
            this.memoEdit1.Location = new System.Drawing.Point(12, 69);
            this.memoEdit1.Name = "memoEdit1";
            this.memoEdit1.Size = new System.Drawing.Size(455, 277);
            this.memoEdit1.TabIndex = 3;
            // 
            // taskbindingSource
            // 
            this.taskbindingSource.DataSource = typeof(AbacusSUPP.Task);
            // 
            // lookUpEdit1
            // 
            this.lookUpEdit1.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.taskbindingSource, "id_partner", true));
            this.lookUpEdit1.Location = new System.Drawing.Point(13, 26);
            this.lookUpEdit1.Name = "lookUpEdit1";
            this.lookUpEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit1.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("naziv", "naziv", 35, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lookUpEdit1.Properties.DataSource = this.partneriBindingSource;
            this.lookUpEdit1.Properties.DisplayMember = "naziv";
            this.lookUpEdit1.Properties.NullText = "";
            this.lookUpEdit1.Properties.NullValuePrompt = "Partner";
            this.lookUpEdit1.Properties.NullValuePromptShowForEmptyValue = true;
            this.lookUpEdit1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEdit1.Properties.ValueMember = "id";
            this.lookUpEdit1.Size = new System.Drawing.Size(167, 20);
            this.lookUpEdit1.TabIndex = 0;
            // 
            // partneriBindingSource
            // 
            this.partneriBindingSource.DataSource = typeof(AbacusSUPP.Partneri);
            // 
            // lookUpEdit2
            // 
            this.lookUpEdit2.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.taskbindingSource, "status_id", true));
            this.lookUpEdit2.Location = new System.Drawing.Point(186, 26);
            this.lookUpEdit2.Name = "lookUpEdit2";
            this.lookUpEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit2.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("opis", "opis", 29, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lookUpEdit2.Properties.DataSource = this.statusBindingSource;
            this.lookUpEdit2.Properties.DisplayMember = "opis";
            this.lookUpEdit2.Properties.NullText = "";
            this.lookUpEdit2.Properties.NullValuePrompt = "Status";
            this.lookUpEdit2.Properties.NullValuePromptShowForEmptyValue = true;
            this.lookUpEdit2.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEdit2.Properties.ValueMember = "id_status";
            this.lookUpEdit2.Size = new System.Drawing.Size(186, 20);
            this.lookUpEdit2.TabIndex = 1;
            // 
            // statusBindingSource
            // 
            this.statusBindingSource.DataSource = typeof(AbacusSUPP.Status);
            // 
            // lookUpEdit3
            // 
            this.lookUpEdit3.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.taskbindingSource, "prioritet_id", true));
            this.lookUpEdit3.Location = new System.Drawing.Point(378, 26);
            this.lookUpEdit3.Name = "lookUpEdit3";
            this.lookUpEdit3.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit3.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("opis", "opis", 29, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lookUpEdit3.Properties.DataSource = this.prioritetBindingSource;
            this.lookUpEdit3.Properties.DisplayMember = "opis";
            this.lookUpEdit3.Properties.NullText = "";
            this.lookUpEdit3.Properties.NullValuePrompt = "Prioritet";
            this.lookUpEdit3.Properties.NullValuePromptShowForEmptyValue = true;
            this.lookUpEdit3.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEdit3.Properties.ValueMember = "id_prioritet";
            this.lookUpEdit3.Size = new System.Drawing.Size(186, 20);
            this.lookUpEdit3.TabIndex = 2;
            // 
            // prioritetBindingSource
            // 
            this.prioritetBindingSource.DataSource = typeof(AbacusSUPP.Prioritet);
            // 
            // simpleButton1
            // 
            this.simpleButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(473, 296);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(95, 50);
            this.simpleButton1.TabIndex = 4;
            this.simpleButton1.Text = "Dodaj";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // simpleButton2
            // 
            this.simpleButton2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton2.ImageOptions.Image")));
            this.simpleButton2.Location = new System.Drawing.Point(473, 70);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(95, 50);
            this.simpleButton2.TabIndex = 5;
            this.simpleButton2.Text = "Zatvori";
            // 
            // FormAddTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 358);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.lookUpEdit3);
            this.Controls.Add(this.lookUpEdit2);
            this.Controls.Add(this.lookUpEdit1);
            this.Controls.Add(this.memoEdit1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormAddTask";
            this.Text = "Dodaj novi task";
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.taskbindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.partneriBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.prioritetBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.MemoEdit memoEdit1;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit1;
        private System.Windows.Forms.BindingSource partneriBindingSource;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit2;
        private System.Windows.Forms.BindingSource statusBindingSource;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit3;
        private System.Windows.Forms.BindingSource prioritetBindingSource;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private System.Windows.Forms.BindingSource taskbindingSource;
    }
}