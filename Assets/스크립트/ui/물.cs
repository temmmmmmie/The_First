using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class 물 : MonoBehaviour
{
    public GameObject[] 용수철;
    public GameObject 플레이어;
    public static 물 instance;
    public float 속력;
    public float 힘;
    public float 시간;
    private void Awake()
    {
        물.instance = this;
    }
    private void Start()
    {
        StartCoroutine("water");
        for (int i = 0; i + 1 < 용수철.Length; i++)
        {
            //용수철[i].GetComponent<SpringJoint2D>().connectedBody = 용수철[i + 1].GetComponent<Rigidbody2D>();
            //용수철[41].GetComponent<SpringJoint2D>().connectedBody = 용수철[42].GetComponent<Rigidbody2D>();
        }
        
    }
    private void Update()//물 텍스쳐
    {
        for (int i = 0; i+1 < 용수철.Length; i++)
        {
            용수철[i].GetComponent<LineRenderer>().SetPosition(0, new Vector2(용수철[i].transform.position.x, -8f)); //박힘
            용수철[i].GetComponent<LineRenderer>().SetPosition(1, 용수철[i].transform.position);
            용수철[42].GetComponent<LineRenderer>().SetPosition(0, new Vector2(용수철[42].transform.position.x, -8f));
            용수철[42].GetComponent<LineRenderer>().SetPosition(1, 용수철[42].transform.position);
        }
    }
    IEnumerator water()//물 효과
    {
        bool switc = true;
        while(true)
        {
            int i;
            int a = Random.Range(3, 20);
            int b = Random.Range(20, 40);
            if(switc)
            {
                i = a;
                switc = false;
            }
            else
            {
                i = b;
                switc = true;
            }
            용수철[i - 3].GetComponent<Rigidbody2D>().AddForce(Vector2.down * 0.03f, ForceMode2D.Impulse);
            용수철[i - 2].GetComponent<Rigidbody2D>().AddForce(Vector2.down * 0.03f, ForceMode2D.Impulse);
            용수철[i-1].GetComponent<Rigidbody2D>().AddForce(Vector2.down * 0.05f, ForceMode2D.Impulse);
            용수철[i].GetComponent<Rigidbody2D>().AddForce(Vector2.down * 0.05f, ForceMode2D.Impulse);
            용수철[i+1].GetComponent<Rigidbody2D>().AddForce(Vector2.down * 0.05f, ForceMode2D.Impulse);
            용수철[i + 2].GetComponent<Rigidbody2D>().AddForce(Vector2.down * 0.03f, ForceMode2D.Impulse);
            용수철[i - 3].GetComponent<Rigidbody2D>().AddForce(Vector2.down * 0.03f, ForceMode2D.Impulse);
            yield return new WaitForSeconds(1);
           
        }
    }
}
