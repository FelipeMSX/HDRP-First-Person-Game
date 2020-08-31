using UnityEngine;

namespace Assets.Scripts
{
    public class BehaviourRotate : MonoBehaviour
    {
        public Axis AxisToRotate;

        public float RotationSpeed = 1.5f;

        public bool AntiClockWise;


        private void Update()
        {
            
            if(AxisToRotate == Axis.X)
            {
                transform.Rotate(transform.rotation.x +GetValue(), 0f,0f, Space.Self);
            }else if( AxisToRotate == Axis.Y)
            {
                transform.Rotate(0f, transform.rotation.y + GetValue(), 0f, Space.Self);
            }
            else
            {
                transform.Rotate(0f, 0f, transform.rotation.z + GetValue(), Space.Self);
            }
        }


        private float GetValue()
        {
            float value = RotationSpeed + Time.deltaTime;
            return AntiClockWise ? - value : value;
        }
    }

    public enum Axis { X,Y,Z};
}
