namespace Oppgave_Bossfight
{
    internal class Game
    {
        public bool GameIsRunning;
        private GameCharacter _hero;
        private GameCharacter _demon;

        public Game()
        {
            GameIsRunning = true;
            _hero = new GameCharacter("Hero", 100, 20, 40); ;
            _demon = new GameCharacter("Demon", 400, 20, 10);
        }

        public void Start()
        {
            Console.WriteLine("Press any key for 1 round of combat to pass");
            while (GameIsRunning)
            {
                Console.ReadKey(true);
                Console.WriteLine();
                _hero.Fight(_demon);
                _demon.RandomizeStrength(0, 31);
                _demon.Fight(_hero);
                IsGameWon();
            }
        }

        public void IsGameWon()
        {
            if (_demon.Health <= 0 && _hero.Health <= 0)
            {
                Console.WriteLine();
                Console.WriteLine($"The fight is a tie!");
                AskToRestartGame();
            }
            else if (_demon.Health <= 0)
            {
                Console.WriteLine();
                Console.WriteLine($"{_hero.Name} is the winner!");
                AskToRestartGame();
            }
            else if (_hero.Health <= 0)
            {
                Console.WriteLine();
                Console.WriteLine($"{_demon.Name} is the winner!");
                AskToRestartGame();
            }
        }

        private void AskToRestartGame()
        {
            Console.WriteLine("\nWould you like to fight again? (y/n)");
            var userInput = Console.ReadLine().ToLower();
            if (userInput is "yes" or "y")
            {
                GameIsRunning = false;
                Console.Clear();
                var game = new Game();
                game.Start();
            }
            else if (userInput is "no" or "n")
            {
                Console.WriteLine("That's too bad :( Hope to see you again soon! :)");
                Environment.Exit(404);
            }
            else
            {
                AskToRestartGame();
            }
        }
    }
}
