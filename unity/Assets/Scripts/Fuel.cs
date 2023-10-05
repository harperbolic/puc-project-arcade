using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuel : MonoBehaviour
{
    public Negacao scriptNegacao;
    public float amount, velocidade;
    private void OnCollisionEnter(Collision colidido)
    {
        if (colidido.gameObject.CompareTag("Player"))
        {
            Negacao scriptNegacao = colidido.gameObject.GetComponent<Negacao>();
            if (scriptNegacao != null)
            {
                scriptNegacao.AddFuel(amount);
            }
            else
            {
                Debug.LogError("O objeto Player não possui o componente Negacao.");
            }
            Destroy(this.gameObject);
        }
    }
    void Start()
    {
        

    }

    void Update()
    {
        transform.Translate(0, 0, -velocidade);
    }


}
