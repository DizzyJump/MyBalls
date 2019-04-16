using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HPBarFiller : MonoBehaviour
{
    int _ID;
    [SerializeField]
    GameLogicEngine _Engine;

    [SerializeField]
    Image _BarImage;

    [SerializeField]
    TextMeshProUGUI _HPLabel;

    public void Setup(int objectID)
    {
        _ID = objectID;
        gameObject.SetActive(true);
    }

    private void OnEnable()
    {
        _Engine.GetObjectEvent(_ID, ObjectEvents.EventTypes.OnChangeHP).AddHandler(UpdateView);
        _Engine.GetObjectEvent(_ID, ObjectEvents.EventTypes.OnDie).AddHandler(Die);
    }

    private void OnDisable()
    {
        _Engine.GetObjectEvent(_ID, ObjectEvents.EventTypes.OnChangeHP).RemoveHandler(UpdateView);
        _Engine.GetObjectEvent(_ID, ObjectEvents.EventTypes.OnDie).RemoveHandler(Die);
    }

    void UpdateView()
    {
        _BarImage.fillAmount = _Engine.GetObjectHPPercent(_ID);
        _HPLabel.text = _Engine.GetObjectCurrentHP(_ID).ToString();
    }

    void Die()
    {
        // можно было бы закинуть в пул, но в рамках этой задачи лень, так что просто выключу
        gameObject.SetActive(false);
    }
}
