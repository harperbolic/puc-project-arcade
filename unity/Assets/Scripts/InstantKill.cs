using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantKill : MonoBehaviour
{
    private void OnCollisionEnter(Collision colidido)
    {
        if (colidido.gameObject.CompareTag("Player"))
        {
            Destroy(colidido.gameObject);
        }
        if (colidido.gameObject.CompareTag("Bala"))
        {
            Destroy(colidido.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    
    }
}

