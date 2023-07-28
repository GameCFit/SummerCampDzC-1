using System;

namespace DZ1
{
    class Program
    {
        public static void Main()
        {
            Unit defensiveUnit = new(25, 10, Unit.Fraction.Good, true);
            Unit attackingUnit = new(25, 10, Unit.Fraction.Good, true);

            Console.WriteLine($"Защищающийся юнит получит {GetDamageDefensiveUnit(defensiveUnit, attackingUnit)}");
        }

        public static float GetDamageDefensiveUnit(Unit defensiveUnit, Unit attackingUnit)
        {
            float damageDefensiveUnit = 0;

            if (defensiveUnit.BerserkState == false && attackingUnit.BerserkState == false)
            {
                damageDefensiveUnit = attackingUnit.BaseDamage * (1f - (defensiveUnit.BaseArmor / 100));
            }
            else if (defensiveUnit.BerserkState == true && attackingUnit.BerserkState == false)
            {
                damageDefensiveUnit = attackingUnit.BaseDamage * (1f - (defensiveUnit.BaseArmor * 0.2f / 100));
            }
            else if (defensiveUnit.BerserkState == true && attackingUnit.BerserkState == true)
            {
                damageDefensiveUnit = attackingUnit.BaseDamage * 2 * (1f - (defensiveUnit.BaseArmor * 0.2f / 100));
            }
            else
            {
                damageDefensiveUnit = attackingUnit.BaseDamage * 2 * (1f - (defensiveUnit.BaseArmor / 100));
            }

            if (defensiveUnit.UnitFraction != Unit.Fraction.Neutral && attackingUnit.UnitFraction != Unit.Fraction.Neutral)
            {
                if (defensiveUnit.UnitFraction == attackingUnit.UnitFraction)
                    damageDefensiveUnit *= 0.5f;
                else if (defensiveUnit.UnitFraction != attackingUnit.UnitFraction)
                    damageDefensiveUnit += damageDefensiveUnit / 2;
            }
            return damageDefensiveUnit;
        }
    }

    class Unit
    {
        public int BaseDamage => _baseDamage;
        public int BaseArmor => _baseArmor;

        public Fraction UnitFraction => _unitFraction;

        public bool BerserkState => _berserkState;

        private int _baseDamage;
        private int _baseArmor;

        private Fraction _unitFraction;

        private bool _berserkState;

        public enum Fraction
        {
            Good,
            Evil,
            Neutral
        }

        public Unit(int baseDamage, int baseArmor, Fraction unitFraction, bool berserkState)
        {
            _baseDamage = baseDamage;
            _baseArmor = baseArmor;
            _unitFraction = unitFraction;
            _berserkState = berserkState;
        }
    }
}
