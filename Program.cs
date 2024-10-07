using doga20241007;
using System.Text;

List<Verseny> versenyek = [];

StreamReader sr = new StreamReader(@"..\..\..\src\forras.txt", encoding: System.Text.Encoding.UTF8);

while (!sr.EndOfStream)
{
    versenyek.Add(new Verseny(sr.ReadLine()));
}

Console.WriteLine($"{versenyek.Count} db versenyző fejezte be a versenyt");

//select nev.Count from Verseny where korcsopport = 25-29
var f2 = versenyek.Count(v => v.Korcsoport == "25-29");
Console.WriteLine($"{f2} darab versenyző van a 25-29 közötti korcsoportban.");

var f3 = versenyek.Average(p => p.Szuletesiev);
Console.WriteLine($"{f3} az átlag életkor");

double f4 = Math.Round(versenyek.Sum(p => p.Idoadatok["kerekpar"].TotalHours),2);
Console.WriteLine($"{f4} az uszással töltött idő");

var f5a =  versenyek.Where(p => p.Korcsoport == "elit");
double f5b = f5a.Average(p => p.Idoadatok["uszasido"].TotalSeconds);
Console.WriteLine($"{f5b} az átlagos úszási idő elit kategóriában");

var ferfi = versenyek.Where(p => p.Nem == "f");
var f6 = ferfi.MinBy(p => p.Idoadatok.Sum(x => x.Value.TotalSeconds));
Console.WriteLine($"{f6} férfi győztes van");

var f7a = versenyek.GroupBy(p => p.Korcsoport);
foreach(var kategoria in f7a)
{
    Console.WriteLine($"{kategoria.Key}: {kategoria.Count()}");
    Console.WriteLine($"Átlagos depóban töltött idő: {kategoria.Average(p => p.Idoadatok["elsodepo"].TotalSeconds + p.Idoadatok["masodikdepo"].TotalSeconds)}");
}
