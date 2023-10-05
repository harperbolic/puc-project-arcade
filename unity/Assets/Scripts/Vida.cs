using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vida : MonoBehaviour
{
    public int life;
    private void OnCollisionEnter(Collision colidido)
    {
        if (colidido.gameObject.CompareTag("Bala"))
        {
            life--;
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
        if (life <= 0)
        {
            Destroy(this.gameObject);
        }
    }

}
