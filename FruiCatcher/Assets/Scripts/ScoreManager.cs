using System;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    public event Action<int> OnScoreChanged;

    private int score;

    public int Score => score;
    public bool gameLost = false;
    [SerializeField] private AudioClip youLoseSound;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        OVRManager.instance.usePositionTracking = false/*disablePositionTracking = true*/;
        /*OVRManager.instance.useRotationTracking = false *//*disablePositionTracking = true*/;
    }

    public void AddPoints(int amount)
    {
        if (amount == 0)
        {
            gameLost = true;
            AudioSource.PlayClipAtPoint(youLoseSound, transform.position);
        }
        score += amount;
        OnScoreChanged?.Invoke(score);
        Debug.Log(score);
    }

    public void ResetScore()
    {
        score = 0;
        OnScoreChanged?.Invoke(score);
    }
}