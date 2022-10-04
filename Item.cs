using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Based_RPG
{
    class Item : GameObject
    {
        public bool used = false;
        public string colorID;
        public bool obtained = false;
        public bool IsItemHere(GameCharacter gameCharacter)
        {
            if (gameCharacter.futureX == this.x && gameCharacter.futureY == this.y)
            {
                return true;
            }

            return false;
        }

        public virtual void OnContact(Player player, Key key, Inventory inventory)
        {

        }
    }

    class Money : Item
    {
        public Money(int posX, int posY)
        {
            x = posX;
            y = posY;
            avatar = '$';
            used = false;
            colorID = "money";
        }

        public override void OnContact(Player player, Key key, Inventory inventory)
        {
            if (IsItemHere(player) == true && used == false)
            {
                inventory.money++;
                Console.Beep(900, 80);
                used = true;
            }
        }
    }

    class Trophy : Item
    {
        public Trophy()
        {
            x = 3;
            y = 1;
            avatar = '#';
            used = false;
            obtained = false;
            colorID = "key";
        }
        public override void OnContact(Player player, Key key, Inventory inventory)
        {
            if (IsItemHere(player) == true && obtained == false)
            {
                obtained = true;
                inventory.trophy++;
            }
        }
    }


    class Medkit : Item
    {
        private Random rd = new Random();
        private int healingAmount;

        public Medkit(int posX, int PosY)
        {
            used = false;
            avatar = 'H';
            x = posX;
            y = PosY;
            colorID = "medkit";
        }

        public override void OnContact(Player player, Key key, Inventory inventory)
        {
            if (IsItemHere(player) && used == false)
            {
                healingAmount = rd.Next(3, 12);
                player.health += healingAmount;
                if (player.health > player.maxHealth) { player.health = player.maxHealth; }
                Console.Beep(400, 50);
                Console.Beep(600, 75);
                used = true;
            }
        }

        public void OnBuy(Player player)
        {
            healingAmount = rd.Next(3, 12);
            player.health += healingAmount;
            if (player.health > player.maxHealth) { player.health = player.maxHealth; }
            Console.Beep(400, 50);
            Console.Beep(600, 75);
        }
    }


    class PowerUp : Item
    {
        private int damageMultiplier;
        public PowerUp(int posX, int posY)
        {
            avatar = 'P';
            x = posX;
            y = posY;
            damageMultiplier = 2;
            used = false;
            colorID = "powerup";
        }

        public override void OnContact(Player player, Key key, Inventory inventory)
        {
            if (IsItemHere(player) == true && used == false)
            {
                player.damage = player.damage * damageMultiplier;
                used = true;
                Console.Beep(200, 80);
                Console.Beep(300, 80);
                Console.Beep(400, 80);
            }
        }

        public void OnBuy(Player player)
        {
            player.damage = player.damage * damageMultiplier;
            used = true;
            Console.Beep(200, 80);
            Console.Beep(300, 80);
            Console.Beep(400, 80);
        }
    }

    class Key : Item
    {
        public Key(int PosX, int PosY)
        {
            avatar = 'K';
            x = PosX;
            y = PosY;
            used = false;
            obtained = false;
            colorID = "key";
        }

        public override void OnContact(Player player, Key key, Inventory inventory)
        {
            if (IsItemHere(player) == true && obtained == false)
            {
                inventory.PlayerInventory.Add(key);
                obtained = true;
                colorID = "";
            }
        }

        public void OnBuy(Key key, Inventory inventory)
        {
            inventory.PlayerInventory.Add(key);
            obtained = true;
            colorID = "";
        }
    }

    class Rock : Item
    {
        public Rock(int PosX, int PosY)
        {
            avatar = '.';
            x = PosX;
            y = PosY;
            used = false;
            obtained = false;
            colorID = "";
        }

        public override void OnContact(Player player, Key key, Inventory inventory)
        {
            if (IsItemHere(player) == true && obtained == false)
            {
                inventory.PlayerInventory.Add(this);
                obtained = true;
                colorID = "";
            }
        }
    }

    class Worm : Item
    {
        public Worm(int PosX, int PosY)
        {
            avatar = '-';
            x = PosX;
            y = PosY;
            used = false;
            obtained = false;
            colorID = "";
        }

        public override void OnContact(Player player, Key key, Inventory inventory)
        {
            if (IsItemHere(player) == true && obtained == false)
            {
                inventory.PlayerInventory.Add(this);
                obtained = true;
                colorID = "";
            }
        }
    }
   
}
