using System;

namespace DZ1
{
    class Program
    {
        public static void Main()
        {
            Unit defensiveUnit = new(25, 10, Unit.Fraction.Good, false);
            Unit attackingUnit = new(25, 10, Unit.Fraction.Good, false);

            Console.WriteLine($"Защищающийся юнит получит {GetDamageDefensiveUnit(defensiveUnit, attackingUnit)}");
        }

        public static float GetDamageDefensiveUnit(Unit defensiveUnit, Unit attackingUnit)
        {
            float damageDefensiveUnit = 0;

            float armor = defensiveUnit.BerserkState ? defensiveUnit.BaseArmor * 0.2f : defensiveUnit.BaseArmor;

            float damage = attackingUnit.BerserkState ? attackingUnit.BaseDamage * 2 : attackingUnit.BaseDamage;

            damageDefensiveUnit = damage * (1f - (armor / 100));

            if (defensiveUnit.UnitFraction != Unit.Fraction.Neutral && attackingUnit.UnitFraction != Unit.Fraction.Neutral)
                if (defensiveUnit.UnitFraction == attackingUnit.UnitFraction)
                    damageDefensiveUnit *= 0.5f;
                else if (defensiveUnit.UnitFraction != attackingUnit.UnitFraction)
                    damageDefensiveUnit += damageDefensiveUnit / 2;

            return damageDefensiveUnit;
        }
    }

    class Unit
    {
        public int BaseDamage { get; private set; }
        public int BaseArmor { get; private set; }

        public Fraction UnitFraction { get; private set; }

        public bool BerserkState { get; private set; }

        public enum Fraction
        {
            Good,
            Evil,
            Neutral
        }

        public Unit(int baseDamage, int baseArmor, Fraction unitFraction, bool berserkState)
        {
            BaseDamage = baseDamage;
            BaseArmor = baseArmor;
            UnitFraction = unitFraction;
            BerserkState = berserkState;
        }
    }
}
