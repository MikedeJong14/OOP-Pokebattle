using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Pokebattle
{
    class Weakness
    {
        private string _energyType;
        private float _multiplier;

        public Weakness(string energyType, float multiplier)
        {
            this._energyType = energyType;
            this._multiplier = multiplier;
        }

        public string EnergyType
        {
            get { return this._energyType; }
        }
        public float Multiplier
        {
            get { return this._multiplier; }
        }

    }
}
