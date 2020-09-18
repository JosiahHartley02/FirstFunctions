using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    struct Item
    {
        public int statBoost;
        public string name;
    }

    class Game
    {
        private bool _gameOver = false;
        private Player _player1;
        private Player _player2;
        private Item _longSword;
        private Item _dagger;
        private Item _bow;
        private Item _crossBow;
        private Item _cherryBomb;
        private Item _mace;

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
            _longSword.statBoost = 15;
            _dagger.statBoost = 10;
            _bow.statBoost = 12;
            _crossBow.statBoost = 34;
            _cherryBomb.statBoost = 24;
            _mace.statBoost = 25;
            _longSword.name = "Knight's Sword";
            _dagger.name = "Thief's Dagger";
            _bow.name = "Ranger's Bow";
            _crossBow.name = "Ranger's Crossbow";
            _cherryBomb.name = "CHerry Bomb";
            _mace.name = "Normal Mace";
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
        public void GetInput(out char input, string option1, string option2, string option3, string query)
        {
            Console.WriteLine(query);
            Console.Write("1. " + option1 + "\n2. " + option2 + "\n3.> " + option3);
            input = ' ';
            while (input != '1' && input != '2' && input != '3')
            {
                input = Console.ReadKey().KeyChar;
                if (input != '1' && input != '2')
                {
                    Console.WriteLine("Invalid input");
                }

            }
            Console.Clear();
        }
        public void SwitchWeapons(Player player)
        {
            Item[] inventory = player.GetInventory();
            char input = ' ';
            for (int i = 0; i < inventory.Length; i++)
            {
                Console.WriteLine((i+1) + ". " + inventory[i].name + "  " + inventory[i].statBoost + " damage");
            }
            Console.WriteLine("> ");
            input = Console.ReadKey().KeyChar;

            switch (input)
            {
                case '1':
                    player.EquipItem(0);
                    Console.Clear();
                    Console.WriteLine("You equipped " + inventory[0].name);
                    Console.WriteLine("Base damage increased by " + inventory[0].statBoost);
                    break;
                case '2':
                    player.EquipItem(1);
                    Console.Clear();
                    Console.WriteLine("You equipped " + inventory[1].name);
                    Console.WriteLine("Base damage increased by " + inventory[1].statBoost);
                    break;
                case '3':
                    player.EquipItem(2);
                    Console.Clear();
                    Console.WriteLine("You equipped " + inventory[2].name);
                    Console.WriteLine("Base damage increased by " + inventory[2].statBoost);
                    break;
                default:
                    player.UnequipItem();
                    Console.Clear();
                    Console.WriteLine("You dropped your weapon!\n unlucky :(");
                    Console.ReadKey();
                    break;
            }
            Console.Clear();

        }
        public void SelectLoadout(Player player)
        {
            Console.Clear();
            Console.WriteLine(":Loadout one :     :Loadout Two:\nLongsword          CrossBow\nDagger          Cherry Bomb\nBow              Mace");
            char input;
            GetInput(out input, "Loadout One", "Loadout Two", "Welcome! please choose a loadout.");

            if (input == '1')
            {
                player.AddItemToInventory(_longSword, 0);
                player.AddItemToInventory(_dagger, 1);
                player.AddItemToInventory(_bow, 2);
            }
            else if (input == '2')
            {
                player.AddItemToInventory(_crossBow, 0);
                player.AddItemToInventory(_cherryBomb, 1);
                player.AddItemToInventory(_mace, 2);
            }
            player.PrintStats();
            Console.ReadKey();
            Console.Clear();
        }
        public Player CreateCharacter()
        {
            Console.WriteLine("What is your name");
            string name = Console.ReadLine();
            Player player = new Player(name, 100, 10, 3);
            SelectLoadout(player);
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
                    GetInput(out input, "Attack", "Change Weapon", "Player one, what is your move?");
                    if (input == '1')
                    {
                        _player1.Attack(_player2);
                    }
                    if (input == '2')
                    {
                        SwitchWeapons(_player1);
                    }
                }
                if (_player2.GetIsAlive())
                {
                    GetInput(out input, "Attack", "Change Wapon", "Player two, how do you counter?");
                    if (input == '1')
                    {
                        _player2.Attack(_player1);
                    }
                    if (input == '2')
                    {
                        SwitchWeapons(_player2);
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
