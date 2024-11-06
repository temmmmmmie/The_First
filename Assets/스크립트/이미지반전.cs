
using UnityEngine;

public class 이미지반전 : MonoBehaviour
{

    void Start()
    {
 
    }

    void Update()
    {
        float 이동속도 = GetComponent <Rigidbody2D> ().velocity.x;
        if (이동속도 > 0.5f)
        {
            GetComponent<SpriteRenderer>().flipX = false;

        }
        else if (이동속도 < -0.5f)
        {
            GetComponent<SpriteRenderer>().flipX = true;

        }
    }
};
