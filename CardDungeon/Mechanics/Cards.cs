using CardDungeonGame.scenes.Map;
using Godot;
using System;
using System.Collections.Generic;
using System.Data;
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

        public const string AttackType = "АТАКА";
        public const string DefenceType = "ЗАЩИТА";
        public const string SkillType = "НАВЫК";

        public const string Enemy = "МОНСТР";
        public const string Warrior = "ВОИН";
        public const string Mage = "МАГ";
        public const string Archer = "ЛУЧНИК";

        public string Title { get; set; }

        public string Description { get; set; }

        public string Class { get; set; }

        public string Type { get; set; }

        public string Image { get; set; }

        public int Rarity { get; set; }

        public int? EnergyCost { get; set; }

        public int? DealDamage { get; set; }

        public int? DealArmor { get; set; }

        public List<Effect>? Effects { get; set; }

        public virtual void Use(Creature dealer, Creature target)
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
            Class = Warrior;
            Image = "res://.godot/imported/Eye Beast Attack1.png-ca48308122d7c2972ce8f7fa5e913bc1.ctex";
        }
        public override void Use(Creature dealer, Creature target)
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
            Class = Warrior;
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
            Class = Warrior;
            Effects.Add(new Stun_Effect(1));
        }
        public override void Use(Creature dealer, Creature target)
        {
            if (target.CurrentArmor > 0)
            {
                for (int i = (int)DealDamage; i < target.CurrentArmor; i++)
                {
                    target.CurrentArmor--;
                    DealDamage--;
                }
            }
            target.CurrentHealth -= (int)DealDamage;
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
                Class = Warrior;
            }
            public override void Use(Creature dealer, Creature target)
            {
                target.CurrentHealth -= (int)DealDamage;
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
                Class = Warrior;
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
                Class = Warrior;
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
                Class = Warrior;
            }
            public override void Use(Creature dealer, Creature target)
            {
                target.TakeDamage((int)dealer.CurrentArmor / 2);
                dealer.CurrentArmor = 0;
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
                Class = Warrior;
            }
            public override void Use(Creature dealer, Creature target)
            {

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
                Class = Warrior;
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
                Class = Warrior;
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
                Class = Warrior;
            }
        }
    }
}
