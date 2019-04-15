using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectClickable : MonoBehaviour
{
    [SerializeField]
    GameLogicEngine _Engine;

    int _ID;

    public void Setup(int id)
    {
        _ID = id;
    }

    private void OnMouseDown()
    {
        _Engine.OnClickObject(_ID);
    }
}
