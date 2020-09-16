using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    struct Item
    {
        public int statBoost;
    }

    class Game
    {
        private bool _gameOver = false;
        private Player _player1;
        private Player _player2;
        private Item longSword;
        private Item dagger;
        //Run the game
        public void Run()
        {
            Start();
            while (_gameOver == false)
            {
                Update();
            }
            End();
        }        

        public void InitializeItems()
        {
            longSword.statBoost = 15;
            dagger.statBoost = 10;
        }
        public void GetInput(out char input, string option1, string option2, string query)
        {
            Console.WriteLine(query);
            Console.Write("1. " + option1 + "\n2. " + option2 + "\n> ");
            input = ' ';
            while (input != '1' && input != '2')
            {
                input = Console.ReadKey().KeyChar;
                if (input != '1' && input != '2')
                {
                    Console.WriteLine("Invalid input");
                }

            }
        }
        public void SelectItems(Player player)
        {
            char input;
            GetInput(out input, "LongSword", "Dagger", "Welcome! please choose a weapon.");

            if (input == '1')
            {
                player.AddItemToInventory(longSword, 0);
            }
            else if (input == '2')
            {
                player.AddItemToInventory(dagger,0);
            }            
            player.PrintStats();
        }
        public Player CreateCharacter()
        {
            Console.WriteLine("wuts ur name????");
            string name = Console.ReadLine();
            Player player = new Player(name, 100, 10, 5);
            SelectItems(player);
            return player;
        }
        public void StartBattle()
        {
            Console.WriteLine("Fight!");
            while (_player1.GetIsAlive() && _player2.GetIsAlive())
            {
                Console.WriteLine("Player one info");
                _player1.PrintStats();
                Console.WriteLine("Player two info");
                _player2.PrintStats();
                char input;
                if (_player1.GetIsAlive())
                {
                    GetInput(out input, "Attack", "Stare Menacingly", "Player one, what is your move?");
                    if (input == '1')
                    {                       
                        _player1.Attack(_player2);
                    }
                    if (input == '2')
                    {
                        Console.WriteLine("Player one stares hard, nothing seems to happen.");
                    }
                }
                if (_player2.GetIsAlive())
                {
                    GetInput(out input, "Attack", "Stare Menacingly", "Player two, how do you counter?");
                    if (input == '1')
                    {
                        _player2.Attack(_player1);
                    }
                    if (input == '2')
                    {
                        Console.WriteLine("Player one stares hard, nothing seems to happen.");
                    }
                }
                Console.Clear();
            }
            Console.WriteLine("There has been a winner!");
            if (_player1.GetIsAlive())
            {
                Console.WriteLine("Player One Has Proven Themself to be Better!");
            }
            if (_player2.GetIsAlive())
            {
                Console.WriteLine("Player Two Has Proven Themself to be Better!");
            }
            char gameoveroption;
            GetInput(out gameoveroption, "Rematch", "End", "Do you wish to continue?");
            if (gameoveroption == '1')
            {

            }
            if (gameoveroption == '2')
            {
                _gameOver = true;
            }
        }        
        

        //Performed once when the game begins
        public void Start()
        {
            InitializeItems();
        }

        //Repeated until the game ends
        public void Update()
        {            
            _player1 = CreateCharacter();
            _player2 = CreateCharacter();
            StartBattle();
        }

        //Performed once when the game ends
        public void End()
        {

        }

    }
}
