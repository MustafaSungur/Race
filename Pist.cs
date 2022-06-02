using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
namespace Yarisma
{
    class Pist
    {

        private List<IYarismaci>[] pist;
        private int pistUzunlugu;
        public int PistUzunlugu
        {
            get { return pistUzunlugu; }
            set
            {
                if (value <= 0)
                {
                    throw new Exception("pist uzunlugu pozitif tam sayı olmalı");
                }
                pistUzunlugu = value;

            }
        }

        public Pist(int pistUzunlugu)
        {
            PistUzunlugu = pistUzunlugu;

            pist = new List<IYarismaci>[PistUzunlugu];
            for (int i = 0; i < PistUzunlugu; i++)
            {
                pist[i] = new List<IYarismaci>();
            }

        }


        public void YarismaciEkle(IYarismaci yarismaci)
        {

            pist[0].Add(yarismaci);

        }



        public void KonumGuncelle()
        {

            for (int i = 0; i < pist.Length; i++)
            {
                if (pist[i] is null)
                {
                    continue;
                }
                else
                {
                    for (int j = 0; j < pist[i].Count; j++)
                    {

                        pist[i][j].HareketEt();
                        //  Console.WriteLine(pist[i][j].Konum);
                        if (pist[i][j].Konum >= PistUzunlugu)
                        {

                        }
                        else
                        {
                            pist[pist[i][j].Konum].Add(pist[i][j]);
                            pist[i].Remove(pist[i][j]);
                        }


                    }
                }



            }
        }
        public void KonumdakiYarismaci(int konum)
        {

            for (int yariamaci = 0; yariamaci < pist[konum].Count; yariamaci++)
            {
                if (pist[konum] is null)
                {

                }
                else
                {
                    Console.Write($"{pist[konum][yariamaci].Konum,-5} ::  {pist[konum][yariamaci].YarismaciNo,-5}\t{pist[konum][yariamaci].Isim,-5}");
                    Console.WriteLine(" ");
                }
            }
        }
        public void Durumuyazdir()
        {


            Console.WriteLine("Konum\tnumara\tisim");

            for (int konumlar = 0; konumlar < PistUzunlugu; konumlar++)
            {
                KonumdakiYarismaci(konumlar);
            }

        }

    }
}
