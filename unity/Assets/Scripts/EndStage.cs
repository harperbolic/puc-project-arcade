using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndStage : MonoBehaviour
{
    void Start()
    {
	StartCoroutine(waiter());
    }

    IEnumerator waiter()
    {
	yield return new WaitForSeconds(18);
	SceneManager.LoadScene("Victory");
}
}