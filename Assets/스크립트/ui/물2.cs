using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 물2 : MonoBehaviour
{

    // Start is called before the first frame update
    private void OnCollisionStay2D(Collision2D collision)
    {
        gameObject.GetComponent<CircleCollider2D>().isTrigger = true;
    }
}
