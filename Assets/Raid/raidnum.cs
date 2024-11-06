using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class raidnum : MonoBehaviour
{
    public TextMeshProUGUI ui;
    public void up()
    {
        if (Data.inst.c_raid[Data.inst.cureditingindex] >= 9)
        {
            return;
        }
        Data.inst.c_raid[Data.inst.cureditingindex]++;
        display();
    }

    public void down()
    {
        if (Data.inst.c_raid[Data.inst.cureditingindex] <= 0)
        {
            return;
        }
        Data.inst.c_raid[Data.inst.cureditingindex]--;
        display();
    }

    public void display()
    {
        ui.text = Data.inst.c_raid[Data.inst.cureditingindex].ToString();
    }
}
