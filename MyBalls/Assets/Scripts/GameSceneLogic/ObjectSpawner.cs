using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Game/Object Spawner")]
public class ObjectSpawner : ScriptableObject
{
    [SerializeField]
    GameLogicEngine _Engine;

    [SerializeField]
    LevelConfigValue OnGameStart;

    private void OnEnable()
    {
        OnGameStart.AddHandler(OnGameStartHandler);
    }

    void OnGameStartHandler()
    {
        LevelConfig levelConfig = OnGameStart.Value;
        int spawnCounter = _Engine.GetObjectsCount();
        for(int i=0; i < spawnCounter; i++)
        {
            var obj = Instantiate(levelConfig.ObjectPrefab, levelConfig.ObjectSpawnOffset * i, Quaternion.identity);
            obj.Setup(i);
        }
    }

    private void OnDisable()
    {
        OnGameStart.RemoveHandler(OnGameStartHandler);
    }
}
