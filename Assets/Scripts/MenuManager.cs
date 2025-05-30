using System;
using TMPro;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class MenuManager : MonoBehaviour
{
    public GameObject panelHistoria;
    public GameObject panelInicio;
    public GameObject buttonContinue;
    [SerializeField] private TMP_Text dialogueText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        panelHistoria.SetActive(false);
        panelInicio.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void cargarHistoria()
    {
        buttonContinue.SetActive(false);
        panelHistoria.SetActive(true);
        panelInicio.SetActive(false);
        StartCoroutine(ContarHistoria());
    }

    private IEnumerator ContarHistoria()
    {
        dialogueText.text = string.Empty;
        string story = "Esta es la historia de un hamster que por circuntancias de la vida fue llevado por la lluvia y terminó siendo arrastrado hasta lo más profundo de las alcantarillas. Ahora es el momento de intentar regresar a casa...";

        foreach (char ch in story)
        {
            dialogueText.text += ch;
            yield return new WaitForSecondsRealtime(0.05f);
        }
        buttonContinue.SetActive(true);
    }

    public void cargarJuego()
    {
        SceneManager.LoadSceneAsync(1);
    }
}
