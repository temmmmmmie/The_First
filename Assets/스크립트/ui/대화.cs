
using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Random = UnityEngine.Random;


public class 대화 : MonoBehaviour, IPointerClickHandler
{
    TextMeshProUGUI 텍스트;
    TextMeshProUGUI 이름텍스트트;
    Image 표정사진;
    public GameObject 이름칸;
    public static 대화 instance;   //변수 선언부// 
    public bool 대화끝;
    public GameObject 표정오브젝트;
    public GameObject 이름텍스트;
    public GameObject 선택지;
    public Transform 선택지엄마;
    public bool 선택지중;
    public int 선택지몇번;
    public KeyCode 취소;
    private char[] temp;
    public string ttemp = "";
    private int i;
    public bool 진행중;
    private bool nope;
    public int 선택지갯수 = 0;
    public void Awake()
    {
        대화.instance = this;  //변수 초기화부 // 
    }
    public void Update()
    {
        텍스트.GetComponent<RectTransform>().anchoredPosition = npc.instance.글씨위치;
        텍스트.GetComponent<TextMeshProUGUI>().fontSize = npc.instance.글씨크기;
        if(Input.GetKeyDown(취소) && npc.대화중)
        {
            monsterhurt();
        }

    }
    private void Start()
    {
        텍스트 = gameObject.GetComponent<TextMeshProUGUI>();
        이름텍스트트 = 이름텍스트.GetComponent<TextMeshProUGUI>();
        표정사진 = 표정오브젝트.GetComponent<Image>();
        if (npc.instance.바로시작)
        {
            표정사진.sprite = npc.instance.표정[npc.instance.대화순서];
            say();
        }
    }
    public void say()
    {
        nope = false;
        텍스트.text = "";
        ttemp = "";
        if (대화끝)
        {
            return;
        }
        npc.대화중 = true;
        if (npc.instance.타이핑효과)
        {
            sayfuck();
        }
        else
        {
            saysip();
        }
        표정오브젝트.GetComponent<Animator>().SetTrigger("표정올라감");
        GameObject.Find("대화창").GetComponent<Animator>().SetTrigger("대화시작");
        if(npc.instance.흔들림)
        {
            StartCoroutine("tremble");
        }

    }
    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        if (선택지중)
        {
            return;
        }
        if(nope)
        {
            return;
        }
        if (진행중 == false)
        {
            npc.instance.대화순서++; //다음대화
            if (npc.instance.대화순서 >= npc.instance.대화내용.Length) //대화끝?
            {
                nope = true;
                ttemp = "";
                if (npc.instance.타이핑효과)
                {
                    Array.Clear(temp, 0, temp.Length);
                }
                GameObject.Find("대화창").GetComponent<Animator>().SetTrigger("대화끝");
                표정오브젝트.GetComponent<Animator>().SetTrigger("표정내려감");
                npc.대화중 = false;
                if (npc.instance.반복)
                {
                    대화끝 = false;
                }
                else
                {
                    대화끝 = true;
                }
                return;
            }
            else //대화진행중 and 기다렸다가
            {
                if (npc.instance.대화내용[npc.instance.대화순서].Contains("선택지")) //선택지 시작
                {
                    선택지중 = true;
                    선택지갯수++;
                    for(int i = 0; i < npc.instance.선택지.Length; i++) //선택지복제
                    {
                        var s = Instantiate(선택지, 선택지엄마);
                        s.GetComponentInChildren<선택지>().몇번 = i;
                        s.GetComponentInChildren<TextMeshProUGUI>().text = npc.instance.선택지[i];
                    }
                    선택지엄마.GetComponent<Animator>().Play("선택지");
                    
                }
                if (npc.instance.타이핑효과) //다음대화
                {
                    텍스트.text = "";
                    ttemp = "";
                    sayfuck();
                }
                else
                {
                    saysip();
                }
            }
        }
        else //넘기기
        {
            StopCoroutine("timer");
            텍스트.text = npc.instance.대화내용[npc.instance.대화순서];
            진행중 = false;
        }


    }
    IEnumerator tremble()
    {
        while(true)
        {

            gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(Random.Range(-2, 2), Random.Range(-2, 2));
            yield return new WaitForSeconds(0.1f);
        }
    }
    public void monsterhurt()
    {
        GameObject.Find("대화창").GetComponent<Animator>().SetTrigger("대화끝");
        표정오브젝트.GetComponent<Animator>().SetTrigger("표정내려감");
        if(선택지중)
        {
            선택지엄마.GetComponent<Animator>().Play("선택지반대");
        }
        Array.Clear(temp, 0, temp.Length);
        npc.대화중 = false;
    }
    public void saysip()
    {
        텍스트.text = npc.instance.대화내용[npc.instance.대화순서]; //텍스트
        표정사진.sprite = npc.instance.표정[npc.instance.대화순서]; //표정
        if (npc.instance.이름[npc.instance.대화순서] == "") //이름
        {
            이름칸.SetActive(false);
        }
        else
        {
            이름칸.SetActive(true);
            이름텍스트트.text = npc.instance.이름[npc.instance.대화순서];
        }
    }
    public void sayfuck()
    {

        표정사진.sprite = npc.instance.표정[npc.instance.대화순서]; //표정
        if (npc.instance.이름[npc.instance.대화순서] == "") //이름
        {
            이름칸.SetActive(false);
        }
        else
        {
            이름칸.SetActive(true);
            이름텍스트트.text = npc.instance.이름[npc.instance.대화순서];
        }
        temp = npc.instance.대화내용[npc.instance.대화순서].ToCharArray(); //텍스트 조각내기 temp 는 텍스트 arrey
        if(선택지중)
        {
            Array.Resize(ref temp, temp.Length - 4); //---------------0 1 2 3, ------------------- (빈칸) 선 택 지
        }
        i = 0;
        StartCoroutine("timer");
        진행중 = true;
    }
    IEnumerator timer() //타이핑 치기
    {
        while(true)
        {
            if(i >= temp.Length)
            {
                진행중 = false;
                break;
            }
            ttemp = 텍스트.text = ttemp + temp[i].ToString(); //최종산물 ttemp
            i++;
            yield return new WaitForSeconds(npc.instance.속도);
        }
        yield break;
    }
    public void ini()
    {
        텍스트.text = "";
        ttemp = "";
    }
}
