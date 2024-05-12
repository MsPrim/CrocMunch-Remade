using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    private void Start()
    {

    }
    public void restart()
    {
        SceneManager.LoadScene("Main Scene");
    }
    public void mainmenu()
    {
        SceneManager.LoadScene("Title Scene");
    }
}
