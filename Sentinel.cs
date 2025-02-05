﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Based_RPG
{
    class Sentinel : Enemy
    {
        public Sentinel(int posX, int posY)
        {
            damage = 2;
            avatar = 'S';
            health = 3;
            maxHealth = health;
            x = posX;
            y = posY;
        }

        public override void Draw(Renderer renderer, Camera camera)
        {
            renderer.Draw(x, y, avatar, camera);
        }

        public override void CalculateMovement(Renderer renderer, Map map, Player player, EnemyManager enemyManager, HUD hud, Door door, Camera camera)
        {
            SaveLastPosition();
            canMoveThere = true;
            if (Math.Abs(player.x - this.x) <= 3 && Math.Abs(player.y - this.y) <= 3)
            {
                if (Math.Abs(player.x - this.x) > Math.Abs(player.y - this.y) || Math.Abs(player.y - this.y) == 0)
                {
                    if (player.x > this.x)
                    {
                        deltaX = 1;
                    }
                    else
                    {
                        deltaX = -1;
                    }
                }
                else
                {
                    if (player.y > this.y)
                    {
                        deltaY = 1;
                    }
                    else
                    {
                        deltaY = -1;
                    }
                }
            }
            GetFuturePosition();

            if (renderer.IsObjectSolid(futureX, futureY, map))
            {
                canMoveThere = false;
            }

            if (IsGameCharacter(this, player))
            {
                Console.Beep(200, 33);
                Console.Beep(100, 33);
                player.TakeDamage(damage);
                hud.ShowPlayerStats(player);
                hud.ShowEnemyStats(this);
                this.canMoveThere = false;
            }

            for (int i = 0; i < enemyManager.enemies.Length; i++)
            {
                if (enemyManager.enemies[i] != null)
                {
                    if (IsGameCharacter(this, enemyManager.enemies[i]) == true && (this != enemyManager.enemies[i]))
                    {
                        canMoveThere = false;
                    }
                }
            }

            if (door.WillEntityCollide(this))
            {
                canMoveThere = false;
            }

         Move();
        }
    }
}
