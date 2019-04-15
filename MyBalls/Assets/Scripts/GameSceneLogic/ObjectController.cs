using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    [SerializeField]
    GameLogicEngine _Engine;

    int _ID;

    public void Setup(int objectID)
    {
        _ID = objectID;
        var clickable = GetComponent<ObjectClickable>();
        if(clickable)
            clickable.Setup(objectID);
        gameObject.SetActive(true);
    }

    private void OnEnable()
    {
        _Engine.GetObjectEvent(_ID, ObjectEvents.EventTypes.OnChangeSize).AddHandler(UpdateView);
        _Engine.GetObjectEvent(_ID, ObjectEvents.EventTypes.OnDie).AddHandler(Die);
        UpdateView();
    }

    private void OnDisable()
    {
        _Engine.GetObjectEvent(_ID, ObjectEvents.EventTypes.OnChangeSize).RemoveHandler(UpdateView);
        _Engine.GetObjectEvent(_ID, ObjectEvents.EventTypes.OnDie).RemoveHandler(Die);
    }

    void UpdateView()
    {
        transform.localScale = Vector3.one * _Engine.GetObjectScale(_ID);
    }

    void Die()
    {
        // поидее можно было бы запихнуть объект в пул, если бы было больше одного левела
        gameObject.SetActive(false);
    }
}
