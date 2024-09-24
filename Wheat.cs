using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace test
{
    public class Wheat : Product
    {
        public int NumFertilizer { get; set; }
        public int NumWater { get; set; }

        public Wheat()
        {
            Cost = 10m;
            Value = 30m;
            FertilizerCost = 1m;
            WaterCost = 0.75m;
            Duration = TimeSpan.FromSeconds(10);
        }

        public override void Seed()
        {
            Start = DateTime.Now;
            Console.WriteLine($"Lúa mì đã được gieo trồng vào {Start}. Thời gian chăm bón: {Duration} giây.");
            
        }

        public override decimal Harvest()
        {
            if (DateTime.Now < Start.Add(Duration))
                throw new InvalidOperationException("Lúa mì chưa đủ thời gian để thu hoạch.");

            decimal totalFertilizerCost = NumFertilizer * FertilizerCost;
            decimal totalWaterCost = NumWater * WaterCost;
            decimal totalCost = Cost + totalFertilizerCost + totalWaterCost;

            Console.WriteLine($"Bạn đã thu hoạch lúa mì với {NumFertilizer} lần bón phân và {NumWater} lần tưới nước.");
            Console.WriteLine($"Tổng chi phí: {totalCost}. Giá trị thu hoạch: {Value}.");

            decimal profit = Value - totalCost;
            Console.WriteLine($"Lãi thu được: {profit}.");
            return profit;
        }
    }
}
