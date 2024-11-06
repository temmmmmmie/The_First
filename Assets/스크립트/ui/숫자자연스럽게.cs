using TMPro;
using UnityEngine;

public class 숫자자연스럽게 : MonoBehaviour
{
    private bool a;
    private bool b;
    private bool c;
    private void Update()
    {
        if(Input.GetKey(인벤토리.instance.인벤키))
        {
            num();
        }
    }
    public void num()
    {
        int i = int.Parse(gameObject.GetComponent<TextMeshProUGUI>().text); 
        if(i<10)
        {
            if(a)
            {
                return;
            }
            gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(gameObject.GetComponent<RectTransform>().anchoredPosition.x + 7, gameObject.GetComponent<RectTransform>().anchoredPosition.y);
            a = true;
        }
        if(i>=10)
        {
            if (b)
            {
                return;
            }
            gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(gameObject.GetComponent<RectTransform>().anchoredPosition.x - 3, gameObject.GetComponent<RectTransform>().anchoredPosition.y);
            b = true;
        }
        if (i >= 100)
        {
            if (c)
            {
                return;
            }
            gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(gameObject.GetComponent<RectTransform>().anchoredPosition.x - 10, gameObject.GetComponent<RectTransform>().anchoredPosition.y);
            c = true;
        }
    }
}
