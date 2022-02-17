using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace StockMarket
{
    public class Investor
    {
        public List<Stock> Portfolio { get; set; }
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public decimal MoneyToInvest { get; set; }
        public string BrokerName { get; set; }
        public int Count => Portfolio.Count;

        public Investor(string name, string email, decimal moneyToInvest, string brokerName)
        {
            FullName = name;
            EmailAddress = email;
            MoneyToInvest = moneyToInvest;
            BrokerName = brokerName;
            Portfolio = new List<Stock>();
        }

        public void BuyStock(Stock stock)
        {
            if (stock.MarketCapitalization > 10000 && this.MoneyToInvest >= stock.PricePerShare)
            {
                MoneyToInvest -= stock.PricePerShare;
                Portfolio.Add(stock);
            }
        }

        public string SellStock(string companyName, decimal sellPrice)
        {
            foreach (Stock stock in Portfolio)
            {
                if (stock.CompanyName == companyName)
                {
                    if (sellPrice < stock.PricePerShare)
                    {
                        return $"Cannot sell {companyName}.";
                    }
                    else
                    {
                        Portfolio.Remove(stock);
                        return $"{companyName} was sold.";
                    }
                }
            }

            return $"{companyName} does not exist.";
        }

        public Stock FindStock(string companyName)
        {
            foreach (Stock stock in Portfolio)
            {
                if (stock.CompanyName == companyName)
                {
                    return stock;
                }
            }

            return null;
        }

        public Stock FindBiggestCompany()
        {
            if (this.Count == 0)
            {
                return null;
            }
            
            decimal max = Int32.MinValue;
            Stock saved = null;

            foreach (Stock stock in Portfolio)
            {
                if (stock.MarketCapitalization > max)
                {
                    saved = stock;
                    max = stock.MarketCapitalization;
                }
            }

            return saved;
        }

        public string InvestorInformation()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The investor {FullName} with a broker {BrokerName} has stocks:");
            foreach (Stock stock in Portfolio)
            {
                sb.AppendLine(stock.ToString());
            }

            return sb.ToString();
        }
    }
}
