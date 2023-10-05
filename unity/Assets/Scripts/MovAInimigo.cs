using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovAInimigo : MonoBehaviour
{
    public float tempoTiro;
    private float tempo;
    public GameObject projetil;
    public float velocidade = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        tempo = tempoTiro;
    }

    // Update is called once per frame
    void Update()
    {
        if (tempo <= 0)
        {
            Instantiate(projetil, transform.position, Quaternion.identity);
            tempo = tempoTiro;
        }
        else
        {
        tempo -= Time.deltaTime;
        }
        float movimentoHorizontal = Mathf.Sin(Time.time) * velocidade * 0.8f; 
        float movimentoVertical = 0.5f * velocidade;
        Vector3 movimento = new Vector3(movimentoHorizontal, 0.0f, movimentoVertical);
        transform.Translate(movimento * Time.deltaTime);
    }
}
