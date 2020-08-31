using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Weapons.Behaviours
{


    public class RangeDestructionBehaviour : MonoBehaviour
    {
        public float DecayVelocity = 30.0f;

        private IList<LifeTimeProjectile> _projectiles = new List<LifeTimeProjectile>();
        private IList<LifeTimeProjectile> _projectilesTrashCan= new List<LifeTimeProjectile>();


        private void Update()
        {
            _projectilesTrashCan.Clear();

            foreach (LifeTimeProjectile item in _projectiles)
            {
                item.ReamingLifeTime -= DecayVelocity * Time.deltaTime;

                if(item.ReamingLifeTime <= 0f)
                {
                    _projectilesTrashCan.Add(item);
                }
            }

            foreach (var item in _projectilesTrashCan)
            {
                if(item.ProjectileStandard != null)
                {
                    Destroy(item.ProjectileStandard.gameObject);
                }
                _projectiles.Remove(item);
            }
        }

        public void AddItemToDestruction(ProjectileStandard projectileStandard)
        {
            _projectiles.Add(new LifeTimeProjectile(projectileStandard, projectileStandard.Range));
        }

    }

    public class LifeTimeProjectile
    {
        public ProjectileStandard ProjectileStandard;
        public float ReamingLifeTime;
        public LifeTimeProjectile(ProjectileStandard projectileStandard, float range)
        {
            ProjectileStandard = projectileStandard;
            ReamingLifeTime = range;
        }

    }  
}
