using UnityEngine;

public class Fruit : MonoBehaviour
{
    public FruitData data;
    public float fallSpeed = 2f;
    public int GetPoints() => data != null ? data.pointValue : 0;
    public AudioClip GetSplashSound() => data != null ? data.splashSound : null;
    public AudioClip GetCaughtSound() => data != null ? data.caughtSound : null;

    private void Start()
    {
        Destroy(gameObject, 4);
    }

    private void FixedUpdate()
    {
        transform.Rotate(Vector3.up * 100 * Time.fixedDeltaTime);
        transform.position += Vector3.down * fallSpeed * Time.fixedDeltaTime;
    }
}