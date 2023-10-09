using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Overdrive : MonoBehaviour
{

    private bool load;
    public bool isOverdrive;

    // Start is called before the first frame update
    void Start()
    {
        load = true;
	isOverdrive = false;
    }

    [SerializeField] private float boostValue;


    // Update is called once per frame
    void Update()
    {

	if (load == true || Input.GetButtonDown("Overdrive"))
	{
		load = false;
		isOverdrive = true;

		Vector3 newPos = transform.position + Vector3.up * (boostValue);

		
	}
    }
}
