using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    struct Player
    {
        public int health;
        public int damage;
    }

    struct Item
    {
        public int statBoost;
    }

    class Game
    {
        bool _gameOver = false;
        Player _player1;
        Player _player2;
        Item longSword;
        Item dagger;
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
        public void InitializePlayers()
        {
            _player1.health = 100;
            _player1.damage = 5;

            _player2.health = 100;
            _player2.damage = 5;
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
        public void EquipItems()
        {
            char input;
            GetInput(out input, "LongSword", "Dagger", "Welcome! Player one please choose a weapon.");

            if (input == '1')
            {
                _player1.damage += longSword.statBoost;
            }
            else if (input == '2')
            {
                _player1.damage += dagger.statBoost;
            }
            Console.WriteLine("Player one");
            PrintStats(_player1);

            GetInput(out input, "LongSword", "Dagger", "Welcome! Player two please choose a weapon.");

            if (input == '1')
            {
                _player2.damage += longSword.statBoost;
            }
            else if (input == '2')
            {
                _player2.damage += dagger.statBoost;
            }
            Console.WriteLine("Player two");
            PrintStats(_player2);
            Console.WriteLine("Press enter to continue");
            Console.ReadKey();
            Console.Clear();
        }
        public void StartBattle()
        {
            Console.WriteLine("Fight!");
            while (_player1.health > 0 && _player2.health > 0)
            {
                Console.WriteLine("Player one info");
                PrintStats(_player1);
                Console.WriteLine("Player two info");
                PrintStats(_player2);
                char input;
                if (_player1.health > 0)
                {
                    GetInput(out input, "Attack", "Stare Menacingly", "Player one, what is your move?");
                    if (input == '1')
                    {
                        Console.WriteLine("Player one hit Player two for " + _player1.damage + "!");
                        _player2.health -= _player1.damage;
                    }
                    if (input == '2')
                    {
                        Console.WriteLine("Player one stares hard, nothing seems to happen.");
                    }
                }
                if (_player2.health > 0)
                {
                    GetInput(out input, "Attack", "Stare Menacingly", "Player two, how do you counter?");
                    if (input == '1')
                    {
                        Console.WriteLine("Player one hit Player two for " + _player1.damage + "!");
                        _player1.health -= _player2.damage;
                    }
                    if (input == '2')
                    {
                        Console.WriteLine("Player one stares hard, nothing seems to happen.");
                    }
                }
                Console.Clear();
            }
            Console.WriteLine("There has been a winner!");
            if (_player1.health > 0)
            {
                Console.WriteLine("Player One Has Proven Themself to be Better!");
            }
            if (_player2.health > 0)
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
        public void PrintStats(Player player)
        {
            Console.WriteLine("Health: " + player.health + "\n Damage: " + player.damage);
        }

        //Performed once when the game begins
        public void Start()
        {
            InitializePlayers();
            InitializeItems();
        }

        //Repeated until the game ends
        public void Update()
        {
            InitializePlayers();
            EquipItems();
            StartBattle();
        }

        //Performed once when the game ends
        public void End()
        {

        }

    }
}
