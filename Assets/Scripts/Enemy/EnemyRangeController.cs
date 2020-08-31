using Assets.Scripts.Enemy;
using UnityEngine;

public class EnemyRangeController : MonoBehaviour, IEnemyRangeFollowBehaviour
{

    public float Range = 10f;

    private GameObject _controlledObject;

    public void Follow(GameObject controlledObject)
    {
        _controlledObject = controlledObject;
    }

    void Update()
    {
        if (_controlledObject == null)
            return;


        if ((this.transform.position - _controlledObject.transform.position).magnitude <= Range)
        {
            Debug.Log("Está no Range");
        }
        else
        {
            Debug.Log("Não está no Range");
        }
    }
}
