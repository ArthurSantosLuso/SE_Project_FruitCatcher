using UnityEngine;

public class SplashZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Splash triggered by: {other.name} (layer {other.gameObject.name})");
        Fruit fruit = other.GetComponent<Fruit>();
        if (fruit != null)
        {
            AudioClip splashSound = fruit.GetSplashSound();
            if (splashSound != null)
            {
                AudioSource.PlayClipAtPoint(splashSound, other.transform.position);
            }
            Destroy(other.gameObject);
        }
    }
}
