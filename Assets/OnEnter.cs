using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEnter : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        GameManager.instance.GameOver();
    }
}
