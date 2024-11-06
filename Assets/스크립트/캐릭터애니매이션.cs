using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 캐릭터애니매이션 : MonoBehaviour
{
   Rigidbody2D 리지드바디;
    공중인가 공중;
    Animator 애니매이터;
    // Start is called before the first frame update
    void Start()
    {
        리지드바디 = GetComponent<Rigidbody2D>();
        공중 = GetComponent<공중인가>();
        애니매이터 = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        애니매이터.SetFloat("속도", Mathf.Abs(리지드바디.velocity.x));
        애니매이터.SetBool("공중", 공중.떨어지는중);
    }
}
