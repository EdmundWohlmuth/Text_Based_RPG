using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Based_RPG
{   
    class Quest
    {
        private ConsoleKey input;
        bool onGoingQuest = false;

        public void Update(HUD hud, Player player, Inventory inventory)
        {
            hud.QuestGiverUI(player);
            QuestOptions(player, inventory);
            AcceptQuest(player, inventory);
        }

        public void QuestOptions(Player player, Inventory inventory)
        {
            input = Console.ReadKey(true).Key;

            switch (input)
            {
                case ConsoleKey.E:
                    ExitQuest(player);
                    break;
                case ConsoleKey.D1:
                    AcceptQuest(player, inventory);
                    break;
                case ConsoleKey.D2:
                    ReturnQuest();
                    break;
            }
        }

        // ----------------------- Quest Options ------------------- \\
        public void ExitQuest(Player player)
        {
            player.inQuest = false;
        }

        public void AcceptQuest(Player player, Inventory inventory)
        {
            if (onGoingQuest == false)
            {
                inventory.QuestInfo(player);
                player.inQuest = false;
            }
            else return; // put some text here about already having a quest instead of return
            
        }

        public void ReturnQuest()
        {
            if (onGoingQuest == true)
            {

            }
            else return; // put some stuff here about not having a quest at the momment
        }
    }
}
