using CardDungeonGame.scenes.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Creatures
{
    public abstract class Enemy : Creature
    {
        public bool Boss { get; set; } = false;
        public bool EliteEnemy { get; set; }
    }
    public class Goblin : Enemy
    {
        public Goblin()
        {
            Name = "Гоблин нацист";
            MaxHealth = 30;
            CurrentHealth = MaxHealth;
            Sprite = "res://Creatures/Enemies/First_loc/Goblin/goblin.tscn";
        }
        

    }
}
