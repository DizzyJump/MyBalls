using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarPanel : MonoBehaviour
{
    [SerializeField]
    GameLogicEngine _Engine;

    [SerializeField]
    LevelConfigValue _OnStartGameEvent;

    [SerializeField]
    EventObject _OnEndGame;

    List<HPBarFiller> _Objects = new List<HPBarFiller>();
    [SerializeField]
    HPBarFiller BarPrefab;

    private void OnEnable()
    {
        _OnStartGameEvent.AddHandler(OnGameStartHandler);
        _OnEndGame.AddHandler(OnGameEndHandler);
    }

    void OnGameStartHandler()
    {
        int spawnCounter = _Engine.GetObjectsCount();
        for(int i = 0; i < spawnCounter; i++)
        {
            var obj = Instantiate(BarPrefab, transform);
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
        _OnStartGameEvent.RemoveHandler(OnGameStartHandler);
        _OnEndGame.RemoveHandler(OnGameEndHandler);
    }
}
