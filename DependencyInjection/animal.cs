using System;

namespace Animal
{
    public interface Monster {
        void Cry();
        bool CanCatch();
    }

    public class Pokemon: Monster {
        private string _name;
        public Pokemon(string name){
            _name = name;
        }

        public void Cry(){
            Console.WriteLine(_name + " says: Poke poke poke !");
        }

        public bool CanCatch(){
            Random r = new Random();
            int x= r.Next(2);
            return x == 0 ? false: true;
        }
    }

    public class Fish: Monster {
        public void Cry(){
            Console.WriteLine(" Fish says: Boo Boo Boo !");
        }

        public bool CanCatch(){
            Random r = new Random();
            int x= r.Next(2);
            return x == 0 ? false: true;
        }
    }
}
