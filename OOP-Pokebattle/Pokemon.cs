using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Text;

namespace OOP_Pokebattle
{
    /*enum EnergyType
    {
        Fire,
        Lightning,
        Earth,
        Fighting
    }*/
    class Pokemon
    {
        private string _name;
        private string _energyType;
        private int _hitPoints;
        private int _maxHitPoints;
        private List<Attack> _attacks;
        private Weakness _weakness;
        private Resistance _resistance;
        static string battleResult;
        static List<Pokemon> alivePopulation;
        static List<Pokemon> deadPopulation;

        public Pokemon(string name, string energyType, int hitPoints, List<Attack> attacks, Weakness weakness, Resistance resistance)
        {
            this._name = name;
            this._energyType = energyType;
            this._hitPoints = hitPoints;
            this._maxHitPoints = this._hitPoints;
            this._attacks = new List<Attack>(attacks);
            this._weakness = weakness;
            this._resistance = resistance;
            if (alivePopulation == null)
            {
                alivePopulation = new List<Pokemon>();
            }
            if (deadPopulation == null)
            {
                deadPopulation = new List<Pokemon>();
            }
            alivePopulation.Add(this);
        }

        public string Name
        {
            get { return this._name; }
        }

        public static int GetPopulation()
        {
            return alivePopulation.Count;
        }

        public static string ReturnBattle()
        {
            string result = battleResult;
            battleResult = "";
            return result;
        }

        public void AttackPokemon(Pokemon target, string attackName)
        {
            // If ATTACKING pokemon is alive
            if (alivePopulation.Find(x => x == this) != null)
            {
                Attack attack = this._attacks.Find(x => x.Name == attackName);

                battleResult += (this._name + " attacks " + target.Name + " with " + attack.Name + "\n");

                // If Defending pokemon is alive
                if (alivePopulation.Find(x => x == target) != null)
                {
                    target.TakeDamage(attack);
                } 
                else
                {
                    battleResult += ("STOP, STOP!!! " + target.Name + " is already dead!\n");
                }
            } 
            else
            {
                battleResult += ("X_X\n");
            }
        }

        public void TakeDamage(Attack attack)
        {
            int attackDamage = 0;
            int initHealth = this._hitPoints;

            // If attack energytype equals pokemon weakness
            if (attack.EnergyType == this._weakness.EnergyType)
            {
                battleResult += ("It was very effective!\n");
                attackDamage = Convert.ToInt32(attack.AttackPoints * this._weakness.Multiplier);
            }
            // If attack energytype equals pokemon resistance
            else if (attack.EnergyType == this._resistance.EnergyType) 
            {
                battleResult += ("It was not very effective...\n");
                attackDamage = Convert.ToInt32(attack.AttackPoints - this._resistance.DamageReduction);
            }
            else
            {
                attackDamage = attack.AttackPoints;
            }

            // Deal damage
            this._hitPoints -= attackDamage;

            battleResult += (this._name + " has taken " + attackDamage + " points of damage!\n");

            // If this pokemon has died from the attack
            if (this._hitPoints <= 0)
            {
                Pokemon thisPokemon = alivePopulation.Find(x => x.Name.Contains(this._name));
                
                // Make pokemon dead
                alivePopulation.Remove(thisPokemon);
                deadPopulation.Add(thisPokemon);

                this._hitPoints = 0;
                battleResult += (this._name + " has " + initHealth + " -> " + this._hitPoints + " health left!\n\n");
                battleResult += (this._name + " has died!\n");
            } 
            else
            {
                battleResult += (this._name + " has " + initHealth + " -> " + this._hitPoints + " health left!\n\n");
            }
        }
    }
}
