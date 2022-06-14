using System.Configuration;

namespace RetailManagerDesktopUI.Library.Helpers
{
    public class ConfigHelper : IConfigHelper
    {
        public decimal GetTaxRate()
        {
            string configRate = ConfigurationManager.AppSettings["taxRate"];
            bool isValid = decimal.TryParse(configRate, out decimal taxRate);
            if (!isValid)
            {
                throw new ConfigurationErrorsException("The tax rate is not set up properly");
            }
            return taxRate;
        }
    }
}
