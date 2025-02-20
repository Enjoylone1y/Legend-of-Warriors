using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Boar : FightObj
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("OnTriggerStay2D");
        FightObj obj = collision.gameObject.GetComponent<FightObj>();
        obj.Hurt(this, atkDamage);
    }

    
    private void OnTriggerExit2D(Collider2D collision)
    {
        
    }
}
