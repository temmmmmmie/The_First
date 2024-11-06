using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 다이알로그 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var d = CSVReader.Read("쌉소리");

        print(d[0]["content"].ToString());
    }

}
