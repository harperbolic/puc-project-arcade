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
	private static GameObject[] spawnPoints;
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
			var entityScript = spawnedEntity.AddComponent<EntityScript>();
			entityScript.SetEntity(toSpawn.spawnEntity);
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

	public static float GetSpawnPoint (int s)
	{
		return spawnPoints[s].transform.position.x;
	}
}