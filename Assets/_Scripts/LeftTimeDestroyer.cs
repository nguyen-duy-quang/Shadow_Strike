using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftTimeDestroyer : MonoBehaviour
{
    public float Time = 0.2f;
    void Start()
    {
        Destroy(this.gameObject, Time);
    }
}
