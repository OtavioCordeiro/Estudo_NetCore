﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Greetings.StartupAndMiddleware.Models
{
    public class GreetingModel
    {
        public int Id { get; set; }

        public string Message { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
