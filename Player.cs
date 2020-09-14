using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    class Player
    {
        private string _name;
        private int _health;
        private int _damage;
        public Player()
        {
            _health = 100;
            _damage = 10;
            _name = "Hero";
        }
        public Player(string nameVal, int healthVal, int damageVal)
        {
            _health = healthVal;
            _damage = damageVal;
            _name = nameVal;
        }
        public void EquipItem(Item weapon)
        {
            _damage += weapon.statBoost;
        }
        public string GetName()
        {
            return _name;
        }
        public void Attack(Player enemy)
        {
            enemy.TakeDamage(_damage);
        }
        public void PrintStats()
        {
            Console.WriteLine("Name: " + _name + "\nHealth: " + _health + "\n Damage: " + _damage);
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

    }
}
