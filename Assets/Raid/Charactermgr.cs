using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Charactermgr : MonoBehaviour
{
    public static Charactermgr instance;
    public Transform par;
    public GameObject character;
    public raidnum raid;

    public TMP_InputField c_name;
    public TMP_InputField c_desc;
    public TMP_Dropdown c_job;
    public Sprite[] characterimg;

    private void Awake()
    {
        Charactermgr.instance = this;
    }
    public void addcharacter()
    {
        var a = Instantiate(character, par);
        a.name = Data.inst.c_namedata.Length.ToString();
        Array.Resize(ref Data.inst.c_namedata, Data.inst.c_namedata.Length + 1);
        Array.Resize(ref Data.inst.c_descdata, Data.inst.c_descdata.Length + 1);
        Array.Resize(ref Data.inst.c_raid, Data.inst.c_raid.Length + 1);
        Array.Resize(ref Data.inst.c_jobdata, Data.inst.c_jobdata.Length + 1);

        Array.Resize(ref DataManager.Instance.data.c_namedata, Data.inst.c_namedata.Length);
        Array.Resize(ref DataManager.Instance.data.c_descdata, Data.inst.c_namedata.Length);
        Array.Resize(ref DataManager.Instance.data.c_raid, Data.inst.c_namedata.Length);
        Array.Resize(ref DataManager.Instance.data.c_jobdata, Data.inst.c_namedata.Length);
        gameObject.transform.SetAsLastSibling();
    }
    public void characterinfo()
    {
        Data.inst.c_namedata[Data.inst.cureditingindex]= c_name.text;
        Data.inst.c_descdata[Data.inst.cureditingindex]= c_desc.text;
        Data.inst.c_jobdata[Data.inst.cureditingindex] = c_job.value;
        par.transform.GetChild(Data.inst.cureditingindex).GetComponentInChildren<TextMeshProUGUI>().text = Data.inst.c_namedata[Data.inst.cureditingindex];
        par.transform.GetChild(Data.inst.cureditingindex).GetChild(1).GetComponent<Image>().sprite = characterimg[Data.inst.c_jobdata[Data.inst.cureditingindex]];
        Data.inst.save();
    }

    public void display()
    {
        c_name.text = Data.inst.c_namedata[Data.inst.cureditingindex];
        c_desc.text = Data.inst.c_descdata[Data.inst.cureditingindex];
        c_job.value = Data.inst.c_jobdata[Data.inst.cureditingindex];
        raid.ui.text = Data.inst.c_raid[Data.inst.cureditingindex].ToString();
    }

    public void load()
    {
        for(int i = 0; i < Data.inst.c_namedata.Length; i++)
        {
            var a = Instantiate(character, par);
            gameObject.transform.SetAsLastSibling();
            a.name = i .ToString();
            par.transform.GetChild(i).GetComponentInChildren<TextMeshProUGUI>().text = Data.inst.c_namedata[i];
            par.transform.GetChild(i).GetChild(1).GetComponent<Image>().sprite = characterimg[Data.inst.c_jobdata[i]];
        }
    }
}
