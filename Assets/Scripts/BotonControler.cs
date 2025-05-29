using UnityEngine;

public class BotonPresion : MonoBehaviour
{
    [SerializeField] private GameObject objetoActivable;
    [SerializeField] private string[] tagsActivadores = { "Player", "Caja" };
    [SerializeField] private bool mantenerActivo = false; // Si querés que no se apague al salir

    private int objetosEncima = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (EsActivadorValido(other.tag))
        {
            objetosEncima++;
            if (objetosEncima == 1)
            {
                ActivarObjeto();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (EsActivadorValido(other.tag))
        {
            objetosEncima--;
            if (objetosEncima <= 0 && !mantenerActivo)
            {
                DesactivarObjeto();
            }
        }
    }

    private bool EsActivadorValido(string tag)
    {
        foreach (string t in tagsActivadores)
        {
            if (tag == t)
                return true;
        }
        return false;
    }

    private void ActivarObjeto()
    {
        if (objetoActivable != null)
            objetoActivable.SetActive(true);
    }

    private void DesactivarObjeto()
    {
        if (objetoActivable != null)
            objetoActivable.SetActive(false);
    }
}
