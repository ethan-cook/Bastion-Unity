using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    void MenuPlay()
    {
        SceneManager.LoadSceneAsync("Start", LoadSceneMode.Single);
    }
}
