using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName ="Event/CharEventSO")]
public class CharEventSO : ScriptableObject
{
    public UnityAction<FightObj> OnEventRaised;

    public void RaiseEvent(FightObj fightObj)
    {
        OnEventRaised?.Invoke(fightObj);
    }
}
