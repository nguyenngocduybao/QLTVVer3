using System;
using System.Windows.Forms;
using Desktop.GUI;
using DevExpress.Skins;
using DevExpress.UserSkins;
using System.Configuration;
using System.Reflection;
using System.Data.SqlClient;
namespace Desktop
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Configuration config;
            config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.ConnectionStrings.ConnectionStrings["QuanLyThuVienEntities"].ConnectionString = "metadata=res://*/Model.QuanLyThuVienEntities.csdl|res://*/Model.QuanLyThuVienEntities.ssdl|res://*/Model.QuanLyThuVienEntities.msl;provider=System.Data.SqlClient;provider connection string=&quot;"  + "MultipleActiveResultSets = True; App = EntityFramework & quot;";
            config.ConnectionStrings.ConnectionStrings["QuanLyThuVienEntities"].ProviderName = "System.Data.EntityClient";
            config.Save(ConfigurationSaveMode.Modified);

            //var DBCS = ConfigurationManager.ConnectionStrings["QuanLyThuVienEntities"];
            //var writable = typeof(ConfigurationElement).GetField("_bReadOnly", BindingFlags.Instance | BindingFlags.NonPublic);
            //writable.SetValue(DBCS, false);
            //DBCS.ConnectionString = Data.DAO.ConnectionSQL.ConSTR();
            //DBCS.ProviderName = "System.Data.SqlClient";
            //DBCS.save(ConfigurationSaveMode.Modified);
            //ConfigurationManager.ConnectionStrings["QuanLyThuVienEntities"].ConnectionString = DBCS;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            SkinManager.EnableFormSkins();
            Application.Run(new frmTheDocGia());
        }
    }
}
