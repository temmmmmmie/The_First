using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class 번쩍 : MonoBehaviour
{
    public Image 빨강;
    public float 알파;
    public void flash()
    {
        StartCoroutine("flashstart");
    }
    IEnumerator flashstart()
    {
        알파 = 0;
        while (알파 < 1)
        {
            알파 += 0.1f;
            yield return new WaitForSeconds(0.01f);
            빨강.color = new Color(164, 0, 0, 알파);
            if(알파==1)
            {
                yield return new WaitForSeconds(0.1f);
                break;
            }
        }
        while (알파 >= 0)
        {
            알파 -= 0.1f;
            yield return new WaitForSeconds(0.01f);
            빨강.color = new Color(164, 0, 0, 알파);
            if (알파 == 0)
            {
                break;
            }
        }
        yield break;
    }
}

