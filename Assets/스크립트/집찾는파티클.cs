using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 집찾는파티클 : MonoBehaviour
{
    public ParticleSystem ps;
    public void emit()
    {
        ps.Emit(100);
    }
}
