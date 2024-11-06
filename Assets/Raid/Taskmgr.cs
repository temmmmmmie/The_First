using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Taskmgr : MonoBehaviour
{
    public GameObject popup;
    public Image tirdbar;
    public TMP_InputField maxtiredinput;
    public Transform par;
    public GameObject character;

    public float tiredness;
    public float tiredness_d;
    public float maxtired = 80;

    string taskname;
    int taskindex;
    string result;
    private void Start()
    {
        tiredness = maxtired;
        tiredness_d = maxtired;
    }
    public void popuptask()
    {
        popup.SetActive(true);
    }

    public void setmaxtiredness()
    {
        int result;
        if(int.TryParse(maxtiredinput.text, out result))
        {
            maxtired = Convert.ToInt32(maxtiredinput.text);
        }
        maxtiredinput.text = tiredness.ToString();
    }

    public void selectesk(int i)
    {
        taskindex = i;
        if(tiredness <= 0)
        {
            nopower();
            return;
        }
        switch(i)
        {
            case 0:
                tiredness -= 8;
                taskname = "선미";
                break;
            case 1:
                tiredness -= 10;
                taskname = "승리";
                break;
            case 2:
                tiredness -= 0;
                taskname = "보물";
                break;
            case 3:
                tiredness -= 6;
                taskname = "오디";
                break;
            case 4: //crack
                tiredness -= 12;
                taskname = "균열";
                break;
            case 5: //raid
                tiredness -= 0;
                taskname = "레이드";
                break;
            case 6://card
                tiredness -= 16;
                taskname = "유랑단";
                break;
            case 7://fourking
                tiredness -= 12;
                taskname = "사천왕";
                break;
            case 8://up
                tiredness -= 7;
                taskname = "승급";
                break;
            case 9://story
                tiredness -= 8;
                taskname = "스토리";
                break;
            case 10://kap
                tiredness -= 8;
                taskname = "카프";
                break;
            case 11://sunship
                tiredness -= 8;
                taskname = "선수";
                break;
            case 12://10up
                tiredness += 10;
                taskname = "피료도 10 회복";
                break;
            case 13://20up
                tiredness += 20;
                taskname = "피료도 20 회복";
                break;
            case 14://30up
                tiredness += 30;
                taskname = "피료도 30 회복";
                break;
        }
        tirednesscheck();
        uiset();
    }
    public void tirednesscheck()
    {
        tiredness_d = tiredness;
        if (tiredness < 0)
        {
            tiredness_d = 0;
        }
        else if (tiredness > maxtired)
        {
            tiredness_d = maxtired;
        }
    }

    void nopower()
    {
        popup.SetActive(false);
    }
    void uiset()
    {
        maxtiredinput.text = tiredness_d.ToString();
        tirdbar.fillAmount = tiredness_d / maxtired;
        addtask();
        popup.SetActive(false);
    }

    public void addtask()
    {
        Data.inst.addtask(taskindex);
        var a = Instantiate(character, par);
        a.name = (Data.inst.task.Length -1).ToString();
        a.GetComponentInChildren<TextMeshProUGUI>().text = taskname;
        gameObject.transform.SetAsLastSibling();
    }
    public void refreshui()
    {
        maxtiredinput.text = tiredness.ToString();
        tirdbar.fillAmount = tiredness / maxtired;
    }

    public void reset()
    {
        GameObject[] a = GameObject.FindGameObjectsWithTag("task");
        for(int i = 0; i < a.Length; i++)
        {
            Destroy(a[i]);
        }
        Array.Resize(ref Data.inst.task, 0);
        tiredness = maxtired;
        tiredness_d = maxtired;
        refreshui();
    }

    public void makestring()
    {
        string[] task = new string[Data.inst.task.Length];
        for(int i = 0; i<Data.inst.task.Length; i++)
        {
            switch (Data.inst.task[i])
            {
                case 0:
                    task[i] = "선미";
                    break;
                case 1:
                    task[i] = "승리";
                    break;
                case 2:
                    task[i] = "보물";
                    break;
                case 3:
                    task[i] = "오디";
                    break;
                case 4: //crack
                    task[i] = "균열";
                    break;
                case 5: //raid
                    task[i] = "레이드";
                    break;
                case 6://card
                    task[i] = "유랑단";
                    break;
                case 7://fourking
                    task[i] = "사천왕";
                    break;
                case 8://up
                    task[i] = "승급";
                    break;
                case 9://story
                    task[i] = "스토리";
                    break;
                case 10://kap
                    task[i] = "카프";
                    break;
                case 11://sunship
                    task[i] = "선수";
                    break;
                case 12://10up
                    task[i] = "피료도 10 회복";
                    break;
                case 13://20up
                    task[i] = "피료도 20 회복";
                    break;
                case 14://30up
                    task[i] = "피료도 30 회복";
                    break;
            }
        }
        for(int i = 0; i < task.Length; i++)
        {
            result = result + task[i] + " - ";
        }
        GUIUtility.systemCopyBuffer = result;
    }
}
