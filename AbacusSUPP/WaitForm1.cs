using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.Utils.Drawing;
using DevExpress.XtraWaitForm;

namespace AbacusSUPP
{
    public partial class WaitForm1 : WaitForm
    {
        Color transparentColor;
        public WaitForm1()
        {
            InitializeComponent();
            this.transparentColor = Color.Magenta;
            TransparencyKey = transparentColor;
        }

        #region Overrides
        protected override void DrawContent(GraphicsCache graphicsCache, DevExpress.Skins.Skin skin)
        {
            //base.DrawContent(graphicsCache, skin);
            DrawBackground(graphicsCache);
        }
        protected override void DrawTopElement(GraphicsCache graphicsCache, DevExpress.Skins.Skin skin)
        {
            //base.DrawTopElement(graphicsCache, skin);
            DrawBackground(graphicsCache);
        }

        void DrawBackground(GraphicsCache graphicsCache)
        {
            graphicsCache.FillRectangle(graphicsCache.GetSolidBrush(transparentColor), ClientRectangle);
            //graphicsCache.DrawRectangle(graphicsCache.GetPen(Color.Black), ClientRectangle);
        }

        public override void ProcessCommand(Enum cmd, object arg)
        {
            base.ProcessCommand(cmd, arg);
        }
        #endregion

        public enum WaitFormCommand
        {
        }
    }
}