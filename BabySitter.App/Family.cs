using System;
using System.Collections.Generic;

namespace BabySitter.App 
{
    public class Family
    {

        public Family(string Id, List<PayPeriod> payPeriods)
        {
            this.Id = Id;
            this.PayPeriods = payPeriods;
        }
        
        public string Id { get; set; }

        public List<PayPeriod> PayPeriods { get; set; }
    }
}