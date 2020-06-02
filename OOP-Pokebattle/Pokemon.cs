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

        // Every property except the name is private
        public string Name
        {
            get { return this._name; }
        }

        // Return amount of pokemon that are alive
        public static int GetPopulation()
        {
            return alivePopulation.Count;
        }

        // Attack another pokemon
        public void AttackPokemon(Pokemon target, string attackName)
        {
            // If ATTACKING pokemon is alive
            if (alivePopulation.Find(x => x == this) != null)
            {
                // Get attack object with 'attackName' given as function param
                Attack attack = this._attacks.Find(x => x.Name == attackName);

                Console.WriteLine(this._name + " attacks " + target.Name + " with " + attack.Name);

                // If TARGET pokemon is alive
                if (alivePopulation.Find(x => x == target) != null)
                {
                    target.TakeDamage(attack);
                } 
                else // If not alive, signal user to stop being such a terrible person
                {
                    Console.WriteLine("STOP, STOP!!! " + target.Name + " is already dead!\n");
                }
            } 
            else // If not alive, play dead
            {
                Console.WriteLine("X_X\n");
            }
        }

        // Handles damage calculations
        public void TakeDamage(Attack attack)
        {
            int attackDamage = 0;
            int initHealth = this._hitPoints;

            // If attack energytype equals pokemon weakness
            if (attack.EnergyType == this._weakness.EnergyType)
            {
                Console.WriteLine("It was very effective!");

                // Multiply attack's attack damage by weakness's multiplier
                attackDamage = Convert.ToInt32(attack.AttackPoints * this._weakness.Multiplier);
            }
            // If attack energytype equals pokemon resistance
            else if (attack.EnergyType == this._resistance.EnergyType) 
            {
                Console.WriteLine("It was not very effective...");

                // Lower attack's damage by the resistance's damage reduction
                attackDamage = Convert.ToInt32(attack.AttackPoints - this._resistance.DamageReduction);
            }
            else // If no weakness or resistance is detected
            {
                attackDamage = attack.AttackPoints;
            }

            // Deal damage
            this._hitPoints -= attackDamage;

            Console.WriteLine(this._name + " has taken " + attackDamage + " points of damage!");

            // If this pokemon has died from the attack
            if (this._hitPoints <= 0)
            {
                // Find this pokemon in the alive population and remove it from there
                Pokemon thisPokemon = alivePopulation.Find(x => x.Name.Contains(this._name));
                alivePopulation.Remove(thisPokemon);

                // Make pokemon dead
                deadPopulation.Add(thisPokemon);

                // In case the pokemon has a negative amount of hitpoints after the attack, put it to zero
                this._hitPoints = 0;
                Console.WriteLine(this._name + " has " + initHealth + " -> " + this._hitPoints + " health left!");
                Console.WriteLine(this._name + " has died!\n");
            } 
            else // If this pokemon is still alive, resume as normal
            {
                Console.WriteLine(this._name + " has " + initHealth + " -> " + this._hitPoints + " health left!\n");
            }
        }
    }
}
