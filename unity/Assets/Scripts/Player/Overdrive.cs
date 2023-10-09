using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Overdrive : MonoBehaviour
{

    private bool canOverdrive;
    public bool isOverdrive;

    [SerializeField] private float overdrivePower = 24f;
    [SerializeField] private float overdriveTime = 0.2f;


    void Start()
    {
        canOverdrive = true;
	isOverdrive = false;
    }



    void Update()
    {

	if (canOverdrive == true && Input.GetButtonDown("Overdrive"))
	{
		StartCoroutine(overdrive());
	}
    }

    IEnumerator overdrive()
    {
	float startTime = Time.time;

	canOverdrive = false;
	isOverdrive = true;

	transform.Translate(Vector3.forward * overdrivePower);
	yield return new WaitForSeconds(0.2f);
	transform.Translate(Vector3.forward * (-1 * overdrivePower));
	
	isOverdrive = false;
	yield return null;
    }

}