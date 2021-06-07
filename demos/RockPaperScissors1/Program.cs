using System;
using System.Collections.Generic;

namespace RockPaperScissors1
{
    class Program
    {
        public enum RPS
        {
            Rock = 1,
            Paper = 2,
            Scissors = 3
        }
        static Dictionary<RPS, string> Moves = new Dictionary<RPS, string>
        {
            { RPS.Rock, "Rock" },
            { RPS.Paper, "Paper" },
            { RPS.Scissors, "Scissors" }
        };
        static Dictionary<Tuple<RPS, RPS>, object> Effects = new Dictionary<Tuple<RPS, RPS>, object>
        {
            {  new Tuple<RPS, RPS>(RPS.Rock, RPS.Rock), new { Effect = "ties with", ResultText = "Tied With Computer" } },
            {  new Tuple<RPS, RPS>(RPS.Rock, RPS.Paper), new { Effect = "is covered by", ResultText = "Loses" } },
            {  new Tuple<RPS, RPS>(RPS.Rock, RPS.Scissors), new { Effect = "smashes", ResultText = "Wins!!!" } },
            {  new Tuple<RPS, RPS>(RPS.Paper, RPS.Rock), new { Effect = "covers", ResultText = "Wins!!!" } },
            {  new Tuple<RPS, RPS>(RPS.Paper, RPS.Paper), new { Effect = "ties with", ResultText = "Loses" } },
            {  new Tuple<RPS, RPS>(RPS.Paper, RPS.Scissors), new { Effect = "is cut by", ResultText = "Tied With Computer" } },
            {  new Tuple<RPS, RPS>(RPS.Scissors, RPS.Rock), new { Effect = "is smashed by", ResultText = "Loses" } },
            {  new Tuple<RPS, RPS>(RPS.Scissors, RPS.Paper), new { Effect = "cuts", ResultText = "Wins!!!" } },
            {  new Tuple<RPS, RPS>(RPS.Scissors, RPS.Scissors), new { Effect = "ties with", ResultText = "Tied With Computer" } }
        };


        static void Main(string[] args)
        {
            Console.WriteLine("Hello Opponent. We are about to play a game of Rock, Paper, Scissors.");
            Console.WriteLine("What do you deem yourself worthy to call yourself?");
            string userName = Console.ReadLine();
            Random randomGenerator = new Random();
            bool playAgain;
            do
            {
                for (int i = 0; i < 3; i++)
                {
                    short choice;
                    bool result;
                    do
                    {
                        Console.WriteLine($"Enter {(short)RPS.Rock} to select {RPS.Rock.ToString()}, enter {(short)RPS.Paper} to select {RPS.Paper.ToString()}, or enter {(short)RPS.Scissors} to select {RPS.Scissors.ToString()}");
                        result = short.TryParse(Console.ReadLine(), out choice);

                    } while (!result || !(choice > 0 && choice < 4));
                    short computerChoice = (short)randomGenerator.Next(1, 4);
                    Moves.TryGetValue((RPS)choice, out string choiceText);
                    Moves.TryGetValue((RPS)computerChoice, out string computerChoiceText);

                    Effects.TryGetValue(new Tuple<RPS, RPS>((RPS)choice, (RPS)computerChoice), out dynamic effect);
                    Console.WriteLine($"{userName}'s Choice: {choiceText}");
                    Console.WriteLine($"Computer Choice: {computerChoiceText}");
                    Console.WriteLine($"{userName} {effect.ResultText}. {choiceText} {effect.Effect} {computerChoiceText}");
                    Console.WriteLine();


                }
                Console.WriteLine($"Enter 'Y' to play again?");
                string playAgainText = Console.ReadLine();
                playAgain = playAgainText == "Y";
            } while (playAgain);
        }
    }
}
