using Interfaces;
using UnityEngine;

namespace Card.Minion
{ 
    public abstract class Minion : Card, IDamageable
    {
        [Header("Minion Fields")] 
        public int health;
        public int attack;
        public int defense;
    
        // Constructors

        protected Minion(string id, string name, string description, CardType type, CardRarity rarity, CardKeyword[] keywords, int attack, int defense)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.attack = attack;
            this.defense = defense;
            // Static elements
            this.type = CardType.Minion;
        }


        public void Damage(int amount)
        {
            health -= amount;
        }

        public void Heal(int amount)
        {
            health += amount;
        }
    }
}

