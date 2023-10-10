using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBlackBall : MonoBehaviour
{
    [SerializeField] private float attackSpeed;
    [SerializeField] private float time;
    private GameObject enemyBullet;
    [SerializeField] private float speed;
    // Start is called before the first frame update
    void Start()
    {
        time = attackSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (time <= 0)
        {
            Instantiate(enemyBullet, transform.position, Quaternion.identity);
            time = attackSpeed;
        }
        else
        {
        time -= Time.deltaTime;
        }
        float movimentoHorizontal = Mathf.Sin(Time.time) * speed * 0.8f; 
        float movimentoVertical = 0.5f * speed;
        Vector3 movimento = new Vector3(movimentoHorizontal, 0.0f, movimentoVertical);
        transform.Translate(movimento * Time.deltaTime);
    }
}