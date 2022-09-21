using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Based_RPG
{
    class Shop
    {
        private ConsoleKey input;
        // shop prices
        public int medkitCost = 3;
        public int powerupCost;
        public int keyCost = 15;

        public void Start()
        {

        }
        public void Update(Player player)
        {
            // update powerUp price
            powerupCost = 2 * player.damage;
        }

        public void ShopOptions(Player player, Inventory inventory, Medkit medkit, PowerUp powerUp, Key key)
        {
            input = Console.ReadKey(true).Key;
            switch (input)
            {
                case ConsoleKey.D1:
                    if (inventory.money >= medkitCost)
                    {
                        inventory.money = inventory.money - medkitCost;
                        medkit.OnBuy(player);
                    }
                    break;

                case ConsoleKey.D2:
                    if (inventory.money >= powerupCost)
                    {
                        inventory.money = inventory.money - powerupCost;
                        powerUp.OnBuy(player);
                    }
                    break;

                case ConsoleKey.D3:
                    if (inventory.money >= keyCost)
                    {
                        inventory.money = inventory.money - keyCost;
                        key.OnBuy(key, inventory);
                    }
                    break;

                case ConsoleKey.D4:
                    break;

                case ConsoleKey.E:
                    ExitShop(player);
                    break;
            }
        }

        public void ExitShop(Player player)
        {
            player.inShop = false;
        }
    }
}
