using System.IO;
using UnityEngine;

namespace DataSave
{
    public sealed class NicknameData : DataSave<string>
    {
        public NicknameData() => data = new PlayerData();

        public override void SaveData(string name)
        {
            data.name = name;
            string json = JsonUtility.ToJson(data);
            File.WriteAllText(path, json);
        }

        public override string LoadData()
        {
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                return JsonUtility.FromJson<PlayerData>(json).name;
            }
            return "";
        }
    }
}