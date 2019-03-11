using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Desktop.HelperUI;
using System.Text.RegularExpressions;
using Desktop.BUS;
using Desktop.DTO;

namespace Desktop.GUI
{
    public partial class frmTheDocGia : DevExpress.XtraEditors.XtraForm
    {
        public frmTheDocGia()
        {
            InitializeComponent();
        }
        #region Value
        //Ghi lại tất cả thuộc tính thể hiện trên frm
        public string HoTenDG;
        public string UserName;
        public string Pwd;
        public DateTime NgaySinhDG;
        public string DiaChiDG;
        public string EmailDG;
        public int IDLoaiDG;
        public DateTime NgayLapThe;
        #endregion
        #region FrmLoad
        private void frmTheDocGia_Load(object sender, EventArgs e)
        {
            dgv_DuLieu.AutoGenerateColumns = false;
            fillAllDataFromTableTheDocGia();
            TheDocGiaBUS.Instance.Xem(dgv_DuLieu);
        }
        #endregion
        #region fillAllDataFromTable
        public void fillAllDataFromTableTheDocGia()
        {
            List<TheDocGiaDTO> ls = new List<TheDocGiaDTO>();
            dgv_DuLieu.DataSource = ls;
        }
        #endregion
    }
}