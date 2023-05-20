using System;
using System.Collections;
using UnityEngine;

namespace Card
{
    public class Deck : IEnumerable
    {
        private Card[] _cards;

        public Deck(Card[] cArray)
        {
            _cards = new Card[cArray.Length];

            for (int i = 0; i < cArray.Length; i++)
            {
                _cards[i] = cArray[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public DeckEnum GetEnumerator()
        {
            return new DeckEnum(_cards);
        }
    }
    
    /// <summary>
    /// Deck Enumerator
    /// </summary>
    public class DeckEnum : IEnumerator
    {
        private int _position = -1;
        private Card[] _cards;

        public DeckEnum(Card[] list)
        {
            _cards = list;
        }
        
        public bool MoveNext()
        {
            _position++;
            return (_position < _cards.Length);
        }

        public void Reset()
        {
            _position = -1;
        }

        object IEnumerator.Current => ((IEnumerator) this).Current;
        
        public Card Current
        {
            get
            {
                try
                {
                    return _cards[_position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }
}
