using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 툴팁 : MonoBehaviour
{
    public GameObject 툴팁팁;
    public GameObject 이름;
    public GameObject 내용;
    public int 몇번; //몇번째칸?
    private Vector2 마우스;
    public GameObject 이미지;
    public GameObject 아이템임시이미지;
    public void tool()
    {
        if(인벤토리.instance.인벤상태[몇번] == "")
        {
            return;
        }
        else if(옮기기.move.아이템들음)
        {
            return;
        }
        string a = 이름.GetComponent<TextMeshProUGUI>().text = 인벤토리.instance.인벤상태[몇번];
        for(int i = 0; i < 인벤토리.instance.이름.Length; i++)
        {
            if(a == 인벤토리.instance.이름[i])
            {
                옮기기.move.현재아이템 = 인벤토리.instance.이름[i];
                내용.GetComponent<TextMeshProUGUI>().text = 인벤토리.instance.설명[i];
                아이템임시이미지.GetComponent<Image>().sprite = 인벤토리.instance.이미지[i];
            }
        }
        StartCoroutine("mouse");
        StartCoroutine("mousefollow");
        Invoke("vis", 0.1f);
        
    }
    IEnumerator mouse() //툴팁
    {
        while(true)
        {
            yield return null;
            마우스 = Input.mousePosition;
            툴팁팁.transform.position = new Vector2(마우스.x+50, 마우스.y-35);
        }

    }
    void vis()
    {
        툴팁팁.SetActive(true);
    }
    public void mouseclick()
    {
        if(Input.GetMouseButtonUp(1)) //우클릭
        {
            if(상점.selling)
            {
                sellall();
            }
            else
            {
                use();
            }
        }
        else if(Input.GetMouseButtonUp(0)) //좌클릭
        {
            moveitem();
        }
    }
    public void use()
    {
        for (int i = 0; i < 인벤토리.instance.이름.Length; i++)
        {
            if (인벤토리.instance.인벤상태[옮기기.move.현재슬롯] == 인벤토리.instance.이름[i])
            {
                if(인벤토리.instance.효과2[i] == "")
                {
                    return;
                }
                if (인벤토리.instance.효과2[i] == "체력" && 체력ui.실제체력 < 체력애니매이션.최대체력) //체력
                {
                    인벤토리.instance.갯수[i]--; //아이템
                    인벤토리.instance.showinv();
                    체력ui.실제체력 += 인벤토리.instance.효과[i];
                }
            }
        }
    }
    public void sellall()
    {
        Debug.Log("모두팔기");
        if (상점.selling)
        {
            if (인벤토리.instance.인벤상태[옮기기.move.현재슬롯] == "")
            {
                return;
            }
            else
            {
                for (int i = 0; i < 인벤토리.instance.이름.Length; i++)
                {
                    if (인벤토리.instance.인벤상태[옮기기.move.현재슬롯] == 인벤토리.instance.이름[i])
                    {
                        while (인벤토리.instance.갯수[i] > 0)
                        {
                            인벤토리.instance.갯수[i] --; //아이템
                            인벤토리.instance.갯수[1] = 인벤토리.instance.갯수[1] + 인벤토리.instance.가격[i]; //돈

                        }
                    }
                }

            }
            인벤토리.instance.showinv();
        }
    }
    public void moveitem() //or sell
    {
        Debug.Log("하나만");
        if (상점.selling)
        {
            if(인벤토리.instance.인벤상태[옮기기.move.현재슬롯] == "")
            {
                return;
            }
            else
            {
                for(int i = 0; i < 인벤토리.instance.이름.Length; i++)
                {
                    if(인벤토리.instance.인벤상태[옮기기.move.현재슬롯] == 인벤토리.instance.이름[i])
                    {
                        인벤토리.instance.갯수[i]--; //아이템
                        인벤토리.instance.갯수[1] = 인벤토리.instance.갯수[1] + 인벤토리.instance.가격[i]; //돈
                    }
                }

            }
            인벤토리.instance.showinv();
        }
        else
        {
            if(인벤토리.instance.인벤상태[옮기기.move.현재슬롯] == "" && 옮기기.move.아이템들음 == false)
            {
                return;
            }
            if(옮기기.move.아이템들음) //놓기
            {
                옮기기.move.놓은슬롯 = 옮기기.move.현재슬롯;
                if(인벤토리.instance.인벤상태[옮기기.move.놓은슬롯] != "") //바꾸기
                {
                    string 임시;
                    인벤토리.instance.인벤상태[옮기기.move.이전선택된슬롯] = "";
                    임시 = 인벤토리.instance.인벤상태[옮기기.move.놓은슬롯];
                    인벤토리.instance.인벤상태[옮기기.move.놓은슬롯] = 옮기기.move.현재아이템;
                    옮기기.move.현재아이템 = 임시;
                    for(int i = 0; i < 인벤토리.instance.이름.Length; i++)
                    {
                        if(임시 == 인벤토리.instance.이름[i])
                        {
                            아이템임시이미지.GetComponent<Image>().sprite = 인벤토리.instance.이미지[i];
                        }
                    }

                    인벤토리.instance.showinv();

                }
                else //그냥 놓기
                {
                    인벤토리.instance.인벤상태[옮기기.move.이전선택된슬롯] = "";
                    인벤토리.instance.인벤상태[옮기기.move.놓은슬롯] = 옮기기.move.현재아이템;
                    아이템임시이미지.SetActive(false);
                    인벤토리.instance.showinv();
                    옮기기.move.아이템들음 = false;
                }
            }
            else
            {
                옮기기.move.아이템들음 = true; //들기
                인벤토리.instance.인벤상태[몇번] = "";
                인벤토리.instance.slot[몇번].GetComponent<Image>().color = new Color(255, 255, 255, 0);
                인벤토리.instance.slotnum[몇번].SetActive(false);
                옮기기.move.이전선택된슬롯 = 옮기기.move.현재슬롯;
                툴팁팁.SetActive(false);
                StopCoroutine("mouse");
                아이템임시이미지.SetActive(true);
            }
        }
    }
    IEnumerator mousefollow()
    {
        while(true)
        {
            yield return null;
            마우스 = Input.mousePosition;
            아이템임시이미지.transform.position = new Vector2(마우스.x, 마우스.y);
        }
    }
}
