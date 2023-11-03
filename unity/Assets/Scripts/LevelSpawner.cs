using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSpawner : MonoBehaviour
{
	[SerializeField]
	private float secondsToStart;
	[SerializeField] private Level level;
	public GameObject[] spawnPoints;
	private void Start()
	{
		StartCoroutine(Spawn());
	}

	private IEnumerator Spawn()
	{
		//Logar quantos segundos dura a seção da fase (útil para evitar manter a fase curta ou longa demais)
		float levelLength = secondsToStart;
		foreach (var row in level.rows)
		{
			levelLength += row.secondsToNextRow;
		}
		Debug.Log("Essa seção durará um total de: " + (levelLength) + " segundos");
		yield return new WaitForSeconds(secondsToStart);
		
		foreach (var row in level.rows)
		{
			foreach (var toSpawn in row.spawnPoints)
			{
				var spawnedEntity = Instantiate(toSpawn.spawnEntity.entityPrefab, spawnPoints[toSpawn.position].transform);
				var entityScript = spawnedEntity.AddComponent<EntityScript>();
				entityScript.levelSpawner = this;
				entityScript.SetEntity(toSpawn.spawnEntity);
			}
			yield return new WaitForSeconds(row.secondsToNextRow);
		}
		//TODO TROCAR SEÇÕES DO LEVEL - Fazer para a etapa 3
		SceneManager.LoadScene("Victory");
	}
	public float GetSpawnPoint (int s)
	{
		return spawnPoints[s].transform.position.x;
	}
}