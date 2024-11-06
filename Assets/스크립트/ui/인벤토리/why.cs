
using UnityEngine;
using UnityEngine.EventSystems;

public class why : MonoBehaviour
{
    public int 내슬롯;
    // Update is called once per frame
    public void touched()
    {
        옮기기.move.현재슬롯 = 내슬롯;
    }
}
