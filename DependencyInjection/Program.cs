using System;
using human;
using Animal;
using Objective;

namespace DependencyInjection
{
    class Program
    {
        static void Main(string[] args)
        {
            // ===== Human born =====
            Player tom = new Player("Tom", new Car("Benz"));
            Player robert = new Player("Robert", new Car("BMW"));

            Console.WriteLine("====== Animal born =====");
            Monster pika = new Pokemon("Pika");            
            Monster catfish = new Fish();
            pika.Cry();
            catfish.Cry();

            Console.WriteLine("====== turn on alll car =====");
            tom.Drive();
            robert.Drive();

            Console.WriteLine("====== try catch animal =====");
            tom.Catch(pika);
            tom.Catch(catfish);

            
        }
    }
}
