using UnityEngine;
[System.Serializable]
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Entity", order = 1)]
public class Entity : ScriptableObject
{
    public enum MovementTypes
    {
        Zigzag, //Move-se para frente enquanto se movimenta-se para os lados em zigzag
        Straight, //Move-se para frente sem qualquer movimento para os lados
        Follow, //Avança imitando o movimenbto lateral do jogador
        None //Não move-se
    }
    public enum EntityTypes
    {
        Enemy, //Inimigo: Pode ser destruído para recarregar seu overdrive
        Obstacle, //Obstáculo, pode dar dano ou atrapalhar o jogador de alguma forma, alguns podem ser destruídos pelo overdrive, outros devem apenas ser evitados
        PowerUp, //Powerup, tenta
        Other //Qualquer coisa que não se encaixe nas outra categorias
    }

    public EntityTypes entType;
    public MovementTypes movType;
    public int hp;
    public bool takesBulletDamage;
    public bool doesContactDamage;
    public bool shootsProjectiles;
    public GameObject entityPrefab;

}