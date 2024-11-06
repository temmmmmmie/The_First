
using UnityEngine;
using UnityEngine.UI;

public class 체력애니매이션 : MonoBehaviour
{
    public float 속도;
    public Image 체력바;
    public static float 최대체력 = 100;
    public float 현재체력;
    public Text 최대체력표시;
    private void Start()
    {
        체력ui.실제체력 = 현재체력;
        현재체력 = 최대체력;
        
    }
    private void Update()
    {
        최대체력표시.text = 최대체력.ToString();
        if (체력ui.실제체력 != 현재체력)
        {
            현재체력 = Mathf.Lerp(현재체력, 체력ui.실제체력, Time.deltaTime * 속도);
        }
        else if (Mathf.Approximately(체력ui.실제체력, 현재체력))
        {
            return;
        }

        GetComponent<Image>().fillAmount = 현재체력 / 최대체력;
    }
}
