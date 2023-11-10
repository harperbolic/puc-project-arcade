using UnityEngine;
[System.Serializable]
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Entity", order = 1)]
public class Entity : ScriptableObject
{
    public enum MovementTypes
    {
        SetMovement, //Move-se para pontos pré-determinados em loop
        Straight, //Move-se para frente sem qualquer movimento para os lados
        Follow, //Avança imitando o movimento lateral do jogador
        None //Não move-se
    }
    public enum EntityTypes
    {
        Enemy, //Inimigo: Pode ser destruído para recarregar seu overdrive
        Obstacle, //Obstáculo, pode dar dano ou atrapalhar o jogador de alguma forma, alguns podem ser destruídos pelo overdrive, outros devem apenas ser evitados
        PowerUp, //Powerup
        Other //Qualquer coisa que não se encaixe nas outra categorias
    }
    [System.Serializable]
    public class Spot
    {
        //0-6, com cada número simbolizando um dos espaços separados pelas cordas
        public int spot;
        //Duração do movimento (em segundos)
        public float movLength;
        public int newVertSpeed;
    }
    
    public EntityTypes entType;
    public MovementTypes movType;
    public GameObject entityPrefab;
    public int hp;
    public int startingspeed;
    public bool takesBulletDamage;
    public bool doesContactDamage;
    public bool shootsProjectiles;
    //Nulos se não disparar projéteis
    public GameObject projectilePrefab;
    public float projectileSpeed;
    //Tempo até próximo disparo
    public float projectileRate;
    //Usado apenas em entidades com movType SetMovement
    public Spot[] spots;
    public bool selfDestructs;
    //Usado apenas em entidades com selfDestructs
    public float timeToSelfDestruct;

}