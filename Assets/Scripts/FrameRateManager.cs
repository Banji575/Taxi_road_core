using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameRateManager : MonoBehaviour
{
    private int targetFrameRate = 60;
    void Start()
    {
        Application.targetFrameRate = targetFrameRate;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
