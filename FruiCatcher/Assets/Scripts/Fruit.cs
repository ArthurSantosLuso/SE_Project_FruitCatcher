using UnityEngine;

public class Fruit : MonoBehaviour
{
    public FruitData data;

    public int GetPoints()
    {
        return data != null ? data.pointValue : 0;
    }

    private void Start()
    {
        Destroy(gameObject, 4);
    }
}