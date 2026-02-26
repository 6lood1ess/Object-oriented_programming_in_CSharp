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

  public Mammal(string name, int age, string habitat, string typeOfFood, double weight, double length, double height, string color, bool presenceOfWool): base(name, age, habitat, typeOfFood, weight, length, height, color) {

    HasFur = presenceOfWool;
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

    ZooManager zoo = ZooManager.Instance;

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

      string choice;
      Console.Write("\n\nPlease enter the command number (1 to 4): ");
      choice = Console.ReadLine();

      switch (choice) {

        case "1": {

          Console.Clear();
          zoo.ShowAllAnimals();
          break;
        }

        case "2": {

          Console.Clear();
          CreateAnimal(zoo);
          break;
        }

        case "3": {

          Console.Clear();

          Console.Write("Enter animal index (1, 2, 3, etc.): ");

          if (int.TryParse(Console.ReadLine(), out int animalIndex)) {

            zoo.GetAnimalByIndex(animalIndex - 1);
          } else {

            Console.WriteLine("Incorrect animal index! >:O");
          }

          break;
        }

        case "4": {

          isRunning = false;
          break;

        default:
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

  }

  public void CreateDemoAnimals() {

  }
}