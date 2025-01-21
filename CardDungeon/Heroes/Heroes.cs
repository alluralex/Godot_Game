using CardDungeonGame.scenes.Map;
using Godot;
using System;
using System.Collections.Generic;
using Сохранялкагодота.Mechanics;

public partial class Heroes : Node
{
    public const int Warrior_C = 1;
    public const int Mage_C = 2;
    public const int Archer_C = 3;

    public class Hero : Creature
    {
        public int Class { get; set; }
        public int MaxEnergy { get; set; }
        public int CurrentEnergy { get; set; }
        public int Gold {  get; set; }
        public Hero()
        {
            MaxEnergy = 3;
            CurrentEnergy = MaxEnergy;
            Effects = new List<Effect>();
            CurrentArmor = 0;
            
        }
    }
    public class Warrior : Hero
    {
        public Warrior()
        {
            Name = "Мечник";
            MaxHealth = 65;
            CurrentHealth = MaxHealth;
            Cards = new List<Card> { };
            Class = Warrior_C;
            
            Sprite = "warrior";
        }

    }
    public class Archer : Hero
    {
        public Archer()
        {
            Name = "Лучник";
            MaxHealth = 45;
            CurrentHealth = MaxHealth;
            Cards = new List<Card> { };
            Class = Archer_C;
        }
    }
    public class Mage : Hero
    {
        public Mage()
        {
            Name = "Маг";
            MaxHealth = 30;
            CurrentHealth = MaxHealth;
            Cards = new List<Card> { };
            Class = Mage_C;
        }
    }
}
