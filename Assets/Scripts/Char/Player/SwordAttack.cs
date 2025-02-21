using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    public int damage = 0;
    public FightObj player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(string.Format("OnTriggerEnter2D: {0}", collision.name));
        //collision.GetComponent<FightObj>()?.Hurt(player, damage);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log(string.Format("OnTriggerStay2D: {0}", collision.name));
    }
}
