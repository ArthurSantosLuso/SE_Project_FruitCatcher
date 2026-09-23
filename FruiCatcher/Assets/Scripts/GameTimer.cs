using UnityEngine;
using TMPro;

public class GameTimer : MonoBehaviour
{
    [SerializeField] private TMP_Text timerText;

    private float elapsed;

    private void Update()
    {
        elapsed += Time.deltaTime;

        int totalSeconds = Mathf.FloorToInt(elapsed);
        int minutes = totalSeconds / 60;
        int seconds = totalSeconds % 60;

        timerText.text = $"{minutes}:{seconds:00}";
    }
}