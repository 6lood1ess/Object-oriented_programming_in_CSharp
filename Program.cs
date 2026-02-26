using System;
using System.Collections.Generic;

abstract class Animal {

  public string Name { get; set; }
  public int Age { get; set; }
  public string Habitat { get; set; }
  public string TypeOfFood { get; set; }
  public double Weight { get; set; }
  public double Length { get; set; }
  public double Height { get; set; }
  public string Color { get; set; }

  public Animal(string name, int age, string habitat, string typeOfFood, double weight, double length, double height, string color) {
    Name = name;
    Age = age;
    Habitat = habitat;
    TypeOfFood = typeOfFood;
    Weight = weight;
    Length = length;
    Height = height;
    Color = color;
  }

  public virtual string GetInfo() {
    return $"Name: {Name}; age: {Age} years; habitat: {Habitat};\n" +
               $"type of food: {TypeOfFood}; weight: {Weight} kg; lenght: {Length} m; height: {Height} m;\n" +
               $"color: {Color}";
  }
}

class Mammal : Animal {

  public bool HasFur { get; set; }

  public Mammal(string name, int age, string habitat, string typeOfFood, double weight, double length, double height, string color, bool hasFur): base(name, age, habitat, typeOfFood, weight, length, height, color) {
    HasFur = hasFur;
  }

  public override string GetInfo() {
    return base.GetInfo() + $"; animal type: mammal; presence of wool: {HasFur}";
  }
}

class Bird : Animal {

  public double WingSpan { get; set; }

  public Bird(string name, int age, string habitat, string typeOfFood, double weight, double length, double height, string color, double wingSpan): base(name, age, habitat, typeOfFood, weight, length, height, color) {
    WingSpan = wingSpan;
  }

  public override string GetInfo() {
    return base.GetInfo() + $"; animal type: bird; wingspan: {WingSpan}";
  }
}

class Fish : Animal {

  public string WaterType { get; set; }

  public Fish(string name, int age, string habitat, string typeOfFood, double weight, double length, double height, string color, string waterType): base(name, age, habitat, typeOfFood, weight, length, height, color) {
    WaterType = waterType;
  }

  public override string GetInfo() {
    return base.GetInfo() + $"; animal type: fish; water type: {WaterType}";
  }
}

class Reptile : Animal {

  public bool IsVenomous { get; set; }

  public Reptile(string name, int age, string habitat, string typeOfFood, double weight, double length, double height, string color, bool isVenomous): base(name, age, habitat, typeOfFood, weight, length, height, color) {
    IsVenomous = isVenomous;
  }

  public override string GetInfo() {
    return base.GetInfo() + $"; animal type: reptile; is venomous: {IsVenomous}";
  }
}

class Amphibian : Animal {

  public int SkinMoisture { get; set; }

  int minimumSkinMoisture = 15;
  int maximumSkinMoisture = 50;

  public Amphibian(string name, int age, string habitat, string typeOfFood, double weight, double length, double height, string color, int skinMoisture): base(name, age, habitat, typeOfFood, weight, length, height, color) {
    SkinMoisture = skinMoisture;
  }

  public override string GetInfo() {

    if (SkinMoisture < minimumSkinMoisture) {
      return base.GetInfo() + $"; animal type: amphibian; skin moisture: {SkinMoisture}% – dry";

    } else if (SkinMoisture > minimumSkinMoisture && SkinMoisture <= maximumSkinMoisture) {
      return base.GetInfo() + $"; animal type: amphibian; skin moisture: {SkinMoisture}% – normal";

    } else {
      return base.GetInfo() + $"; animal type: amphibian; skin moisture: {SkinMoisture}% – wet";
    }
  }
}

class ZooManager {

  private static ZooManager _instance;

  public List<Animal> animalInventory = new List<Animal> { };

  public void AddAnimalToInventory(Animal animal) {
    animalInventory.Add(animal);

    Console.WriteLine($"\nAnimal {animal.Name} added to the zoo :)");
  }

  public static ZooManager Instance {

    get {

      if (_instance == null) {
        _instance = new ZooManager();
      }

      return _instance;
    }
  }

  public void ShowAllAnimals() {

    if (animalInventory.Count == 0) {
      Console.WriteLine("There are no animals in the zoo yet :(");

      return;
    }

    string[] title = new string[] { "-=_8-8__|- OUR ANIMALS -|__8-8_=-" };
    Program.MoveTextToCenter(title);

    Console.WriteLine("");

    for (int animalIndex = 0; animalIndex < animalInventory.Count; ++animalIndex) {
      Console.WriteLine($"Animal №{animalIndex + 1}:\n\n" +
                        $"{animalInventory[animalIndex].GetInfo()}\n" +
                        "-------------------------------------------------------");
    }
  }

  public void GetAnimalByIndex(int animalIndex) {

    if (animalIndex < 0 || animalIndex >= animalInventory.Count) {
      Console.WriteLine("Wrong animal index! >:O");

      return;
    }

    Console.WriteLine($"\nAnimal №{animalIndex + 1}:\n\n" +
                      $"{animalInventory[animalIndex].GetInfo()}\n");
  }

