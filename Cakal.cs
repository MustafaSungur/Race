using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yarisma
{
    class Cakal : Hayvan
    {
        public Cakal(string isim, int yarismaciNo, Pist yarismaPisti)
        : base(isim, yarismaciNo, yarismaPisti) { }

        public override void HareketEt()
        {
            int olasilik = rng.Next(1, 101);

            if (yarismaPisti.PistUzunlugu < Konum)
            {
                Konum = yarismaPisti.PistUzunlugu;
            }
            if (olasilik <= 20)
            {
                if (Konum <= 0)
                {

                }
                else
                {
                    Konum = Konum - 4;
                }

            }

            if (olasilik > 20 && olasilik <= 50)
            {
                Konum = Konum + 3;
            }
            else
            {
                Konum = Konum + 2;
            }

        }
    }
}
