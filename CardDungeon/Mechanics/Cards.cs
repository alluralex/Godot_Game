using CardDungeonGame.scenes.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Сохранялкагодота.Mechanics
{


    public abstract class Card
    {
        public const int Bronze = 1;
        public const int Iron = 2;
        public const int Gold = 3;
        public const int Diamond = 4;

        public const int AttackType = 1;
        public const int DefenceType = 2;
        public const int SkillType = 3;

        public string Title { get; set; }

        public string Description { get; set; }

        public int Type { get; set; }

        public int Rarity { get; set; }

        public int? EnergyCost { get; set; }

        public int? DealDamage { get; set; }

        public int? DealArmor { get; set; }

        public List<Effect> Effects { get; set; }

        public virtual void Use(Creature creature)
        {
            return;
        }
    }

    public class Warrior_SimpleAttack_Bronze : Card
    {

        public Warrior_SimpleAttack_Bronze()
        {
            Title = "Атака";
            Description = $"Наносит {DealDamage} урона";
            Type = AttackType;
            Rarity = Bronze;
            EnergyCost = 1;
            DealDamage = 8;
            DealArmor = 0;
        }
        public override void Use(Creature creature)
        {
            return;
        }
    }
    public class Warrior_SimpleDefence_Bronze : Card
    {

        public Warrior_SimpleDefence_Bronze()
        {
            Title = "Защита";
            Description = $"Даёт {DealArmor} брони";
            Type = DefenceType;
            Rarity = Bronze;
            EnergyCost = 1;
            DealDamage = 0;
            DealArmor = 6;
        }
    }

    public class Warrior_Lunge_Bronze : Card
    {

        public Warrior_Lunge_Bronze()
        {
            Title = "Защита";
            Description = $"Наносит {DealDamage} урона и оглушает противника на 1 ход";
            Type = AttackType;
            Rarity = Bronze;
            EnergyCost = 2;
            DealDamage = 6;
            DealArmor = 0;
            Effects.Add(new Stun_Effect(1));
        }
    }

    public class Warrior_FastAttack_Bronze : Card
    {

        public Warrior_FastAttack_Bronze()
        {
            Title = "Быстрая атака";
            Description = $"Наносит {DealDamage} урона, не требует энергию";
            Type = AttackType;
            Rarity = Bronze;
            EnergyCost = 0;
            DealDamage = 4;
            DealArmor = 0;
        }
    }

    public class Warrior_Anger_Bronze : Card
    {

        public Warrior_Anger_Bronze()
        {
            Title = "Ярость";
            Description = "Восстанавливает 1 энергию";
            Type = SkillType;
            Rarity = Bronze;
            EnergyCost = -1;
            DealDamage = 0;
            DealArmor = 0;
        }
    }

    public class Warrior_Dodge_Iron : Card
    {
        public Warrior_Dodge_Iron()
        {
            Title = "Уворот";
            Description = "Вы можете увернуться от 2 следующих атак";
            Type = SkillType;
            Rarity = Iron;
            EnergyCost = 1;
            DealDamage = 0;
            DealArmor = 0;
            Effects.Add(new Dodge_Effect(2));
        }
    }

    public class Warrior_ShieldStrike_Iron : Card
    {
        public Warrior_ShieldStrike_Iron()
        {
            Title = "Удар щитом";
            Description = "Вы бьёте щитом, теряете всю броню и наносите 50% от её значения";
            Type = AttackType;
            Rarity = Iron;
            EnergyCost = 1;
            //ТУТ БЕДААААА ХЗ ШО ДЕЛАТЬ)))
            DealDamage = 0;
            DealArmor = 0;
        }
    }
    public class Warrior_Cutting_Iron : Card
    {
        public Warrior_Cutting_Iron()
        {
            Title = "Разрезание";
            Description = $"Вы наносите {DealDamage} все противникам";
            Type = AttackType;
            Rarity = Iron;
            EnergyCost = 2;
            DealDamage = 12;
            DealArmor = 0;
        }
    }

    public class Warrior_Parrying_Gold : Card
    {
        public Warrior_Parrying_Gold()
        {
            Title = "Парирование";
            Description = $"Вы блокируете 75% урона и наносите противнику 25% от его атаки";
            Type = DefenceType;
            Rarity = Gold;
            EnergyCost = 2;
            DealDamage = 0;
            DealArmor = 0;
        }
    }

    public class Warrior_Scare_Gold : Card
    {
        public Warrior_Scare_Gold()
        {
            Title = "Запугивание";
            Description = $"Вы запугиваете противника на 1 ход (элитных противников с шансом 30%)";
            Type = SkillType;
            Rarity = Gold;
            EnergyCost = 1;
            DealDamage = 0;
            DealArmor = 0;
            Effects.Add(new Scare_Effect(1));
        }
    }

    public class Warrior_Berserk_Diamond : Card
    {
        public Warrior_Berserk_Diamond()
        {
            Title = "Разрезание";
            Description = $"Вы восстанавливаете всю свою энергию, но теряете всю броню";
            Type = SkillType;
            Rarity = Diamond;
            EnergyCost = 0;
            DealDamage = 0;
            DealArmor = 0;
        }
    }
}
