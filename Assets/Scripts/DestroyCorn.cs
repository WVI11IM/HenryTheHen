using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCorn : MonoBehaviour
{
    public GameObject corn;
    void CornDestroy()
    {
        Destroy(corn);
    }
}
