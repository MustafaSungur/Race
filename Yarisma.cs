using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Net.WebRequestMethods;

namespace Yarisma
{
    class Yarisma
    {
        private Pist yarismaPisti;
        private List<IYarismaci> Yarismacilar = new List<IYarismaci>();
        private Random rng = new Random();
        public Yarisma(string yarismaciDosyasiYolu, int pistUzunlugu)
        {

            yarismaPisti = new Pist(pistUzunlugu);
            StreamReader oku = new StreamReader(yarismaciDosyasiYolu);
            string metin;
            List<string> metinListe = new List<string>();




            while (!oku.EndOfStream)
            {
                metin = oku.ReadLine();
                metinListe = metin.Split(' ').ToList();


                if (metinListe[2] == "MEKANIKFIL")
                {
                    MekanikFil fil = new MekanikFil(metinListe[1], int.Parse(metinListe[0]), yarismaPisti);
                    yarismaPisti.YarismaciEkle(fil);
                    Yarismacilar.Add(fil);


                }
                if (metinListe[2] == "CAKAL")
                {
                    Cakal cakal = new Cakal(metinListe[1], int.Parse(metinListe[0]), yarismaPisti);
                    Yarismacilar.Add(cakal);
                    yarismaPisti.YarismaciEkle(cakal);
                }
                if (metinListe[2] == "SALYANBOT")
                {
                    SalyanBot salyanbot = new SalyanBot(metinListe[1], int.Parse(metinListe[0]), yarismaPisti);
                    Yarismacilar.Add(salyanbot);
                    yarismaPisti.YarismaciEkle(salyanbot);
                }
                if (metinListe[2] == "DEVEKUSU")
                {
                    DeveKusu deveKusu = new DeveKusu(metinListe[1], int.Parse(metinListe[0]), yarismaPisti);
                    Yarismacilar.Add(deveKusu);
                    yarismaPisti.YarismaciEkle(deveKusu);
                }

                metinListe.Clear();
                metin = null;

            }

        }

        public void KonumlariYazdir()
        {
            yarismaPisti.Durumuyazdir();


        }
        public void Baslat()
        {


            while (true)
            {
                int flag = 0;
                yarismaPisti.KonumGuncelle();


                for (int sıfirlama = 0; sıfirlama < Yarismacilar.Count; sıfirlama++) // Her baslat metodu kullanıldığında paralizeyi true yapar.
                {
                    if (Yarismacilar[sıfirlama] is DeveKusu)
                    {
                        DeveKusu kus = Yarismacilar[sıfirlama] as DeveKusu;
                        kus.Paralize = false;
                    }
                    if (Yarismacilar[sıfirlama] is Robot)
                    {
                        Robot robot = Yarismacilar[sıfirlama] as Robot;
                        robot.Bozuldu = false;
                    }
                }



                for (int i = 0; i < Yarismacilar.Count; i++) // Devekuşunu, salyanbotu  ve robotları bulmak için
                {
                    if (Yarismacilar[i] is DeveKusu)
                    {
                        for (int j = 0; j < Yarismacilar.Count; j++) // diğer yarışmacıların konumunu devekuşunun konumuyla karşılaştırır
                        {
                            int olasilik1 = rng.Next(1, 101);
                            if (Yarismacilar[i].Konum == Yarismacilar[j].Konum && Yarismacilar[j] is MekanikFil && (olasilik1 <= 20))
                            {

                                DeveKusu kus = Yarismacilar[i] as DeveKusu;
                                kus.Paralize = true;


                            }
                            int olasilik2 = rng.Next(1, 101);
                            if (Yarismacilar[i].Konum == Yarismacilar[j].Konum && Yarismacilar[j] is Cakal && (olasilik2 >= 50))
                            {

                                DeveKusu kus = Yarismacilar[i] as DeveKusu;
                                kus.Paralize = true;

                            }

                        }

                    }
                    if (Yarismacilar[i] is SalyanBot)
                    {

                        for (int j = 0; j < Yarismacilar.Count; j++) // diğer yarışmacıların konumunu salyanbotun konumuyla karşılaştırır
                        {
                            if (Yarismacilar[j] is SalyanBot || Yarismacilar[j] is MekanikFil) { } // robot türündeyse konumu etkilememesi için
                            else
                            {
                                int olasılık = rng.Next(1, 101);
                                if (Yarismacilar[i].Konum == Yarismacilar[j].Konum && (olasılık <= 25))
                                {
                                    Yarismacilar[j].Konum -= 1;

                                }
                            }



                        }
                    }
                    int olasilik = rng.Next(1, 101);
                    if (Yarismacilar[i] is Robot && olasilik <= 2) // Robotların bozulma olasılığı
                    {

                        Robot robot = Yarismacilar[i] as Robot;
                        robot.Bozuldu = true;

                    }


                }


                foreach (var item in Yarismacilar)
                {
                    if (item.Konum == yarismaPisti.PistUzunlugu)
                    {
                        flag = 1;
                        break;
                    }

                }
                if (flag == 1)
                {
                    break;
                }

            }




        }
    }
}
