using UnityEngine;
[System.Serializable]
public class SpawnPoint
{
    public int position;    //0-6, com cada número simbolizando um dos espaços separados pelas cordas
    public GameObject spawnEntity;
}
[System.Serializable]
public class Row
{
    public SpawnPoint[] spawnPoints;
    public float secondsToNextRow;
}

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Level", order = 1)]
public class Level : ScriptableObject
{
    public Row[] rows;
}