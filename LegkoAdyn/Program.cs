using System;
using System.Collections.Generic;

public interface IMushroom
{
    void Grow();
}

public class Agaricus : IMushroom
{
    public void Grow()
    {
        Console.WriteLine("Agaricus mushroom is growing!");
    }
}

public class Boletus : IMushroom
{
    public void Grow()
    {
        Console.WriteLine("Boletus mushroom is growing!");
    }
}

public class MushroomFactory
{
    private Dictionary<string, IMushroom> mushrooms = new Dictionary<string, IMushroom>();

    public IMushroom GetMushroom(string name)
    {
        IMushroom mushroom = null;

        if (mushrooms.ContainsKey(name))
        {
            mushroom = mushrooms[name];
        }
        else
        {
            switch (name)
            {
                case "Agaricus":
                    mushroom = new Agaricus();
                    break;
                case "Boletus":
                    mushroom = new Boletus();
                    break;
            }

            mushrooms.Add(name, mushroom);
        }

        return mushroom;
    }
}

class Program
{
    static void Main(string[] args)
    {
        MushroomFactory factory = new MushroomFactory();

        IMushroom mushroom1 = factory.GetMushroom("Agaricus");
        mushroom1.Grow();

        IMushroom mushroom2 = factory.GetMushroom("Boletus");
        mushroom2.Grow();

        IMushroom mushroom3 = factory.GetMushroom("Agaricus");
        mushroom3.Grow();
    }
}
