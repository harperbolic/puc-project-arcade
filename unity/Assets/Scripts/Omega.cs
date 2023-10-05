using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Omega : MonoBehaviour
{
    private void OnCollisionEnter(Collision colidido)
    {
        name = colidido.gameObject.name;

        if (name != "Plane")

            Destroy(colidido.gameObject);

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
