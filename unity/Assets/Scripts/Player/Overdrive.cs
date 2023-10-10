using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Overdrive : MonoBehaviour
{

    private bool canOverdrive;
    public bool isOverdrive;

    [SerializeField] private float overdrivePower = 2.0f;
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
	canOverdrive = false;
	isOverdrive = true;

	transform.Translate(Vector3.forward * overdrivePower);
	yield return new WaitForSeconds(overdriveTime);
	transform.Translate(Vector3.forward * (-1 * overdrivePower));
	
	isOverdrive = false;
	yield return null;
    }

}