using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class 마우스로이동 : MonoBehaviour
{
    public GameObject 핑;
    RaycastHit2D ray;
    public 점프 test;
    public 마우스로공격 mouse;
    public Vector2 범위;
    public Vector2 오른쪽위치;
    public Vector2 왼쪽위치;
    // Start is called before the first frame update
    void Start()
    {
        test = gameObject.GetComponent<점프>();
        mouse = gameObject.GetComponent<마우스로공격>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var 마우스 = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, 10));
            ray=Physics2D.Raycast(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 1), new Vector3(마우스.x, gameObject.transform.position.y - 1 + 3.31f), Mathf.Abs(gameObject.transform.position.x - 마우스.x), LayerMask.GetMask("몬스터"));
            Collider2D mon = Physics2D.OverlapBox(new Vector2(gameObject.transform.position.x + 왼쪽위치.x, gameObject.transform.position.y + 왼쪽위치.y), 범위, 0, LayerMask.GetMask("몬스터"));
            Debug.DrawRay(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y -1), new Vector3(마우스.x, gameObject.transform.position.y+ 3.31f), Color.yellow);
            if(ray || mon)
            {
                return;
            }
            if(mouse.atk || 인벤토리.인벤여는중 || 상점.selling || 대화.instance.진행중 || 대화.instance.선택지중 || 상점.openshop || npc.대화중)
            {
                return;
            }
            if(GameObject.Find("핑(Clone)"))
            {
                return;
            }
            var ping = Instantiate(핑, 마우스, Quaternion.identity);
            StartCoroutine(move(ping));
        }
    }

    IEnumerator move(GameObject ping)
    {
        if (ping.transform.position.x > gameObject.transform.position.x) //오른쪽
        {
            이동.오른쪽 = true;
            이동.왼쪽 = false;
            while (ping.transform.position.x > gameObject.transform.position.x)
            {
                if(Input.GetKey(gameObject.GetComponent<이동>().오른쪽이동) || Input.GetKey(gameObject.GetComponent<이동>().왼쪽이동)) //키보드입력
                {
                    break;
                }
                gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * gameObject.GetComponent<이동>().이동속도);
                yield return new WaitForSeconds(0.00001f);
                Collider2D coll = Physics2D.OverlapBox(new Vector2(gameObject.transform.position.x + 오른쪽위치.x, gameObject.transform.position.y + 오른쪽위치.y), 범위, 0, LayerMask.GetMask("땅"));
                if (coll)
                {
                    if(test.남은점프개수 > 0)
                    {
                        gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.up * gameObject.GetComponent<점프>().점프력);
                        test.남은점프개수--;
                        yield return new WaitForSeconds(0.05f);

                    }
                    else if(gameObject.GetComponent<공중인가>().떨어지는중 == false)
                    {
                        test.남은점프개수 = test.최대점프개수;
                    }
                }
                if (Input.GetMouseButtonDown(0)) //다른쪽으로 입력받음
                {
                    Vector2 temp = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, 10));
                    Destroy(ping);
                    interrupt(temp);
                    StopCoroutine("move");
                    break;
                }


            }
        }
        else if (ping.transform.position.x < gameObject.transform.position.x) //왼쪽
        {
            이동.왼쪽 = true;
            이동.오른쪽 = false;
            while (ping.transform.position.x < gameObject.transform.position.x)
            {
                if (Input.GetKey(gameObject.GetComponent<이동>().오른쪽이동) || Input.GetKey(gameObject.GetComponent<이동>().왼쪽이동))
                {
                    break;
                }
                gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.left * gameObject.GetComponent<이동>().이동속도);
                yield return new WaitForSeconds(0.00001f);
                Collider2D coll = Physics2D.OverlapBox(new Vector2(gameObject.transform.position.x + 왼쪽위치.x, gameObject.transform.position.y + 왼쪽위치.y), 범위, 0, LayerMask.GetMask("땅"));
                if (coll)
                {
                    if (test.남은점프개수 > 0)
                    {
                        gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.up * gameObject.GetComponent<점프>().점프력);
                        test.남은점프개수--;
                        yield return new WaitForSeconds(0.05f);
                    }
                    else if (gameObject.GetComponent<공중인가>().떨어지는중 == false)
                    {
                        test.남은점프개수 = test.최대점프개수;
                    }
                }
                if (Input.GetMouseButtonDown(0))
                {
                    Vector2 temp = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, 10));
                    Destroy(ping);
                    interrupt(temp);
                    StopCoroutine("move");
                    break;
                }
            }
        }
        Destroy(ping);      
    }
    public void interrupt(Vector2 temp)
    {
        var ping = Instantiate(핑, temp, Quaternion.identity);
        StartCoroutine(move(ping));
    }
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        if(이동.오른쪽)
        {
            Gizmos.DrawWireCube(new Vector2(gameObject.transform.position.x + 오른쪽위치.x, gameObject.transform.position.y + 오른쪽위치.y), 범위);

        }
        else if(이동.왼쪽)
        {
            Gizmos.DrawWireCube(new Vector2(gameObject.transform.position.x + 왼쪽위치.x, gameObject.transform.position.y + 왼쪽위치.y), 범위);
        }
        else
        {
            Gizmos.DrawWireCube(new Vector2(gameObject.transform.position.x + 오른쪽위치.x, gameObject.transform.position.y + 오른쪽위치.y), 범위);
            Gizmos.DrawWireCube(new Vector2(gameObject.transform.position.x + 왼쪽위치.x, gameObject.transform.position.y + 왼쪽위치.y), 범위);
        }
    }
}
