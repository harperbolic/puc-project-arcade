using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSpawner : MonoBehaviour
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
			var spawnedEntity = Instantiate(toSpawn.spawnEntity.entityPrefab, spawnPoints[toSpawn.position].transform);
			spawnedEntity.GetComponent<EntityScript>().SetEntity(toSpawn.spawnEntity,toSpawn.entitySpeed);
		}
		nextRow++;
		if (level.rows.Length < nextRow)
		{
			yield return Spawn(level.rows[nextRow - 1].secondsToNextRow, level.rows[nextRow]);
		}
		else
		{
			//TODO TROCAR SEÇÕES DO LEVEL - Fazer para a etapa 3
			SceneManager.LoadScene("Victory");
		}
	}

	private void StartSpawn()
	{
		//Logar quantos segundos dura a seção da fase (útil para evitar manter a fase curta ou longa demais)
		float levelLength = secondsToStart;
		foreach (var row in level.rows)
		{
			levelLength += row.secondsToNextRow;
		}
		Debug.Log("Essa seção durará um total de: " + (levelLength) + " segundos");
		nextRow = 0;
		StartCoroutine(Spawn(secondsToStart,level.rows[0]));
	}
}