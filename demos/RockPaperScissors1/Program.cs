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
        static Dictionary<Tuple<RPS, RPS>, string> Effects = new Dictionary<Tuple<RPS, RPS>, string>
        {
            {  new Tuple<RPS, RPS>(RPS.Rock, RPS.Rock), "ties with" },
            {  new Tuple<RPS, RPS>(RPS.Rock, RPS.Paper), "is covered by" },
            {  new Tuple<RPS, RPS>(RPS.Rock, RPS.Scissors), "smashes" },
            {  new Tuple<RPS, RPS>(RPS.Paper, RPS.Rock), "covers" },
            {  new Tuple<RPS, RPS>(RPS.Paper, RPS.Paper), "ties with" },
            {  new Tuple<RPS, RPS>(RPS.Paper, RPS.Scissors), "is cut by" },
            {  new Tuple<RPS, RPS>(RPS.Scissors, RPS.Rock), "is smashed by" },
            {  new Tuple<RPS, RPS>(RPS.Scissors, RPS.Paper), "cuts" },
            {  new Tuple<RPS, RPS>(RPS.Scissors, RPS.Scissors), "ties with" },
        };

        static Dictionary<Tuple<RPS, RPS>, string> Results = new Dictionary<Tuple<RPS, RPS>, string>
        {
            {  new Tuple<RPS, RPS>(RPS.Rock, RPS.Rock), "Tied With Computer" },
            {  new Tuple<RPS, RPS>(RPS.Rock, RPS.Paper), "Loses" },
            {  new Tuple<RPS, RPS>(RPS.Rock, RPS.Scissors), "Wins!!!" },
            {  new Tuple<RPS, RPS>(RPS.Paper, RPS.Rock), "Wins!!!" },
            {  new Tuple<RPS, RPS>(RPS.Paper, RPS.Scissors), "Loses" },
            {  new Tuple<RPS, RPS>(RPS.Paper, RPS.Paper), "Tied With Computer" },
            {  new Tuple<RPS, RPS>(RPS.Scissors, RPS.Rock), "Loses" },
            {  new Tuple<RPS, RPS>(RPS.Scissors, RPS.Paper), "Wins!!!" },
            {  new Tuple<RPS, RPS>(RPS.Scissors, RPS.Scissors), "Tied With Computer" },
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
                    Results.TryGetValue(new Tuple<RPS, RPS>((RPS)choice, (RPS)computerChoice), out string resultText);
                    Effects.TryGetValue(new Tuple<RPS, RPS>((RPS)choice, (RPS)computerChoice), out string effectText);
                    Console.WriteLine($"{userName}'s Choice: {choiceText}");
                    Console.WriteLine($"Computer Choice: {computerChoiceText}");
                    Console.WriteLine($"{userName} {resultText}. {choiceText} {effectText} {computerChoiceText}");
                    Console.WriteLine();


                }
                Console.WriteLine($"Enter 'Y' to play again?");
                string playAgainText = Console.ReadLine();
                playAgain = playAgainText == "Y";
            } while (playAgain);
        }
    }
}
