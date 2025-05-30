using UnityEngine;
using UnityEngine.SceneManagement;

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
            if (pastelillos == 4)
            {
                return true;
            } else
            {
                return false;
            }                      
        }
        return false;
    }

    public void cargarSiguienteNivel()
    {
        if (checkNivelCompleted())
        {
            if (nivel == 1)
            {
                SceneManager.LoadSceneAsync(2);
                setNivel(2);
            }
            else if (nivel == 2)
            {
                SceneManager.LoadSceneAsync(3);
                setNivel(3);
            }
        }
    }


}
