using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Boar : FightObj
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(string.Format("OnTriggerEnter2D: {0}", collision.name));
        FightObj obj = collision.gameObject.GetComponent<FightObj>();
        obj?.Hurt(this, atkDamage);
    }
}
