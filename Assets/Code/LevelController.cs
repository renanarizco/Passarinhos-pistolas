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
    [SerializeField] int _maxLevel = 2;

    private string _nextLevelName;



    /*      MÉTODOS    */
    //Serve para chamar a função de esperar uma quantidade de segundos pro som da explosão não acabar tão rápido.
    IEnumerator WaitFewSecondsToNextLevel()
    {
        //Espera uma quantidade de segundos pra ir pra próxima fase.
        yield return new WaitForSeconds(2);

        //Mostra uma mensagem no debug falando que matou todos os inimigos.
        Debug.Log("You killed all enemies");

        //A variável que controla o nível aumenta +1
        _nextLevelIndex++;

        //Define o nome do próximo nivel baseado na variavel do indice de level.
        _nextLevelName = "Level" + _nextLevelIndex;

        //Faz com que se o indice atual do nivel for maior que o máximo de níveis existentes, volta pra fase 1 e reseta o contador de níveis.
        if(_nextLevelIndex > _maxLevel)
        {
            _nextLevelIndex = 1;
            SceneManager.LoadScene("Menu");
        }

        //Carrega a próxima fase.
        SceneManager.LoadScene(_nextLevelName);
    }


    //Ao Level ser carregado, faz com que a variável _enemies receba todos os monstros da fase.
    private void OnEnable()
    {
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

        StartCoroutine(WaitFewSecondsToNextLevel());
    }
}
