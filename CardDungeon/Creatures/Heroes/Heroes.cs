using CardDungeonGame.scenes.Map;
using Godot;
using System;
using System.Collections.Generic;
using Game.Mechanics;

public class Hero : Creature
{
	public const int Warrior_C = 1;
	public const int Mage_C = 2;
	public const int Archer_C = 3;
	public int Class { get; set; }
	public int MaxEnergy { get; set; }
	public int CurrentEnergy { get; set; }
	public int Gold { get; set; }
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
		Cards = new()
			{
				new Warrior_SimpleAttack_Bronze(),
				new Warrior_Lunge_Bronze(),
				new Warrior_SimpleDefence_Bronze(),
				new Warrior_SimpleDefence_Bronze(),
				new Warrior_SimpleDefence_Bronze()
			};
		Class = Warrior_C;

		Sprite = "res://Creatures/Heroes/Warrior/warrior_hero_good.tscn";

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

		Sprite = "res://Creatures/Heroes/Archer/hero_archer.tscn";
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

		Sprite = "res://Creatures/Heroes/Mage/hero_mage.tscn";
	}

}
