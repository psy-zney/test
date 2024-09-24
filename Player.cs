using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    
    
        public class Player
        {
            public string Username { get; set; }
            public decimal Reward { get; set; }
            public List<Product> Products { get; set; }

            public Player(string username)
            {
                Username = username;
                Reward = 50m;
                Products = new List<Product>();
            }

            public void EarnReward(decimal amount)
            {
                Reward += amount;
                Console.WriteLine($"{Username} đã nhận được {amount} điểm!");
            }

            public void AddProduct(Product product)
            {
                Products.Add(product);
                Console.WriteLine($"{product.GetType().Name} đã được thêm vào trang trại của {Username}.");
            }
        }
    }

