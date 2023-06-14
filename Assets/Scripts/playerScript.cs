using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class playerScript : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float speed = 25.0F;
    [SerializeField] private float jumpSpeed = 8.0F;
    [SerializeField] private float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;
    private float turner;
    private float looker;
    [SerializeField] private float sensitivity = 5;
    [SerializeField] private Camera mainCam;
    private CharacterController controller;
    [Header("Weapons")]
    [SerializeField] private GameObject katana;
    [SerializeField] private GameObject dagger;
    [SerializeField] private GameObject dagger_scene;
    [SerializeField] private GameObject wand;
    public bool isAnimPlaying;
    [Header("TripleDagger")]
    [SerializeField] private GameObject dagger2;
    [SerializeField] private GameObject dagger2_spawn;
    [SerializeField] private GameObject dagger3;
    [SerializeField] private GameObject dagger3_spawn;
    [SerializeField] private GameObject daggers_effect;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (isAnimPlaying) return;
        moveDirection = new Vector3(-Input.GetAxis("Horizontal"), 0, -Input.GetAxis("Vertical"));
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= speed;

        if (controller.isGrounded && Input.GetButton("Jump")) moveDirection.y = jumpSpeed;

        turner = Input.GetAxis("Mouse X") * sensitivity;
        looker = -Input.GetAxis("Mouse Y") * sensitivity;

        if (turner != 0)
        {
            transform.eulerAngles += new Vector3(0, turner, 0);
        }
        if (looker != 0)
        {
            mainCam.transform.eulerAngles += new Vector3(looker, 0, 0);
        }

        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }

    public void UnActiveSceneDagger()
    {
        dagger_scene.SetActive(false);
    }

    public void DaggerChange()
    {
        dagger_scene.SetActive(true);
    }

    public void TripleDagger()
    {
        GameObject dagger2GO = Instantiate(dagger2, dagger2_spawn.transform.position, dagger2_spawn.transform.rotation);
        GameObject dagger3GO = Instantiate(dagger3, dagger3_spawn.transform.position, dagger3_spawn.transform.rotation);
        GameObject daggersEffect = Instantiate(daggers_effect, dagger.transform.position, daggers_effect.transform.rotation);
    }
}
