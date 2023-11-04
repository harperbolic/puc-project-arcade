using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityScript : MonoBehaviour
{
    public Entity entity;
    private int hp;
    private int speed;
    [NonSerialized]
    public LevelSpawner levelSpawner;
    [NonSerialized]
    public Player player;
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
            Instantiate(bullet,transform).GetComponent<Bullet>().DefineBullet(false, bSpeed);
        }
    }
    private IEnumerator FollowMove()
    {
        while (true)
        {
            var ePosition = transform.position;
            Vector3 playerDirection = new Vector3(player.GetPlayerPosition().x,ePosition.y,ePosition.z);
            transform.position = Vector3.MoveTowards(ePosition, playerDirection, Time.deltaTime);
            transform.Translate(Vector3.forward * (speed * Time.deltaTime));
            yield return null;
        }
    }
    private IEnumerator StraightMove()
    {
        while (true)
        {
            transform.Translate(Vector3.forward * (speed * Time.deltaTime));
            yield return null;
        }
    }
    private IEnumerator SetMove()
    {
        while (true)
        {
            foreach (var nSpot in entity.spots)
            {
                var spotX = levelSpawner.GetSpawnPoint(nSpot.spot);
                yield return StartCoroutine(MoveNext(spotX,nSpot.movLength));
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
            transform.position = Vector3.Lerp(new Vector3(initialPosition,ePosition.y,ePosition.z), new Vector3(destinationX,ePosition.y,ePosition.z), timePassed / movLength);
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
