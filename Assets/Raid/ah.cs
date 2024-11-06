using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ah : MonoBehaviour
{
    public void conveydata()
    {
        Data.inst.temp = gameObject.name;
        Data.inst.erasetask();
        Destroy(gameObject);
    }

    public void conveycharcterdata()
    {
        Data.inst.cureditingindex = Convert.ToInt32(gameObject.name);
        Charactermgr.instance.display();
        Data.inst.infodis();
    }
}
