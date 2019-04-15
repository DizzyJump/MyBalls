using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectModel
{
    public ObjectEvents Events;
	public int StartHP;
    public int CurrentHP;

    public ObjectModel(int number, int hp)
    {
        Events = new ObjectEvents();
        StartHP = CurrentHP = hp;
    }
}
