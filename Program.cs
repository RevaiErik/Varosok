using System.Text;
using Varosok;

List<Varos> varosok = new List<Varos>();
using (StreamReader be = new StreamReader(path:"../../../src/varosok.csv", encoding: Encoding.UTF8))
{
    _ = be.ReadLine();
    while (!be.EndOfStream)
    {
        varosok.Add(new Varos(be.ReadLine()));
    }
}


Console.WriteLine($"A kollekció hossza: {varosok.Count()}");
//1. feladat
Console.WriteLine($"1. feladat \n Kínai nagyvárosokban összesen {varosok.Where(o => o.Orszag == "Kína").Sum(f => f.Nepesseg):.00} millió fő él");
//2. feladat
Console.WriteLine($"2. feladat \n Az indiai nagyvárosok átlaglélekszáma: {varosok.Where(o => o.Orszag == "India").Average(f => f.Nepesseg)}");
//3. feladat
Console.WriteLine($"3. feladat \n A legnépesebb nagyváros: {varosok.OrderByDescending(f => f.Nepesseg).First().Varos_nev}");
//4. feladat
Console.WriteLine($"4. feladat \n 20M lakos feletti nagyvárosok:");
foreach (var item in varosok.Where(f => f.Nepesseg > 20).OrderByDescending(f => f.Nepesseg))
{
    Console.WriteLine($"{item.ToString()}");
}
//5. feladat
Console.WriteLine($"Országok száma, amik több nagyávárossal is szerepel a listában: {varosok.GroupBy(v => v.Orszag).Count(g => g.Count() > 1)}");
//6. feladat
int legtobbetBetuvelKezdodo = varosok.GroupBy(v => v.Varos_nev[0]).OrderByDescending(g => g.Count()).First().Count();
List<IGrouping<char,Varos>> legtobb = varosok.GroupBy(v => v.Varos_nev[0]).OrderByDescending(g => g.Count()).Where(c => c.Count()==legtobbetBetuvelKezdodo).ToList();
Console.WriteLine($"6. feladat \n A legtöbb nagyváros neve:");
foreach (var item in legtobb)
{
    Console.Write($"{item.First().Varos_nev[0]} ");
}
Console.Write("betűvel kezdődik.");