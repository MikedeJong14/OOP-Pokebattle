using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Pokebattle
{
    class Pikachu : Pokemon
    {
        public Pikachu(string name) : base(
            name, "Fire", 100,
            new List<Attack>() {
                new Attack("Pika Punch", 20, "Fighting"),
                new Attack("Electric Ring", 30, "Lightning"),
                new Attack("Thunderbolt", 50, "Lightning")
            },
            new Weakness("Fire", 1.5F),
            new Resistance("Fighting", 20))    
        {
            
        }
    }
}
