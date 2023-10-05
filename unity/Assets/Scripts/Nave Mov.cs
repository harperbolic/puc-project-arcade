using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveMov : MonoBehaviour
{
    public float velocidadeMovimento = 5.0f;
    public float limiteEsquerdo = -5.0f; // Limite esquerdo da �rea retangular
    public float limiteDireito = 5.0f;   // Limite direito da �rea retangular
    public GameObject projetil, arma;
    void Update()
    {
        // Obt�m a entrada do jogador no eixo horizontal (teclas A e D, setas esquerda e direita, etc.)
        float movimentoHorizontal = Input.GetAxis("Horizontal");

        // Calcula a nova posi��o da nave
        Vector3 novaPosicao = transform.position + Vector3.right * movimentoHorizontal * velocidadeMovimento * Time.deltaTime;

        // Limita a nave dentro da �rea retangular
        novaPosicao.x = Mathf.Clamp(novaPosicao.x, limiteEsquerdo, limiteDireito);

        // Atualiza a posi��o da nave
        transform.position = novaPosicao;

        if (Input.GetButtonDown("Atirar"))
        {
            Instantiate(projetil, arma.transform);
        }

    }
}
