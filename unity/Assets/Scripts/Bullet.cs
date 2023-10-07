using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private bool isPlayer;
    private float speed;
    void Update()
    {
        transform.Translate( 0 , 0 , speed);
        Destroy(this.gameObject, 0.9F); //TODO Remover condição por tempo de autodestruição da bala, realizando a autodestruição considerando a posição
    }
    //Define a velocidade inicial da bala e quem a disparou
    public void DefineBullet(bool bisPlayer, float bSpeed)
    {
        isPlayer = bisPlayer;
        speed = bSpeed;
    }
    //Checa se o projétil deveria dar dano
    //Fazendo com que projéteis do jogador e dos inimigos não deem danos em quem os dispara
    //Retorna true caso a entidade deva receber dano
    public bool DamageCheck(bool targetIsPlayer)
    {
        if (isPlayer == targetIsPlayer)
        {
            return false;
        }
        return true;
    }
}