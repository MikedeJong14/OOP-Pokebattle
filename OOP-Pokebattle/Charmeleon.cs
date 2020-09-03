using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Pokebattle
{
    class Charmeleon : Pokemon
    {
        public Charmeleon(string name) : base(
            name, "Lightning", 100,
            new List<Attack>() {
                new Attack("Head Butt", 10, "Fighting"),
                new Attack("Flare", 30, "Fire"),
                new Attack("Earthquake", 40, "Earth")
            },
            new Weakness("Water", 2),
            new Resistance("Lightning", 10))
        { 

        }
    }
}
