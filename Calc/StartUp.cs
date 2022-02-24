namespace Calc
{
    using System;

    public class StartUp
    {
        private const decimal LowCountSmsPrice = 0.18m;
        private const decimal MidCountSmsPrice = 0.16m;
        private const decimal HighCountSmsPrice = 0.11m;
        private const decimal LowCountMmsPrice = 0.25m;
        private const decimal MidCountMmsPrice = 0.23m;
        private const decimal HighCountMmsPrice = 0.18m;
        private const decimal A1MinutesPrice = 0.03m;
        private const decimal OtherOperatorMinutesPrice = 0.09m;
        private const decimal RoamingMinutesPrice = 0.15m;
        private const decimal BgMbPrice = 0.02m;
        private const decimal EuMbPrice = 0.05m;
        private const decimal OutsideEuMbPrice = 0.20m;


        static void Main(string[] args)
        {
            Console.Write("Montly fee: ");
            var monthlyFee = decimal.Parse(Console.ReadLine());
            Console.Write("SMS sent: ");
            var sentSmsCount = int.Parse(Console.ReadLine());
            Console.Write("MMS sent: ");
            var sentMmsCount = int.Parse(Console.ReadLine());
            Console.Write("A1 network minutes outside package: ");
            var a1MinutesOutsidePackage = int.Parse(Console.ReadLine());
            Console.Write("Telenor network minutes outside package: ");
            var telenorMinutesOutsidePackage = int.Parse(Console.ReadLine());
            Console.Write("Vivacom network minutes outside package: ");
            var vivacomMinutesOutsidePackage = int.Parse(Console.ReadLine());
            Console.Write("Roaming (min): ");
            var roamingMinutes = int.Parse(Console.ReadLine());
            Console.Write("Mobile data used in BG (Mb): ");
            var dataInBg = int.Parse(Console.ReadLine());
            Console.Write("Mobile data used in EU (Mb): ");
            var dataInEu = int.Parse(Console.ReadLine());
            Console.Write("Mobile data used outside EU (Mb): ");
            var dataOutsideEu = int.Parse(Console.ReadLine());
            Console.Write("Other fees: ");
            var otherFees = decimal.Parse(Console.ReadLine());
            Console.Write("Discounts: ");
            var discount = decimal.Parse(Console.ReadLine());

            decimal result = 0;

            result += monthlyFee;

            decimal smsPrice = GetSmsPrice(sentSmsCount);
            result += sentSmsCount * smsPrice;

            decimal mmsPrice = GetMmsPrice(sentMmsCount);
            result += sentMmsCount * mmsPrice;

            if (a1MinutesOutsidePackage > 0)
            {
                result += a1MinutesOutsidePackage * A1MinutesPrice;
            }

            if (telenorMinutesOutsidePackage > 0)
            {
                result += telenorMinutesOutsidePackage * OtherOperatorMinutesPrice;
            }

            if (vivacomMinutesOutsidePackage > 0)
            {
                result += vivacomMinutesOutsidePackage * OtherOperatorMinutesPrice;
            }

            if (roamingMinutes > 0)
            {
                result += roamingMinutes * RoamingMinutesPrice;
            }

            if (dataInBg > 0)
            {
                result += dataInBg * BgMbPrice;
            }

            if (dataInEu > 0)
            {
                result += dataInEu * EuMbPrice;
            }

            if (dataOutsideEu > 0)
            {
                result += dataOutsideEu * OutsideEuMbPrice;
            }

            result += otherFees;
            result -= discount;

            Console.WriteLine($"Result : {result:f2}");
        }

        private static decimal GetMmsPrice(int sentMmsCount)
        {
            decimal mmsPrice;
            if (sentMmsCount < 50)
            {
                mmsPrice = LowCountMmsPrice;
            }
            else if (sentMmsCount >= 50 && sentMmsCount < 100)
            {
                mmsPrice = MidCountMmsPrice;
            }
            else
            {
                mmsPrice = HighCountMmsPrice;
            }

            return mmsPrice;
        }

        private static decimal GetSmsPrice(int sentSmsCount)
        {
            decimal smsPrice;
            if (sentSmsCount < 50)
            {
                smsPrice = LowCountSmsPrice;
            }
            else if (sentSmsCount >= 50 && sentSmsCount < 100)
            {
                smsPrice = MidCountSmsPrice;
            }
            else
            {
                smsPrice = HighCountSmsPrice;
            }

            return smsPrice;
        }
    }
}
