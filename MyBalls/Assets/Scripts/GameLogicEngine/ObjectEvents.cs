using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectEvents
{
    public enum EventTypes
    {
        OnChangeHP,
        OnChangeSize,
        OnDie,
        _LAST_ENUM
    }

    List<EventObject> EventsList = new List<EventObject>();

    public ObjectEvents()
    {
        for(int i=0; i < (int)EventTypes._LAST_ENUM; i++)
        {
            EventsList.Add(ScriptableObject.CreateInstance<EventObject>());
        }
    }

    ~ObjectEvents()
    {
        for(int i = 0; i < (int)EventTypes._LAST_ENUM; i++)
        {
            ScriptableObject.Destroy(EventsList[i]);
        }
    }

    public EventObject GetEvent(EventTypes Type)
    {
        return EventsList[(int)Type];
    }

    public void Invoke(EventTypes Type)
    {
        GetEvent(Type).Invoke();
    }
}
