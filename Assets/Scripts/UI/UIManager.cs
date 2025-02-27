using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public CharEventSO CharEvent;

    public PlayerStatusUI playerStatusUI;

    private void OnEnable()
    {
        CharEvent.OnEventRaised += OnFightObjectChange;
    }

    private void OnDisable()
    {
        CharEvent.OnEventRaised -= OnFightObjectChange;
    }

    private void OnFightObjectChange(FightObj fight)
    {
        Debug.Log(string.Format("OnFightObjectChange:{0}", fight.name));
        float percent = fight.curHp / fight.maxHp;
        playerStatusUI.onHpChange(percent);
    }
}
