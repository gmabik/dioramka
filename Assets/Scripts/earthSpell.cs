using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class earthSpell : MonoBehaviour
{
    public GameObject training_dummy;
    public void MakeDummyFlyAway()
    {
        training_dummy.GetComponent<Animator>().SetBool("hasToFlyAway", true);
    }
}
