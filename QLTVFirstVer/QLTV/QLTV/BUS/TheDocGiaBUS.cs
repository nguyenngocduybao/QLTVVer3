using Desktop.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop.BUS
{
    public class TheDocGiaBUS
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
        private TheDocGiaBUS() { }
        public void Xem(DataGridView data)
        {
            data.DataSource = TheDocGiaDAO.Instance.Xem();
        }

    }
}
