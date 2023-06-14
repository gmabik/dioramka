using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon_trigger : MonoBehaviour
{
    [Header("Animations")]
    [SerializeField] private Animator playerAnim;
    [SerializeField] private string animBoolName;
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
            playerAnim.applyRootMotion = false;
            playerAnim.SetBool(animBoolName, true);
            playerAnim.gameObject.GetComponent<playerScript>().isAnimPlaying = true;
        } 
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag != "Player") return;
        interactText.SetActive(false);
    }
}