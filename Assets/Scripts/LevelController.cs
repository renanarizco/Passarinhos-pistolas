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
    int _maxLevel = 1;

    //Variável que controla o nome do próximo nivel
    private string _nextLevelName;

    //Variável que controla o tempo de espera
    private float _timeToNextLevel = 3.5F;

    //Variável responsável pelos controles do jogador.
    private KeysControls _keysControls;

    //Variável responsável pelo nome da fase atual.
    private string _currentSceneName;


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

        //Faz com que se o indice atual do nivel for maior que o máximo de níveis existentes, volta pro menu e reseta o contador de níveis.
        if(_nextLevelIndex > _maxLevel)
        {
            _nextLevelIndex = 1;
            Globals.Quit();
        }
        else
        {
            //Carrega a próxima fase.
            SceneManager.LoadScene(_nextLevelName);
        }
    }

    //Vem primeiro e ativa.
    private void Awake()
    {
        //Instancia o novo _keysControls que é um objeto de KeysControls
        _keysControls = new KeysControls();
    }

    //Vem um pouco depois do Awake.
    private void Start()
    {
        _keysControls.Fase.Exit.performed += _ => Globals.Quit();
        _keysControls.Fase.Restart.performed += _ => Globals.Restart();
    }

    //Ao Level ser carregado, ativa. 
    private void OnEnable()
    {
        //A variável global IsAllMonsterDead recebe falso.
        Globals.IsAllMonsterDead = false;

        //Faz com que a variável _enemies receba todos os monstros da fase.
        _enemies = FindObjectsOfType<Enemy>();

        //Habilita o _keysControls.
        _keysControls.Enable();
    }

    //Ao level acabar desabilita as teclas.
    private void OnDisable()
    {
        _keysControls.Disable();
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
