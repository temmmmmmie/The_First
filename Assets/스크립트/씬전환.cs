using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class 씬전환 : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "플레이어")
        {
            if(Input.GetKey(KeyCode.F))
            {
                SceneManager.LoadScene("game1");

            }
        }
    }
}
