using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class 다시게임으로 : MonoBehaviour
{
    public GameObject 일시정지지;
    public void resume()
    {
        GameObject.FindGameObjectWithTag("플레이어").GetComponent<일시정지>().정지 = false;
        EventSystem.current.SetSelectedGameObject(null);
        일시정지지.SetActive(false);
        Time.timeScale = 1;
    }
}
