using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Player player = new Player("zney");
            Console.WriteLine($"Chào mừng {player.Username} đến với HarvestFarm!");

            List<Product> plantedProducts = new List<Product>();

            while (true)
            {
                Console.WriteLine($"Bạn có {player.Reward} điểm để gieo trồng.");
                Console.WriteLine("Chọn vật phẩm để gieo trồng:");
                Console.WriteLine("1. Lúa mì (10 điểm)");
                Console.WriteLine("2. Cà chua (13 điểm)");
                Console.WriteLine("3. Hoa hướng dương (15 điểm)");
                Console.WriteLine("0. Thoát");
                Console.Write("Lựa chọn của bạn :"  );

                string choice = Console.ReadLine();
                Product product = null;

                try
                {
                    switch (choice)
                    {
                        case "1":
                            if (player.Reward < 10)
                                throw new NotEnoughPointsException("Không đủ điểm để gieo trồng lúa mì.");
                            product = new Wheat();
                            break;
                        case "2":
                            if (player.Reward < 13)
                                throw new NotEnoughPointsException("Không đủ điểm để gieo trồng cà chua.");
                            product = new Tomato();
                            break;
                        case "3":
                            if (player.Reward < 15)
                                throw new NotEnoughPointsException("Không đủ điểm để gieo trồng hoa hướng dương.");
                            product = new Sunflower();
                            break;
                        case "0":
                            Console.WriteLine("Cảm ơn bạn đã chơi!");
                            return;
                        default:
                            Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng chọn lại.");
                            continue;
                    }

                    product.Seed();
                    player.AddProduct(product);
                    player.Reward -= product.Cost;
                    plantedProducts.Add(product);

                    Console.Write("Nhập số lần bón phân: ");
                    if (int.TryParse(Console.ReadLine(), out int fertilizer) && fertilizer >= 0)
                    {
                        if (product is Wheat wheat)
                            wheat.NumFertilizer = fertilizer;
                        else if (product is Tomato tomato)
                            tomato.NumFertilizer = fertilizer;
                        else if (product is Sunflower sunflower)
                            sunflower.NumFertilizer = fertilizer;
                    }

                    Console.Write("Nhập số lần tưới nước: ");
                    if (int.TryParse(Console.ReadLine(), out int water) && water >= 0)
                    {
                        if (product is Wheat wheat)
                            wheat.NumWater = water;
                        else if (product is Tomato tomato)
                            tomato.NumWater = water;
                        else if (product is Sunflower sunflower)
                            sunflower.NumWater = water;
                    }

                }
                catch (NotEnoughPointsException e)
                {
                    Console.WriteLine($"Lỗi: {e.Message}");
                }

                Console.WriteLine("Nhấn phím bất kỳ để thu hoạch sau khi thời gian chăm bón đã đủ.");
                Console.ReadKey();

                foreach (var plantedProduct in plantedProducts.ToList())
                {
                    try
                    {
                        decimal profit = plantedProduct.Harvest();
                        player.EarnReward(profit);
                        plantedProducts.Remove(plantedProduct);
                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.WriteLine($"Lỗi: {ex.Message}");
                    }
                }

                Console.ReadLine();
            }
        }
    }
}
