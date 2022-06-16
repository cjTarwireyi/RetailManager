using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailManagerDesktopUI
{
    public class ConfigHelperExt
    {
        public static decimal GetTaxRate()
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
