using System;
using System.Collections.Generic;
using System.Text;

namespace TestInfrastructure.Tools
{
    public class Operations
    {
        public decimal GetTotalWithIVA(decimal subtotal, int IVA)
        {
            return subtotal * IVA / 100;
        }
    }
}
