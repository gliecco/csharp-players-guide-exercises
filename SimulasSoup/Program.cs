using Microsoft.VisualBasic;
using System;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Xml.Linq;

class Program
{
    static void Main(string[] args)
    {
        (Seasoning seasoning, MainIngredient ingredient, Type type) FinalDish = GetDish();
        Console.WriteLine($"a fresh {FinalDish.seasoning} {FinalDish.ingredient} {FinalDish.type}!");
    }

    // enums for the different dish types, main ingredients and seasonings

    enum Type { soup, stew, gumbo }
    enum MainIngredient { mushroom, chicken, carrots, potatoes }
    enum Seasoning { spicy, salty, sweet }

    // method to get the user's seasoning

    static Seasoning GetUserSeasoning()
    {
        Console.WriteLine("Choose your seasoning:");
        Console.WriteLine("1. Spicy");
        Console.WriteLine("2. Salty");
        Console.WriteLine("3. Sweet\n");
        int userSeasoning = Convert.ToInt32(Console.ReadLine());

        return userSeasoning switch
        {
            1 => Seasoning.spicy,
            2 => Seasoning.salty,
            3 => Seasoning.sweet,
            _ => throw new ArgumentException("we're out of that one!")
        };
    }

    // method to get the user's main ingredient

    static MainIngredient GetUserIngredient()
    {
        Console.WriteLine("\nChoose your main ingredient:");
        Console.WriteLine("1. Mushroom");
        Console.WriteLine("2. Chicken");
        Console.WriteLine("3. Carrots");
        Console.WriteLine("4. Potatoes\n");
        int userIngredient = Convert.ToInt32(Console.ReadLine());

        return userIngredient switch
        {
            1 => MainIngredient.mushroom,
            2 => MainIngredient.chicken,
            3 => MainIngredient.carrots,
            4 => MainIngredient.potatoes,
            _ => throw new ArgumentException("we're out of that one!")
        };
    }

    // method to get the user's dish type

    static Type GetUserType()
    {
        Console.WriteLine("\nChoose your type of recipe:");
        Console.WriteLine("1. Soup");
        Console.WriteLine("2. Stew");
        Console.WriteLine("3. Gumbo\n");
        int UserType = Convert.ToInt32(Console.ReadLine());

        return UserType switch
        {
            1 => Type.soup,
            2 => Type.stew,
            3 => Type.gumbo,
            _ => throw new ArgumentException("we're out of that one!")
        };
    }

    // method to get the user's final dish
    static (Seasoning, MainIngredient, Type) GetDish()
    {
        Seasoning userSeasoning = GetUserSeasoning();
        MainIngredient userIngredient = GetUserIngredient();
        Type userType = GetUserType();
        return (userSeasoning, userIngredient, userType);
    }

}

