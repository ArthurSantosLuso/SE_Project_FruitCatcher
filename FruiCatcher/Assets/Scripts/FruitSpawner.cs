using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Spawns a fruit utilizing a plane and list of fruit data.
/// </summary>
public class FruitSpawner : MonoBehaviour
{
    [SerializeField] private List<FruitData> fruitTypes = new List<FruitData>();
    [SerializeField] private float spawnInterval = 1f;
    [SerializeField] private float difficultyIncreaseTime = 5f;
    [SerializeField] private float spawnIntervalToRemoveEachDifficultyIncrease = 0.1f;
    [SerializeField] private float spawnIntervalHardCap = 1.5f;
    [SerializeField] private float minSpawnInterval = 0.2f;
    [SerializeField] private Transform spawnArea;

    private float timer;
    private float timerTick;

    /// <summary>
    /// Spawn fruit timer and difficulty increase.
    /// </summary>
    private void Update()
    {
        timer += Time.deltaTime;
        timerTick += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            timer = 0f;
            SpawnObject();
        }

        if (timerTick >= difficultyIncreaseTime)
        {
            spawnInterval = Mathf.Max(minSpawnInterval, spawnInterval - spawnIntervalToRemoveEachDifficultyIncrease);
            timerTick = 0f;
        }
        if (difficultyIncreaseTime < spawnIntervalHardCap)
        {
            difficultyIncreaseTime = spawnIntervalHardCap;
        }
    }
    /// <summary>
    /// Spawns the fruit in a random position.
    /// </summary>
    private void SpawnObject()
    {
        FruitData chosen = PickWeightedFruit();
        if (chosen == null || chosen.prefab == null) return;

        Vector3 spawnPosition = GetRandomPointOnPlane();
        GameObject spawned = Instantiate(chosen.prefab, spawnPosition, chosen.prefab.transform.rotation);

        Fruit fruit = spawned.GetComponent<Fruit>();
        if (fruit != null)
            fruit.data = chosen;
    }
    /// <summary>
    /// Picks a fruit from the list of data.
    /// </summary>
    private FruitData PickWeightedFruit()
    {
        float total = 0f;
        foreach (FruitData f in fruitTypes)
            if (f != null) total += f.spawnWeight;

        if (total <= 0f) return null;

        float roll = Random.Range(0f, total);
        float cumulative = 0f;
        foreach (FruitData f in fruitTypes)
        {
            if (f == null) continue;
            cumulative += f.spawnWeight;
            if (roll <= cumulative) return f;
        }
        return fruitTypes[fruitTypes.Count - 1];
    }
    /// <summary>
    /// Random place selector for the fruit to spawn.
    /// </summary>
    private Vector3 GetRandomPointOnPlane()
    {
        float width = spawnArea.localScale.x * 5f;
        float length = spawnArea.localScale.z * 5f;

        float randomX = Random.Range(-width, width);
        float randomZ = Random.Range(-length, length);

        Vector3 offset = new Vector3(randomX, 0f, randomZ);
        return spawnArea.position + offset;
    }
}