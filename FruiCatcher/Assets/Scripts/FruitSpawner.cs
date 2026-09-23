using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    [Header("Spawn Settings")]
    [SerializeField] private GameObject objectToSpawn;
    [SerializeField] private float spawnInterval = 1f;
    [SerializeField] private float dificultyIncreaseTime = 5f;
    [SerializeField] private float spawnIntervalToRemoveEachDificultyIncrease = 0.2f;

    [Header("Spawn Area")]
    [SerializeField] private Transform spawnArea;

    private float timer;

    private float timerTick = 0f;

    private void Update()
    {
        timer += Time.deltaTime;
        timerTick += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            timer = 0f;
            SpawnObject();
        }

        if (timerTick >= dificultyIncreaseTime)
        {
            spawnInterval -= spawnIntervalToRemoveEachDificultyIncrease;
            timerTick = 0f;
        }
    }

    private void SpawnObject()
    {
        Vector3 spawnPosition = GetRandomPointOnPlane();
        Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
    }

    private Vector3 GetRandomPointOnPlane()
    {
        // Unity default Plane is 10x10 units at scale 1
        // so half-extent is 5 * localScale
        float width = spawnArea.localScale.x * 5f;
        float length = spawnArea.localScale.z * 5f;

        float randomX = Random.Range(-width, width);
        float randomZ = Random.Range(-length, length);

        Vector3 offset = new Vector3(randomX, 0f, randomZ);
        return spawnArea.position + offset;

        // I never gonna treat you like i should
        // 4:44
    }
}
