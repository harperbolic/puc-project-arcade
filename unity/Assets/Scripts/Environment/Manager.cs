using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public static int bgmPercent = 100;

    [SerializeField] private int targetFPS;

    [SerializeField] private GameObject BGMSystem;


    void Awake()
    {
        Application.targetFrameRate = targetFPS;

	Instantiate(BGMSystem).GetComponent<{}>;
    }
}