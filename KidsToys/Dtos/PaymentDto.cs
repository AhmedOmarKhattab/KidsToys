using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidsToys.Dtos
{
    public class PaymentDto
    {
        public int BasketId { get; set; }
        public string PaymentSucessUrl { get; set; }
        public string PaymentFailedUrl { get; set; }
    }
}
