using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Based_RPG
{   
    //TODO:
    // Finish up in ReturnQuest()
    // make it so that the quest is completed and pays out
    // remove item name from inventory

    class Quest
    {
        private ConsoleKey input;

        public void Update(HUD hud, Player player, Inventory inventory, QuestGen questGen)
        {
            hud.QuestGiverUI(player, questGen);           
            QuestOptions(player, inventory, questGen, hud);
        }

        public void QuestOptions(Player player, Inventory inventory, QuestGen questGen, HUD hud)
        {
            input = Console.ReadKey(true).Key;

            if (questGen.InQuest == false)
            {
                switch (input)
                {
                    case ConsoleKey.E:
                        ExitQuest(player);
                        break;
                    case ConsoleKey.D1:
                        AcceptQuest(player, inventory, questGen);
                        break;
                }
            }
            else if (questGen.InQuest == true)
            {
                switch (input)
                {
                    case ConsoleKey.E:
                        ExitQuest(player);
                        break;
                }
            }
        }

        // ----------------------- Quest Options ------------------- \\
        public void ExitQuest(Player player)
        {
            player.inQuest = false;
        }

        public void AcceptQuest(Player player, Inventory inventory, QuestGen questGen)
        {
            if (questGen.InQuest == false)
            {
                questGen.TypeGen();
            }
            else return; // put some text here about already having a quest instead of return
            
        }

        public void ReturnQuest(Player player, Inventory inventory, QuestGen questGen)
        {
            if (questGen.InQuest == true && questGen.questItem.obtained)
            {
                inventory.PlayerInventory.Remove(questGen.questItem);                
            }
            else return; // put some stuff here about not having a quest at the momment
        }
    }
}
