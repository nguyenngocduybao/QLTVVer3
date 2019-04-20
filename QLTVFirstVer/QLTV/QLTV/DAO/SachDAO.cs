using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.DAO
{
    class SachDAO
    {
        #region LoadSach
        public DataTable Load_on()
        {
            DataTable table;
            string Lenh = "select S.*,T.TenTacGia,D.TenDauSach,L.TenLoaiSach,C.DonGia,ThanhTien from Sach as S,TacGia as T,DauSach as D,LoaiSach as L,CT_PHIEUNHAPSACH as C where S.IDTacGia = T.IDTacGia and D.IDLoaiSach = L.IDLoaiSach and D.IDDauSach = S.IDDauSach and S.IDSach = C.IDSach";
            table = ConnectionSQL.TaoBang(Lenh);
            return table;
        }
        #endregion
    }
}
