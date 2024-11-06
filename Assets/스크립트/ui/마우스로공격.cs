
using System.Collections;
using UnityEngine;

public class 마우스로공격 : MonoBehaviour
{
    RaycastHit2D 몬스터;
    public bool atk;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        몬스터 = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, 10)), Vector3.forward, 4, LayerMask.GetMask("몬스터"));
        Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(근접공격.instance.pos.position, 근접공격.instance.공격범위, 0);
        Debug.DrawRay(Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, 10)), Vector3.forward * 4, Color.red);
        if (Input.GetMouseButton(0) && 몬스터)
        {
            atk = true;
            if (몬스터.transform.position.x > gameObject.transform.position.x) //오른쪽
            {
                이동.오른쪽 = true;
                이동.왼쪽 = false;
                while( collider2Ds.Length <= 0)
                {                    
                    gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * gameObject.GetComponent<이동>().이동속도);
                }
                atkk(collider2Ds);
            }
            else if(몬스터.transform.position.x < gameObject.transform.position.x) //왼쪽
            {
                이동.왼쪽 = true;
                이동.오른쪽 = false;
                while (collider2Ds.Length <= 0)
                {
                    gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.left * gameObject.GetComponent<이동>().이동속도);
                }
                atkk(collider2Ds);
            }
        }
        else if(!몬스터)
        {
            atk = false;
        }
    }

    public void atkk(Collider2D[] collider2Ds)
    {
        if (근접공격.instance.curtime <= 0) //공격
        {
            bool crit = Dods_ChanceMaker.GetThisChanceResult_Percentage(근접공격.instance.명중률);
            foreach (Collider2D collider in collider2Ds)
            {
                if (collider.tag == "몬스터")
                {
                    if (crit)
                    {
                        근접공격.instance.실제공격력 = 근접공격.instance.공격력 * 2;
                        collider.GetComponent<데미지>().takedamage(근접공격.instance.공격력 * 2, 근접공격.instance.넉백);
                    }
                    else
                    {
                        근접공격.instance.실제공격력 = 근접공격.instance.공격력;
                        collider.GetComponent<데미지>().takedamage(근접공격.instance.공격력, 근접공격.instance.넉백);
                    }
                }
            }
            근접공격.instance.curtime = 근접공격.instance.쿨타임;
        }
    }
}
