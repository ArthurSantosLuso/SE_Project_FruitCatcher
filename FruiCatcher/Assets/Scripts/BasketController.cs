using UnityEngine;

public class BasketController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Fruit fruit = other.GetComponent<Fruit>();
        if (fruit != null)
        {
            int points = fruit.GetPoints();
            AudioSource.PlayClipAtPoint(fruit.GetCaughtSound(), transform.position);
            ScoreManager.Instance.AddPoints(points);
            Destroy(other.gameObject);
        }
    }
}
