using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Based_RPG
{
    class GameManager
    {
        public bool gameOver = false;
        public Player player;
        public Renderer renderer;
        public Map map;
        public EnemyManager enemyManager;
        public ItemManager itemManager;
        public Door door;
        public HUD hud;
        public Camera camera;
        public Inventory inventory;
        public Settings settings;
        public Shop shop;

        public Medkit medkit;
        public PowerUp powerUp;
        public Key key;

        public void InitializeGame()
        {
            //On game launch
            settings = new Settings();
            hud = new HUD();
            camera = new Camera();
            map = new Map();
            renderer = new Renderer();
            map.GetMapData(settings);
            enemyManager = new EnemyManager();
            enemyManager.CreateEnemies(map, renderer);
            itemManager = new ItemManager();
            itemManager.CreateItems(renderer, map);
            player = new Player(map);
            door = new Door();
            inventory = new Inventory();
            inventory.ShowInventory(camera);

            shop = new Shop();
            medkit = new Medkit(0,0);
            powerUp = new PowerUp(0, 0);
            key = new Key(0, 0);

            Console.CursorVisible = false;            
        }

        public void GameLoop(Player player, Renderer renderer, Map map, EnemyManager enemyManager, HUD hud, ItemManager itemManager, Door door, Camera camera, Inventory inventory)
        {
            //Game Loop
            while (!InLoseState())
            {
                player.CalculateMovement(renderer, enemyManager, hud, door);
                camera.Update(player, map);
                map.Draw(renderer, camera);
                door.Update(player, enemyManager, (Key)itemManager.items[0], inventory);
                enemyManager.Update(renderer, map, player, enemyManager, hud, door, camera);
                enemyManager.Draw(renderer, camera);
                itemManager.Update(player, (Key)itemManager.items[0], inventory);
                itemManager.Draw(renderer, camera);
                door.Draw(renderer, camera);
                player.Draw(renderer, camera);
                hud.Update(player, shop);
                inventory.Update(camera);
                shop.Update(player);
                ShopCheck();
                OnWinGame();
            }
            GameOver();
        }

        public void GameOver()
        {
            if (player.dead != true) return;
            Console.Clear();
            Console.SetCursorPosition(5, 10);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("You Died! Game Over");
            Console.ResetColor();
            Console.ReadKey(true);
        }

        public void OnWinGame()
        {
            if (inventory.trophy < 1) return;
            //Game Win
            Console.ReadKey(true);
            Console.Clear();
            Console.SetCursorPosition(5, 10);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Congratulations! You won the game!");
            Console.ResetColor();
            Console.ReadKey(true);
            System.Environment.Exit(0);
        }

        public void ShopCheck()
        {
            // runs the shop
            while (player.paused)
            {
                hud.ShopUI(player, shop);               
                shop.ShopOptions(player, inventory, medkit, powerUp, key);
                hud.Update(player, shop);
                inventory.Update(camera);
                shop.Update(player);
            }
        }

        public bool InLoseState()
        {
            if (player.dead == true)
            {
                return true;
            }
            return false;
        }

        public void LaunchGame()
        {
            InitializeGame();
            GameLoop(player, renderer, map, enemyManager, hud, itemManager, door, camera, inventory);
            GameOver();
        }
    }
}


