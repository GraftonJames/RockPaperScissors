namespace RockPaperScissors
{
    internal class Program
    {
        public static string[] Throws = new string[] {"Rock" , "Paper" , "Scissors" };
        public static string[,] ResultMatrix = new string[,] { { "Draw" , "Lose" , "Win" }, { "Lose", "Draw", "Win" }, { "Win", "Lose", "Draw" } };
        static void Main(string[] args)
        {
            bool tryAgain = true;
            while (tryAgain) {
                Console.WriteLine(
                    "Do you want to play vs a Human or a Computer?" +
                    " 1) Human" +
                    " 2) Computer"
                    );

                char read = Console.ReadKey().KeyChar;

                if (read == '1')
                {
                    HumanGame();
                    tryAgain = false;
                }
                else if (read == '2')
                {
                    ComputerGame();
                    tryAgain = false;
                }
                else {
                    Console.WriteLine("Invalid Input");
                }
            }
        }

        private static void HumanGame()
        {
            int[] throwCount = new int[3] { 0, 0, 0 };
            int playerOneThrow = 0;
            int playerTwoThrow = 0;
            string result = "Draw";
            int rounds = 0;
            while (result == "Draw")
            {
                Console.Clear();
                Console.WriteLine("Player One Throw:");
                playerOneThrow = GetThrow();
                throwCount[playerOneThrow]++;
                Console.Clear();
                Console.WriteLine("Player Two Throw:");
                playerTwoThrow = GetThrow();
                throwCount[playerTwoThrow]++;
                Console.Clear();
                result = ResultMatrix[playerOneThrow, playerTwoThrow];
                Console.WriteLine($"Player One: {Throws[playerOneThrow]}, Player Two: {Throws[playerTwoThrow]}");
                if (result == "Draw")
                {
                    Console.WriteLine("Draw, play again!");
                }
                else if (result == "Win")
                {
                    Console.WriteLine("Player One Wins!");
                }
                else
                {
                    Console.WriteLine("Player Two Wins!");
                }
                rounds++;
                Console.ReadLine();
            }
            Console.WriteLine($"Rounds: {rounds}");
            Console.WriteLine($"Throw Count: Rock {throwCount[0]}, Paper {throwCount[1]}, Scissors {throwCount[2]}");
            Console.ReadLine();
        }

        private static int GetThrow()
        {
            Console.WriteLine("Rock (1), Paper (2), Scissors (3)");
            bool valid = false;
            int index = 0;
            while (!valid)
            {
                char read = Console.ReadKey().KeyChar;
                if (read == '1' || read == '2' || read == '3')
                {
                    valid = true;
                    // returns keystroke as associated index
                    index = ((int)read) - 49; 
                }
            }
            return index;
        }

        private static void ComputerGame()
        {
            Random rnd = new Random();
            int[] throwCount = new int[3] { 0, 0, 0 };
            int rounds = 0;
            int HumanThrow = 0;
            int ComputerThrow = 0;
            string result = "Draw";
            while (result == "Draw")
            {
                Console.Clear();
                Console.WriteLine("Throw:");
                HumanThrow = GetThrow();
                throwCount[HumanThrow]++;
                Console.Clear();
                ComputerThrow = rnd.Next(0, 2);
                throwCount[ComputerThrow]++;
                result = ResultMatrix[HumanThrow, ComputerThrow];
                Console.WriteLine($"Player: {Throws[HumanThrow]}, Computer: {Throws[ComputerThrow]}");
                if (result == "Draw")
                {
                    Console.WriteLine("Draw, play again!");
                }
                else if (result == "Win")
                {
                    Console.WriteLine("Player Wins!");
                }
                else
                {
                    Console.WriteLine("Computer Wins!");
                }
                rounds++;
                Console.ReadLine();
            }
            Console.WriteLine($"Rounds: {rounds}");
            Console.WriteLine($"Throw Count: Rock {throwCount[0]}, Paper {throwCount[1]}, Scissors {throwCount[2]}");
            Console.ReadLine();
        }
    }
}