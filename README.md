# Laboratory Work: Zoo Management System

## Author
Zaharov Nikita

## Objective
Mastering object-oriented programming principles in C# by creating a class hierarchy of animals and a zoo management system.

## Description
The program implements a zoo management system using an abstract base class `Animal` and five derived classes: `Mammal`, `Bird`, `Fish`, `Reptile`, and `Amphibian`. The system is built using the Singleton pattern for the `ZooManager` class, providing a single point of control for animal inventory management. Users can add animals of different types with unique characteristics, view all animals, or search for them by index through a console menu.

## Input Data
- Basic animal characteristics (common to all types):
  - Name, age, habitat, type of food, weight, length, height, color
- Type-specific characteristics:
  - Mammals: presence of fur
  - Birds: wingspan
  - Fish: water type (fresh/salt)
  - Reptiles: venomousness
  - Amphibians: skin moisture (%)

## Expected Results
The program provides a console interface with the following capabilities:
- Viewing a list of all animals with complete information about each
- Adding a new animal with type selection and input of all characteristics
- Searching for an animal by index
- Demonstrating program functionality with pre-installed animal examples
- Proper text formatting with center alignment in the console
