using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 버리기 : MonoBehaviour
{
    public Transform 플레이어;
    public GameObject 아이템임시이미지;
    public string 아이템;
    private GameObject um;
    public void trash()
    {
        if(옮기기.move.아이템들음)
        {
            아이템 = 옮기기.move.현재아이템;
            for(int i = 0; i < 인벤토리.instance.이름.Length; i++)
            {
                if(아이템 == 인벤토리.instance.이름[i])
                {
                    인벤토리.instance.갯수[i] --;
                    um = Instantiate(인벤토리.instance.prefeb[i], new Vector2(플레이어.position.x,플레이어.position.y + 2), Quaternion.identity);        
                }
            }
            if(이동.오른쪽)
            {
                um.GetComponent<Rigidbody2D>().AddForce(new Vector2(2,1) * 2, ForceMode2D.Impulse);
            }
            else if(이동.왼쪽)
            {
                um.GetComponent<Rigidbody2D>().AddForce(new Vector2(-2, 1) * 2, ForceMode2D.Impulse);
            }
            옮기기.move.현재아이템 = "";
            인벤토리.instance.인벤상태[옮기기.move.이전선택된슬롯] = "";
            아이템임시이미지.SetActive(false);
            옮기기.move.아이템들음 = false;
            인벤토리.instance.showinv();
        }
    }    

}
