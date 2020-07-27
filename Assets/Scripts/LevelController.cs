using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    /*      VARIÁVEIS    */
    //Variável _enemies que recebe a quantidade de monstros definidos na cena.
    private Enemy[] _enemies;

    //Variável _nextLevelIndex que basicamente age como a variável que troca o nível, ao acabar o nível ela some +1 fazendo com que vá ao próximo.
    private static int _nextLevelIndex = 1;

    //Variável que controla o tanto de níveis que existem.
    [SerializeField] int _maxLevel = 4;

    //Variável que controla o nome do próximo nivel
    private string _nextLevelName;

    //Variável que controla o tempo de espera
    private float _timeToNextLevel = 2.5F;

    /*      MÉTODOS    */
    //Serve para chamar a função de esperar uma quantidade de segundos pro som da explosão não acabar tão rápido.
    IEnumerator WaitFewSecondsToNextLevel()
    {
        //Espera uma quantidade de segundos pra ir pra próxima fase.
        yield return new WaitForSeconds(_timeToNextLevel);

        //Mostra uma mensagem no debug falando que matou todos os inimigos.
        Debug.Log("Todos os monstros morreram");

        //A variável que controla o nível aumenta +1
        _nextLevelIndex++;

        //Define o nome do próximo nivel baseado na variavel do indice de level.
        _nextLevelName = "Level" + _nextLevelIndex;

        //Faz com que se o indice atual do nivel for maior que o máximo de níveis existentes, volta pra fase 1 e reseta o contador de níveis.
        if(_nextLevelIndex > _maxLevel)
        {
            _nextLevelIndex = 1;

            //Da stop na musica de fundo quando volta no menu inicial.
            GameObject.FindGameObjectWithTag("Music").GetComponent<BackgroundMusic>().StopMusic();
            SceneManager.LoadScene("Menu");
        }
        //Senão, ele carrega a próxima fase normalmente.
        else
        {
            //Carrega a próxima fase.
            SceneManager.LoadScene(_nextLevelName);
        }
    }


    //Ao Level ser carregado, faz com que a variável _enemies receba todos os monstros da fase.
    //A variável global IsAllMonsterDead recebe falso
    private void OnEnable()
    {
        Globals.IsAllMonsterDead = false;
        _enemies = FindObjectsOfType<Enemy>();
    }

    //A todo segundo faz um foreach de todos os inimigos para verificar se todos morreram ou não.
    void Update()
    {
        foreach(Enemy enemy in _enemies)
        {
            if (enemy != null)
            {
                return;
            }
        }

        Globals.IsAllMonsterDead = true;
        //Se todos os monstros estiverem mortos começa a rotina de troca de fase
        if (Globals.IsAllMonsterDead)
        {
            StartCoroutine(WaitFewSecondsToNextLevel());
        }
    }
}
