using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveMov : MonoBehaviour
{
    public float velocidadeMovimento = 5.0f;
    public float limiteEsquerdo = -5.0f; // Limite esquerdo da área retangular
    public float limiteDireito = 5.0f;   // Limite direito da área retangular
    public GameObject projetil, arma;
    void Update()
    {
        // Obtém a entrada do jogador no eixo horizontal (teclas A e D, setas esquerda e direita, etc.)
        float movimentoHorizontal = Input.GetAxis("Horizontal");

        // Calcula a nova posição da nave
        Vector3 novaPosicao = transform.position + Vector3.right * movimentoHorizontal * velocidadeMovimento * Time.deltaTime;

        // Limita a nave dentro da área retangular
        novaPosicao.x = Mathf.Clamp(novaPosicao.x, limiteEsquerdo, limiteDireito);

        // Atualiza a posição da nave
        transform.position = novaPosicao;

        if (Input.GetButtonDown("Atirar"))
        {
            Instantiate(projetil, arma.transform);
        }

    }
}
