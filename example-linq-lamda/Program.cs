using System;
using System.Collections.Generic;
using System.Linq;

namespace example_linq_lamda
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int[] scores = { 90, 70, 60, 50, 40, 30, 20, 10 };

            int highScoreCount = scores.Max();
            Console.WriteLine("high: " + highScoreCount);

            double avg = scores.Average();
            Console.WriteLine("Averge: " + avg);

            List<People> peopleList = new List<People>();
            peopleList.Add(new People() { _name = "nook", _score = 70 });
            peopleList.Add(new People() { _name = "nack", _score = 60 });
            peopleList.Add(new People() { _name = "nick", _score = 50 });
            Console.WriteLine(peopleList[1]._name);
            peopleList.ForEach(eachPeople => Console.WriteLine(eachPeople._name + " " + eachPeople._score));

            int scoreIsTop = peopleList.Max(m => m._score);
            Console.WriteLine(scoreIsTop);

            //who is top score
            
            string whoIsTopScore = peopleList.Where(w => w._score == peopleList.Max(m => m._score)).Select(s => s._name).First();
            Console.WriteLine(whoIsTopScore);


            // who they are have score more than 50
            List<string> whoIsScoreMore50 = peopleList.Where(w => w._score > 50).Select(s => s._name).ToList();
            Console.WriteLine(whoIsScoreMore50);



            // print name and score order by score with asc
            var peopleASC = peopleList.OrderBy(o => o._score).ToList();



            List<Car> carList = new List<Car>();
            carList.Add(new Car() { carName = "BENZ", year = 2016, series = "se001" });
            carList.Add(new Car() { carName = "BMZ", year = 1998, series = "bm02" });
            carList.Add(new Car() { carName = "POCHE", year = 2000, series = "po55" });


            // print 2 properties, fullCarName that contain CarName and serie and year 
            var fullNameAndYearCarList = carList.Select(s => new { carFullName = s.carName + " " + s.series, s.year}).ToList();
            fullNameAndYearCarList.ForEach(eachCar => Console.WriteLine(eachCar.carFullName + " " + eachCar.year));

            Console.ReadKey();
        }


        public class People
        {
            public string _name { set; get; }
            public int _score { set; get; }

        }

        public class Car
        {
            public string carName { set; get; }
            public string series { set; get; }
            public int? year { set; get; }
        }
        
    }
}
