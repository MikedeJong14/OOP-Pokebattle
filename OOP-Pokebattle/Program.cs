using System;
using System.Collections.Generic;

namespace OOP_Pokebattle
{
    class Program
    {
        static void Main(string[] args)
        {
            //pikachu
            Pikachu Pika = new Pikachu("Piet");

            //charmeleon
            Charmeleon Char = new Charmeleon("Kees");

            //battle commands
            Pika.AttackPokemon(Char, "Pika Punch");
            Char.AttackPokemon(Pika, "Flare");
            Console.WriteLine(Pokemon.GetPopulation() + " pokemon are alive\n");
            Pika.AttackPokemon(Char, "Thunderbolt");
            Char.AttackPokemon(Pika, "Earthquake");
            Console.WriteLine(Pokemon.GetPopulation() + " pokemon are alive\n");
            Pika.AttackPokemon(Char, "Electric Ring");
            Char.AttackPokemon(Pika, "Flare");
            Pika.AttackPokemon(Char, "Pika Punch");
        }
    }
}
