using System.IO;
using UnityEngine;

namespace DataSave
{
    public sealed class ScoreData : DataSave<int>
    {
        public override void SaveData(int score)
        {
            data.score = score;
            string json = JsonUtility.ToJson(data);
            File.WriteAllText(path, json);
        }

        public override int LoadData()
        {
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                return JsonUtility.FromJson<PlayerData>(json).score;
            }

            return 0;
        }
    }
}