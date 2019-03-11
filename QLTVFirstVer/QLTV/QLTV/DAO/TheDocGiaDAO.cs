using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Desktop.DTO;
using System.Data;

namespace Desktop.DAO
{
    public class TheDocGiaDAO
    {
        private static TheDocGiaDAO instance;
        public static TheDocGiaDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new TheDocGiaDAO();
                return instance;
            }
        }
        private TheDocGiaDAO() { }
        public List<TheDocGiaDTO> Xem()
        {
            List<TheDocGiaDTO> TheDocGia = new List<TheDocGiaDTO>();
            string query = "SELECT TheDocGia.IDDocGia,HoTenDG,DiaChiDG,EmailDG,UserName,NgaySinhDG,NgayLapThe,NgayHetHan,TenLoaiDG,TongNo from THEDOCGIA,LOAIDOCGIA,USERS where THEDOCGIA.IDLoaiDG = LOAIDOCGIA.IDLoaiDG and THEDOCGIA.IDDocGia=USERS.IDDocGia";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                int IDDocGia = (int)item["IDDocGia"];
                string HoTenDG = item["HoTenDG"].ToString();
                string DiaChiDG = item["DiaChiDG"].ToString();
                string EmailDG = item["EmailDG"].ToString();
                string UserName = item["UserName"].ToString();
                DateTime NgaySinhDG = (DateTime)item["NgaySinhDG"];
                DateTime NgayLapThe = (DateTime)item["NgayLapThe"];
                DateTime NgayHetHan = (DateTime)item["NgayHetHan"];
                string TenLoaiDocGia = item["TenLoaiDG"].ToString();
                decimal TongNo = (decimal)item["TongNo"];
                TheDocGiaDTO newTDG = new TheDocGiaDTO(IDDocGia, HoTenDG, UserName, DiaChiDG, EmailDG, NgaySinhDG, NgayLapThe, NgayHetHan, TenLoaiDocGia, TongNo);
                TheDocGia.Add(newTDG);
            }
            return TheDocGia;
        }
    }
}
