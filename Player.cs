using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    class Player
    {
        private string _name;
        private int _health;
        private int _basedamage;
        private Item[] _inventory;
        private Item _currentWeapon;
        private Item _hands;
        public Player()
        {
            _inventory = new Item[3];
            _health = 100;
            _basedamage = 10;
            _hands.name = "These Hands";
            _hands.statBoost = 0;
            _name = "Hero";
        }
        public Player(string nameVal, int healthVal, int damageVal, int inventorySize)
        {
            _health = healthVal;
            _basedamage = damageVal;
            _name = nameVal;
            _inventory = new Item[inventorySize];
            _hands.name = "These Hands";
            _hands.statBoost = 0;
        }
        public void AddItemToInventory(Item item, int index)
        {
            _inventory[index] = item;
        }
        public bool Contains(int itemIndex)
        {
            if(itemIndex > 0 && itemIndex < _inventory.Length)
            {
                return true;
            }
            return false;
        }

        public void UnequipItem()
        {
            _currentWeapon = _hands;
        }

        public void EquipItem(int itemIndex)
        {
            if (Contains(itemIndex))
            {
                _currentWeapon = _inventory[itemIndex];
            }
            
            
        }
        public string GetName()
        {
            return _name;
        }
        public void Attack(Player enemy)
        {
            int totalDamage = _basedamage + _currentWeapon.statBoost;
            enemy.TakeDamage(totalDamage);
        }
        public void PrintStats()
        {
            Console.WriteLine("Name: " + _name + "\nHealth: " + _health + "\n Damage: " + _basedamage + "\nCurrent Weapon");
        }
        public void TakeDamage(int damageVal)
        {
            if (GetIsAlive())
            {
                _health -= damageVal;
            }
            Console.WriteLine(_name + " took" + damageVal + " damage!");
        }
        public bool GetIsAlive()
        {
            return _health > 0;
        }
        public Item[] GetInventory()
        {
            return _inventory;
        }
    }
}
