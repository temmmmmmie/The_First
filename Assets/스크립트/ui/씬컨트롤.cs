
using UnityEngine;
using UnityEngine.SceneManagement;

public class 씬컨트롤 : MonoBehaviour
{
    public GameObject 페이드아웃;
    private void Start()
    {
        gameObject.GetComponent<Animator>().Rebind();
    }
    public void togame()
    {
        Invoke("a", 1f);
    }
    public void totitle()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("start");
    }
    public void a()
    {
        SceneManager.LoadScene("SampleScene");

    }
}
