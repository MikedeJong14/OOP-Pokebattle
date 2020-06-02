using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Pokebattle
{
    class Resistance
    {
        private string _energyType;
        private int _damageReduction;

        public Resistance(string energyType, int damageReduction)
        {
            this._energyType = energyType;
            this._damageReduction = damageReduction;
        }

        public string EnergyType
        {
            get { return this._energyType; }
        }
        public float DamageReduction
        {
            get { return this._damageReduction; }
        }
    }
}
