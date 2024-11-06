
using UnityEngine;


public class 일시정지 : MonoBehaviour
{
    public GameObject 일시정지지;
    public bool 정지;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(정지)
            {
                resume();
            }
            else
            {
                pause();
            }
        }
    }

    public void pause()
    {
        일시정지지.SetActive (true);
        정지 = true;
        Time.timeScale = 0;

    }
    public void resume()
    {
        일시정지지.SetActive(false);
        정지 = false;
        Time.timeScale = 1;
    }
}
