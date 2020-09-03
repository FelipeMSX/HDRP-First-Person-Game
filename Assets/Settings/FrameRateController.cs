using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameRateController : MonoBehaviour
{
    [SerializeField]
    private int _frameRate = 60;
    public int FrameRate 
    {
        get => _frameRate;
        set => _frameRate = value;
    }
    void Start()
    {
        QualitySettings.vSyncCount = 2;
        Application.targetFrameRate = 60;
    }

}
