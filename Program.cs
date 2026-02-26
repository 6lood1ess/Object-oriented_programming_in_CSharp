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
