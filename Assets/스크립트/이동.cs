using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 이동 : MonoBehaviour
{
    public KeyCode 오른쪽이동;
    public KeyCode 왼쪽이동;
    public KeyCode 웅크리기;
    public Rigidbody2D 리지드바디;
    public float 이동속도;
    public float 최대속도;
    public int 최대대쉬;
    public int 현재대쉬;
    public int 쿨타임;
    public static bool 오른쪽;
    public static bool 왼쪽;
    private bool 오른쪽1;
    private bool 왼쪽1;
    private bool 부족;
    public GameObject 이펙트;
    // Start is called before the first frame update
    void Start()
    {
        리지드바디 = GetComponent<Rigidbody2D>();
        현재대쉬 = 최대대쉬;
        StartCoroutine("cooltime");
    }
    
    // Update is called once per frame
    void Update()
    {
        if (npc.대화중 == true || 상점.openshop || 인벤토리.인벤여는중)
        {
            return;
        }
        if(Input.GetKey(웅크리기))
        {
            if(물3.물속)
            {
                gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.down*12);
            }
        }
        //------------------------------------------------ 부족 감지
        if(현재대쉬 > 최대대쉬)
        {
            현재대쉬 = 최대대쉬;
        }
        else if (현재대쉬 < 최대대쉬)
        {
            부족 = true;
        }
        else if(현재대쉬 == 최대대쉬)
        {
            부족 = false;
        }
        //----------------------------------------------- 이동
        if (Input.GetKey(오른쪽이동))
        {
            리지드바디.AddForce(Vector3.right * 이동속도);
            오른쪽 = true;
            왼쪽 = false;
        }
        if(Input.GetKeyUp(오른쪽이동))
        {
            오른쪽1 = true;
            timerr();
        }
        //---------------------------------------------- 대쉬
        if (오른쪽1 && Input.GetKeyDown(오른쪽이동))
        {
            if(현재대쉬<=0)
            {
                return;
            }
            리지드바디.AddForce(Vector3.right * 이동속도, ForceMode2D.Impulse);
            if (GameObject.Find("Trail(Clone)") == false)
            {
                Instantiate(이펙트, gameObject.transform);
            }
            현재대쉬--;
        }
//------------------------------------------------------------------------------------------------
        else if (Input.GetKey(왼쪽이동))
        {
            리지드바디.AddForce(Vector3.left * 이동속도);
            오른쪽 = false;
            왼쪽 = true;
        }
        if (Input.GetKeyUp(왼쪽이동))
        {
            왼쪽1 = true;
            timelll();
        }
        if (왼쪽1 && Input.GetKeyDown(왼쪽이동))
        {
            if(현재대쉬 <= 0)
            {
                return;
            }
            리지드바디.AddForce(Vector3.left * 이동속도, ForceMode2D.Impulse);
            if(GameObject.Find("Trail(Clone)") == false)
            {
                Instantiate(이펙트, new Vector2(gameObject.transform.position.x + 0.3f, gameObject.transform.position.y), Quaternion.identity, gameObject.transform);
            }
            현재대쉬--;
        }
//------------------------------------------------------------------------------------------------
        LimitMoveSpeed();
    }
    void LimitMoveSpeed()
    {
        if (리지드바디.velocity.x > 최대속도)
        {
            리지드바디.velocity = new Vector2(최대속도, 리지드바디.velocity.y);
        }
    }
    //----------------------------------------------------------------------------------------------
    void timerr()
    {
        float timer = 0.2f;
        StartCoroutine(timerr(timer));
    }
    IEnumerator timerr(float timer)
    {
        while(timer >= 0)
        {
            timer -= 0.1f;
            yield return new WaitForSeconds(0.1f);
        }
        오른쪽1 = false;
        StopCoroutine("timerr");
    }
    //---------------------------------------------------------------------------------------------
    void timelll()
    {
        float timel = 0.2f;
        StartCoroutine(timell(timel));
    }
    IEnumerator timell(float timeㅣ)
    {
        while (timeㅣ >= 0)
        {
            timeㅣ -= 0.1f;
            yield return new WaitForSeconds(0.1f);
        }
        왼쪽1 = false;
        StopCoroutine("timeell");
    }

    IEnumerator cooltime() //대쉬 채우기
    {
        yield return new WaitUntil(() => 부족 == true);
        yield return new WaitForSeconds(쿨타임);
        현재대쉬++;
        StartCoroutine("cooltime");
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.transform.tag == "땅")
        {
            물3.물속 = false;
        }
    }
}
