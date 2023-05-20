using Interfaces;
using UnityEngine;

namespace Card.Item
{
    public abstract class Item : Card, IUsable
    {
        public bool inRelicSlot = false;
        public bool isRelic;
    }
}
