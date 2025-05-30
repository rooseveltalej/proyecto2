using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para cambiar de escena

public class GameManager3 : MonoBehaviour
{
    // Instancia estática para acceder fácilmente al GameManager desde otros scripts
    public static GameManager3 instance;

    // Variables visibles en el Inspector de Unity
    [Header("Configuración de Nivel")]
    [Tooltip("Nivel actual en el que se encuentra el jugador. Comienza en 1.")]
    [SerializeField] public int nivel = 1; // Nivel inicial

    [Header("Contador de Coleccionables")]
    [Tooltip("Cantidad de pastelillos recolectados en el nivel actual.")]
    [SerializeField] public int pastelillos;

    private void Awake()
    {
        // Implementación del patrón Singleton para asegurar una única instancia del GameManager
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Hace que el GameManager persista entre escenas
        }
        else if (instance != this)
        {
            Destroy(gameObject); // Destruye duplicados si ya existe una instancia
        }
    }

    void Start()
    {
        // Inicializa los pastelillos a 0 al comenzar el juego o un nuevo nivel
        // Si GameManager persiste, Start() solo se llama una vez.
        // El reinicio de pastelillos por nivel se maneja en ComprobarCondicionNivel()
        // o podría llamarse explícitamente al cargar una nueva escena.
        // Por ahora, lo inicializamos aquí para el primer arranque.
        pastelillos = 0;
        Debug.Log("GameManager Iniciado. Nivel actual: " + nivel + ", Pastelillos: " + pastelillos);
    }

    /// <summary>
    /// Método para llamar cuando el jugador recolecta un pastelillo.
    /// </summary>
    public void RecolectarPastelillo()
    {
        pastelillos++;
        Debug.Log("Pastelillo recolectado. Total: " + pastelillos);

        // Comprueba si se ha alcanzado la cantidad necesaria de pastelillos
        if (pastelillos >= 3)
        {
            ComprobarCondicionNivel();
        }
    }

    /// <summary>
    /// Verifica si se debe pasar de nivel o si el jugador ha ganado.
    /// </summary>
    private void ComprobarCondicionNivel()
    {
        Debug.Log("¡Se han recolectado 3 pastelillos!");

        if (nivel < 3) // Si no estamos en el último nivel
        {
            nivel++; // Avanza al siguiente nivel
            Debug.Log("¡Nivel completado! Pasando al Nivel " + nivel + ".");
            ReiniciarPastelillos(); // Reinicia el contador para el nuevo nivel

            // Aquí deberías cargar la escena del siguiente nivel
            // Ejemplo: SceneManager.LoadScene("Nivel" + nivel);
            // O si tus escenas tienen nombres específicos (ej. "EscenaNivel2", "EscenaNivel3")
            Debug.LogWarning("ACCIÓN REQUERIDA: Implementar la carga de la escena para el Nivel " + nivel);
            // SceneManager.LoadScene("NombreDeTuEscenaNivel" + nivel);
        }
        else if (nivel == 3) // Si estamos en el nivel 3 y se recolectaron los pastelillos
        {
            Debug.Log("¡Felicidades! ¡Has ganado el juego!");
            // Aquí deberías implementar la lógica de victoria
            // Ejemplo: mostrar una pantalla de victoria, detener el tiempo, etc.
            Debug.LogWarning("ACCIÓN REQUERIDA: Implementar la pan  talla o lógica de victoria.");
            // SceneManager.LoadScene("PantallaVictoria");
            // También puedes desactivar controles del jugador u otras acciones de fin de juego.
        }
    }

    /// <summary>
    /// Reinicia el contador de pastelillos a 0.
    /// Útil al comenzar un nuevo nivel.
    /// </summary>
    private void ReiniciarPastelillos()
    {
        pastelillos = 0;
        Debug.Log("Contador de pastelillos reiniciado a 0 para el nuevo nivel.");
    }

    // El método Update() se puede usar para lógicas que se ejecutan cada frame,
    // pero en este caso, la lógica de los pastelillos es reactiva a eventos.
    // void Update()
    // {
    // }

    // Método de ejemplo para cargar un nivel específico (opcional)
    // public void CargarNivelEspecifico(int numeroNivel)
    // {
    // nivel = numeroNivel;
    // ReiniciarPastelillos();
    // Debug.Log("Cargando Nivel " + nivel);
    // SceneManager.LoadScene("NombreDeTuEscenaNivel" + nivel);
    // }
}