using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Event : MonoBehaviour
{
    void AttackEvent(string tagName)
    {
        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == tagName)
            {
                int collisonhp = collision.gameObject.GetComponent<Enemy>().nowHp;
                //collision -=

            }
        }
    }
}
