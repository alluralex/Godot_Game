using CardDungeonGame.scenes.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace Сохранялкагодота.Mechanics
{
    public abstract class Effect
    {

        public string Title { get; set; }

        public int Duration { get; set; }
        public virtual string Use(Creature creature)
        {
            return "TestUse";
        }
    }

    public class Stun_Effect : Effect
    {
        public override string Use(Creature creature)
        {
            creature.Effects.Add(new Stun_Effect(Duration));
            return $"{creature.Name} оглушён!";
        }

        public Stun_Effect(int duration) 
        {
            Title = "Оглушение";

            Duration = duration;
        }
    }

    public class Bleeding_Effect : Effect
    {
        public override string Use(Creature creature)
        {
            creature.Effects.Add(new Bleeding_Effect(Duration));
            return $"{creature.Name} Истекает кровью!";
        }

        public Bleeding_Effect(int duration)
        {
            Title = "Кровотечение";

            Duration = duration;
        }
    }

    public class Dodge_Effect : Effect
    {
        public int DodgeScore { get; set; }
        public override string Use(Creature creature)
        {
            creature.Effects.Add(new Dodge_Effect(DodgeScore));
            return $"{creature.Name} Готовится к увороту!";
        }

        public Dodge_Effect(int score)
        {
            Title = "Увернуться";

            DodgeScore = score;
        }
    }

    public class Scare_Effect : Effect
    {
        public override string Use(Creature creature)
        {
            creature.Effects.Add(new Scare_Effect(Duration));
            return $"{creature.Name} Напуган!";
        }

        public Scare_Effect(int duration)
        {
            Title = "Испуг";

            Duration = duration;
        }
    }


}
