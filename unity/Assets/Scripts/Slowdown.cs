using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slowdown : MonoBehaviour
{
    public float tempodeefeito = 5f;
    private float tempoinicio, tempoatual;
    private bool slowdativo = false;
    private void OnCollisionEnter(Collision colidido)
    {
        if (colidido.gameObject.CompareTag("Inimigo"))
        {
            colidido.transform.SetParent(transform);
            colidido.gameObject.SendMessageUpwards("DiminuirVelocidade");
            tempoinicio = Time.time;
            slowdativo = true; 

        }
    }
        // Start is called before the first frame update
        void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (slowdativo && Time.time - tempoinicio >= tempodeefeito)
        {
            Transform filho = transform.GetChild(0);
            filho.gameObject.SendMessageUpwards("AumentarVelocidade");
            filho.SetParent(null);
            filho.gameObject.SendMessage("Sefldestruct");

        }
    }
}
