using UnityEngine;

public class Pastelillo : MonoBehaviour
{
    GameManager gameManager;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")){           
            Destroy(gameObject);
            gameManager.pastelillos = gameManager.pastelillos + 1;
        }
    }
}
