using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 물3 : MonoBehaviour
{
    public GameObject 플레이어;
    public static bool 물속 = false;
    public int i = 0;
    public bool sink;
    public bool ticking;

    private void Update()
    {
        if(물속)
        {
            플레이어.GetComponent<Animator>().SetBool("수영중", true);
        }
        else if(물속 == false)
        {
            플레이어.GetComponent<Animator>().SetBool("수영중", false);
        }
        if(sink)
        {
            플레이어.GetComponent<Rigidbody2D>().AddForce(Vector2.down * 0.2f, ForceMode2D.Impulse);
            if (Input.anyKey)
            {
                ticking = false;
                sink = false;
                i = 0;
            }
            return;
        }
        if(물속 && Input.anyKey == false)
        {
            if(ticking)
            {
                return;
            }
            StartCoroutine("wait");
            ticking = true;
        }
    }
    IEnumerator wait()
    {
        while(i<10)
        {
            if(물속 == false || Input.anyKey)
            {
                StopCoroutine("wait");
                sink = false;
                ticking = false;
                i = 0;
            }
            i++;
            yield return new WaitForSeconds(1);
        }
        sink = true;

    }
    private void OnTriggerExit2D(Collider2D collision) // 물에서 나옴
    {
        if (collision.tag == "플레이어")
        {
            물속 = false;
            for (int i = 0; i < 물.instance.용수철.Length; i++)
            {
                물.instance.용수철[i].GetComponent<CircleCollider2D>().isTrigger = false;
            }

        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision) // 물로 들어감
    {
        if (collision.tag == "플레이어")
        {
            물속 = true;
            for (int i = 0; i < 물.instance.용수철.Length; i++)
            {
                물.instance.용수철[i].GetComponent<CircleCollider2D>().isTrigger = true;
            }

        }
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "플레이어")
        {
            물속 = true;
        }
    }
}
