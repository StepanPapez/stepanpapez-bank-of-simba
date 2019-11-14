using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankOfSimba.Models
{
    public class BankAccount
    {
        public string Name { get; private set; }
        public double Balance { get; set; }
        public string AnimalType { get; private set; }
        public bool IsKing { get; private set; } = false;
        public bool IsGood { get; private set; } = true;

        public BankAccount(string name, double balance, string animalType)
        {
            Name = name;
            Balance = balance;
            AnimalType = animalType;
        }

        public BankAccount(string name, double balance, string animalType, bool isKing, bool isGood)
        {
            Name = name;
            Balance = balance;
            AnimalType = animalType;
            IsKing = isKing;
            IsGood = isGood;
        }
    }
}
