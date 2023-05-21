using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public List<BaseCard> cards = new List<BaseCard>();

    public int GetSize()
    {
        return cards.Count;
    }

    public BaseCard Draw()
    {
        BaseCard tempCard = cards[0];
        cards.RemoveAt(0);
        return tempCard;
    }

    public void Shuffle(Deck deck)
    {
        System.Random random = new System.Random();

        for (int i = 0; i < deck.cards.Count; i++)
        {
            int j = random.Next(i, deck.cards.Count);
            BaseCard temporary = deck.cards[i];
            deck.cards[i] = deck.cards[j];
            deck.cards[j] = temporary;
        }
    }

    public List<int> GetLocationsOfCardInDeck(string whichCard)
    {
        int counter = 0;
        List<int> ret_list = new List<int>();

        foreach (BaseCard card in cards)
        {
            if (card.cardName == whichCard)
            { 
                ret_list.Add(counter);
            }

            counter += 1;
        }

        return ret_list;
    }

    public int GetCountofCardNameInDeck(string whichCard)
    {
        int ret_int = 0;

        foreach (BaseCard card in cards)
        {
            if (card.cardName == whichCard)
            {
                ret_int += 1;
            }
        }

        return ret_int;
    }

    public int GetCountofCardTypeInDeck(BaseCard.CardType whichType)
    {
        int ret_int = 0;

        foreach (BaseCard card in cards)
        {
            if (card.type == whichType)
            {
                ret_int += 1;
            }
        }

        return ret_int;
    }

    public void PutCardAtPosition(BaseCard theCard, int position)
    { 
        cards.Insert(position, theCard);
    }

    public void PutCardAtTop(BaseCard theCard)
    {
        PutCardAtPosition(theCard, 0);
    }

    public void PutCardAtBottom(BaseCard theCard)
    { 
        PutCardAtPosition(theCard, cards.Count - 1);
    }

    public List<BaseCard> LookAtTopX(int x)
    {
        List<BaseCard> ret_list = new List<BaseCard>();

        for (int i = 0; i < x; i++)
        {
            ret_list.Add(cards[i]);
        }

        return ret_list;
    }

    public float ProbabilityOfDeath()
    { 
        float probability = 0;

        int size = cards.Count;
        int deathCount = GetCountofCardTypeInDeck(BaseCard.CardType.Death);

        probability = deathCount / size;

        return probability;
    }

}
