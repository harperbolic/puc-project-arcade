using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teste : MonoBehaviour
{
    public string death;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Nave") == null)
        {
            SceneManager.LoadScene(death);
        }

    }
}
