using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AbacusSUPP
{
    static class Program
    {
        internal static FormMain MainForm { get; set; }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            SkinManager.EnableFormSkins();
            SkinManager.EnableMdiFormSkins();
            DevExpress.UserSkins.BonusSkins.Register();
            Application.Run(new FormLogin());
            SkinManager.EnableFormSkins();
            SkinManager.EnableMdiFormSkins();
            //WindowsFormsSettings.AllowHoverAnimation = DevExpress.Utils.DefaultBoolean.True;
            //WindowsFormsSettings.AllowPixelScrolling = DevExpress.Utils.DefaultBoolean.True;
            //WindowsFormsSettings.AnimationMode = AnimationMode.EnableAll;
            //WindowsFormsSettings.ForceDirectXPaint();
            
            //UserLookAndFeel.Default.SetSkinStyle(SkinStyle.Bezier);
            //UserLookAndFeel.Default.SetSkinStyle(SkinSvgPalette.Bezier.OfficeColorful);
        }
    }
}
