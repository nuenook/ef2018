using System;
using Animal;
using Objective;

namespace human
{
    public interface Human
    {
        void Catch(Monster obj);
        void Drive();
    }

    public class Player: Human 
    {
       
        private string _name;
        private Monster _pet;
        private Vehicle _car;

        public Player(string name, Vehicle car){
            _name = name;
            _car = car;
        }

        public void Catch(Monster pet){
            _pet = pet;
            _pet.Cry();            
            if(_pet.CanCatch())
                Console.WriteLine("gotcha !!!");
            else 
                Console.WriteLine("fail, is escape ");
        }

        public void Drive()
        {
            _car.Start();
        }
    }
}
