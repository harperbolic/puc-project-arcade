using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBlackBall : MonoBehaviour
{
    [SerializeField] private float attackSpeed;
    [SerializeField] private float time;
    [SerializeField]private GameObject enemyBullet;
    [SerializeField] private float speed;
    void Start()
    {
        time = attackSpeed;
    }
    
    void Update()
    {
        if (time <= 0)
        {
            Instantiate(enemyBullet, transform.position, Quaternion.identity).GetComponent<Bullet>().DefineBullet(false,0.4f);
            time = attackSpeed;
        }
        else
        {
        time -= Time.deltaTime;
        }
        float movimentoHorizontal = Mathf.Sin(Time.time) * speed * 0.8f;
        float movimentoVertical = 0.5f * speed * -1;
        Vector3 movimento = new Vector3(movimentoHorizontal, 0.0f, movimentoVertical);
        transform.Translate(movimento * Time.deltaTime);
    }
    private void OnCollisionEnter(Collision collided)
    {
        if (collided.rigidbody.gameObject.GetComponent<Bullet>().DamageCheck(false))
        {
            Destroy(this.gameObject);
            }
    }
}    