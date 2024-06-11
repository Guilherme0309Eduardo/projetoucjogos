using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
   public void LoadScene(string cena)
    {
        SceneManager.LoadScene(cena);
        GameController.gc.timeCount = 20;
        
    }
    public void Quit()
    {
        Application.Quit();
    }
}
