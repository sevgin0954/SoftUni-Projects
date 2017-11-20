﻿using System.Collections.Generic;

namespace P01_BillsPaymentSystem.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public ICollection<PaymentMethod> PaymentMethods { get; set; }
    }
}
