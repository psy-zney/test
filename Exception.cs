﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    public class NotEnoughPointsException : Exception
    {
        public NotEnoughPointsException(string message) : base(message) { }
    }

    public class EarlyHarvestException : InvalidOperationException
    {
        public EarlyHarvestException(string message) : base(message) { }
    }
}
