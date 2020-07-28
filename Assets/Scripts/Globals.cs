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
}