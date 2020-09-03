using Assets.Scripts.Weapons;
using Assets.Scripts.Weapons.Behaviours;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class RecycleProjectileWrapper : MonoBehaviour
    {

        [SerializeField]
        public int _maxSize = 15;
        public int MaxSize
        {
            get => _maxSize;
            set => _maxSize = value;
        }

        private RecycleManager<IProjectile> _recycleManagar;

        [SerializeField]
        public Transform _recyleContainer;
        public Transform RecyleContainer 
        {
            get => _recyleContainer;
            set => _recyleContainer = value;
        }

        private void Start()
        {
            _recycleManagar = new RecycleManager<IProjectile>(MaxSize);
        }


        public ProjectileStandard CreateOrRecoverObject(GameObject prefab)
        {
            ProjectileStandard projectile = (ProjectileStandard)_recycleManagar.Remove();

            if(projectile == null)
            {
                GameObject newProjectile = Instantiate(prefab);
                projectile = newProjectile.GetComponent<ProjectileStandard>();
            }
            else
            {
                //After recover needs to remove the parent.
                projectile.gameObject.transform.parent = null;
            }

            return projectile;
        }

        public void AddOrDestroyObject(GameObject gameObject)
        {
            ProjectileStandard projectile = gameObject.GetComponent<ProjectileStandard>();
            bool result = _recycleManagar.AddIfNecessary(projectile);

            if (!result)
                Destroy(gameObject);
            else
                projectile.gameObject.transform.parent = RecyleContainer;
        }
    }
}
