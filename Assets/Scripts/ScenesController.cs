using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesController : MonoBehaviour
{
    public void LoadSceneByName(string n) 
    {
        SceneManager.LoadScene(n);
    }
}
