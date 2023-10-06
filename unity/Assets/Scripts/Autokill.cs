using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Autokill : MonoBehaviour
{
    public float tempoemtela;
    private float tempoinicial;
    private float tempoatual;
    // Start is called before the first frame update
    void Start()
    {
        tempoinicial = Time.time;    
    }

    // Update is called once per frame
    void Update()
    {
        tempoatual = Time.time;
        if (tempoatual - tempoinicial >= tempoemtela)
        {
            Destroy(this.gameObject);
        }
    }
}