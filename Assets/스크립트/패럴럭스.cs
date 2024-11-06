using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class 패럴럭스 : MonoBehaviour
{
    public Transform[] 배경;
    public GameObject 주인공;
    public Vector2 속도;
    public float 부드라미;
    public Vector2 위치;

    public void Update() // -11(왼) ~ 1(오른)
    {
        if(주인공.transform.position.x >= -11 && 주인공.transform.position.x <= 0)
        {
            위치 = 배경[1].localPosition;
            속도 = 주인공.GetComponent<Rigidbody2D>().velocity;
            if (-0.79f <= 배경[1].transform.localPosition.x  &&  배경[1].transform.localPosition.x <= -0.43f)
            {
                배경[1].transform.Translate(Vector2.right * 속도.x * 0.0005f * 부드라미);
            }
            else
            {
                if(위치.x > -0.43f && 위치.x <= -0.43f+0.05f) //오른쪽
                {
                    배경[1].transform.Translate(Vector2.left * 0.001f);
                }
                else if(위치.x < -0.79 && 위치.x >= -0.79f - 0.05f) //왼쪽
                {
                    배경[1].transform.Translate(Vector2.right * 0.001f);
                }
            }

        }
    }

}
