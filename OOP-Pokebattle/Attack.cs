using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Pokebattle
{
    class Attack
    {
        private string _name;
        private int _attackPoints;
        private string _energyType;

        public Attack(string name, int attackPoints, string energyType)
        {
            this._name = name;
            this._attackPoints = attackPoints;
            this._energyType = energyType;
        }

        public string Name
        {
            get { return this._name; }
        }
        public int AttackPoints
        {
            get { return this._attackPoints; }
        }
        public string EnergyType
        {
            get { return this._energyType; }
        }
    }
}
