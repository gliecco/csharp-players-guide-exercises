class Program
{
    static void Main(string[] args)
    {
        // create an arrow object based on user input, then calculate its total cost
        Arrow arrow = Arrow.CreateUserArrow();
        float totalCost = arrow.GetTotalArrowCost();
        Console.WriteLine($"your total cost is {totalCost}!");

    }
   
    class Arrow
    {
        public ArrowHeads _arrowHeads;
        public float _length;
        public Fletching _fletching;

        public Arrow(ArrowHeads arrowHeads, float length, Fletching fletching)
            {
                _arrowHeads = arrowHeads; 
                _length = length;
                _fletching = fletching;
                
            }

        // method to take the user's input and create an instance of the class Arrow based on the user inputs
        public static Arrow CreateUserArrow()
        {
            ArrowHeads arrowHeads = GetUserArrowHead();
            float length = GetUserLength();
            Fletching fletching= GetUserFletchingType();

            Arrow userArrow = new Arrow(arrowHeads, length, fletching);

            return userArrow;
        }

        // method to get the user's arrowhead
        public static ArrowHeads GetUserArrowHead()
        {
            Console.WriteLine("choose your arrowhead (steel, wood, obsidian):");
            string input = Console.ReadLine() ?? string.Empty; 

            ArrowHeads selectedArrowHead = input.ToLower() switch

            {
                "steel" => ArrowHeads.steel,
                "wood" => ArrowHeads.wood,
                "obsidian" => ArrowHeads.obsidian,
                _ => throw new ArgumentException("invalid arrowhead type. please choose steel, wood or obsidian")
            };

            return selectedArrowHead;
        }

        // method to get the user's length 
        public static float GetUserLength()
        {
            Console.WriteLine("choose your desired length, between 60 and 100 cm:");
            float input = Convert.ToSingle(Console.ReadLine());

            float selectedLength = input switch
            {
                < 60 => throw new ArgumentException("length cannot be less than 60cm"),
                > 100 => throw new ArgumentException("length cannot be greater than 100cm"),
                _ => input
            };

            return selectedLength;
        }

        // method to get the user's fletching type
        public static Fletching GetUserFletchingType()
        {
            Console.WriteLine("choose your fletching type (plastic, turkey feathers, goose feathers):");
            string input = Console.ReadLine() ?? string.Empty;

            Fletching selectedFletching = input.ToLower() switch

            {
                "plastic" => Fletching.plastic,
                "turkey feathers" => Fletching.turkey_feathers,
                "goose feathers" => Fletching.goose_feathers,
                _ => throw new ArgumentException("invalid fletching type. please choose plastic, turkey feathers or goose feathers")
            };

            return selectedFletching;
        }

        // method to get the user's arrow total cost
        public float GetTotalArrowCost()
        {
            float arrowHeadCost = _arrowHeads switch
            {
                ArrowHeads.steel => 10f,
                ArrowHeads.wood => 3f,
                ArrowHeads.obsidian => 5f,
                _ => throw new ArgumentException("invalid input")
            };

            float shaftCost = _length * 0.05f;

            float fletchingCost = _fletching switch
            {
                Fletching.plastic => 10f,
                Fletching.turkey_feathers => 5f,
                Fletching.goose_feathers => 3f,
                _ => throw new ArgumentException("invalid input")
            };

            return arrowHeadCost + shaftCost + fletchingCost;
        }

    }
        public enum ArrowHeads { steel, wood, obsidian };
        public enum Fletching { plastic, turkey_feathers, goose_feathers };
}




