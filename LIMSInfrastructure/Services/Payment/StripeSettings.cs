﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LIMSInfrastructure.Services.Payment
{
    public class StripeSettings
    {
        public string StripeSecretKey { get; set; }
        public string StripePublishableKey { get; set; }
    }
}
