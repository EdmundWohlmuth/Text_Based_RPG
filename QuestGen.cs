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
        public string enemyType; // enemy needed to engage with
        public string dialogue; // what the quest giver says
        public int achiveAmmount; // ammout of x needed to succeed quest

        Random rd = new Random();

        public void TypeGen()
        {
            rd.Next(0, 2); // sets quest type

            if (questType == 0)
            {
                enemyType = "Spaz";
                achiveAmmount = 0;
            }
            else if (questType == 1)
            {
                enemyType = "Tracker";
                achiveAmmount = 0;
            }
            else if (questType == 2)
            {

            }
        }
    }
}
