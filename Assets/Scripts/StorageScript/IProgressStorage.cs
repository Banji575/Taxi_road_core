using UnityEngine;

public interface IProgressStorage
{
    public void Save(GameData gameData, params string[] fields);
    public void Load();
}
