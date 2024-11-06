
using System;
using System.Linq;
using TMPro;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;


public class 인벤토리 : MonoBehaviour
{
    
    public static 인벤토리 instance;   //변수 선언부// 
    [Header("슬롯")]
    [Space(10)]
    public GameObject[] prefeb;
    public GameObject[] slot;
    public GameObject[] slotnum;
    public GameObject 인벤;
    private int i = 0;
    public static bool 인벤여는중;
    public KeyCode 인벤키;
    [Space(20)]
    [Header("아이템")]
    [Space(20)]
    public string[] 인벤상태;
    public int[] 갯수;
    public string[] 이름;
    [TextArea]
    public string[] 설명;
    public Sprite[] 이미지;
    public int[] 효과;
    public string[] 효과2;
    public int[] 가격;
    private string 아이템;
    public void Awake()
    {
        인벤토리.instance = this;  //변수 초기화부 // 
    }
    // Update is called once per frame
    void Update()
    {
        if (npc.대화중 || 상점.selling || 상점.openshop)
        {
            return;
        }
        if (인벤여는중)
        {
            if (Input.GetKeyDown(인벤키) && 인벤여는중) //인벤닫음
            {
                인벤여는중 = false;
                인벤.SetActive(false);
            }
        }
        else if (Input.GetKeyDown(인벤키)) //인벤염
        {
            인벤여는중 = true;
            인벤.SetActive(true);
            showinv();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision) //리스트 //아이템 추가
    {
        for(int a = 0; a < 이름.Length; a++)
        {    
            if (collision.gameObject.name == 이름[a]+"(Clone)")
            {
                아이템 = 이름[a];
                갯수[a]++; 
                eatitem();
            }
        }

    }
    public void eatitem() //아이템 리스트
    {
        if (인벤상태.Contains(아이템))
        {
            return;
        }
        else
        {
            for(int a = 0; a < 6; a++)
            {
                if (인벤상태[a] == "")
                {
                    i = a;
                    break;
                }
            }
            인벤상태[i] = 아이템;
            showinv();
        }

    }


    public void showinv() //0은 달걀, 1은 코인 //아이템 추가 //이미지
    {

        for (int a = 0; a < 이름.Length; a++)
        {
            nozero(a, 이름[a]);
        }

        for (int i = 0; i < 6; i++)
        {
            if (인벤상태[i] != "") //1번 슬롯
            {
                slotnum[i].SetActive(true);
                slot[i].GetComponent<Image>().color = new Color(255, 255, 255, 1);
                for (int a = 0; a < 이름.Length; a++)
                {
                    if (인벤상태[i] == 이름[a])
                    {
                        slot[i].GetComponent<Image>().sprite = 이미지[a];
                        slotnum[i].GetComponent<TextMeshProUGUI>().text = 갯수[a].ToString();
                    }
                }
            }
            else if (인벤상태[i] == "")
            {
                slotnum[i].SetActive(false);
                slot[i].GetComponent<Image>().color = new Color(255, 255, 255, 0);
            }
        }
    }
    public void nozero(int i, string what)
    {
        if (갯수[i] <= 0 && 인벤상태.Contains(what))
        {
            인벤상태[Array.IndexOf(인벤상태, what)] = "";
        }
    }
    
}