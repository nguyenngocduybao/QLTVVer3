using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Desktop.DTO;

namespace Desktop.DAO
{
    class TacGiaDAO
    {
        #region LoadTacGia
        public DataTable Load_on()
        {
            DataTable table;
            string Lenh = "select * From TacGia order by IDTacGia asc";
            table = ConnectionSQL.TaoBang(Lenh);
            return table;
        }
        #endregion
        #region InsertTacGia
        public bool Insert_TG(TacGiaDTO TG)
        {
            string ID = "IDTacGia";
            string Bang = "TacGia";
            TG.IDTacGia = ConnectionSQL.Identitytable(TG.IDTacGia,ID,Bang);
            string L_Insert = "INSERT INTO TacGia VALUES ('" + TG.IDTacGia + "',N'" + TG.TenTacGia + "', '" + TG.NgaySinh + "')";
            bool table = false;
            if (ConnectionSQL.ExecuteNonQuery(L_Insert) > 0)
            {
                table = true;
            }
            return table;
        }
        #endregion
        #region UpDateTacGia
        public bool UpdateTheDocGia(TacGiaDTO TG)
        {
            string L_Update = "UPDATE TacGia SET TenTacGia = N'" + TG.TenTacGia + "', NgaySinh = '" + TG.NgaySinh + "' WHERE IDTacGia = '" + TG.IDTacGia + "'";
            bool table = false;
            if (ConnectionSQL.ExecuteNonQuery(L_Update) > 0)
            {
                table = true;
            }
            return table;
        }
        #endregion
        #region Search_TacGia
        public DataTable SearchTheDocGia(string SearchTT, string NhapTT)
        {
            DataTable table;
            string Search = "select * From TacGia where  " + SearchTT + " like '%" + NhapTT + "%' order by IDTacGia asc";
            table = ConnectionSQL.TaoBang(Search);
            return table;
        }
        #endregion
    }
}
