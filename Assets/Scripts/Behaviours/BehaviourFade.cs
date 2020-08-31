using UnityEngine;
using UnityEngine.Rendering.HighDefinition;


[RequireComponent(typeof(DecalProjector))]
public class BehaviourFade : MonoBehaviour
{

    [Range(0,1)]
    public float Frequency;

    public bool DestroyWhenReachZero = true;

    private DecalProjector _decalProjector;

    void Start()
    {
        _decalProjector = GetComponent<DecalProjector>(); 
    }

    void Update()
    {
        _decalProjector.fadeFactor -=  Frequency * Time.deltaTime;

        if (DestroyWhenReachZero && _decalProjector.fadeFactor <= 0f)
        {
            Destroy(gameObject);
        }
    }
}
