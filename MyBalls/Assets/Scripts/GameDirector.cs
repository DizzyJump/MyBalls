using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    [SerializeField]
    GameLogicEngine _Engine;

    [SerializeField]
    LevelConfig _LevelConfig;

    // Start is called before the first frame update
    void Start()
    {
        _Engine.Initialize(_LevelConfig);
    }
}
