using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameLogicAPI
{
    void Initialize(LevelConfig level);
    int GetObjectsCount();
    int GetObjectCurrentHP(int objectID);
    float GetObjectScale(int objectID);
    bool isObjectAlive(int objectID);
    void OnClickObject(int objectID);
    EventObject GetObjectEvent(int objectID, ObjectEvents.EventTypes eventType);
}
