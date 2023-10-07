using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelSpawner : MonoBehaviour
{

	[SerializeField] private Transform level;
	private void Awake() {
		Instantiate(level, new Vector3(0,0), Quaternion.identity);
		

	}

}
