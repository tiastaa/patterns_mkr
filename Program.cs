using System;
//Prototype
namespace Prototype
{
    public class Replenishment
    {
        public IdInfo Id;
        public DateTime Date;
        public string Purpose;
        public double Suma;

        public Replenishment ShallowCopy()
        {
            return (Replenishment)this.MemberwiseClone();
        }

        public Replenishment DeepCopy()
        {
            Replenishment clone = (Replenishment)this.MemberwiseClone();
            clone.Id = new IdInfo(Id.IdNumber);
            clone.Purpose = String.Copy(Purpose);
            return clone;
        }
    }

    public class IdInfo
    {
        public int IdNumber;

        public IdInfo(int idNumber)
        {
            this.IdNumber = idNumber;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Replenishment p1 = new Replenishment();
            p1.Date = Convert.ToDateTime("2021-08-11");
            p1.Purpose = "food";
            p1.Id = new IdInfo(123);
            p1.Suma = 340;

            // Perform a shallow copy of p1 and assign it to p2.
            Replenishment p2 = p1.ShallowCopy();
            // Make a deep copy of p1 and assign it to p3.
            Replenishment p3 = p1.DeepCopy();

            // Display values of p1, p2 and p3.
            Console.WriteLine("Original values of p1, p2, p3:");
            Console.WriteLine("p1 instance values: ");
            DisplayValues(p1);
            Console.WriteLine("p2 instance values:");
            DisplayValues(p2);
            Console.WriteLine("p3 instance values:");
            DisplayValues(p3);


            p1.Date = Convert.ToDateTime("2012-11-09");
            p1.Purpose = "taxi";
            p1.Id.IdNumber = 564;
            p1.Suma = 765;
            Console.WriteLine("\nValues of p1, p2 and p3 after changes to p1:");
            Console.WriteLine("p1 instance values: ");
            DisplayValues(p1);
            Console.WriteLine("p2 instance values (reference values have changed):");
            DisplayValues(p2);
            Console.WriteLine("p3 instance values (everything was kept the same):");
            DisplayValues(p3);
            Console.ReadLine();
        }
        public static void DisplayValues(Replenishment p)
        {
            Console.WriteLine($"Purpose:{p.Purpose}\nDate:{p.Date}\nSuma: {p.Suma}");

            Console.WriteLine($"    ID#:{p.Id.IdNumber}");
        }
    }
}