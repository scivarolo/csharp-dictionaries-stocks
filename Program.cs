using System;
using System.Collections.Generic;

namespace dictionaries
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string,string> stocks = new Dictionary<string, string>();
            stocks.Add("GM", "General Motors");
            stocks.Add("CAT", "Caterpillar");
            stocks.Add("AAPL", "Apple");
            stocks.Add("MSFT", "Microsoft");
            stocks.Add("GOOG", "Google");

            string GM = stocks["GM"];

            List<Dictionary<string, double>> purchases = new List<Dictionary<string, double>>();
            purchases.Add(new Dictionary<string, double>(){ {"GM", 230.21} });
            purchases.Add(new Dictionary<string, double>(){ {"AAPL", 175.23} });
            purchases.Add(new Dictionary<string, double>(){ {"MSFT", 125.24} });
            purchases.Add(new Dictionary<string, double>(){ {"GM", 220.21} });
            purchases.Add(new Dictionary<string, double>(){ {"AAPL", 145.23} });
            purchases.Add(new Dictionary<string, double>(){ {"MSFT", 145.24} });

            /*
                Define a new Dictionary to hold the aggregated purchase information.
                - The key should be a string that is the full company name.
                - The value will be the total valuation of each stock


                From the three purchases above, one of the entries
                in this new dictionary will be...
                    {"General Electric", 1217.53}

                Replace the questions marks below with the correct types.
            */

            Dictionary<string, double> stockReport = new Dictionary<string, double>();

            /*
            Iterate over the purchases and record the valuation
            for each stock.
            */
            foreach (Dictionary<string, double> purchase in purchases)
            {
                foreach (KeyValuePair<string, double> stock in purchase)
                {
                    string companyName = stocks[stock.Key];
                    double stockValue = stock.Value;

                    // Does the full company name key already exist in the `stockReport`?
                    // If it does, update the total valuation
                    if (!stockReport.ContainsKey(companyName))
                    {
                        stockReport.Add(companyName, stockValue);
                    }
                    else
                    {
                        stockReport[companyName] += stockValue;
                    }
                }
            }

            foreach (KeyValuePair<string, double> item in stockReport)
            {
                Console.WriteLine($"The position in {item.Key} is worth {item.Value}");
            }

        }
    }
}
