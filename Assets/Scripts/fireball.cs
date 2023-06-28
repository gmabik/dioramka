using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireball : MonoBehaviour
{
    public GameObject player;
    public GameObject explosionVFX;
    public GameObject onFireVFX;
    public void Explode()
    {
        GameObject explosion = Instantiate(explosionVFX, explosionVFX.transform.position + transform.position, explosionVFX.transform.rotation);
        GameObject onFire = Instantiate(onFireVFX, onFireVFX.transform.position + transform.position, onFireVFX.transform.rotation);
        player.GetComponent<playerScript>().fireWall = onFire;
        Destroy(gameObject);
    }
}
