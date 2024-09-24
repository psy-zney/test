using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    public abstract class Product
    {
        public decimal Cost { get; set; }
        public decimal Value { get; set; }
        public DateTime Start { get; set; }
        public TimeSpan Duration { get; set; }
        public decimal FertilizerCost { get; set; }
        public decimal WaterCost { get; set; }

        public abstract void Seed();
        public abstract decimal Harvest();
    }
}
