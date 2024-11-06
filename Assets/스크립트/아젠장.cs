using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 아젠장 : MonoBehaviour
{
    public bool 아이템애니;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "물")
        {
            gameObject.GetComponent<Rigidbody2D>().mass = 0.1f;
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 0.5f;
            gameObject.GetComponent<CapsuleCollider2D>().isTrigger = false;
            if(아이템애니 == false)
            {
                gameObject.GetComponent<Animator>().Play("물위아이템");

            }
            아이템존맛.개 = true;
        }
        else if (collision.gameObject.tag == "땅")
        {
            아이템존맛.개 = true;
        }
    }
}
