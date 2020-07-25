using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    /*      VARIÁVEIS    */
    //Variável _enemies que recebe a quantidade de monstros definidos na cena.
    private Enemy[] _enemies;

    //Variável _nextLevelIndex que basicamente age como a variável que troca o nível, ao acabar o nível ela some +1 fazendo com que vá ao próximo.
    private static int _nextLevelIndex = 1;

    [SerializeField] int _maxLevel = 2;



    /*      MÉTODOS    */
    //Ao Level ser carregado, faz com que a variável _enemies receba todos os monstros da fase.
    private void OnEnable()
    {
        _enemies = FindObjectsOfType<Enemy>();
    }

    //A todo segundo faz um foreach de todos os inimigos para verificar se todos morreram ou não. Se sim ele adiciona +1 no indice de level e a próxima cena é carregada.
    void Update()
    {
        foreach(Enemy enemy in _enemies)
        {
            if (enemy != null)
            {
                return;
            }
        }

        //Mostra uma mensagem no debug falando que matou todos os inimigos.
        Debug.Log("You killed all enemies");

        //A variável que controle o nível aumenta +1
        _nextLevelIndex++;

        //Define o nome do próximo nivel baseado na variavel do indice de level.
        string nextLevelName = "Level" + _nextLevelIndex;

        //Carrega a próxima fase.
        SceneManager.LoadScene(nextLevelName);

        if(_nextLevelIndex > _maxLevel)
        {
            _nextLevelIndex = 1;
            SceneManager.LoadScene("Level1");
        }
    }
}
