using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    //Ao clicar no botão Jogar, ele carrega a fase "Level1"
    public void PlayGame()
    {
        SceneManager.LoadScene("Level1");
    }

    //Função para fechar o jogo ao clicar no botão Sair
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit!");
    }
}
