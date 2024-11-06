using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 스폰 : MonoBehaviour
{
    public float 스폰딜레이;
    public GameObject 몬스터;
    private Transform 몬스터보관;
    public Vector2 위치;
    private void Start()
    {
        StartCoroutine("spawn");
        몬스터보관 = GameObject.Find("몬스터보관").GetComponent<Transform>();
    }
    IEnumerator spawn()
    {
        while(true)
        {
            Instantiate(몬스터,new Vector2(transform.position.x,transform.position.y), Quaternion.identity, 몬스터보관);
            yield return new WaitForSeconds(스폰딜레이);
        }
    }    
}
