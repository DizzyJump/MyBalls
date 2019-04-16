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

    [SerializeField]
    EventObject OnGameEnd;

    List<ObjectController> _Objects = new List<ObjectController>();

    private void OnEnable()
    {
        _Objects.Clear();
        OnGameStart.AddHandler(OnGameStartHandler);
        OnGameEnd.AddHandler(OnGameEndHandler);
    }

    void OnGameStartHandler()
    {
        LevelConfig levelConfig = OnGameStart.Value;
        int spawnCounter = _Engine.GetObjectsCount();
        for(int i=0; i < spawnCounter; i++)
        {
            var obj = Instantiate(levelConfig.ObjectPrefab, levelConfig.ObjectSpawnOffset * i, Quaternion.identity);
            obj.Setup(i);
            _Objects.Add(obj);
        }
    }

    void OnGameEndHandler()
    {
        foreach(var obj in _Objects)
        {
            Destroy(obj.gameObject);
        }
        _Objects.Clear();
    }

    private void OnDisable()
    {
        OnGameStart.RemoveHandler(OnGameStartHandler);
        OnGameEnd.RemoveHandler(OnGameEndHandler);
        _Objects.Clear();
    }
}
