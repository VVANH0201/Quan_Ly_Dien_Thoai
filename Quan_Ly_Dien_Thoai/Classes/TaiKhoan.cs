using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_Dien_Thoai.Classes
{
    internal class TaiKhoan
    {
        private string Tentk;
        private string mk;
        private string quyen;

        public TaiKhoan()
        {

        }

        public TaiKhoan(string tentk, string mk, string quyen)
        {
            Tentk = tentk;
            this.mk = mk;
            this.quyen = quyen;
        }

        public string Tentk1 { get => Tentk; set => Tentk = value; }
        public string Mk { get => mk; set => mk = value; }
        public string Quyen { get => quyen; set => quyen = value; }
    }
}
