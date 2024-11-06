using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 키보드로공격 : MonoBehaviour
{
    public KeyCode 공격키;
    public GameObject 공격할거;
    public float 공격강도;
    SpriteRenderer 렌더러;
    // Start is called before the first frame update
    void Start()
    {
        렌더러 = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(공격키))
        { 
            GameObject 지금발사함 = Instantiate(공격할거);
            지금발사함.transform.position = this.transform.position;
            if(렌더러.flipX == true )
            {
                지금발사함.GetComponent<Rigidbody2D>().AddForce(Vector2.left * 공격강도);
            }
            else
            {
                지금발사함.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 공격강도);
            };
        };
    }
}
