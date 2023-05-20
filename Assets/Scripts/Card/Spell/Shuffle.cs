using Interfaces;

namespace Card.Spell
{
    public class Shuffle : Card, IUsable
    {
        public override Card MakeCopy()
        {
            return new Shuffle();
        }

        public override void Use()
        {
            throw new System.NotImplementedException();
        }
    }
}