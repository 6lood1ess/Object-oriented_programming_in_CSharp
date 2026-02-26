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