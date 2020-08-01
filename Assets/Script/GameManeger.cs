using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManeger : MonoBehaviour
{
    public void OnClickChangeSceneButton(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
