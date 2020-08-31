using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

namespace Assets.Scripts.Weapons
{
    public class BehaviourSurfaceHit : MonoBehaviour
    {
        public DecalProjector DecalHitEffect;
        public ParticleSystem HitEffect;


        public void ShowDecal(Vector3 position, Vector3 direction)
        {
            DecalProjector decalProjector = Instantiate(DecalHitEffect, position, Quaternion.LookRotation(direction));

            decalProjector.transform.parent = this.gameObject.transform;

        }

        public void ShowHitEffect(Vector3 position, Vector3 direction)
        {
            ParticleSystem particleSystem = Instantiate(HitEffect, position, Quaternion.LookRotation(direction));

            particleSystem.transform.parent = this.gameObject.transform;
            particleSystem.Play();
        }
    }
}
