﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Based_RPG
{
    class HUD
    {
        public void ShowPlayerStats(Player player)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.SetCursorPosition(Console.WindowLeft +1, Console.WindowTop + 10);
            Console.Write(player.avatar + " health: " + player.health + "/" + player.maxHealth + " damage: " + player.damage + " " + "(" + player.x + "," + player.y + ")"+ "  ");
            Console.ResetColor();
        }

        public void ShowEnemyStats(Enemy enemy)
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(Console.WindowLeft +1, Console.WindowTop + 11);
            Console.Write(enemy.avatar + " "+ enemy.name + " health: " + enemy.health + "/" + enemy.maxHealth + " ");
            Console.ResetColor();
        }

        // ---------------------------------- Shop UserInterface ------------------------------ \\
        public void ShopUI(Player player, Shop shop)
        {
            if (player.inShop)
            {
                Console.SetCursorPosition(Console.WindowLeft + 13, Console.WindowTop + 0);
                Console.Write("Welcome to the Inventorium");
                Console.SetCursorPosition(Console.WindowLeft + 15, Console.WindowTop + 2);
                Console.Write("1. Health Potion: $" + shop.medkitCost);
                Console.SetCursorPosition(Console.WindowLeft + 15, Console.WindowTop + 3);
                Console.Write("2. Attack Up: $" + shop.powerupCost);
                Console.SetCursorPosition(Console.WindowLeft + 15, Console.WindowTop + 4);
                Console.Write("3. Special Key: $" + shop.keyCost);
                Console.SetCursorPosition(Console.WindowLeft + 15, Console.WindowTop + 6);
                Console.Write("Press 'E' to exit");

                Console.ResetColor();
            }
            else
            {
                Console.SetCursorPosition(Console.WindowLeft + 13, Console.WindowTop + 0);
                Console.Write("                          ");
                Console.SetCursorPosition(Console.WindowLeft + 13, Console.WindowTop + 2);
                Console.Write("                          ");
                Console.SetCursorPosition(Console.WindowLeft + 13, Console.WindowTop + 3);
                Console.Write("                          ");
                Console.SetCursorPosition(Console.WindowLeft + 13, Console.WindowTop + 4);
                Console.Write("                          ");
                Console.SetCursorPosition(Console.WindowLeft + 13, Console.WindowTop + 6);
                Console.Write("                          ");
            }
        }

        // -------------------------------- Quests UserInterface ---------------------------\\
        public void QuestGiverUI(Player player, QuestGen questGen)
        {
            if (player.inQuest && questGen.InQuest == false)              
            {
                Console.SetCursorPosition(Console.WindowLeft + 13, Console.WindowTop + 2);
                Console.Write("Hello I could use some help");
                Console.SetCursorPosition(Console.WindowLeft + 13, Console.WindowTop + 3);
                Console.Write("1. Accept Quest");
                Console.SetCursorPosition(Console.WindowLeft + 13, Console.WindowTop + 4);
                Console.Write("                 ");
                Console.SetCursorPosition(Console.WindowLeft + 13, Console.WindowTop + 6);
                Console.Write("Press 'E' to exit");
            }
            else if (questGen.InQuest == true && player.inQuest == true)
            {
                Console.SetCursorPosition(Console.WindowLeft + 13, Console.WindowTop + 2);
                Console.Write(questGen.dialogue1);
                Console.SetCursorPosition(Console.WindowLeft + 13, Console.WindowTop + 3);
                Console.Write(questGen.dialogue2);
                Console.SetCursorPosition(Console.WindowLeft + 13, Console.WindowTop + 4);
                Console.Write(questGen.dialogue3);
                Console.SetCursorPosition(Console.WindowLeft + 13, Console.WindowTop + 6);
                Console.Write("Press 'E' to exit");
            }
            else
            {
                Console.SetCursorPosition(Console.WindowLeft + 13, Console.WindowTop + 1);
                Console.Write("                             ");
                Console.SetCursorPosition(Console.WindowLeft + 13, Console.WindowTop + 2);
                Console.Write("                             ");
                Console.SetCursorPosition(Console.WindowLeft + 13, Console.WindowTop + 3);
                Console.Write("                             ");
                Console.SetCursorPosition(Console.WindowLeft + 13, Console.WindowTop + 4);
                Console.Write("                              ");
                Console.SetCursorPosition(Console.WindowLeft + 13, Console.WindowTop + 6);
                Console.Write("                             ");
            }
        }

        // ---------------------------------------- Update ------------------------------ \\
        public void Update(Player player, Shop shop)
        {
            ShowPlayerStats(player);
            ShopUI(player, shop);

        }
    }
}
