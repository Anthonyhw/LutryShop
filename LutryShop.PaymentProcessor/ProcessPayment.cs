using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LutryShop.PaymentProcessor
{
    public class ProcessPayment : IProcessPayment
    {
        public bool PaymentProcessor()
        {
            // Just a Mock
            return true;
        }
    }
}
