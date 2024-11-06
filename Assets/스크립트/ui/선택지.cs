using System;
using UnityEngine;

public class 선택지 : MonoBehaviour
{
    public string[] 선택지대화내용;
    public string[] 선택지이름;
    public Sprite[] 선택지표정;
    public int 몇번;
    public void select()
    {
        Array.Clear(npc.instance.대화내용, 0, npc.instance.대화내용.Length);
        for(int i = 0; i < npc.instance.선택지후대화내용[몇번].대화내용.Length; i++)
        {
            npc.instance.대화내용[i] = npc.instance.선택지후대화내용[몇번].대화내용[i].ToString(); //선택지 후 대화내용 바꾸기
        }
        Array.Resize(ref npc.instance.대화내용, npc.instance.선택지후대화내용[몇번].대화내용.Length);
        npc.instance.대화순서 = 0;
        대화.instance.선택지엄마.GetComponent<Animator>().Play("선택지반대");
        대화.instance.선택지중 = false;
        대화.instance.ini();
        대화.instance.sayfuck();
    }
}
