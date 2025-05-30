using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    [SerializeField] public int nivel;
    [SerializeField] public int pastelillos;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pastelillos = 0;
        nivel = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void setNivel(int nnivel)
    {
        nivel = nnivel;
    }
    void resetPastelillos()
    {
        pastelillos = 0;
    }

    public bool checkNivelCompleted()
    {
        if (nivel == 1)
        {
            if (pastelillos == 1)
            {
                return true;
            } else
            {
                return false;
            }                      
        }
        return false;
    }

}
