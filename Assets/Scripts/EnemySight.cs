using UnityEngine;

public class EnemySight : MonoBehaviour
{
    public GameObject Target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = Target.transform.position - transform.position;
        float angleZ = Vector3.Angle(dir, transform.forward);

        float angleY = Vector3.Angle(dir, transform.up);
        Debug.Log($"Angle Y: {angleY}  AngleZ: {angleZ} ");

        Debug.DrawRay(transform.position, dir, Color.red, 2);
    }
}
