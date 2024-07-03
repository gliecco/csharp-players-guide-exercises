using System;

internal class Program
{
    // variables to store the manticore distance, city hp, manticore hp, and round number
    private static int manticoreDistance;
    private static int cityHP = 15;
    private static int manticoreHP = 10;
    private static int round = 1;

    private static void Main(string[] args)
    {
        // get player one's input for the manticore distance
        int manticoreDistance = GetPlayerOneInput();
        Console.WriteLine($"player 1 has set the distance to: {manticoreDistance}");
        // start the game loop with the given manticore distance
        GameLoop(manticoreDistance);
    }

    // method to get the manticore distance from player one
    static int GetPlayerOneInput()
    {
        while (true)
        {
            Console.WriteLine("player 1, how far away from the city do you want to station the manticore?");
            int manticoreDistance = Convert.ToInt32(Console.ReadLine());
            Console.Clear();

            // validate the input to make sure it's between 0 and 100
            if (manticoreDistance < 0 || manticoreDistance > 100)
            {
                Console.WriteLine("the number must be between 0 and 100!");
                continue;
            }

            // return the valid manticore distance
            return manticoreDistance;
        }
    }

    // main game loop method
    static void GameLoop(int manticoreDistance)
    {
        while (cityHP > 0 && manticoreHP > 0)
        {
            Console.WriteLine("-----------------------------------------------------------");
            // display the status of the game
            Console.WriteLine($"status: round: {round} | city hp: {cityHP}/15 | manticore hp: {manticoreHP}/10");
            int expectedDamage = CalculateDamage(round);
            // display the expected damage for the current round
            Console.WriteLine($"the cannon is expected to deal {expectedDamage} damage this round.");
            Console.WriteLine("-----------------------------------------------------------");

            // prompt player two for their cannon range input
            Console.WriteLine("player 2, it is your turn.");
            Console.WriteLine("enter the desired cannon range: ");
            int playerTwoRange = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"player 2 entered: {playerTwoRange}, manticore distance is: {manticoreDistance}");

            // check if the player overshot, undershot, or hit the target
            if (playerTwoRange > manticoreDistance)
            {
                Console.WriteLine("you overshot the target!");
                cityHP--;
                round++;
            }
            else if (playerTwoRange < manticoreDistance)
            {
                Console.WriteLine("you undershot the target!");
                cityHP--;
                round++;
            }
            else if (playerTwoRange == manticoreDistance)
            {
                Console.WriteLine("it's a hit!!!");
                manticoreHP -= CalculateDamage(round);
                round++;
            }

            // check if the game has ended
            if (cityHP <= 0)
            {
                Console.WriteLine("the city of consolas has been destroyed! game over!");
            }
            else if (manticoreHP <= 0)
            {
                Console.WriteLine("the manticore has been destroyed! the city of consolas is safe.");
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
        }
    }
}
