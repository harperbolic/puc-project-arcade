using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private int hp;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private HealthDisplay healthDisplay;
    private void OnCollisionEnter(Collision collided)
    {
        if (collided.gameObject.GetComponent<Bullet>() && collided.gameObject.GetComponent<Bullet>().DamageCheck(true))
        {
            TakeDamage();
            Destroy(collided.gameObject);
        }
        else if(collided.gameObject.GetComponent<EntityScript>() && collided.gameObject.GetComponent<EntityScript>().entity.doesContactDamage)
        {
            TakeDamage();
            Destroy(collided.gameObject);
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

    public Vector3 GetPlayerPosition()
    {
        return transform.position;
    }

    public void TakeDamage()
    {
        healthDisplay.RemoveHeart();
        if (--hp < 1)
        {
            SceneManager.LoadScene("GameOverScreen");
            Destroy(this.gameObject);
        }
    }
}
