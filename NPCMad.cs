using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPCMad : MonoBehaviour
{
    bool playerDetection = false;
    public GameObject d_template;
    public GameObject canva;

    
    void Update()
    {
        if (playerDetection && Input.GetKeyDown(KeyCode.F) && !PlayerMovement.dialogue)
        {
            canva.SetActive(true);
            PlayerMovement.dialogue = true;
            NewDialogue("Hey!");
            NewDialogue("What do you think you're doing on my property!");
            NewDialogue("Go away!");
            NewDialogue("");
            canva.transform.GetChild(1).gameObject.SetActive(true);
        }
    }
    void NewDialogue(string text)
    {
        GameObject template_clone = Instantiate(d_template, d_template.transform);
        template_clone.transform.parent = canva.transform;
        template_clone.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = text;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "PlayerObj")
        {
            playerDetection = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        playerDetection = false;
        canva.SetActive(false);
    }
}
