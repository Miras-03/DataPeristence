using TMPro;
using UnityEngine;

namespace DataSave
{
    public sealed class DataHandler : MonoBehaviour
    {
        [Space(10)]
        [Header("Texts(TMP)")]
        [SerializeField] private TextMeshProUGUI scoreRecord;
        [SerializeField] private TextMeshProUGUI playerNickname;
        private NicknameData nameData;
        private ScoreData scoreData;

        private void Awake()
        {
            scoreData = new ScoreData();
            nameData = new NicknameData();
        }

        private void Start()
        {
            UpdateScore(scoreData.LoadData());
            UpdateNickname(nameData.LoadData());
        }

        public void ChangeName(string nickname)
        {
            UpdateNickname(nickname);
            nameData.SaveData(nickname);
        }

        public void UpdateScore(int score) => scoreRecord.text = $"Score: {score}";

        private void UpdateNickname(string nickname) => playerNickname.text = $"Nick: {nickname}";
    }
}