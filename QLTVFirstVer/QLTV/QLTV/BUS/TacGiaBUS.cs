using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Desktop.DTO;
using Desktop.DAO;

namespace Desktop.BUS
{
    class TacGiaBUS
    {
        private static TheDocGiaBUS instance;
        public static TheDocGiaBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new TheDocGiaBUS();
                return instance;
            }
        }
        TacGiaDAO TG_DAO = new TacGiaDAO();

        public bool Insert_TG(TacGiaDTO TG)
        {
            return TG_DAO.Insert_TG(TG);
        }

        public bool Update_TDG(TacGiaDTO TG)
        {
            return TG_DAO.UpdateTheDocGia(TG);
        }
    }
}
