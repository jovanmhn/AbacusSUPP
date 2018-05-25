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
            this.richEditControl1 = new DevExpress.XtraRichEdit.RichEditControl();
            this.memoEdit1 = new DevExpress.XtraEditors.MemoEdit();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.memoEdit2 = new DevExpress.XtraEditors.MemoEdit();
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit2.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // richEditControl1
            // 
            this.richEditControl1.Location = new System.Drawing.Point(12, 12);
            this.richEditControl1.Name = "richEditControl1";
            this.richEditControl1.Options.HorizontalRuler.ShowLeftIndent = false;
            this.richEditControl1.Options.HorizontalRuler.ShowRightIndent = false;
            this.richEditControl1.Options.HorizontalRuler.ShowTabs = false;
            this.richEditControl1.Options.HorizontalRuler.Visibility = DevExpress.XtraRichEdit.RichEditRulerVisibility.Hidden;
            this.richEditControl1.Options.VerticalRuler.Visibility = DevExpress.XtraRichEdit.RichEditRulerVisibility.Hidden;
            this.richEditControl1.Size = new System.Drawing.Size(847, 579);
            this.richEditControl1.TabIndex = 0;
            // 
            // memoEdit1
            // 
            this.memoEdit1.Location = new System.Drawing.Point(918, 12);
            this.memoEdit1.Name = "memoEdit1";
            this.memoEdit1.Size = new System.Drawing.Size(361, 104);
            this.memoEdit1.TabIndex = 1;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(865, 37);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(47, 49);
            this.simpleButton1.TabIndex = 2;
            this.simpleButton1.Text = "u .rtf\r\n->";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // simpleButton2
            // 
            this.simpleButton2.Location = new System.Drawing.Point(1042, 122);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(107, 31);
            this.simpleButton2.TabIndex = 3;
            this.simpleButton2.Text = "zip ";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // memoEdit2
            // 
            this.memoEdit2.Location = new System.Drawing.Point(919, 159);
            this.memoEdit2.Name = "memoEdit2";
            this.memoEdit2.Size = new System.Drawing.Size(360, 115);
            this.memoEdit2.TabIndex = 4;
            // 
            // simpleButton3
            // 
            this.simpleButton3.Location = new System.Drawing.Point(879, 368);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(75, 23);
            this.simpleButton3.TabIndex = 5;
            this.simpleButton3.Text = "Nazad";
            this.simpleButton3.Click += new System.EventHandler(this.simpleButton3_Click);
            // 
            // FormTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1291, 603);
            this.Controls.Add(this.simpleButton3);
            this.Controls.Add(this.memoEdit2);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.memoEdit1);
            this.Controls.Add(this.richEditControl1);
            this.Name = "FormTest";
            this.Text = "FormTest";
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit2.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraRichEdit.RichEditControl richEditControl1;
        private DevExpress.XtraEditors.MemoEdit memoEdit1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.MemoEdit memoEdit2;
        private DevExpress.XtraEditors.SimpleButton simpleButton3;
    }
}