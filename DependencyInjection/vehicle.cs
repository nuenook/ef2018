using System;
namespace Objective
{
    public interface Vehicle {        
        void Start();        
    }

    public class Car: Vehicle {
        private string _brand;

        public Car(string brand){
            _brand = brand;
        }

        public void Start(){
            Console.WriteLine( _brand + " !!! " + " burn burn burn");
        }
    }

}