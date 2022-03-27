using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public string nomeDaCena;

    public void IniciarJogo(){
        Time.timeScale = 1f;
        SceneManager.LoadScene(nomeDaCena);
    }

    public void MenuPrincipal(){
        SceneManager.LoadScene(nomeDaCena);
    }

    public void SairJogo(){
        Application.Quit();
    }
}
