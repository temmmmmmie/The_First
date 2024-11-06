using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 공중인가: MonoBehaviour
{
    public bool 떨어지는중;
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "땅")
        {
            떨어지는중 = false;
        };

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "땅")
        {
            떨어지는중 = true;
        };
    }
}