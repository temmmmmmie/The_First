using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 옮기기 : MonoBehaviour
{
    public static 옮기기 move;
    public GameObject 플레이어;
    public string 현재아이템;
    public int 현재슬롯;
    [Space(10)]
    public int 이전선택된슬롯;
    public int 놓은슬롯;
    [Space(10)]
    public bool 아이템들음;
    public void Awake()
    {
        옮기기.move = this;  //변수 초기화부 // 
    }
}
