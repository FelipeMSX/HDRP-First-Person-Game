using UnityEngine;

namespace Assets.Scripts
{
    public class BehaviourFixedMovement : MonoBehaviour
    {
        public Axis AxisToMove;

        public float MoveSpeed = 1.5f;

        public float MaxRange = 10f;

        private Vector3 _vectorMax;
        private Vector3 _vectorMin;

        private bool _swapDirection;

        private void Start()
        {
            if (AxisToMove == Axis.X)
            {
                _vectorMax = new Vector3(transform.position.x + GetValue(), transform.position.y, transform.position.z);
                _vectorMin = new Vector3(transform.position.x - GetValue(), transform.position.y, transform.position.z);
            }
            else if (AxisToMove == Axis.Y)
            {
                _vectorMax = new Vector3(transform.position.x, transform.position.y + GetValue(), transform.position.z);
                _vectorMin = new Vector3(transform.position.x, transform.position.y - GetValue(), transform.position.z);
            }
            else
            {
                _vectorMax = new Vector3(transform.position.x, transform.position.y, transform.position.z + GetValue());
                _vectorMin = new Vector3(transform.position.x, transform.position.y, transform.position.z - GetValue());
            }
        }

        private void Update()
        {

            if (Vector3.Distance(transform.position, _vectorMax) <= 0f)
                _swapDirection = true;
            else if (Vector3.Distance(transform.position, _vectorMin) <= 0f)
                _swapDirection = false;


            if (_swapDirection)
            {
                transform.position = Vector3.MoveTowards(transform.position, _vectorMin, MoveSpeed * Time.deltaTime);
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, _vectorMax, MoveSpeed * Time.deltaTime);
            }
        }


        private float GetValue()
        {
            return MaxRange + Time.deltaTime;
        }
    }
}
