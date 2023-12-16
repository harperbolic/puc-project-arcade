using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EntityScript : MonoBehaviour
{
    public GameObject entPart;
    public AudioSource audioSource;
    public AudioClip deathSFX;
    public Entity entity;
    private int hp;
    private int speed;
    [NonSerialized]
    public LevelSpawner levelSpawner;
    [NonSerialized]
    public Player player;

    public Overdrive overdrive;
    void Start()
    {
        hp = entity.hp;
        speed = entity.startingspeed;
        if (entity.shootsProjectiles && entity.movType != Entity.MovementTypes.SetMovement && entity.movType != Entity.MovementTypes.Boss)
        {
            StartCoroutine(Shoot(entity.projectilePrefab, entity.projectileSpeed,entity.projectileRate,true,0));
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
            case Entity.MovementTypes.Boss:
            {
                StartCoroutine(BossMove());
                break;
            }
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
        if (entity.takesBulletDamage && collided.gameObject.GetComponent<Bullet>() && collided.gameObject.GetComponent<Bullet>().DamageCheck(false))
        {
            Instantiate(entPart,transform.position,Quaternion.identity);
            if (--hp < 1)
            {
                if (entity.movType == Entity.MovementTypes.Boss)
                {
                    SceneManager.LoadScene("Victory");
                }
                audioSource.PlayOneShot(deathSFX,0.7f);
                overdrive.canOverdrive = true;
                Destroy(gameObject);
            }
            Destroy(collided.gameObject);
        }
    }
    private IEnumerator Shoot (GameObject bullet, float bSpeed, float bRate, bool fixedRate, int bulletNum)
    {
        if (fixedRate)
        {
            while (true)
            {
                yield return new WaitForSeconds(bRate);
                Instantiate(bullet, transform).GetComponent<Bullet>().DefineBullet(false, bSpeed);
            }
        }
        float shotDelay = bRate / bulletNum;
        for (int i = 0; i < bulletNum; i++)
        {
            yield return new WaitForSeconds(shotDelay);
            Instantiate(bullet, transform).GetComponent<Bullet>().DefineBullet(false, bSpeed);
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
                if (entity.shootsProjectiles)
                {
                    StartCoroutine(Shoot(entity.projectilePrefab, entity.projectileSpeed, nSpot.movLength, false, nSpot.shotsPerMove));
                }
                yield return StartCoroutine(MoveNext(spotX,nSpot.movLength,nSpot.newVertSpeed));
            }
        }
    }
    private IEnumerator BossMove()
    {
        while (true)
        {
            foreach (var nSpot in entity.spots)
            {
                var spotX = levelSpawner.GetSpawnPoint(nSpot.spot);
                if (entity.shootsProjectiles)
                {
                    StartCoroutine(Shoot(entity.projectilePrefab, entity.projectileSpeed, nSpot.movLength, false, nSpot.shotsPerMove));
                }
                yield return StartCoroutine(MoveNext(spotX,nSpot.movLength,0));
            }
        }
    }
    private IEnumerator MoveNext(float destinationX, float movLength, int newVertSpeed)
    {
        float timePassed = 0.0f;
        Vector3 ePosition = transform.position;
        float initialPosition = ePosition.x;
        speed = newVertSpeed;
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
