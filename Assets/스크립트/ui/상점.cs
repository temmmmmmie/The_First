using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[Serializable]
public struct test
{
    public int[] test1;
    public string[] test2;

}
public class 상점 : MonoBehaviour
{
    public test fuck;
    public static bool openshop;
    public static bool selling;
    public Sprite 빈사진;
    public GameObject 상점창;
    public GameObject 뒤로;
    public GameObject[] 상점창들;
    public GameObject[] 상점사진;
    public GameObject[] 상점가격;
    [Space(20)]
    [Header("상점설정")]
    [Space(20)]
    public string[] 상점상태 = new string[6];
    public int[] 가격;
    public int 클릭 = 6;
    public void prep()
    {
        if (npc.대화중 == false)
        {
            인벤토리.instance.인벤.SetActive(false);
            인벤토리.인벤여는중 = false;
            openshop = true;
            상점창.SetActive(true);
            상점창.GetComponent<Animator>().Play("상점창");

        }
        for(int i = 0; i < 6; i++)
        {
            if(상점상태[i] == "")
            {
                상점사진[i].GetComponent<Image>().sprite = 빈사진;
            }
            else
            {
                for(int a = 0; a < 인벤토리.instance.이름.Length; a++)
                {
                    if (상점상태[i] == 인벤토리.instance.이름[a])
                    {
                        상점사진[i].GetComponent<Image>().sprite = 인벤토리.instance.이미지[a];
                    }

                }
            }

        }
        for(int i = 0; i < 6; i++) //가격
        {
            if (가격[i] == 0)
            {
                상점가격[i].SetActive(false); //가격없음
            }
            else
            {
                상점가격[i].SetActive(true);
                상점가격[i].GetComponent<TextMeshProUGUI>().text = 가격[i].ToString(); //가격있음

            }
        }
            
    }
    public void buy()
    {
        int a = 0;
        if (클릭 == 6)
        {
            buy();
        }
        else
        {
            if (인벤토리.instance.갯수[1] < 가격[클릭])
            {
                return;
            }
            else
            {
                인벤토리.instance.갯수[1] = 인벤토리.instance.갯수[1] - 가격[클릭]; //돈뺏어가기
                for(int i = 0; i < 6; i++)
                {
                    if(인벤토리.instance.인벤상태[i] == 상점상태[클릭]) //같은게 있어오;; //스위치 또 써야해??????????????????/
                    {
                        switchh(인벤토리.instance.인벤상태[i]);
                        a = 1;
                        break;
                    }
                }
                if(a == 0) //못찾음
                {
                    for(int i = 0; i < 6; i++)
                    {
                        if (인벤토리.instance.인벤상태[i] == "")
                        {
                            인벤토리.instance.인벤상태[i] = 상점상태[클릭]; //같은게 없군여
                            break;
                        }
                    }
                    switchh(상점상태[클릭]);
                }

                상점사진[클릭].GetComponent<Image>().sprite = 빈사진;
                상점가격[클릭].SetActive(false);
                
            }
            
        }
    }

    public void close()
    {
        openshop = false;
    }


    //18
    public void zero()
    {
        클릭 = 0;
    }
    public void one()
    {
        클릭 = 1;
    }
    public void two()
    {
        클릭 = 2;
    }
    public void three()
    {
        클릭 = 3;
    }
    public void four()
    {
        클릭 = 4;
    }
    public void five()
    {
        클릭 = 5;
    }

    public void switchh(string what)
    {
        for(int a = 0; a < 인벤토리.instance.이름.Length; a++)
        {
            if(what == 인벤토리.instance.이름[a])
            {
                인벤토리.instance.갯수[a]++;
            }
        }
    }

    public void sell()
    {
        상점창.SetActive(false);
        인벤토리.instance.인벤.SetActive(true);
        뒤로.SetActive(true);
        인벤토리.instance.showinv();
        selling = true;
    }
    public void back()
    {
        인벤토리.instance.인벤.SetActive(false);
        뒤로.SetActive(false);
        상점창.SetActive(true);
        selling = false;
    }
}
