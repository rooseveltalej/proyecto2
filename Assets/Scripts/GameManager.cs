using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    [SerializeField] public int nivel;
    [SerializeField] public int pastelillos;

    private void Awake()
    {
        instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pastelillos = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void resetPastelillos()
    {
        pastelillos = 0;
    }

}
