using UnityEngine;

namespace Card.Minion
{
    public class Gerblin : Minion
    {
        public Gerblin(string id, string name, string description, CardType type, CardRarity rarity, CardKeyword[] keywords, int attack, int defense) : 
            base(id, name, description, type, rarity, keywords, attack, defense)
        {
            
        }


        public override Card MakeCopy()
        {
            throw new System.NotImplementedException();
        }

        public override void Use()
        {
            throw new System.NotImplementedException();
        }
    }
}