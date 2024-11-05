using System;
using System.Collections.Generic;

namespace BankApp
{
    public class Owner
    {
        public string FuldtNavn => $"{Fornavn} {Efternavn}";
        public string Fornavn { get; }
        public string Efternavn { get; }
        public string KundeId { get; }

        public Owner(string fornavn, string efternavn, string kundeId)
        {
            Fornavn = fornavn;
            Efternavn = efternavn;
            KundeId = kundeId;
        }
    }

    public class BankAccount
    {
        private decimal saldo;
        public Owner Ejer { get; }
        public string KontoId { get; }

        public BankAccount(Owner ejer, decimal startSaldo, string kontoId)
        {
            Ejer = ejer;
            saldo = Math.Max(startSaldo, 100);
            KontoId = kontoId;
        }

        public string IndsætBeløb(decimal beløb)
        {
            if (beløb > 0) { saldo += beløb; return $"Opdateret saldo: kr. {saldo}."; }
            return "Beløbet skal være større end 0.";
        }

        public string TrækBeløb(decimal beløb)
        {
            if (beløb > 0 && beløb <= saldo) { saldo -= beløb; return $"Opdateret saldo: kr. {saldo}."; }
            return "Trækket kunne ikke gennemføres.";
        }

        public decimal VisSaldo() => saldo;
    }

    public class Program
    {
        private BankAccount konto;

        public void Start()
        {
            var actions = new Dictionary<string, Action>
            {
                { "1", OpretKonto },
                { "2", IndsætBeløb },
                { "3", TrækBeløb },
                { "4", VisSaldo },
                { "5", Afslut }
            };

            while (true)
            {
                Console.WriteLine("1: Opret konto | 2: Indsæt | 3: Træk | 4: Vis saldo | 5: Afslut");
                Console.Write("Indtast valg: ");
                string valg = Console.ReadLine();

                if (actions.ContainsKey(valg))
                {
                    actions[valg].Invoke();
                }
                else
                {
                    Console.WriteLine("Ugyldigt valg.\n");
                }
            }
        }

        private void OpretKonto()
        {
            Console.Write("Fornavn: "); string fornavn = Console.ReadLine();
            Console.Write("Efternavn: "); string efternavn = Console.ReadLine();
            Console.Write("Kunde ID (6 cifre): "); string kundeId = Console.ReadLine();
            konto = new BankAccount(new Owner(fornavn, efternavn, kundeId), 100, kundeId);
            Console.WriteLine($"Konto oprettet for {konto.Ejer.FuldtNavn}.\n");
        }

        private void IndsætBeløb()
        {
            if (konto == null) { Console.WriteLine("Opret konto først.\n"); return; }
            Console.Write("Beløb: "); decimal beløb = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine(konto.IndsætBeløb(beløb));
        }

        private void TrækBeløb()
        {
            if (konto == null) { Console.WriteLine("Opret konto først.\n"); return; }
            Console.Write("Beløb: "); decimal beløb = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine(konto.TrækBeløb(beløb));
        }

        private void VisSaldo()
        {
            if (konto == null) { Console.WriteLine("Opret konto først.\n"); return; }
            Console.WriteLine($"Saldo: {konto.VisSaldo()} kr.\n");
        }

        private void Afslut()
        {
            Console.WriteLine("Programmet afsluttes.");
            Environment.Exit(0);
        }
    }
}

