using UnityEngine;

public class Pastelillo : MonoBehaviour
{    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")){           
            Destroy(gameObject);
            GameManager.Instance.pastelillos = GameManager.Instance.pastelillos + 1;
        }
    }
}
