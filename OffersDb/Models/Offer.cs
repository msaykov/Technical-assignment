namespace OffersDb.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Offer
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string Number { get; set; }

        public string DialedNumber { get; set; }

        public string Service { get; set; }

        public int Quantity { get; set; }

        public Decimal Price { get; set; }
    }
}
