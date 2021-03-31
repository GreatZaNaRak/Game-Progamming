using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
   
    public KeyCode interactKey;
    public bool isInRange;
    public Material playerColor;
    public string interactionText = "Press F to interact";
    public GameObject Com_can;
    public Text com_text;

    void Start()
    {
        com_text.text = interactionText;
    }

    void Update()
    {
        if (isInRange) {
            Com_can.SetActive(true);
            if (Input.GetKeyDown(interactKey)) {
                if (playerColor.color == Color.black) {
                    com_text.text = "Nothing happend";
                } else {
                    com_text.text = "It's Work";
                }
            }
        } else {
            Com_can.SetActive(false);
            com_text.text = interactionText;
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player") {
            isInRange = true;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Player") {
            isInRange = false;
        }
    }

}