  public void RunMainMenu() {

    bool isRunning = true;

    while (isRunning) {
      Console.WriteLine("\n\n\n\n\n\n\n");
            
      string[] mainMenuControls = new string[] {

        "- ZOO MENU -",
        "",
        "1 - show all animals",
        "---------------------",
        "2 - add new animal",
        "---------------------",
        "3 - find animal by index",
        "---------------------",
        "4 - exit"
      };
      Program.MoveTextToCenter(mainMenuControls);

      string userChoice;
      Console.Write("\n\nPlease enter the command number (1 to 4): ");
      userChoice = Console.ReadLine();

      switch (userChoice) {

        case "1": {
          Console.Clear();
          ShowAllAnimals();

          break;
        }

        case "2": {
          Console.Clear();
          CreateAnimal(this);

          break;
        }

        case "3": {
          Console.Clear();

          Console.Write("Enter animal index (1, 2, 3, etc.): ");

          if (int.TryParse(Console.ReadLine(), out int animalIndex)) {
            GetAnimalByIndex(animalIndex - 1);
          } else {
            Console.WriteLine("Incorrect animal index! >:O");
          }

          break;
        }

        case "4": {
          isRunning = false;

          break;
        }

        default: { 
          Console.WriteLine("Incorrect command number. Try again, please . . .");

          break;
        }
      }

      if (isRunning) {
        Console.Write("\nEnter any key to return to the main menu: ");
        Console.ReadKey();
        Console.Clear();
      }
    }
  }

  
  public void CreateAnimal(ZooManager zoo) {

    Console.WriteLine("\n\n\n\n\n\n\n");

    string[] addingMenuControls = new string[] {

      "+ SELECT ANIMAL TYPE +",
      "",
      "1 - mammal",
      "---------------------",
      "2 - bird",
      "---------------------",
      "3 - fish",
      "---------------------",
      "4 - reptile",
      "---------------------",
      "5 - amphibian"
    };
    Program.MoveTextToCenter(addingMenuControls);

    string[] commandNumbers = new string[] { "1", "2", "3", "4", "5" };

    string userChoice;
    Console.Write("\n\nEnter the command number: ");
    userChoice = Console.ReadLine();

    bool isValidChoice = false;
        
    for (int index = 0; index < commandNumbers.Length; ++index) {

      if (userChoice == commandNumbers[index]) {
        isValidChoice = true;

        break;
      }
    }

    if (isValidChoice == false) {
      Console.WriteLine("Incorrect command number! >:O");

      return;

    } else {
      Console.Clear();

      string name;
      int age;
      string habitat;
      string typeOfFood;
      double weight, length, height;
      string color;

      Console.Write("\nName: ");
      name = Console.ReadLine();

      Console.Write("\nAge: ");
      age = Convert.ToInt32(Console.ReadLine());

      Console.Write("\nHabitat: ");
      habitat = Console.ReadLine();

      Console.Write("\nType of food (carnivore, herbivore, omnivore): ");
      typeOfFood = Console.ReadLine();

      while (typeOfFood != "carnivore" && typeOfFood != "herbivore" && typeOfFood != "omnivore") {
        Console.Write("\nPlease, enter \"carnivore\", \"herbivore\" or \"omnivore\": ");
        typeOfFood = Console.ReadLine();
      }

      Console.Write("\nWeight (kg): ");
      weight = Convert.ToDouble(Console.ReadLine());

      Console.Write("\nLength (m): ");
      length = Convert.ToDouble(Console.ReadLine());

      Console.Write("\nHeight (m): ");
      height = Convert.ToDouble(Console.ReadLine());

      Console.Write("\nColor: ");
      color = Console.ReadLine();

      string userInput;

      switch (userChoice) {

        //Mammal
        case "1": {
          bool hasFur = false;

          Console.Write("\nYour animal has fur (true/false): ");
          userInput = Console.ReadLine();

          while (userInput != "true" && userInput != "false") {
            Console.Write("\nPlease, enter \"true\" or \"false\": ");
            userInput = Console.ReadLine();
          }

          if (userInput == "true") {
            hasFur = true;
          }

          zoo.AddAnimalToInventory(new Mammal(name, age, habitat, typeOfFood, weight, length, height, color, hasFur));

          break;
        }

        //Bird
        case "2": {
          double wingSpan;
          Console.Write("\nWingspan (m): ");
          wingSpan = Convert.ToDouble(Console.ReadLine());

          zoo.AddAnimalToInventory(new Bird(name, age, habitat, typeOfFood, weight, length, height, color, wingSpan));

          break;
        }

        //Fish
        case "3": {
          string waterType;
          Console.Write("\nWater type (fresh/salt): ");
          waterType = Console.ReadLine();

          while (waterType != "fresh" && waterType != "salt") {
            Console.Write("\nPlease, enter \"fresh\" or \"salt\": ");
            waterType = Console.ReadLine();
          }

          zoo.AddAnimalToInventory(new Fish(name, age, habitat, typeOfFood, weight, length, height, color, waterType));

          break;
        }

        //Reptile
        case "4": {
          bool isVenomous = false;

          Console.Write("\nYour animal is venomous (true/false): ");
          userInput = Console.ReadLine();

          while (userInput != "true" && userInput != "false") {
            Console.Write("\nPlease, enter \"true\" or \"false\": ");
            userInput = Console.ReadLine();
          }

          if (userInput == "true") {
            isVenomous = true;
          }

          zoo.AddAnimalToInventory(new Reptile(name, age, habitat, typeOfFood, weight, length, height, color, isVenomous));

          break;
        }

        //Amphibian
        case "5": {
          int skinMoisture;
          Console.Write("\nSkin moisture (%): ");
          skinMoisture = Convert.ToInt32(Console.ReadLine());

          zoo.AddAnimalToInventory(new Amphibian(name, age, habitat, typeOfFood, weight, length, height, color, skinMoisture));

          break;
        }
      }
    }
  }

