
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;


public class 데미지 : MonoBehaviour
{
    public Transform 몬스터;
    public Transform 체력표시;
    public GameObject 플레이어;
    public GameObject 피;
    public GameObject 먼지파티클;
    public GameObject 데미지표시;
    private Transform 게이지;
    [Space(20)]
    [Header("몬스터")]
    [Space(10)]
    public float 몬스터데미지;
    public float 몬스터넉백크키;
    public float 몬스터최대체력;
    public float 몬스터체력;
    [Space(20)]
    [Header("아이템")]
    [Space(10)]
    private Transform 아이템보관;
    public GameObject[] 아이템;
    public float[] 드랍확률;
    public int[] 갯수;
    public float 날아가는크기;
    private float yup;
    public int showing;

    private void Start()
    {
        yup = 1;
        몬스터체력 = 몬스터최대체력;
        플레이어 = GameObject.FindGameObjectWithTag("플레이어");
        아이템보관 = GameObject.Find("아이템보관").GetComponent<Transform>();
        먼지파티클 = GameObject.Find("먼지파티클");
        체력표시 = gameObject.transform.GetChild(0);
        게이지 = 체력표시.GetChild(1);
        StartCoroutine("time");
    }

    private void Update()
    {
        if (몬스터체력 != 몬스터최대체력)
        {
            yup = Mathf.Lerp(yup, 몬스터체력 / 몬스터최대체력, Time.deltaTime * 3);
        }
        else if (Mathf.Approximately(yup, 몬스터체력 / 몬스터최대체력))
        {
            return;
        }
        게이지.GetComponent<SpriteRenderer>().size = new Vector2(yup, 1); //1이 최대체력     최대 100 현재 70
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //플레이어 피격
        if (collision.gameObject.tag == "플레이어")
        {
            if(npc.대화중)
            {
                대화.instance.monsterhurt();
            }
            Destroy( GameObject.Find("Trail(Clone)"));
            체력ui.실제체력 -= 몬스터데미지;
            먼지파티클.GetComponent<집찾는파티클>().emit();
            if (이동.왼쪽 == true) //넉백
            {
                플레이어.GetComponent<Rigidbody2D>().AddForce(new Vector2(1, 1) * 몬스터넉백크키, ForceMode2D.Impulse);
            }
            else
            {
                플레이어.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1, 1) * 몬스터넉백크키, ForceMode2D.Impulse);
            }
            GameObject.FindWithTag("카메라").GetComponent<SimpleCameraShakeInCinemachine>().Camerashake();
            //파티클
            var p = Instantiate(피, new Vector2(플레이어.transform.position.x, 플레이어.transform.position.y), Quaternion.identity) as GameObject;
            Destroy(p, 0.5f);
        }
    }
    public void takedamage(int 데미지, float 플레이어넉백크키)
    {
        //몬스터
        몬스터체력 = 몬스터체력 - 데미지;
        if (몬스터체력 <= 0) //쥬금
        {
            Vector2 wut = gameObject.transform.position;
            var b = Instantiate(데미지표시);
            b.GetComponent<RectTransform>().anchoredPosition = wut;
            공격표시.showdam.finaldamage();
            var p = Instantiate(피, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.identity) as GameObject;
            Destroy(p, 0.5f);
            for(int i = 0; i < 아이템.Length; i++)
            {
                bool itemdroped = Dods_ChanceMaker.GetThisChanceResult_Percentage(드랍확률[i]);
                if(itemdroped)
                {
                    for(int a = 0; a < 갯수[i]; a++)
                    {
                        itemdrop(i);
                    }
                }
            }
            Destroy(gameObject);

        }
        else
        {
            Instantiate(데미지표시, 몬스터);
            공격표시.showdam.showdamage();
            if(showing == 0)
            {
                체력표시.transform.gameObject.SetActive(true);
            }
            showing = 10;
            var p = Instantiate(피, 몬스터) as GameObject; //몬스터 맞음
            Destroy(p, 0.5f);
            if (이동.오른쪽 == true) //몬스터 넉백
            {
                GetComponent<EnemyMove>().enabled = false;
                GetComponent<Rigidbody2D>().AddForce(new Vector2(1, 1).normalized * 플레이어넉백크키, ForceMode2D.Impulse);
                Invoke("Aistart", 1f);

            }
            else
            {
                GetComponent<EnemyMove>().enabled = false;
                GetComponent<Rigidbody2D>().AddForce(new Vector2(-1, 1).normalized * 플레이어넉백크키, ForceMode2D.Impulse);
                Invoke("Aistart", 1f);
            }
        }
    }
    private void Aistart()
    {
        GetComponent<EnemyMove>().enabled = true;
    }
    public void itemdrop(int i)
    {
        var 아이템템 = Instantiate(아이템[i], new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.identity, 아이템보관);
        아이템템.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-1, 2), 1) * 날아가는크기, ForceMode2D.Impulse);
    }

    IEnumerator time()
    {
        while(true)
        {
            if(showing > 0 )
            {
                yield return new WaitForSeconds(1);
                showing--;
            }
            else if (showing <= 0)
            {
                체력표시.transform.gameObject.SetActive(false);
                yield return new WaitUntil(() => showing > 0);
            }
        }
    }

}
