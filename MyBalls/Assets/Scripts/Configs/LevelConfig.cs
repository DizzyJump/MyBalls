using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(menuName ="Game/Configs/Level Config")]
public class LevelConfig : ScriptableObject
{
    [TabGroup("Object spawning settings")]
    [SerializeField]
    int _ObjectsCountMin;

    [TabGroup("Object spawning settings")]
    [SerializeField]
    int _ObjectsCountMax;

    [TabGroup("Object settings")]
    [SerializeField]
    int _ObjectHP;

    [TabGroup("Game actions settings")]
    [SerializeField]
    int _DamageMin;

    [TabGroup("Game actions settings")]
    [SerializeField]
    int _DamageMax;

    [TabGroup("Object settings")]
    [SerializeField]
    int _ObjectMinHpToDie;

    [TabGroup("Object settings")]
    [SerializeField]
    float _ObjectHpToScaleModif;

    [TabGroup("Object spawning settings")]
    [SerializeField]
    ObjectController _ObjectPrefab;

    [TabGroup("Object spawning settings")]
    [SerializeField]
    Vector3 _ObjectSpawnOffset;

    public int ObjectsCountMin { get => _ObjectsCountMin; }
    public int ObjectsCountMax { get => _ObjectsCountMax; }
    public int ObjectHP { get => _ObjectHP; }
    public int DamageMin { get => _DamageMin; }
    public int DamageMax { get => _DamageMax; }
    public int ObjectMinHpToDie { get => _ObjectMinHpToDie; }
    public float ObjectHpToScaleModif { get => _ObjectHpToScaleModif; }
    public ObjectController ObjectPrefab { get => _ObjectPrefab; }
    public Vector3 ObjectSpawnOffset { get => _ObjectSpawnOffset; }
}
