using DataSave;
using TMPro;
using UnityEngine;

public sealed class UIManager : MonoBehaviour
{
    [Space(10)]
    [SerializeField] private MainManager mainManager;

    [Space(20)]
    [Header("UI")]
    [SerializeField] private TextMeshProUGUI bestScore;
    [SerializeField] private TextMeshProUGUI currentScore;
    [SerializeField] private GameObject restartButton;
    private ScoreData data;

    private int score = 0;

    private void Awake() => data = new ScoreData();

    private void OnEnable()
    {
        mainManager.OnPointPick += UpdateScore;
        mainManager.OnGameOver += ShowRestartButton;
        UpdateScore(0);
        UpdateBestScore();
    }

    private void OnDestroy()
    {
        mainManager.OnPointPick -= UpdateScore;
        mainManager.OnGameOver -= ShowRestartButton;
    }

    private void UpdateScore(int point)
    {
        score += point;
        currentScore.text = $"Score: {score}";
    }

    private void UpdateBestScore() => bestScore.text = $"Best score: {data.LoadData()}";

    private void ShowRestartButton() => restartButton.SetActive(true);
}