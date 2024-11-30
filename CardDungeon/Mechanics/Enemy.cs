using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Сохранялкагодота.Mechanics;

namespace CardDungeonGame.scenes.Map
{
    public abstract class Creature
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int MaxHealth { get; set; }

        public int? CurrentArmor { get; set; }


        public int CurrentHealth { get; set; }

        public List<Card> Cards { get; set; }

        public List<Effect> Effects { get; set; }

        public void TakeDamage(int damage)
        {
            Dodge_Effect find = (Dodge_Effect)Effects.FirstOrDefault(s => s.Title == "Увернуться");
            if (find != null)
            {
                find.DodgeScore--;
            }
            if (CurrentArmor > 0)
            {
                for (int i = damage; i < CurrentArmor; i++)
                {
                    CurrentArmor--;
                    damage--;
                }
            }
            CurrentHealth -= damage;
        }
    }

    public class Hero : Creature
    {
        public int Class { get; set; }
    }

    public class Enemy : Creature
    {
        //public bool Boss { get; set; } = false;
    }
}
