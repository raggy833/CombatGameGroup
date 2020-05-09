using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private AudioManager audioManager;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        audioManager.Stop("Theme");
        audioManager.Play("Battle");
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }


}
