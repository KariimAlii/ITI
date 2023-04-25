using Lab1.Validators;
using System.ComponentModel.DataAnnotations;

namespace Lab1.Models
{
    public class Car
    {
        [Range(1,100,ErrorMessage = "{0} must be between {1} and {2}")] // => {name},{minimum},{maximum}
        public int Id { get; set; }
        [StringLength(50,MinimumLength = 5 , ErrorMessage = "{0} Length must be between {2} and {1}")] // => {name},{maximum},{minimum}
        public string Name { get; set; }
        public string Model { get; set; }
        public double Price { get; set; }
        [DateInPast(ErrorMessage = "Production Date Must be in past")]
        public DateTime ProductionDate { get; set; }
        public string Type { get; set;}

        public Car (int id, string name, string model, double price)
        {
            Id = id;
            Name = name;
            Model = model;
            Price = price;
        }
        private static List<Car> Cars = new List<Car>()
        {
            new Car(1,"BMW","Land Cruiser",150000),
            new Car(1,"Mercedes","Magiver",120000),
            new Car(1,"Toyota","Rav 4",100000),
            new Car(1,"Mistsubishi","Pajero",200000)
        };
        //public static List<Car> GetCars() { return Cars; }
        public static List<Car> GetCars() => Cars;
    }
}
