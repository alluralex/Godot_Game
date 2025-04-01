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

    public class BossDemon : Enemy
    {
        public BossDemon()
        {
            Name = "Димооон";
            MaxHealth = 150;
            CurrentHealth = MaxHealth;
            Sprite = "";
            Boss = true;
        }
    }

    public class BossFireWorm : Enemy
    {
        public BossFireWorm()
        {
            Name = "Глист подзалупный";
            MaxHealth = 250;
            CurrentHealth = MaxHealth;
            Sprite = "";
            Boss = true;
        }
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
    public class FlyingEye : Enemy
    {
        public FlyingEye()
        {
            Name = "Глаз дрочун";
            MaxHealth = 25;
            CurrentHealth = MaxHealth;
            Sprite = "";
        }
    }

    public class GolemSmall : Enemy
    {
        public GolemSmall()
        {
            Name = "Робот долбаёб";
            MaxHealth = 45;
            CurrentHealth = MaxHealth;
            Sprite = "";
        }
    }

    public class Mushroom : Enemy
    {
        public Mushroom()
        {
            Name = "Грибок гашиш";
            MaxHealth = 20;
            CurrentHealth = MaxHealth;
            Sprite = "";
        }
    }

    public class Cultist : Enemy
    {
        public Cultist()
        {
            Name = "Культист садист";
            MaxHealth= 50;
            CurrentHealth= MaxHealth;
            Sprite = "";
        }
    }

    public class EvilEye : Enemy
    {
        public EvilEye()
        {
            Name = "Глаз пидорас";
            MaxHealth = 65;
            CurrentHealth = MaxHealth;
            Sprite = "";
        }
    }

    public class Minotaur : Enemy
    {
        public Minotaur()
        {
            Name = "Тушёнка";
            MaxHealth = 75;
            CurrentHealth = MaxHealth;
            Sprite = "";
        }
    }

    public class Skeleton : Enemy
    {
        public Skeleton()
        {
            Name = "Скелетончик";
            MaxHealth = 60;
            CurrentHealth = MaxHealth;
            Sprite = "";
        }
    }

    public class SkeletonLighter : Enemy
    {
        public SkeletonLighter()
        {
            Name = "Петух солнечный";
            MaxHealth = 110;
            CurrentHealth = MaxHealth;
            Sprite = "";
            EliteEnemy = true;
        }
    }

    public class BigGolem : GolemSmall
    {
        public BigGolem()
        {
            Name = "БРАТИК ПОСТАРШЕ";
            MaxHealth = 70;
            CurrentHealth= MaxHealth;
            Sprite = "";
            EliteEnemy = true;
        }
    }

}
