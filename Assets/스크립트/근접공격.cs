using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class 근접공격 : MonoBehaviour
{
    public static 근접공격 instance;
    public Transform pos;
    public float curtime;
    public int 실제공격력;
    [Space(20)]
    [Header("능력치")]
    [Space(10)]
    public int 공격력;
    public Vector2 공격범위;
    public float 쿨타임;
    public float 넉백;
    public float 명중률;
    [Space(20)]
    [Header("조작키")]
    [Space(10)]
    public KeyCode 공격키;
    // Update is called once per frame

    public void Awake()
    {
        DontDestroyOnLoad(gameObject);
        근접공격.instance = this;  //변수 초기화부 // 
    }
    void Update()
    {       
        if (curtime<=0)
        {

            if (Input.GetKeyDown(공격키))
            {
                bool crit = Dods_ChanceMaker.GetThisChanceResult_Percentage(명중률);
                Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(pos.position, 공격범위, 0);
                foreach (Collider2D collider in collider2Ds)
                {
                    if (collider.tag == "몬스터")
                    {
                        if(crit)
                        {
                            실제공격력 = 공격력 * 2;
                            collider.GetComponent<데미지>().takedamage(공격력 * 2, 넉백);
                        }
                        else
                        {
                            실제공격력 = 공격력;
                            collider.GetComponent<데미지>().takedamage(공격력, 넉백);
                        }
                    }
                }
                curtime = 쿨타임;
            }
        }
        else
        {
            curtime -= Time.deltaTime;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(pos.position, 공격범위); 
    }
}
