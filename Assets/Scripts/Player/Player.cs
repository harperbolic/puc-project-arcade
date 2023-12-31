using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private bool canTakeDamage = true;
    private bool isGodMode;
    [SerializeField] private GameObject playerPart;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip deathSFX, damageSFX, shootSFX, enemyDeathSFX;
    [SerializeField] private int hp;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private HealthDisplay healthDisplay;
    private void OnCollisionEnter(Collision collided)
    {
        if (canTakeDamage)
        {
            if (collided.gameObject.GetComponent<Bullet>() &&
                collided.gameObject.GetComponent<Bullet>().DamageCheck(true))
            {
                Instantiate(playerPart, gameObject.transform.position, Quaternion.identity);
                TakeDamage();
                Destroy(collided.gameObject);
            }
            else if (collided.gameObject.GetComponent<EntityScript>() &&
                     collided.gameObject.GetComponent<EntityScript>().entity.doesContactDamage)
            {
                Instantiate(playerPart, gameObject.transform.position, Quaternion.identity);
                TakeDamage();
                audioSource.PlayOneShot(enemyDeathSFX, 0.7f);
                Destroy(collided.gameObject);
            }
        }
        else
        {
            if (!(collided.gameObject.GetComponent<Bullet>() &&
                collided.gameObject.GetComponent<Bullet>().DamageCheck(false)))
            {
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
        if (Input.GetKeyDown(KeyCode.G))
        {
            isGodMode = true;
            canTakeDamage = false;
        }
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
            audioSource.PlayOneShot(shootSFX, 0.2f);
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
            audioSource.PlayOneShot(deathSFX,0.7f);  
            SceneManager.LoadScene("GameOverScreen");
            Destroy(gameObject);
        }
        else
        {
         audioSource.PlayOneShot(damageSFX,0.7f);   
        }
    }

    public void ChangeInvincibility()
    {
        if (!isGodMode)
        {
            canTakeDamage = !canTakeDamage;
        }
    }
}
