using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsTask
{
    
        public class PaymentRecord
        {
            public int Id { get; set; }
            public int OrderId { get; set; }
            public decimal Amount { get; set; }
            // Other properties as needed
        }

        public class PaymentRecordManager
        {
            private List<PaymentRecord> paymentRecords;

            public PaymentRecordManager()
            {
                paymentRecords = new List<PaymentRecord>();
            }

            public void Add(PaymentRecord paymentRecord)
            {
                paymentRecords.Add(paymentRecord);
            }

            public void Update(PaymentRecord paymentRecord)
            {
                // Implement update logic
            }

            public void Remove(PaymentRecord paymentRecord)
            {
                paymentRecords.Remove(paymentRecord);
            }
        }
    }


