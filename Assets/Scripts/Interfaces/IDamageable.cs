using UnityEngine;

namespace Interfaces
{
    public interface IDamageable
    {
        public void Damage(int amount);
        public void Heal(int amount);
    }
}
