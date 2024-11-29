using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardDungeonGame.scenes.Map
{
	public abstract class Creature
	{
        public int Id { get; set; }

        public string Name { get; set; }

        public int MaxHealth { get; set; }

        public int CurrentHealth { get; set; }

        public List<Card> Cards { get; set; }
    }

	public class Hero : Creature 
	{ 
		public int Class {  get; set; }
	}

	public class Enemy : Creature 
	{
		public bool Boss { get; set; } = false;
	}

	public class Card
	{
		public int Id { get; set; }

		public string Title { get; set; }

		public string Description { get; set; }

		public int? EnergyCost { get; set; }

		public int? DealDamage { get; set; }

		public int? DealArmor { get; set; }

	}
}
