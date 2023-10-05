using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NovaMovimentacao : MonoBehaviour
{ 
public float velocidadeMaxima = 5f;
public float aceleracao = 2f;
public float desaceleracao = 5f;
private Rigidbody rb;
private Vector3 velocidadeAtual;


    void Start()
{
    rb = GetComponent<Rigidbody>();
}

    void Update()
    {
        // Input horizontal e vertical
        float inputHorizontal = Input.GetAxis("Horizontal");
        float inputVertical = Input.GetAxis("Vertical");

        // Calcula a direção do movimento
        Vector3 direcao = new Vector3(inputHorizontal, 0, inputVertical).normalized;

        // Calcula a velocidade desejada com base no input
        Vector3 velocidadeDesejada = direcao * velocidadeMaxima;

        // Calcula a aceleração
        Vector3 aceleracaoAtual = (velocidadeDesejada - rb.velocity) * aceleracao;

        // Aplica a aceleração ao rigidbody
        rb.AddForce(aceleracaoAtual);

        // Interpolação linear para suavizar a desaceleração
        if (direcao == Vector3.zero)
        {
            rb.velocity = Vector3.Lerp(rb.velocity, Vector3.zero, desaceleracao * Time.deltaTime);
        }

    }
}
