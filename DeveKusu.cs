using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yarisma
{
    class DeveKusu : Hayvan
    {

        public DeveKusu(string isim, int yarismaciNo, Pist yarismaPisti)
         : base(isim, yarismaciNo, yarismaPisti)
        {

        }

        public bool Paralize { get; set; }

        public override void HareketEt()
        {

            if (Paralize)
            {

            }
            else
            {
                int olasilik = rng.Next(1, 101);

                if (olasilik > 0 || olasilik <= 20)
                {
                    Konum = Konum + 6;
                }
                if (olasilik > 20 || olasilik <= 50)
                {
                    if (Konum <= 0)
                    {

                    }
                    else
                    {
                        Konum = Konum - 4;
                    }


                }

                else
                {
                    Konum = Konum + 3;
                }
            }


        }
    }
}
