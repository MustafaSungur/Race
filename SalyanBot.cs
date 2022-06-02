using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yarisma
{
    class SalyanBot : Robot
    {
        public SalyanBot(string isim, int yarismaciNo, Pist yarismaPisti)
        : base(isim, yarismaciNo, yarismaPisti) { }
        public override void HareketEt()
        {
            int bozulmaOlasiligi = rng.Next(1, 101);
            if (bozulmaOlasiligi <= 2)
            {

            }
            else
            {
                Konum = Konum + 1;
            }


        }
    }
}
