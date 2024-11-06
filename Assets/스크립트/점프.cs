using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 점프 : MonoBehaviour
{
    public int 최대점프개수;
    public int 남은점프개수;
    public float 점프력;
    public KeyCode 점프키;
    private void Update()
    {
        if(물3.물속 && Input.GetKeyDown(점프키))
        {
            GetComponent<Rigidbody2D>().AddForce(Vector3.up * 점프력);
        }
        else
        {

                if(Input.GetKeyDown(점프키))
                {
                    공중인가 확인 = GetComponent<공중인가>();
                if(확인!=null)
                {
                    if (확인.떨어지는중)
                    {
                        if (남은점프개수 > 0)
                        {
                            남은점프개수--;
                        }
                        else
                        {
                            return;
                        };
                    }
                    else 
                    {
                        남은점프개수 = 최대점프개수 - 1;
            
                    };

                };
        
                GetComponent<Rigidbody2D>().AddForce(Vector3.up * 점프력);
            }
        }
    }

}
