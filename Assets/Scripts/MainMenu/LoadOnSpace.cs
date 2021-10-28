using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadOnSpace : MonoBehaviour
{

    public KeyCode keyCode;
    public string sceneName;

    void Update()
    {
        if (Input.GetKeyDown(keyCode))
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
