using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Data;
using Data.Dtos;
using Desktop.HelperUI;


namespace Desktop.GUI
{
    public partial class FrmThemLoaiSach : Form
    {
        public FrmThemLoaiSach()
        {
            InitializeComponent();
        }

        #region Value
        public string TenLoaiSach;
        #endregion
        #region KeyPress
        private void tb_ThemTheLoaiSach_KeyPress(object sender, KeyPressEventArgs e)
        {
            HelperGUI.Instance.CheckKiTu(sender, e);
        }
        #endregion
        #region Event Click
        #endregion

    }
}
