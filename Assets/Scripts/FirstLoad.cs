using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstLoad : MonoBehaviour
{
    void Start()
    {
        if(GameManager.Instance.FirstLoadBool)
        {
            GameManager.Instance.FirstLoadBool = false;
            GameManager.Instance.FirstLoad();
        }
    }
}
