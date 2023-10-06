using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantKill : MonoBehaviour
{
    private void OnCollisionEnter(Collision colidido)
    {
        if (colidido.gameObject.CompareTag("Player")||colidido.gameObject.CompareTag("Bala"))
        {
            Destroy(colidido.gameObject);
        }
    }
}

