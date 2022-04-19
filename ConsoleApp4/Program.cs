namespace MyApp // Note: actual namespace depends on the project name.
{
    class Petshop
    {
        Animal[] Animals;
        private int count = 0;
        private int Price { get; set; }
        private int Food { get; set; }
        public void Newanimal(Animal animal)
        {
            if (Animals == null) Animals = new Animal[] { animal };
            else Animals = Animals.Append(animal).ToArray();
            count++;
        }
        private int Allfood()
        {
            foreach (var Animal in Animals) Food += Animal.MealQuantity;
            return Food;
        }
        private int AllPrice()
        {

            foreach (var Animal in Animals) Price += Animal.Price;
            return Price;
        }
        public void Remove(string AnimalNmae)
        {
            for (int i = 0; i < Animals.Length; i++)
            {
                if (Animals[i].Name == AnimalNmae)
                {

                    for (int j = i; j < Animals.Length - 1; j++)
                    {
                        Animals[j] = Animals[j + 1];
                    }
                    Array.Resize(ref Animals, Animals.Length - 1);
                    return;
                }
            }
            Console.WriteLine("No Name");
        }
        public void Select()
        {
            int number = 0;
            Console.WriteLine("Enter (LeftArrow && RightArrow && click Enter to select)");
            while (Animals != null)
            {
                ConsoleKeyInfo selec = Console.ReadKey();
                Console.Clear();
                if (selec.Key == ConsoleKey.RightArrow && number == 0) number = Animals.Length - 1;
                else if (selec.Key == ConsoleKey.LeftArrow && number == Animals.Length - 1) number = 0;
                else if (selec.Key == ConsoleKey.LeftArrow) number++;
                else if (selec.Key == ConsoleKey.RightArrow) number--;
                else if (selec.Key == ConsoleKey.Enter) Start(number);
                else { Console.WriteLine("Enter (LeftArrow && RightArrow && click Enter to select)"); continue; }
                Console.ForegroundColor = ConsoleColor.DarkYellow; Console.WriteLine($"{Animals[number].ClassName()}: -> {Animals[number].Name} <-\nAnimal: {number + 1}");
                Thread.Sleep(100);
            }
        }
        public void FullEnrgy(){foreach (var Animal in Animals)Animal.Energy=100;}
        
        public void Start(int number)
        {
            int day = 1;
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                FullEnrgy();
                Console.WriteLine($"Day {day}"); Thread.Sleep(200);
                Console.WriteLine($"food consumed: {Allfood()}\nPrice: {AllPrice()}$"); Thread.Sleep(2000);
                Console.Clear();
                Animals[number].Start(); Thread.Sleep(3000);
                Console.Clear();
                day++;
            }
        }
    }
    public class Animal
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Color { get; set; }
        public int Energy { get; set; }
        public int Price { get; set; }
        public int MealQuantity { get; set; }
        public virtual string ClassName() => "Animal";
        public Animal(int age, string color, string name, int price)
        {
            Age = age;
            Color = color;
            Name = name;
            Energy = 20;
            Price = price;
        }
        public void Start()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Enter : P-Play Y-give the food");
            Thread.Sleep(2000);
            Console.Clear();
            for (int i = 0; i < 8; i++)
            {
                Console.WriteLine($"0{i}:00 \t Close(07:00)");
                Cout(); 
                Thread.Sleep(1000);
                if (Energy <= 10)
                {
                    Sleeps();
                }
                Console.Write("Enter: ");
                ConsoleKeyInfo number = Console.ReadKey();
                if (number.Key == ConsoleKey.P)Energy -= 20;
                else if (number.Key == ConsoleKey.Y)
                {
                    MealQuantity += 10;
                    Energy += (100 - Energy) / 2;
                }
                else
                {
                    Console.Clear();
                    i--;
                    continue;
                }
                Console.Clear();
            }
            Console.Clear();
        }
        public virtual void Cout()
        {
            Console.WriteLine($"Name {Name}\nColor {Color}\nAge {Age}\nPrice {Price}\nEnergy {Energy}\n");
        }
        public void Sleeps()
        {
            Energy = 100;
            MealQuantity += 10;
            Price += 55;
            Age++;
            for (int i = 0; i < 5; i++)
            {
                Console.Write("Z");
                for (int j = 0; j < 5; j++)
                {
                    Console.Write(".");
                    Thread.Sleep(250);
                }
            }
            Thread.Sleep(655);
        }
    }

    class Cat : Animal
    {
        public Cat(int age, string color, string name, int meal) : base(age, color, name, meal) { }
        public override string ClassName() => "Cat";
    }
    class Bird : Animal
    {
        public Bird(int age, string color, string name, int meal) : base(age, color, name, meal) { }
        public override string ClassName() => "Bird";
    }
    class Dog : Animal
    {
        public Dog(int age, string color, string name, int meal) : base(age, color, name, meal) { }
        public override string ClassName() => "Dog";
    }
    class Program
    {
        static void Main(string[] args)
        {
            Petshop Animalss = new Petshop();
            Animalss.Newanimal(new Dog(12, "Yellow", "Nayda", 50));
            Animalss.Newanimal(new Cat(12, "Black", "Mesi", 50));
            Animalss.Newanimal(new Bird(12, "Green and Yellow", "Zipy", 50));
           // Animalss.Remove("Nayda");
            Animalss.Select();

        }
    }
}
