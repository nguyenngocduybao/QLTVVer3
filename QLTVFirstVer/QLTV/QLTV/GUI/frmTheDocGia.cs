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
using Data.Dtos;
using Data.DTO;
using Data.IBUS;
using Data;
using Data.DAO;
using Data.BUS;

namespace Desktop.GUI
{
    public partial class frmTheDocGia : DevExpress.XtraEditors.XtraForm
    {
        public frmTheDocGia()
        {
            InitializeComponent();
        }
        private void frmTheDocGia_Load(object sender, EventArgs e)
        {
            dgv_DuLieu.AutoGenerateColumns = false;
            fillAllDataFromTableTheDocGia();
            TheDocGiaBUS.Instance.Xem(dgv_DuLieu);

        }
        #region Value
        public string HoTenDG;
        public string UserName;
        public string Pwd;
        public DateTime NgaySinhDG;
        public string DiaChiDG;
        public string EmailDG;
        public int IDLoaiDG;
        public DateTime NgayLapThe;
        #endregion
        #region Event Click
        private void bt_CNDL_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tb_HoTenDG.Text)) { MessageBox.Show("Không được để trống họ tên độc giả.", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning); tb_HoTenDG.Focus(); }
            else if (string.IsNullOrEmpty(tb_User.Text)) { MessageBox.Show("Không được để trống Tài khoản.", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning); tb_User.Focus(); }
            else if (string.IsNullOrEmpty(tb_Passwork.Text)) { MessageBox.Show("Không được để trống Passwork.", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning); tb_Passwork.Focus(); }
            else if (string.IsNullOrEmpty(tb_Diachi.Text)) { MessageBox.Show("Không được để trống địa chỉ.", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning); tb_Diachi.Focus(); }
            else if (string.IsNullOrEmpty(tb_Email.Text)) { MessageBox.Show("Không được để trống Email.", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning); tb_Email.Focus(); }
            else if (HelperGUI.Instance.checkIsMail(tb_Email) == false) { MessageBox.Show("Email không hợp lệ", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning); tb_Email.Focus(); }
            else if (string.IsNullOrEmpty(cb_LoaiDocGia.Text)) { MessageBox.Show("Không được để trống loại độc giả.", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning); cb_LoaiDocGia.Focus(); }
            else
            {
                try
                {
                    TheDocGiaDtos tdg = new TheDocGiaDtos();
                    UserDtos user = new UserDtos();
                    HoTenDG = HelperGUI.Instance.KiemTraHoTen(tb_HoTenDG.Text);
                    UserName = tb_User.Text;
                    Pwd = tb_Passwork.Text;
                    DiaChiDG = tb_Diachi.Text;
                    EmailDG = tb_Email.Text;
                    NgayLapThe = dt_NgayLT.Value;
                    tdg.HoTenDG = HoTenDG;
                    tdg.IDLoaiDocGia = IDLoaiDG;
                    tdg.NgayLapThe = NgayLapThe;
                    tdg.NgaySinhDG = NgaySinhDG;
                    tdg.DiaChiDG = DiaChiDG;
                    tdg.EmailDG = EmailDG;
                    user.Password = Pwd;
                    user.UserName = UserName;
                    MessageBox.Show("Thêm thành công!");
                    fillAllDataFromTableTheDocGia();
                    HelperGUI.ResetAllControls(groupControl_TTDG);
                }
                catch
                {

                }
            }
        }

        private void bt_Lamlai_Click(object sender, EventArgs e)
        {
            HelperGUI.ResetAllControls(groupControl_TTDG);
        }

        private void bt_TimKiem_Click(object sender, EventArgs e)
        {
            List<TheDocGiaDTO> ls = new List<TheDocGiaDTO>();
            if (cbb_ThongTinTimKiem.Text == "Họ và tên")
            {
               dgv_DuLieu.DataSource = ls;
            }
            else if (cbb_ThongTinTimKiem.Text=="Email")
            {
               dgv_DuLieu.DataSource = ls;
            }
            else if (cbb_ThongTinTimKiem.Text=="Địa chỉ")
            {
                dgv_DuLieu.DataSource = ls;
            }
            else if (cbb_ThongTinTimKiem.Text=="Tài khoản")
            {
                dgv_DuLieu.DataSource = ls;
            }

        }

        private void toolStripBt_Reset_Click(object sender, EventArgs e)
        {
            fillAllDataFromTableTheDocGia();
        }

        private void toolStripBt_Muon_Click(object sender, EventArgs e)
        {
            frmPhieuMuon frm = new frmPhieuMuon();
            frm.HoTenDG = dgv_DuLieu.CurrentRow.Cells["cl_HoTen"].Value.ToString();
            frm.IDLoaiDG = Int32.Parse(dgv_DuLieu.CurrentRow.Cells["cl_ID"].Value.ToString());
            frm.Show();
        }

        private void toolStrip_Tra_Click(object sender, EventArgs e)
        {
            frmPhieuTra frm = new frmPhieuTra();
            frm.HoTenDG = dgv_DuLieu.CurrentRow.Cells["cl_HoTen"].Value.ToString();
            frm.IDLoaiDG = Int32.Parse(dgv_DuLieu.CurrentRow.Cells["cl_ID"].Value.ToString());
            frm.Show();
        }

        private void toolStripBt_XuatCSV_Click(object sender, EventArgs e)
        {
            try
            {
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "csv File (.csv)|.csv|All files (.)|*.*";
                    sfd.Title = "Save an Excel File";
                    sfd.ShowDialog();

                    string DuongDan;
                    DuongDan = sfd.FileName;
                    List<TacGiaDtos> ls = new List<TacGiaDtos>();
                    DialogResult dlg = MessageBox.Show("Bạn có chắc chắn xuất CSV!!", "Thông báo!!", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if (dlg.Equals(DialogResult.OK))
                    {
                        MessageBox.Show("Xuất thành công!!", "Thông báo!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
            }
            catch
            {

            }
        }
        #endregion
        #region Event KeyPress
        private void tb_HoTenDG_KeyPress(object sender, KeyPressEventArgs e)
        {
            HelperGUI.Instance.CheckKiTu(sender, e);
        }
        #endregion
        #region getValueChanged Combobox
        private void cb_LDG_SelectedValueChanged(object sender, EventArgs e)
        {
            IDLoaiDG = HelperDAO.Instance.checkIDLoaiDGFromTenLoaiDocGia(cb_LoaiDocGia.Text);
        }
        #endregion
        #region getValueChanged Datetimepicker
        //định dạng về kểu datetimepicker
        private void dt_NgayLT_ValueChanged(object sender, EventArgs e)
        {
            NgayLapThe = dt_NgayLT.Value;
        }
        private void dt_Ngaysinh_ValueChanged(object sender, EventArgs e)
        {
            NgaySinhDG = dt_Ngaysinh.Value;
        }
        #endregion
        #region Load Data to Datagridview
        //get All data from Table dbo.TheDocGia 
        public void fillAllDataFromTableTheDocGia()
        {
            List<TheDocGiaDTO> ls = new List<TheDocGiaDTO>();
            dgv_DuLieu.DataSource = ls;
        }



        #endregion

    
    }
}