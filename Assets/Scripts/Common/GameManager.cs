using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Game Over params")]
    [SerializeField] private GameObject enemiesToDisable;
    private PlayerInput playerInput;
    public GameObject looseScreen;
    public GameObject winScreen;
    public bool gameOver;

    [Header("Score params")]
    private float score;

    [Header("SFX")]
    [SerializeField] private AudioClip gameOverSound;

    [Header("References")]
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text finalScreenScoreText;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        playerInput = GameObject.Find("Hero").GetComponent<PlayerInput>();
        score = 0;
    }

    private void Update()
    {
        scoreText.text = score.ToString();
    }

    public void AddScorePoints(float scorePoints)
    {
        score += scorePoints;
    }


    public void LevelComplete()
    {
        winScreen.SetActive(true);
        finalScreenScoreText.text = score.ToString();

        enemiesToDisable.SetActive(false);
        playerInput.enabled = false;

        MusicController.instance.StopMusic();
        SoundManager.instance.PlaySound(gameOverSound);
    }

    public void LevelFailed()
    {
        looseScreen.SetActive(true);
        enemiesToDisable.SetActive(false);
        MusicController.instance.StopMusic();
        SoundManager.instance.PlaySound(gameOverSound);
    }
}
