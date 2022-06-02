using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yarisma
{
    interface IYarismaci
    {
        string Isim { get; set; }
        int Konum { get; set; }
        int YarismaciNo { get; set; }
        void HareketEt();
    }
}
