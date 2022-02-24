namespace OffersDb
{
    using OffersDb.Models;
    using System;
    using System.IO;

    public class StartUp
    {
        private const string FilePath = @"./offers.csv";
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines(FilePath);

            var db = new OffersDbContext();
            db.Database.EnsureCreated();

            for (int i = 1; i < lines.Length; i++)
            {
                var properties = lines[i].Split(",", StringSplitOptions.RemoveEmptyEntries);

                DateTime date;
                DateTime.TryParse(properties[0], out date);

                var currentOffer = new Offer
                {
                    Date = date,
                    Number = properties[1],
                    DialedNumber = properties[2],
                    Service = properties[3],
                    Quantity = int.Parse(properties[4]),
                    Price = decimal.Parse(properties[5]),
                };
                db.Add(currentOffer);

            }
            db.SaveChanges();
        }
    }
}
