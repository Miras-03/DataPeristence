using DataSave;
using System;
using UnityEngine;

public sealed class MainManager : MonoBehaviour
{
    public Action<int> OnPointPick;
    public Action OnGameOver;
    [SerializeField] private Rigidbody ballRb;
    [SerializeField] private Brick BrickPrefab;
    private ScoreData scoreData;

    private int pointCount;
    private bool hasJumped = false;

    private void Awake() => scoreData = new ScoreData();

    private void Start() => SpawnBricks();

    private void SpawnBricks()
    {
        const int lineCount = 6;
        const float step = 0.6f;
        int perLine = Mathf.FloorToInt(4.0f / step);
        int[] pointCountArray = new[] { 1, 1, 2, 2, 5, 5 };

        for (int i = 0; i < lineCount; i++)
        {
            for (int x = 0; x < perLine; x++)
            {
                Vector3 position = new Vector3(-1.5f + step * x, 2.5f + i * 0.3f, 0);
                var brick = Instantiate(BrickPrefab, position, Quaternion.identity);
                brick.PointValue = pointCountArray[i];
                brick.OnBrickDestroy += AddPoint;
            }
        }
    }

    private void AddPoint(int point)
    {
        pointCount += point;
        OnPointPick(point);
    }

    public void GameOver()
    {
        OnGameOver();

        bool hasReached = scoreData.LoadData() < pointCount;
        if (hasReached)
            SaveData();
    }

    private void SaveData() => scoreData.SaveData(pointCount);
}