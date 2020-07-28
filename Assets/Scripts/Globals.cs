using UnityEngine;
using UnityEngine.SceneManagement;

public class Globals
{
    //Classe global que armazena variáveis

    /*      VARIÁVEIS       */
    private static bool _isAllMonsterDead = false;

    private static bool _canControl = true;

    public static bool IsAllMonsterDead 
    {
        get
        {
            return _isAllMonsterDead;
        }
        set
        {
            _isAllMonsterDead = value;
        }
    }

    public static bool CanControl
    {
        get
        {
            return _canControl;
        }

        set
        {
            _canControl = value;
        }
    }

    private static string _currentSceneName;

    /*      MÉTODOS     */
    //Serve pra voltar ao menu.
    public static void Quit()
    {
        GameObject.FindGameObjectWithTag("Music").GetComponent<BackgroundMusic>().StopMusic();
        SceneManager.LoadScene("Menu");
    }

    //Serve pra reiniciar a fase.
    public static void Restart()
    {
        _currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(_currentSceneName);
    }

}