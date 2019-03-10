using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Data.DAO;
using Desktop.HelperUI;
using Data.BUS;

namespace Desktop.GUI
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        #region Event Click
        private void btn_login_Click(object sender, EventArgs e)
        {
            if(GetDataDAO.Instance.CheckTaiKhoanAndMatKhau(tb_user.Text,tb_passwork.Text))
            {
                frmMain frm = new frmMain();
                this.Hide();
                MessageBox.Show("Đăng nhập thành công");
                frm.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Tài khoản mật khẩu không đúng!");
            }
        }
        private void tb_user_MouseClick(object sender, MouseEventArgs e)
        {
            if(tb_user.Text=="Username")
            {
                tb_user.Text = "";
            }
            if(tb_user.TabIndex==0)
            {
                tb_passwork.Text = "";
                tb_passwork.PasswordChar = '*';
            }
        }
        private void tb_passwork_MouseClick(object sender, MouseEventArgs e)
        {
            if(tb_passwork.Text=="Passwork")
            {
                tb_passwork.Text = "";
                tb_passwork.PasswordChar = '*';
            }
        }
        #endregion
        #region Event KeyDown
        private void tb_passwork_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                if (GetDataDAO.Instance.CheckTaiKhoanAndMatKhau(tb_user.Text, tb_passwork.Text))
                {
                    frmMain frm = new frmMain();
                    this.Hide();
                    MessageBox.Show("Đăng nhập thành công");
                    frm.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Tài khoản mật khẩu không đúng!");
                }
            }
        }
        #endregion

        private void frmLogin_Load(object sender, EventArgs e)
        {
        }

        #region frmConnection
        frmConnection m_Connection = null;
        //frmLogin m_FrmLogin = null;
        public void ReConnection()
        {
            MessageBox.Show("Lỗi kết nối đến cơ sở dữ liệu! Xin vui lòng thiết lập lại kết nối...", "ERROR", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            //m_Connection = new frmConnection();
            if (m_Connection == null || m_Connection.IsDisposed)
                m_Connection = new frmConnection();

            if (m_Connection.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Đã thiết lập kết nối cho lần chạy đầu tiên.\nHãy khởi động lại chương trình để thực thi kết nối!", "SUCCESSED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Restart();
            }
            else
                return;
        }
        #endregion
    }
}
