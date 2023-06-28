using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterball : MonoBehaviour
{
    public GameObject fireWall;
    public GameObject smokeVFX;
    public void Explode()
    {
        Destroy(fireWall);
        GameObject _smoke = Instantiate(smokeVFX, smokeVFX.transform.position + transform.position, smokeVFX.transform.rotation);
        Destroy(gameObject);
    }
}