  public void CreateDemoAnimals() {

    Console.WriteLine("\nAdded demo animals:");

    AddAnimalToInventory(new Mammal("Nick Wilde", 3, "forests, steppes, deserts, tundra", "omnivorous", 6.0, 0.9, 0.4, "red", true));
    AddAnimalToInventory(new Bird("Golubchik", 2, "city", "omnivorous", 0.3, 0.32, 0.2, "gray", 0.72));
    AddAnimalToInventory(new Fish("Nemo", 3, "warm tropical waters", "omnivorous", 0.05, 0.11, 0.04, "orange", "salt"));
    AddAnimalToInventory(new Reptile("Rango", 2, "steppes", "predator", 0.015, 0.15, 0.015, "green", false));
    AddAnimalToInventory(new Amphibian("Naveen", 2, "forest, meadow, swamp", "predator", 0.025, 0.08, 0.04, "green", 80));
  }
}

class Program {

  static void Main() {

    string[] goodbyeMessage = new string[] { "Goodbye! Thanks for visiting our zoo!" };

    ZooManager zoo = ZooManager.Instance;

    DisplayLogo();
    Console.Write("\n\n\n\n\nEnter to start . . .");
    Console.ReadKey();
    Console.Clear();

    zoo.CreateDemoAnimals();
    zoo.RunMainMenu();

    Console.Clear();

    MoveTextToCenter(goodbyeMessage);
  }

  public static void MoveTextToCenter(string[] text) {

    int width, padding;

    width = Console.WindowWidth;

    for (int lineIndex = 0; lineIndex < text.Length; ++lineIndex) {
      padding = (width - text[lineIndex].Length) / 2;

      Console.WriteLine(text[lineIndex].PadLeft(padding + text[lineIndex].Length).PadRight(width));
    }
  }

  static void DisplayLogo() {

    Console.WriteLine("\n\n\n\n\n");

    string[] logo = new string[] {

      "-.*+.:@%= .. =@@:..*",
      "@%.+@@-:@@@@=.=.*@@..#=",
      ".%@*.#@@@::@@@+.#@*.:%@=",
      "-@@@@@@%=:#@#.-@@@=.+@#.:-*@@% --%@@@@@@:",
      "%@= ...-%@@:....:-%@=.%=.:....-@@%= ...+@#",
      "@@= ...-@= .. =@@% *%@+:.#@##%@%-..+@:...+@%",
      "*@% ..:...... %@@@@@@@@@@@@@@*.....::.. %@+",
      "*:.=%#.-@@@@@@@@@@@@@@@@@@@@@@:.##-.-#",
      "+@@@@*.- *@@@@@@@@@@@@@@@@@@@@@@*:.*@@@@=",
      "+@@@% -...=@@@%@@@@@@@@@@@@@@@@#@@@-...-%@@@=",
      "=@@#:*@%..@@@%...*@@@@@@@@@@=..:@@@%..%@*:#@@=",
      "+@-=@@@-..:@@@@@@#-@@@@@@@@-%@@@@@@...-@@@==@+",
      "-= *@@@+....#@@@@@@@@@@@@@@@@@@@@@@=....+@@@*=-",
      ":@@@+:-...:%@@@@@@@@@@@@@@@@@@@@#....-:+@@@:",
      "+@@#-@@:*=..:**@@+@@@@@@@@*@@+*:..-+.@@-#@@+",
      "+@@:#@@-=@*..=@@#..........@@@:..*@=-@@#:@@+",
      "%%.@@@:+@@:.:=#@@@=....+@@%*=:.:@@+:@@@.%%",
      ":.@@@.%@@:.:= +#%@@@-=@@@%*+-:.:@@#.%@@::",
      "%@#.@@@:..:=*%@@%:-%@@%*=:..:@@@.*@%",
      "=@*:@@@:.+....:=#@@*=:....*.-@@@:*@=",
      ":*.@@@=.@@-.*@@@@@@@@=.-@@.=@@@.*:",
      ".@@%.+@@@*..*@@+.:+@@@+.%@@:",
      "+@#.=@@@@*....*@@@@=.#@+",
      "-#@@%..@@@#-",
      ".:::-"
    };
    MoveTextToCenter(logo);    
  }
}