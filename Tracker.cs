﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Based_RPG
{
    class Tracker : Enemy
    {
        private int trackingY;
        private int trackingX;

        public Tracker()
        {
            damage = 1;
            avatar = 'T';
            health = 5;
            maxHealth = health;
            x = 5;
            y = 10;
        }

        public void CalculateMovement(Map map, Player player, Enemy enemy, Enemy enemy1)
        {

            
            if (turnCount == 2)
            {
                SaveLastPosition();
                playerHit = false;
                canMoveThere = true;

                //logic used to move toward the player
                if (trackingX > x && blockedX == false)
                {
                    deltaX = 1;
                    GetFuturePosition();
                    CheckBlockedX();
                }
                else if (trackingX < x && blockedX == false)
                {
                    deltaX = -1;
                    GetFuturePosition();
                    CheckBlockedX();
                }
                else if (trackingY > y && blockedY == false)
                {
                    deltaY = 1;
                    GetFuturePosition();
                    CheckBlockedY();
                }
                else if (trackingY < y && blockedY == false)
                {
                    deltaY = -1;
                    GetFuturePosition();
                    CheckBlockedY();
                }

                //detecting collision with solid objects
                if (map.IsObjectSolid(futureX, futureY))
                {
                    canMoveThere = false;
                }

                //detecting collision with player
                if (IsGameCharacter(this, player))
                {
                    Console.Beep(200, 33);
                    Console.Beep(100, 33);
                    player.TakeDamage(damage);
                    canMoveThere = false;
                    playerHit = true;
                    this.ShowStats(avatar);
                }

                if (IsGameCharacter(this, enemy) == true || IsGameCharacter(this, enemy1) == true)
                {
                    canMoveThere = false;
                }

                Move();
                turnCount = 0;
            }

            //updating turn count and tracking info
            turnCount++;
            trackingY = player.y;
            trackingX = player.x;
        }
    }
}
