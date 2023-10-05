using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoBala : MonoBehaviour
{
    public float velocidade;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate( 0 , 0 , velocidade);
        Destroy(this.gameObject, 0.9F);
    }
}
