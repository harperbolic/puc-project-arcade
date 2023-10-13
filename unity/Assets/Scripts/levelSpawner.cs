using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelSpawner : MonoBehaviour
{
	[SerializeField]
	private float secondsToStart;
	[SerializeField] private Level level;
	private int nextRow;
	[SerializeField] private GameObject[] spawnPoints;
	private void Start()
	{
		StartSpawn();
	}

	private IEnumerator Spawn(float timeToWait, Row rowToSpawn)
	{
		yield return new WaitForSeconds(timeToWait);
		foreach (var toSpawn in rowToSpawn.spawnPoints)
			{
				Instantiate(toSpawn.spawnEntity, spawnPoints[toSpawn.position].transform);
			}
			yield return Spawn(level.rows[nextRow].secondsToNextRow, level.rows[++nextRow]);
	}
	private void StartSpawn()
	{
		//Logar quantos segundos dura a seção da fase (útil para evitar manter a fase curta ou longa demais)
		float levelLength = 20;
		foreach (var row in level.rows)
		{
			levelLength += row.secondsToNextRow;
		}
		Debug.Log("Essa seção durará um total de: " + (levelLength + secondsToStart) + " segundos");
		//
		//TODO TROCAR SEÇÃO DO LEVEL - Fazer para a etapa 3
		nextRow = 0;
		StartCoroutine(Spawn(secondsToStart,level.rows[0]));
	}
}