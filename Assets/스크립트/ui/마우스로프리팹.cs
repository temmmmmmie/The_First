using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 마우스로프리팹 : MonoBehaviour
{
    private void Start()
    {
        gameObject.transform.position = new Vector2(gameObject.transform.position.x, -4.4f);
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
    }
}
