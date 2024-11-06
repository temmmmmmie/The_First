
using UnityEngine;
using UnityEditor;
using System;

public class item : EditorWindow
{
    public 인벤토리 inv;
    public int 아이템;
    public string[] 이름;
    public int[] 갯수;
    public int[] 가격;
    public string[] 효과;
    public int[] 효과정도;
    public Sprite[] 이미지;
    public string[] 설명;
    public GameObject[] 프리팹;
    [MenuItem("Custom/인벤토리")]
    static void Init()
    {
        // 생성되어있는 윈도우를 가져온다. 없으면 새로 생성한다. 싱글턴 구조인듯하다.
        item window = (item)EditorWindow.GetWindow(typeof(item));
        window.Show();
    }
    private void OnEnable()
    {
        inv = GameObject.FindGameObjectWithTag("플레이어").GetComponent<인벤토리>();
        아이템 = inv.이름.Length;
    }
    void OnGUI()
    {
        
        아이템 = EditorGUILayout.IntField("아이템 갯수", 아이템);
        Array.Resize(ref 프리팹, 아이템);
        Array.Resize(ref 이름, 아이템);
        Array.Resize(ref 갯수, 아이템);
        Array.Resize(ref 가격, 아이템);
        Array.Resize(ref 효과, 아이템);
        Array.Resize(ref 효과정도, 아이템);
        Array.Resize(ref 이미지, 아이템);
        Array.Resize(ref 설명, 아이템);
        EditorGUILayout.Space();
        for (int i = 0; i < 아이템; i++)
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("프리팹", GUILayout.MaxWidth(40));
            프리팹[i] = (GameObject)EditorGUILayout.ObjectField(프리팹[i], typeof(GameObject), true);
            EditorGUILayout.LabelField("이름", GUILayout.MaxWidth(30));
            이름[i] = EditorGUILayout.TextField(이름[i]);
            EditorGUILayout.LabelField("갯수", GUILayout.MaxWidth(30));
            갯수[i] = EditorGUILayout.IntField(갯수[i]);
            EditorGUILayout.LabelField("가격", GUILayout.MaxWidth(30));
            가격[i] = EditorGUILayout.IntField(가격[i]);
            EditorGUILayout.LabelField("효과", GUILayout.MaxWidth(30));
            효과[i] = EditorGUILayout.TextField(효과[i]);
            EditorGUILayout.LabelField("효과정도", GUILayout.MaxWidth(50));
            효과정도[i] = EditorGUILayout.IntField(효과정도[i]);
            EditorGUILayout.LabelField("이미지", GUILayout.MaxWidth(50));
            이미지[i] = (Sprite)EditorGUILayout.ObjectField(이미지[i], typeof(Sprite), true);
            EditorGUILayout.LabelField("설명", GUILayout.MaxWidth(30));
            설명[i] = EditorGUILayout.TextField(설명[i]);
            EditorGUILayout.EndHorizontal();

        }
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.BeginHorizontal();
        var but = GUILayout.Button("가져오기");
        var but3 = GUILayout.Button("적용");
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.EndFoldoutHeaderGroup();
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        if(but)
        {
            아이템 = inv.이름.Length;
            
            for (int i = 0; i < inv.이름.Length; i++)
            {
                프리팹[i] = inv.prefeb[i];
                이름[i] = inv.이름[i];
                갯수[i] = inv.갯수[i];
                가격[i] = inv.가격[i];
                효과[i] = inv.효과2[i];
                효과정도[i] = inv.효과[i];
                이미지[i] = inv.이미지[i];
                설명[i] = inv.설명[i];
            }

        }
        if(but3)
        {
            Array.Resize(ref inv.prefeb, 아이템);
            Array.Resize(ref inv.이름, 아이템);
            Array.Resize(ref inv.갯수, 아이템);
            Array.Resize(ref inv.가격, 아이템);
            Array.Resize(ref inv.효과2, 아이템);
            Array.Resize(ref inv.효과, 아이템);
            Array.Resize(ref inv.이미지, 아이템);
            Array.Resize(ref inv.설명, 아이템);
            for (int i = 0; i < inv.이름.Length; i++)
            {
                inv.prefeb[i] = 프리팹[i];
                inv.이름[i] = 이름[i];
                inv.갯수[i] = 갯수[i];
                inv.가격[i] = 가격[i];
                inv.효과2[i] = 효과[i];
                inv.효과[i] = 효과정도[i];
                inv.이미지[i] = 이미지[i];
                inv.설명[i]  = 설명[i];
            }
        }
        
    }
}
