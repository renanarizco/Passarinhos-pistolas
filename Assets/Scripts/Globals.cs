public class Globals
{
    //Classe global que armazena variáveis

    /*      VARIÁVEIS       */
    private static bool _isAllMonsterDead = false;
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
}