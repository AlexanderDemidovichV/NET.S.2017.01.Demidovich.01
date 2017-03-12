using System;
using Animal;

class Program
{
    static void Main()
    {
    	Cat cat = new Cat();
    	cat.CatInfo();

    	Dog dog = new Dog();
    	dog.DogInfo();

    	Mouse mouse = new Mouse();
    	mouse.MouseInfo();

    	Console.ReadLine();
    }
}