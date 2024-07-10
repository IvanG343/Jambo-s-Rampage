using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Game Over params")]
    public GameObject looseScreen;
    public GameObject winScreen;
    public bool gameOver;

    [Header("Score params")]
    private int score;

    [Header("References")]
    [SerializeField] private TMP_Text scoreText;

    private void Awake()
    {
        instance = this;
        score = 0;
    }

    private void Update()
    {
        scoreText.text = score.ToString();
    }

    public void AddScorePoints(int scorePoints)
    {
        score += scorePoints;
    }


    public void LevelComplete()
    {
        winScreen.SetActive(true);
    }

    public void LevelFailed()
    {
        looseScreen.SetActive(true);
    }
}
