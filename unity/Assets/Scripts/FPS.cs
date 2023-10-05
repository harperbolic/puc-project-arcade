using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS : MonoBehaviour
{
    public int targetFPS = 60;

    void Awake()
    {
        Application.targetFrameRate = targetFPS;
    }
}
