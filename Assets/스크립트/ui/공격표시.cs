
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class 공격표시 : MonoBehaviour
{
    public static 공격표시 showdam;
    private void Awake()
    {
        공격표시.showdam = this;
    }
    public void showdamage()
    {
        gameObject.GetComponent<TextMeshPro>().text = GameObject.FindGameObjectWithTag("플레이어").GetComponent<근접공격>().실제공격력.ToString();
        int ran = Random.Range(0, 2);
        if (ran == 1)
        {
            gameObject.GetComponent<Animator>().Play("데미지표시오 1");
        }
        else if (ran == 0)
        {
            gameObject.GetComponent<Animator>().Play("데미지표시왼 1");
        }
        Invoke("d", 1);
    }
    public void finaldamage()
    {
        gameObject.GetComponent<Animator>().enabled = false;
        gameObject.GetComponent<TextMeshPro>().text = GameObject.FindGameObjectWithTag("플레이어").GetComponent<근접공격>().실제공격력.ToString();
        StartCoroutine("up");
        StartCoroutine("al");
        StartCoroutine("size");
    }
    IEnumerator up()
    {
        int a = 0;
        while(a<60)
        {
            transform.Translate(Vector3.up * 0.05f); 
            a += 1;
            yield return null;
        }
        d();
        StopCoroutine("animation");

    }
    IEnumerator al()
    {
        while(true)
        {
            gameObject.GetComponent<TextMeshPro>().alpha -= 0.1f;
            yield return new WaitForSeconds(0.03f);
            if(gameObject.GetComponent<TextMeshPro>().alpha ==0)
            {
                break;
            }

        }
        d();
        StopCoroutine("al");
    }
    IEnumerator size()
    {
        while(true)
        {
            gameObject.GetComponent<TextMeshPro>().fontSize -= 0.1f;
            yield return new WaitForSeconds(0.01f);
            if (gameObject.GetComponent<TextMeshPro>().fontSize == 0)
            {
                break;
            }
        }
        StopCoroutine("size");
    }
    
    public void d()
    {      
        Destroy(gameObject);
    }
}
