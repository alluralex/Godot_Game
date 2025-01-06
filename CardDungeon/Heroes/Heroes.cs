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
    public class Warrior : Hero
    {
        public Warrior()
        {
            Name = "Воин";
            MaxHealth = 65;
            CurrentHealth = MaxHealth;
            CurrentArmor = 0;
            Cards = new List<Card> { new Warrior_SimpleAttack_Bronze(), new Warrior_SimpleDefence_Bronze(), new Warrior_Lunge_Bronze() };
            Effects = new List<Effect>();
            MaxEnergy = 3;
            CurrentEnergy = MaxEnergy;
            Class = Warrior_C;
        }

    }
    public class Archer : Hero
    {
        public Archer()
        {
            Name = "Лучник";
            MaxHealth = 45;
            CurrentHealth = MaxHealth;
            CurrentArmor = 0;
            Cards = new List<Card> { };
            Effects = new List<Effect>();
            MaxEnergy = 3;
            CurrentEnergy = MaxEnergy;
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
            CurrentArmor = 0;
            Cards = new List<Card> { };
            Effects = new List<Effect>();
            MaxEnergy = 3;
            CurrentEnergy = MaxEnergy;
            Class = Mage_C;
        }
    }
}
