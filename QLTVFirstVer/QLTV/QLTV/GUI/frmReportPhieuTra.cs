using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Data.DTO;
using Data.Dtos;
using Data.DAO;
using Microsoft.Reporting.WinForms;

namespace Desktop.GUI
{
    public partial class frmReportPhieuTra : Form
    {
        public frmReportPhieuTra()
        {
            InitializeComponent();
        }
        // value
        public DateTime NgayLapBC;

        private void frmReportPhieuTra_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            this.RpvBaoCao.RefreshReport();
        }
        //Load datetime
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            NgayLapBC = dateTimePicker1.Value;
        }
    }
}
