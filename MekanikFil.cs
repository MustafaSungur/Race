using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yarisma
{
    class MekanikFil : Robot
    {

        public MekanikFil(string isim, int yarismaciNo, Pist yarismaPisti)
              : base(isim, yarismaciNo, yarismaPisti) { }


        public override void HareketEt()
        {
            int bozulmaOlasiligi = rng.Next(1, 101);
            if (bozulmaOlasiligi <= 2)
            {

            }
            else
            {
                int olasilik = rng.Next(1, 101);
                if (olasilik <= 10)
                {
                    Konum = Konum + 3;
                }
                if (olasilik > 10 && olasilik <= 50)
                {
                    Konum = Konum + 2;
                }
                else
                {

                }
            }


        }
    }
}
