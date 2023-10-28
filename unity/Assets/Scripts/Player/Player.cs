using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private int hp;
    [SerializeField] private float bulletSpeed;
    private void OnCollisionEnter(Collision collided)
    {
        //TODO Checar se é um inimigo, obstáculo ou bala, atualmente a colisão só é efetuada com as balas
        if (collided.rigidbody.gameObject.GetComponent<Bullet>().DamageCheck(true))
        {
	    if (hp <= 0)
       	    {
            SceneManager.LoadScene("GameOverScreen");
            Destroy(this.gameObject);
            }
	    else
	    {
            hp--;
            Destroy(collided.gameObject);
	    }
        }
    }
    public float velocidadeMovimento = 5.0f;
    public float limiteEsquerdo = -4.0f; // Limite esquerdo da área retangular
    public float limiteDireito = 4.0f;   // Limite direito da área retangular
    [SerializeField] private GameObject playerBullet;

    void Update()
    {
        // Obtém a entrada do jogador no eixo horizontal (teclas A e D, setas esquerda e direita, etc.)
        float movimentoHorizontal = Input.GetAxis("Horizontal");

        // Calcula a nova posição da nave
        Vector3 novaPosicao = transform.position + Vector3.right * (movimentoHorizontal * velocidadeMovimento * Time.deltaTime);

        // Limita a nave dentro da área retangular
        novaPosicao.x = Mathf.Clamp(novaPosicao.x, limiteEsquerdo, limiteDireito);

        // Atualiza a posição da nave
        transform.position = novaPosicao;

        if (Input.GetButtonDown("Shoot"))
        {
            Instantiate(playerBullet, transform.position,Quaternion.identity).GetComponent<Bullet>().DefineBullet(true,bulletSpeed);
        }
    }

    public float GetXLocation()
    {
        return transform.position.x;
    }
}
