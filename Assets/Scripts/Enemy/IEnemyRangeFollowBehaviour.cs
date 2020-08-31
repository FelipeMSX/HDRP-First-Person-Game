using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public interface IEnemyRangeFollowBehaviour
    {
        void Follow(GameObject controlledObject);
    }
}
