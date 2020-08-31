using UnityEngine;

namespace Assets.Scripts
{
    public class BehaviourFollowObject : MonoBehaviour
    {
        public GameObject Target;

        public Transform Transform;

        public float Speed = 1.5f;

        public float RotationSpeed = 5.0f;

        public float DistanceToStop = 10f;

        private void Update()
        {
            Vector3 direction = Target.transform.position - Transform.position;
             
            //Analises if the object can approach to target.
            if(direction.magnitude >= DistanceToStop)
            {
                Transform.position = Vector3.MoveTowards(Transform.position, Target.transform.position, Speed * Time.deltaTime);
            }



            Quaternion rotation = Quaternion.LookRotation(direction);
            Transform.rotation = Quaternion.Lerp(Transform.rotation, rotation, RotationSpeed * Time.deltaTime);
        }
    }
}
