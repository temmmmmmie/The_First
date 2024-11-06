using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 하스폰 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        우클릭감지.instance.플레이어.transform.position = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
