using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Desktop.HelperUI;
using System.Text.RegularExpressions;
using Desktop.DAO;

namespace Desktop.GUI
{
    public partial class frmSach : Form
    {
        public frmSach()
        {
            InitializeComponent();
        }
        SachDAO Sach_DAO = new SachDAO();
        #region Value
        public int IDSach;
        public int IDTacGia;
        public int IDDauSach;
        public DateTime NgayNhap;
        public string TenDauSach;
        public string NhaXB;
        string TenLoaiSach;
        string TenTacGia;
        public int NamXB;
        public int SoLuong;
        public decimal GiaTien;
        public decimal DonGia;
        public decimal TongTien;
        #endregion
        #region fillAllDataFromTableSach
        public void fillAllDataFromTableSach()
        {
            dgv_DuLieuSach.AutoGenerateColumns = false;
            dgv_DuLieuSach.DataSource = Sach_DAO.Load_on();
        }
        #endregion
        #region LoadSach
        private void frmSach_Load(object sender, EventArgs e)
        {
            fillAllDataFromTableSach();
        }
        #endregion
        #region Click
        private void toolStripBt_Thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripBt_Reset_Click(object sender, EventArgs e)
        {
            fillAllDataFromTableSach();
        }
        #endregion

       
    }
}
