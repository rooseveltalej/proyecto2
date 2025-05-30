using UnityEngine;
using System.Collections;
using TMPro;

public class NPCfinal : MonoBehaviour
{    
    [SerializeField] private GameObject dialogueIndicator;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField, TextArea(4, 6)] private string[] dialogueLines;

    private bool isPlayerInRange;
    private bool didDialogueStart;
    private int lineIndex;
    private float typingTime = 0.05f;

    void Update()
    {
        if(isPlayerInRange && Input.GetButtonDown("Fire1"))
        {
            Debug.Log(GameManager.Instance.checkNivelCompleted());
            if (!GameManager.Instance.checkNivelCompleted())
            {
                if (!didDialogueStart)
                {
                    StartDialogue(4);
                }
                else if (dialogueText.text == dialogueLines[lineIndex])
                {
                    NextDialogueLine();
                }
                else
                {
                    StopAllCoroutines();
                    dialogueText.text = dialogueLines[lineIndex];
                }
            } else if (GameManager.Instance.checkNivelCompleted())
            {
                if (!didDialogueStart && GameManager.Instance.checkNivelCompleted())
                {
                    StartDialogue(0);
                }
                else if (dialogueText.text == dialogueLines[lineIndex])
                {
                    NextDialogueLine();
                }
                else
                {
                    StopAllCoroutines();
                    dialogueText.text = dialogueLines[lineIndex];
                }
            }

            
        }
    }

    private void StartDialogue(int line)
    {
        didDialogueStart = true;
        dialoguePanel.SetActive(true);
        lineIndex = line;
        Time.timeScale = 0f;
        StartCoroutine(ShowLine());
    }

    private void NextDialogueLine()
    {
        lineIndex++;
        if (lineIndex < dialogueLines.Length && lineIndex !=4)
        {
            StartCoroutine(ShowLine());
        }
        else
        {
            didDialogueStart = false;
            dialoguePanel.SetActive(false);
            Time.timeScale = 1f;
            GameManager.Instance.cargarSiguienteNivel();
        }
    }

    private IEnumerator ShowLine()
    {
        dialogueText.text = string.Empty;

        foreach (char ch in dialogueLines[lineIndex])
        {
            dialogueText.text += ch;
            yield return new WaitForSecondsRealtime(typingTime);
        }
    }

    private IEnumerator ShowNotFinished()
    {
        dialogueText.text = string.Empty;
        string lineShow = "No tienes lo pastelillos necesarios, recuerda traer todos los que se encuentran en la alcantarilla de lo contrario no podré abrirte paso.";
        foreach (char ch in lineShow)
        {
            dialogueText.text += ch;
            yield return new WaitForSecondsRealtime(typingTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = true;
            dialogueIndicator.SetActive(true);
            Debug.Log("Entra");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = false;
            dialogueIndicator.SetActive(false);
            Debug.Log("Sale");
        }
    }
}
