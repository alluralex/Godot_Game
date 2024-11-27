using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardDungeonGame.scenes.Map
{
	public class Enemy
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public int MaxHealth { get; set; }

		public int CurrentHealth { get; set; }

		public List<Card> Cards { get; set; }
	}

	public class Card
	{
		public int Id { get; set; }

		public string Title { get; set; }  = "hoho";

		public string Description { get; set; }

		public int? EnergyCost { get; set; }

		public int? DealDamage { get; set; }

		public int? DealArmor { get; set; }

	}
}
