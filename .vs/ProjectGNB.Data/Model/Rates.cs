using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectGNB.Data.Model
{
    [Keyless]
    public class Rates
    {
        
        public string From { get; set; }

        public string To { get; set; }

        public string Rate { get; set; }
    }
}
