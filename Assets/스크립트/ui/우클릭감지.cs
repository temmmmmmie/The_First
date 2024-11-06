using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 우클릭감지 : MonoBehaviour
{
    public static 우클릭감지 instance;
    public Vector3 마우스;
    public RaycastHit2D ray;
    public Vector2 범위;
    [Space(50)]
    [Header("아이템관련")]
    public GameObject 플레이어;
    public Vector2 오차범위;
    public Vector2 size;
    [Space(50)]
    public float 속도;
    private void Awake()
    {
        우클릭감지.instance = this;
    }
    // Update is called once per frame
    void Update()
    {
        if(상점.openshop || 인벤토리.인벤여는중)
        {
            return;
        }
        마우스 = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, 10));
        if (Input.GetMouseButtonDown(1) && 상점.selling) //상점 우클릭
        {
            ray = Physics2D.Raycast(마우스, Vector3.forward, 3, LayerMask.GetMask("상점"));
            Debug.DrawRay(마우스, Vector3.forward * 3, Color.cyan);
            if (ray)
            {
                gameObject.GetComponent<툴팁>().sellall();
            }
        }
        else if (Input.GetMouseButtonDown(1)) //필드
        {
            ray = Physics2D.Raycast(마우스, Vector3.forward, 3, LayerMask.GetMask("필드"));
            Debug.DrawRay(마우스, Vector3.forward * 3, Color.cyan);
            if(ray)
            {
                ray.collider.GetComponent<상점>().prep();
            }
        }



        Collider2D collider2D = Physics2D.OverlapBox(new Vector2(플레이어.transform.position.x + 오차범위.x, 플레이어.transform.position.y + 오차범위.y), size, 0, LayerMask.GetMask("아이템"));
        if(collider2D)
        {
        collider2D.GetComponent<아이템존맛>().getitem();

        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(new Vector2(플레이어.transform.position.x + 오차범위.x, 플레이어.transform.position.y + 오차범위.y), size);
    }
}

