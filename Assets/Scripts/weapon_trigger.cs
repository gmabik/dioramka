using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon_trigger : MonoBehaviour
{
    [Header("Animations")]
    [SerializeField] private Animator playerAnim;
    [SerializeField] private string animName;
    [Header("Text")]
    [SerializeField] private GameObject interactText;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player") return;
        interactText.SetActive(true);
    }
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetMouseButtonDown(0))
        {
            print("click");
        } 
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag != "Player") return;
        interactText.SetActive(false);
    }
}
