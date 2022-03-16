using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSLImit : MonoBehaviour
{
    public int TargetFramrate = 144;
    private void Start()
    {
        TargetFramrate = Screen.currentResolution.refreshRate;
        QualitySettings.vSyncCount = 1;
        Application.targetFrameRate = TargetFramrate;
    }
}