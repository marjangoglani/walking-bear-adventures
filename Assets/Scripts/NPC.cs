using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NPC : MonoBehaviour
{
    public GameObject DialoguePanel;
    public TextMeshProUGUI DialogueText;
    public string[] Dialogue;
    private int Index;
    public GameObject ContinueButton;

    public float WordSpeed;
    public bool PlayerIsClose;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && PlayerIsClose)
        {
            if (DialoguePanel.activeInHierarchy)
            {
                resetText();
            }
            else
            {
                DialoguePanel.SetActive(true);
                StartCoroutine(typing());
            }
        }

        if (DialogueText.text == Dialogue[Index])
        {
            ContinueButton.SetActive(true);
        }
    }

    public void resetText()
    {
        DialogueText.text = "";
        Index = 0;
        DialoguePanel.SetActive(false);
    }

    IEnumerator typing()
    {
        foreach (char letter in Dialogue[Index].ToCharArray())
        {
            DialogueText.text += letter;
            yield return new WaitForSeconds(WordSpeed);
        }
    }

    public void nextLine()
    {
        ContinueButton.SetActive(false);
        if (Index < Dialogue.Length - 1)
        {
            Index++;
            DialogueText.text = "";
            StartCoroutine(typing());
        }
        else
        {
            resetText();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // FIXME: show an image with the button name (E)
        if (other.CompareTag("Player"))
        {
            PlayerIsClose = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerIsClose = false;
            resetText();
        }
    }
}
