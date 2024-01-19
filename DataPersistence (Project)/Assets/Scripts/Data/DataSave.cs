using System;
using UnityEngine;

namespace DataSave
{
    public abstract class DataSave<T>
    {
        protected PlayerData data;
        protected string path = Application.persistentDataPath + "/Data.json";

        public DataSave() => data = new PlayerData();

        public abstract void SaveData(T data);

        public abstract T LoadData();
    }
}

[Serializable]
public struct PlayerData
{
    public string name;
    public int score;
}