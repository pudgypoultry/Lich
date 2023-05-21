using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Deck myDeck;
    public bool isDead = false;

}

/*
public class Deck {

    public List<BaseCard> cards = new List<BaseCard>();
    
    public Deck () { 

    }

    public IEnumerable<BaseCard> GetCards() {
        foreach (BaseCard card in cards) {
            yield return card;
        }
    }

    public int GetSize () {
        return cards.Count;
    }

    public BaseCard Draw() {
        BaseCard tempCard = cards[0];
        cards.RemoveAt(0);
        return tempCard;
    }

    public static void Shuffle(Deck deck) {
        System.Random random = new System.Random();

        for (int i=0; i<deck.cards.Count; i++) {
            int j = random.Next(i, deck.cards.Count);
            BaseCard temporary = deck.cards[i];
            deck.cards[i] = deck.cards[j];
            deck.cards[j] = temporary;
        }
    }

};

*/