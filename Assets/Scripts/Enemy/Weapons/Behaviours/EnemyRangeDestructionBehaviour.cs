using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Enemy.Weapons.Behaviours
{
    public class EnemyRangeDestructionBehaviour : MonoBehaviour
    {
        public float DecayVelocity = 30.0f;

        private IList<LifeTimeProjectile> _projectiles = new List<LifeTimeProjectile>();
        private IList<LifeTimeProjectile> _projectilesTrashCan = new List<LifeTimeProjectile>();


        private void Update()
        {
            _projectilesTrashCan.Clear();

            foreach (LifeTimeProjectile item in _projectiles)
            {
                item.ReamingLifeTime -= DecayVelocity * Time.deltaTime;

                if (item.ReamingLifeTime <= 0f)
                {
                    _projectilesTrashCan.Add(item);
                }
            }

            foreach (var item in _projectilesTrashCan)
            {
                if (item.ProjectileEnemyStandard != null)
                {
                    Destroy(item.ProjectileEnemyStandard.gameObject);
                }
                _projectiles.Remove(item);
            }
        }

        public void AddItemToDestruction(EnemyStandardProjectile projectileStandard)
        {
            _projectiles.Add(new LifeTimeProjectile(projectileStandard, projectileStandard.Range));
        }

    }

    public class LifeTimeProjectile
    {
        public EnemyStandardProjectile ProjectileEnemyStandard;
        public float ReamingLifeTime;
        public LifeTimeProjectile(EnemyStandardProjectile projectileStandard, float range)
        {
            ProjectileEnemyStandard = projectileStandard;
            ReamingLifeTime = range;
        }

    }
}
