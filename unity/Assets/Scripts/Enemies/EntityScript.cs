using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityScript : MonoBehaviour
{
    public Entity entity;
    [SerializeField] private Player player;
    private int hp;
    private int speed;
    private int currentSpot = 0;
    [NonSerialized]
    public LevelSpawner levelSpawner;
    void Start()
    {
        hp = entity.hp;
        speed = entity.speed;
        if (entity.shootsProjectiles)
        {
            StartCoroutine(Shoot(entity.projectilePrefab, entity.projectileSpeed,entity.projectileRate));
        }
        if (entity.movType != Entity.MovementTypes.None)
        {
            Movement();
        }
        if (entity.selfDestructs)
        {
            StartCoroutine(SelfDestruct(entity.timeToSelfDestruct));
        }
    }
    public void SetEntity(Entity newEntity)
    {
        entity = newEntity;
    }

    private void Movement()
    {
        switch (entity.movType)
        { 
            case Entity.MovementTypes.Follow:
            {
                StartCoroutine(FollowMove());
                break;
            }
            case Entity.MovementTypes.SetMovement:
            {
                StartCoroutine(SetMove());
                break;
            }
            case Entity.MovementTypes.Straight:
            {
                StartCoroutine(StraightMove());
                break;
            }
        }
    }
    private void OnCollisionEnter(Collision collided)
    {
        if (entity.takesBulletDamage && collided.rigidbody.gameObject.GetComponent<Bullet>().DamageCheck(false))
        {
            if (--hp < 1)
            {
                if (entity.entType == Entity.EntityTypes.Enemy)
                {
                    //TODO Encher barra de overdrive
                }
                Destroy(gameObject);
            }
        }
    }
    private IEnumerator Shoot (GameObject bullet, float bSpeed, float bRate)
    {
        while (true)
        {
            yield return new WaitForSeconds(bRate);
            Instantiate(bullet).GetComponent<Bullet>().DefineBullet(false, bSpeed);
        }
    }
    private IEnumerator FollowMove()
    {
        while (true)
        {
            var ePosition = transform.position;
            Vector3 playerDirection = new Vector3(player.GetPlayerPosition().x,ePosition.y,ePosition.z);
            transform.Translate(playerDirection * (-1 * speed * Time.deltaTime));
            transform.Translate(Vector3.forward * (-1 *speed * Time.deltaTime));
            yield return null;
        }
    }
    private IEnumerator StraightMove()
    {
        while (true)
        {
            transform.Translate(Vector3.forward * (-1 * speed * Time.deltaTime));
            yield return null;
        }
    }
    private IEnumerator SetMove()
    {
        var spots = entity.spots;
        while (true)
        {
            var spotX = levelSpawner.GetSpawnPoint(spots[currentSpot].spot);
            yield return StartCoroutine(MoveNext(spotX,spots[currentSpot].movLength));
            if (++currentSpot > spots.Length)
            {
                currentSpot = 0;
            }
        }
    }
    private IEnumerator MoveNext(float destinationX, float movLength)
    {
        float timePassed = 0.0f;
        Vector3 ePosition = transform.position;
        float initialPosition = ePosition.x;
        while (timePassed < movLength)
        {
            transform.position.Set(Mathf.Lerp(initialPosition, destinationX, timePassed / movLength),ePosition.y,ePosition.z);
            transform.Translate(Vector3.forward * (speed * Time.deltaTime));
            ePosition = transform.position;
            timePassed += Time.deltaTime;
            yield return null;
        }
        transform.position = new Vector3(destinationX,transform.position.y,transform.position.z);
    }
    private IEnumerator SelfDestruct(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
