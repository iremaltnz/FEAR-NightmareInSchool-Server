using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform teleportTarget;
    public GameObject player;


    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Triggerİçi");
            player.transform.position = teleportTarget.transform.position;

        }

    }
}
