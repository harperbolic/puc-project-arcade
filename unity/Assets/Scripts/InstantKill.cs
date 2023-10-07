using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantKill : MonoBehaviour
{
    private void OnCollisionEnter(Collision collided)
    {
        if (collided.gameObject.CompareTag("Player")||collided.gameObject.CompareTag("Bala"))
        {
            Destroy(collided.gameObject);
        }
    }
}

