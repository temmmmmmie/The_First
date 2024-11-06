using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class 체력ui : MonoBehaviour,IPointerEnterHandler, IPointerExitHandler

{
    public GameObject 체력창;
    public bool 확인용;
    public Text 체력표시;
    public static float 실제체력;
    private void Update ()
    {
        체력표시.text = 실제체력.ToString();
    }
    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        확인용 = true;
        체력창.SetActive(true);
    }
    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        확인용 = false;
        체력창.SetActive(false);
    }
}
