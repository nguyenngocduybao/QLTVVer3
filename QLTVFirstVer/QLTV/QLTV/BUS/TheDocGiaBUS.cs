using Desktop.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Desktop.DTO;
using Desktop.GUI;
using System.Data;

namespace Desktop.BUS
{
    public class TheDocGiaBUS
    {

        //private static TheDocGiaBUS instance;
        //public static TheDocGiaBUS Instance
        //{
        //    get
        //    {
        //        if (instance == null)
        //            instance = new TheDocGiaBUS();
        //        return instance;
        //    }
        //}
        //private TheDocGiaBUS() { }
        //public void Xem(DataGridView data)
        //{
        //    data.DataSource = TheDocGiaDAO.Instance.Xem();
        //}
        TheDocGiaDAO TDG_DAO = new TheDocGiaDAO();
        public bool Insert_TDG(TheDocGiaDTO TDG)
        {
            return TDG_DAO.Insert_TDG(TDG);
        }

        public bool Insert_User(UserDTO User)
        {
            return TDG_DAO.Insert_User(User);
        }

        public bool Update_TDG(TheDocGiaDTO TDG, UserDTO user)
        {
            return TDG_DAO.UpdateTheDocGia(TDG,user);
        }

        public DataTable SearchTheDocGia(string SearchTT, string NhapTT)
        {
            DataTable table;
            table = ConnectionSQL.TaoBang(TDG_DAO.Search(SearchTT, NhapTT));
            return table;
        }
    }
}
