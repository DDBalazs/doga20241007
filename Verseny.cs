using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace doga20241007
{
    internal class Verseny
    {
        public string Nev {  get; set; }
        public int Szuletesiev {  get; set; }
        public int Rajtszam {  get; set; }
        public string Nem {  get; set; }
        public string Korcsoport { get; set; }
        public Dictionary<string, TimeSpan> Idoadatok = new Dictionary<string, TimeSpan>();

        public override string ToString()
        {
            return
                $"\tnev: {Nev}\n" +
                $"\tszuletesi ev: {Szuletesiev}\n" +
                $"\trajtszama: {Rajtszam}\n" +
                $"\tneme {Nem}\n" +
                $"\tkorcsoport: {Korcsoport}\n" +
                $"\tidoadatai: \n" +
                $"\t{Idoadatok["uszasido"]}\n" +
                $"\t{Idoadatok["elsodepo"]}\n" +
                $"\t{Idoadatok["kerekpar"]} \n" +
                $"\t{Idoadatok["masodikdepo"]}\n" +
                $"\t{Idoadatok["futasido"]}\n";
        }
        public Verseny(string row)
        {
            var v = row.Split(';');
            Nev = v[0];
            Szuletesiev = int.Parse(v[1]);
            Rajtszam = int.Parse(v[2]);
            Nem = v[3];
            Korcsoport = v[4];
            Idoadatok.Add("uszasido", TimeSpan.Parse(v[5]));
            Idoadatok.Add("elsodepo", TimeSpan.Parse(v[6]));
            Idoadatok.Add("kerekpar", TimeSpan.Parse(v[7]));
            Idoadatok.Add("masodikdepo", TimeSpan.Parse(v[8]));
            Idoadatok.Add("futasido", TimeSpan.Parse(v[9]));
        }
    }
}
