using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    [SerializeField] private int targetFPS;

    void Awake()
    {
        Application.targetFrameRate = targetFPS;
    }
}