using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 아이템존맛 : MonoBehaviour
{
    public bool 줍기애니매이션;
    public float 사라지는시간;
    public static bool 개 = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(wait(collision));
    }

    IEnumerator wait(Collider2D collision)
    {
        if (collision.tag == "자석")
        {
            while (collision.IsTouching(gameObject.GetComponent<CapsuleCollider2D>()))
            {
                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, new Vector2(우클릭감지.instance.transform.position.x, 우클릭감지.instance.transform.position.y - 0.9f), Time.deltaTime * 우클릭감지.instance.속도);
                yield return new WaitForSeconds(0.001f);
            }
        }
    }
    public void getitem()
    {
        if (개 == false)
        {
            return;
        }
        if (줍기애니매이션)
        {
            gameObject.GetComponent<Animator>().SetTrigger("줍기");
        }
        Destroy(gameObject, 사라지는시간);
    }
}
