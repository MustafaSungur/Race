using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yarisma
{
    abstract class Hayvan : IYarismaci
    {
        private int konum;
        private string isim;
        protected Random rng = new Random();
        private int yarismaciNo;
        protected Pist yarismaPisti;

        public string Isim
        {
            get
            {
                return isim;
            }
            set
            {
                if (value.Length > 30)
                {
                    throw new ArgumentOutOfRangeException("Isim 30 karakterden fazla olamaz.");
                }
                isim = value;
            }
        }
        public int Konum
        {
            get
            {
                return konum;
            }
            set
            {

                if (value < 0)
                {
                    konum = 0;
                }
                else if (value >= yarismaPisti.PistUzunlugu)
                {
                    konum = (int)yarismaPisti.PistUzunlugu;
                }
                else
                    konum = value;


            }
        }
        public int YarismaciNo
        {
            get
            {
                return yarismaciNo;
            }
            set
            {
                if (value <= 0)
                {
                    throw new Exception("Yarışmacı No pozitif tam sayı olmalıdır!");
                }
                yarismaciNo = value;
            }

        }

        abstract public void HareketEt();

        public Hayvan(string isim, int yarismaciNo, Pist yarismaPisti)
        {
            Isim = isim;
            YarismaciNo = yarismaciNo;
            this.yarismaPisti = yarismaPisti;
        }
    }
}
