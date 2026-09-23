using UnityEngine;

[CreateAssetMenu(fileName = "FruitData", menuName = "Fruit/Fruit Data")]
public class FruitData : ScriptableObject
{
    public GameObject prefab;
    public int pointValue = 1;
    public float spawnWeight = 1f;
}