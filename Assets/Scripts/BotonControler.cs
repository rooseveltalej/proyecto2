using UnityEngine;

public class BotonActivador : MonoBehaviour
{
    [SerializeField] private GameObject[] objetosAControlar;
    [SerializeField] private bool usarSoloUnaVez = false;        // ¿Solo una vez?
    [SerializeField] private bool mantenerMientrasPresionado = false; // ¿Mantener efecto mientras presionado?

    private bool haSidoUsado = false;
    private int objetosEnContacto = 0;

    private void ToggleObjetos()
    {
        foreach (GameObject obj in objetosAControlar)
        {
            if (obj != null)
                obj.SetActive(!obj.activeSelf);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.CompareTag("Player") || collision.CompareTag("Caja")) && !haSidoUsado)
        {
            objetosEnContacto++;

            if (objetosEnContacto == 1 && objetosAControlar != null)
            {
                ToggleObjetos();

                if (!mantenerMientrasPresionado && usarSoloUnaVez)
                    haSidoUsado = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if ((collision.CompareTag("Player") || collision.CompareTag("Caja")) && !haSidoUsado)
        {
            objetosEnContacto = Mathf.Max(0, objetosEnContacto - 1);

            if (objetosEnContacto == 0 && objetosAControlar != null && mantenerMientrasPresionado)
            {
                ToggleObjetos();
            }
        }
    }
}
