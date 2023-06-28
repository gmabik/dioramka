using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    [Header("Effects")]
    [SerializeField] private GameObject slashSpawnPos;
    [Header("Weapons")]
    [SerializeField] private GameObject katana;
    [SerializeField] private GameObject sheath;
    [SerializeField] private GameObject katana_scene;
    [SerializeField] private GameObject dagger;
    [SerializeField] private GameObject dagger_scene;
    [SerializeField] private GameObject wand;
    [SerializeField] private GameObject wand_scene;
    [SerializeField] private GameObject training_dummy;
    public bool isAnimPlaying;
    [Header("TripleDagger")]
    [SerializeField] private GameObject dagger2;
    [SerializeField] private GameObject dagger2_spawn;
    [SerializeField] private GameObject dagger3;
    [SerializeField] private GameObject dagger3_spawn;
    [SerializeField] private GameObject daggers_effect;
    [Header("KatanaSlashes")]
    [SerializeField] private GameObject slash1_spawn;
    [SerializeField] private GameObject slash1;
    [SerializeField] private GameObject slash2_spawn;
    [SerializeField] private GameObject slash2;
    [SerializeField] private GameObject slash3_spawn;
    [SerializeField] private GameObject slash3;
    [Header("Spells")]
    [SerializeField] private GameObject fireballVFX;
    public GameObject fireWall;
    [SerializeField] private GameObject waterballVFX;
    [SerializeField] private GameObject earthSpell;

    private void Start()
    {
        GetComponent<Animator>().applyRootMotion = true;
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

    public void AddSlashEffect(GameObject effect)
    {
        GameObject slash = Instantiate(effect, effect.transform.position + slashSpawnPos.transform.position, effect.transform.rotation);
        Destroy(slash, 1f);
    }

    public void UnActiveSceneDagger()
    {
        dagger_scene.SetActive(false);
    }

    public void DaggerChange()
    {
        dagger_scene.SetActive(true);
    }

    public void UnActiveSceneKatana()
    {
        katana_scene.SetActive(false);
    }
    public void UnActiveSceneWand()
    {
        wand_scene.SetActive(false);
    }

    public void TripleDagger()
    {
        GameObject dagger2GO = Instantiate(dagger2, dagger2_spawn.transform.position, dagger2_spawn.transform.rotation);
        GameObject dagger3GO = Instantiate(dagger3, dagger3_spawn.transform.position, dagger3_spawn.transform.rotation);
        GameObject daggersEffect = Instantiate(daggers_effect, dagger.transform.position, daggers_effect.transform.rotation);
    }

    public IEnumerator KatanaMultiSlash()
    {
        GameObject _slash1 = Instantiate(slash1, slash1.transform.position + slash1_spawn.transform.position, slash1.transform.rotation);
        Destroy(_slash1, 1.5f);
        yield return new WaitForSecondsRealtime(0.2f);
        GameObject _slash2 = Instantiate(slash2, slash2.transform.position + slash2_spawn.transform.position, slash2.transform.rotation);
        Destroy(_slash2, 1.3f);
        yield return new WaitForSecondsRealtime(0.2f);
        GameObject _slash3 = Instantiate(slash3, slash3.transform.position + slash3_spawn.transform.position, slash3.transform.rotation);
        Destroy(_slash3, 1.1f);
    }

    public void SpawnFireball()
    {
        GameObject _fireball = Instantiate(fireballVFX, fireballVFX.transform.position + transform.position, fireballVFX.transform.rotation);
        _fireball.GetComponent<fireball>().player = gameObject;
    }

    public void SpawnWaterball()
    {
        GameObject _waterball = Instantiate(waterballVFX, waterballVFX.transform.position + transform.position, waterballVFX.transform.rotation);
        _waterball.GetComponent<waterball>().fireWall = fireWall;
    }

    public void SpawnEarthSpell()
    {
        GameObject _earthspell = Instantiate(earthSpell, earthSpell.transform.position, earthSpell.transform.rotation);
        _earthspell.GetComponent<earthSpell>().training_dummy = training_dummy;
    }

    public void AnimEnd()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
