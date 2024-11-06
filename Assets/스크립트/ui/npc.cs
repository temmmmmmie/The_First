
using System;
using UnityEngine;

[Serializable]
public struct ssay
{
    public string[] 대화내용;
}
public class npc : MonoBehaviour
{
    public static npc instance;
    public static bool 대화중;
    public int 대화순서;
    [Space(20)]
    public bool 바로시작;
    public bool 흔들림;
    public bool 반복;
    public bool 타이핑효과;
    public float 속도;
    [Space(20)]
    public float 글씨크기;
    public Vector2 글씨위치;
    [Space(20)]
    public string[] 이름;
    public string[] 대화내용;
    public Sprite[] 표정;
    [Space(50)]
    public string[] 선택지;
    public ssay[] 선택지후대화내용;
    public void Awake()
    {
        npc.instance = this;  //변수 초기화부 // 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "플레이어")
        {
            대화순서 = 0;
            if(인벤토리.인벤여는중)
            {
                return;
            }
            if(대화중)
            {
                return;
            }
            if(상점.openshop)
            {
                return;
            }
            대화.instance.say();
        }
    }
}
