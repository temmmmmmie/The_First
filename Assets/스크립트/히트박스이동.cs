using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 히트박스이동 : MonoBehaviour
{

    void Update()
    {
        if (이동.왼쪽 == true)
        {
            transform.localPosition = new Vector3(-0.7f, -0.1292775f);
        }
        else if (이동.오른쪽 == true)
        {
            transform.localPosition = new Vector3(0.59f, -0.1292775f);
        }
    }
}
