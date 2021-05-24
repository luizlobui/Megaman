using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // sempre que utilizarmos scene , temos que add na biblioteca

public class LoadLevel : MonoBehaviour
{
    public void LoadScene(string name) // carrega a cena com o nome que passarmos
    {

     SceneManager.LoadScene(name);
    }

    public void QuitGame() // fecha o programa/jogo
    {
    Application.Quit();
    }

}

