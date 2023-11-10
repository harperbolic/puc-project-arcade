using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSpawner : MonoBehaviour
{
	[SerializeField]
	private float secondsToStart;
	[SerializeField] private Level[] levels;
	private int currentLevelIndex;
	private Level currentLevel;
	public GameObject[] spawnPoints;

	[SerializeField] private Player player;
	private void Start()
	{
		currentLevelIndex = -1;
		SetCurrentLevel();
	}

	private IEnumerator Spawn()
	{
		//Logar quantos segundos dura a seção da fase (útil para evitar manter a fase curta ou longa demais)
		float levelLength = secondsToStart;
		foreach (var row in currentLevel.rows)
		{
			levelLength += row.secondsToNextRow;
		}
		Debug.Log("Essa seção durará um total de: " + (levelLength) + " segundos");
		yield return new WaitForSeconds(secondsToStart);
		
		foreach (var row in currentLevel.rows)
		{
			foreach (var toSpawn in row.spawnPoints)
			{
				var spawnedEntity = Instantiate(toSpawn.spawnEntity.entityPrefab,
					spawnPoints[toSpawn.position].transform.position, Quaternion.Euler(0,180f,0));
				var entityScript = spawnedEntity.AddComponent<EntityScript>();
				entityScript.levelSpawner = this;
				entityScript.player = player;
				entityScript.SetEntity(toSpawn.spawnEntity);
			}
			yield return new WaitForSeconds(row.secondsToNextRow);
		}

		if (currentLevelIndex + 1 == levels.Length)
		{
			SceneManager.LoadScene("Victory");
		}
		else
		{
			SetCurrentLevel();
		}
	}
	public float GetSpawnPoint (int s)
	{
		return spawnPoints[s].transform.position.x;
	}

	private void SetCurrentLevel()
	{
		currentLevelIndex++;
		currentLevel = levels[currentLevelIndex];
		StartCoroutine(Spawn());		
	}
}