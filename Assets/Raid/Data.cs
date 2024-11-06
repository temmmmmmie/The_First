using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Data : MonoBehaviour
{
    public static Data inst;
    public Taskmgr taskmgr;
    public GameObject info;
    public GameObject shitpost;
    public int[] task;
    public string[] c_namedata;
    public string[] c_descdata;
    public int[] c_jobdata;
    public int[] c_raid;

    public string temp;
    public int cureditingindex = 100;
    // Start is called before the first frame update
    private void Awake()
    {
        Data.inst = this;
    }
    private void Start()
    {
        DataManager.Instance.LoadGameData();
        if(cureditingindex == 0)
        {
            info.SetActive(false);
            shitpost.SetActive(true);
        }

        Array.Resize(ref c_namedata, DataManager.Instance.data.c_namedata.Length);
        Array.Resize(ref c_descdata, DataManager.Instance.data.c_descdata.Length);
        Array.Resize(ref c_raid, DataManager.Instance.data.c_raid.Length);
        Array.Resize(ref c_jobdata, DataManager.Instance.data.c_jobdata.Length);
        for(int i = 0; i < c_namedata.Length; i++)
        {
            c_namedata[i] = DataManager.Instance.data.c_namedata[i];
            c_descdata[i] = DataManager.Instance.data.c_descdata[i];
            c_raid[i] = DataManager.Instance.data.c_raid[i];
            c_jobdata[i] = DataManager.Instance.data.c_jobdata[i];
        }
        Charactermgr.instance.load();
    }
    public void addtask(int i)
    {
        Array.Resize(ref task, task.Length + 1);
        task[task.Length - 1] = i;
    }
    public void erasetask()
    {
        var a = Convert.ToInt32(temp);
        switch(task[a])
        {
            case 0:
                taskmgr.tiredness += 8;
                break;
            case 1:
                taskmgr.tiredness += 10;
                break;
            case 2:
                taskmgr.tiredness += 0;
                break;
            case 3:
                taskmgr.tiredness += 6;
                break;
            case 4: //crack
                taskmgr.tiredness += 12;
                break;
            case 5: //raid
                taskmgr.tiredness += 0;
                break;
            case 6://card
                taskmgr.tiredness += 16;
                break;
            case 7://fourking
                taskmgr.tiredness += 12;
                break;
            case 8://up
                taskmgr.tiredness += 7;
                break;
            case 9://story
                taskmgr.tiredness += 8;
                break;
            case 10://kap
                taskmgr.tiredness += 8;
                break;
            case 11://sunship
                taskmgr.tiredness += 8;
                break;
            case 12://10up
                taskmgr.tiredness -= 10;
                break;
            case 13://20up
                taskmgr.tiredness -= 20;
                break;
            case 14://30up
                taskmgr.tiredness -= 30;
                break;
        }
        task[a] = 100;
        Invoke("fuck", 0.1f);
        task = Array.FindAll(task, num => num != 100).ToArray();
        taskmgr.refreshui();
    }

    void fuck()
    {
        for (int i = 0; i < taskmgr.par.transform.childCount - 1; i++)
        {
            taskmgr.par.transform.GetChild(i).name = i.ToString();
        }
    }

    public void infodis()
    {
        info.SetActive(true);
        shitpost.SetActive(false);
    }

    private void OnApplicationQuit()
    {
        for(int i = 0; i < c_descdata.Length; i ++)
        {
            DataManager.Instance.data.c_namedata[i] = c_namedata[i];
            DataManager.Instance.data.c_descdata[i] = c_descdata[i];
            DataManager.Instance.data.c_raid[i] = c_raid[i];
            DataManager.Instance.data.c_jobdata[i] = c_jobdata[i];
        }
        DataManager.Instance.SaveGameData();
    }

    public void save()
    {
        for (int i = 0; i < c_descdata.Length; i++)
        {
            DataManager.Instance.data.c_namedata[i] = c_namedata[i];
            DataManager.Instance.data.c_descdata[i] = c_descdata[i];
            DataManager.Instance.data.c_raid[i] = c_raid[i];
            DataManager.Instance.data.c_jobdata[i] = c_jobdata[i];
        }
    }
}
