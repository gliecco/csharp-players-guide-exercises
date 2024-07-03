using System;

internal class Program
{
    // variables to store the city hp, manticore hp, and round number
    private static int cityHP = 15;
    private static int manticoreHP = 10;
    private static int round = 1;

    private static void Main(string[] args)
    {
        int manticoreDistance = GetPlayerOneInput();
        GameLoop(manticoreDistance);
        Console.WriteLine("Press any key to exit the game...");
        Console.ReadKey(true);
    }

    // method to get the manticore distance from player one
    static int GetPlayerOneInput()
    {
        while (true)
        {
            Console.WriteLine("player 1, how far away from the city do you want to station the manticore?");
            int manticoreDistance = Convert.ToInt32(Console.ReadLine());
            Console.Clear();

            if (manticoreDistance < 0 || manticoreDistance > 100)
            {
                Console.WriteLine("the number must be between 0 and 100!");
                continue;
            }

            return manticoreDistance;
        }
    }

    // main game loop method
    static void GameLoop(int manticoreDistance)
    {
        while (cityHP > 0 && manticoreHP > 0)
        {
            DisplayStatus();
            int expectedDamage = CalculateDamage(round);
            Console.WriteLine($"the cannon is expected to deal {expectedDamage} damage this round.");
            Console.WriteLine("-----------------------------------------------------------");


            int playerTwoRange = GetPlayerTwoInput();

            // check if the player overshot, undershot, or hit the target
            if (playerTwoRange > manticoreDistance)
            {
                Console.WriteLine("you overshot the target!\n");
                cityHP--;
                round++;
            }
            else if (playerTwoRange < manticoreDistance)
            {
                Console.WriteLine("you undershot the target!\n");
                cityHP--;
                round++;
            }
            else if (playerTwoRange == manticoreDistance)
            {
                Console.WriteLine("it's a hit!!!\n");
                manticoreHP -= CalculateDamage(round);
                round++;
            }
            EndGame();
        }
    }

    // method to display the status of the game
    static void DisplayStatus()
    {
        Console.WriteLine("-----------------------------------------------------------");
        Console.WriteLine($"status: round: {round} | city hp: {cityHP}/15 | manticore hp: {manticoreHP}/10");
    }

    // method to calculate the damage based on the current round
    static int CalculateDamage(int round)
    {
        if (round % 3 == 0 && round % 5 == 0)
        {
            return 10; // fire-electric blast
        }
        else if (round % 3 == 0 || round % 5 == 0)
        {
            return 3; // fire blast or electric blast
        }
        else
        {
            return 1; // regular damage
        }
    }

    // method to prompt player two for their cannon range input
    static int GetPlayerTwoInput()
    {
        Console.WriteLine("player 2, it's your turn.");

        while (true)
        {
            Console.WriteLine("enter the desired cannon range: ");
            int playerTwoRange = Convert.ToInt32(Console.ReadLine());
            Console.Clear();

            if (playerTwoRange < 0 || playerTwoRange > 100)
            {
                Console.WriteLine("the number must be between 0 and 100!");
                continue;
            }

            return playerTwoRange;
        }
    }

    // method for the game's ending
    static void EndGame()
    {
        if (cityHP <= 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("the city of consolas has been destroyed! game over!\n");
        }
        else if (manticoreHP <= 0)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("the manticore has been destroyed! the city of consolas is safe.\n");
        }
    }

}
