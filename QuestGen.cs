using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Based_RPG
{
    class QuestGen
    {
        int questType;
        public string objType; // what the player needs to collect
        public string dialogue1; // what the quest giver say
        public string dialogue2;
        public string dialogue3;
        public int achiveAmmount; // ammout of x needed to succeed quest

        public bool InQuest = false;
        Item questItem;


        Random rd = new Random();

        public void TypeGen()
        {
            questType = rd.Next(0, 1); // sets quest type
            InQuest = true;

            if (questType == 0)
            {
                objType = "Special Rock";
                achiveAmmount = 1;
            }
            else if (questType == 1)
            {
                objType = "Pet Worm";
                achiveAmmount = 1;
            }

            dialogue1 = "Hello, I seem to have lost ";
            dialogue2 = "my " + objType + " could you";
            dialogue3 = " find it for me ?";
            GenItem();
        }

        public void GenItem()
        {
            int x = rd.Next(1, 22);
            int y = rd.Next(3, 22);

            if (questType == 0)
            {
                questItem = new Rock(7, 7);
                questItem.name = ("\"Special\" Rock" + 0.ToString());
            }
            else if (questType == 1)
            {
                questItem = new Worm(7, 7);
                questItem.name = ("Pet Worm." + 0.ToString());
            }
        }

        public void Draw(Renderer renderer, Camera camera)
        {
            if (questItem == null)
            {
                return;
            }
            else if (questItem.used == false)
            {
                renderer.Draw(questItem.x, questItem.y, questItem.avatar, camera);
            }         
        }

        public void Update(Player player, Key key, Inventory inventory)
        {
            if (questItem == null)
            {
                return;
            }
            else
            {
                questItem.OnContact(player, key, inventory);
            }           
        }

    }
}
