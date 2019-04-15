using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Пример: На сцене несколько шаров (от 2 до 5 рандомно при каждом запуске сцены). 
 * Скейл шара равен его хп. Изначально у шаров 10 хп. 
 * При нажатии мышью на любой шар его хп уменьшается на рандом от 1 до 3. 
 * Если хп меньше 2, смерть. 
 * На экране в виде списка надо отображать хп шаров в двух вариантах: цифрами и шкалой. 
 * После смерти одного шара его UI хп убирается с экрана (либо можно там писать Уничтожен). 
 * Если все шары погибли, то выводить надпись Конец игры.
 * */

//[CreateAssetMenu(menuName ="Game/Game Logic Engine")]
public class GameLogicEngine : ScriptableObject, IGameLogicAPI
{
    LevelConfig _WorkLevel;
    List<ObjectModel> _Objects = new List<ObjectModel>(5);

    [SerializeField]
    LevelConfigValue GameStartEvent;
    [SerializeField]
    EventObject GameEndEvent;

    public int GetObjectCurrentHP(int objectID)
    {
        return _Objects[objectID].CurrentHP;
    }

    public float GetObjectScale(int objectID)
    {
        bool isAlive = isObjectAlive(objectID);
        return isAlive ? _Objects[objectID].CurrentHP * _WorkLevel.ObjectHpToScaleModif : 0;
    }

    public int GetObjectsCount()
    {
        return _Objects.Count;
    }

    public bool isObjectAlive(int objectID)
    {
        return GetObjectCurrentHP(objectID) > _WorkLevel.ObjectMinHpToDie;
    }

    public void Initialize(LevelConfig level)
    {
        _WorkLevel = level;
        _Objects.Clear();
        int objectsCount = Random.Range(_WorkLevel.ObjectsCountMin, _WorkLevel.ObjectsCountMax);
        for(int i=0; i<objectsCount; i++)
        {
            _Objects.Add(new ObjectModel(i, _WorkLevel.ObjectHP));
        }
        GameStartEvent.Value = level;
    }

    void OnEnable()
    {

    }

    void OnDisable()
    {

    }

    public EventObject GetObjectEvent(int objectID, ObjectEvents.EventTypes eventType)
    {
        return _Objects[objectID].Events.GetEvent(eventType);
    }

    bool isAllObjectsAreDie()
    {
        for(int i = 0; i < _Objects.Count; i++)
            if(isObjectAlive(i))
                return false;
        return true;
    }

    public void OnClickObject(int objectID)
    {
        ObjectModel workObject = _Objects[objectID];
        workObject.CurrentHP -= Random.Range(_WorkLevel.DamageMin, _WorkLevel.DamageMax);
        GetObjectEvent(objectID, ObjectEvents.EventTypes.OnChangeHP).Invoke();
        GetObjectEvent(objectID, ObjectEvents.EventTypes.OnChangeSize).Invoke();
        if(workObject.CurrentHP <= _WorkLevel.ObjectMinHpToDie)
        {
            workObject.CurrentHP = 0;
            GetObjectEvent(objectID, ObjectEvents.EventTypes.OnDie).Invoke();
            if(isAllObjectsAreDie())
                GameEndEvent.Invoke();
        }
    }
}
