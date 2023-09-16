using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBridge : MonoBehaviour
{
    public GameObject BridgeBrick;
    void OnTriggerEnter(Collider collider)
    {
        // Destroy the bridge over canyon when triggered by player.
        if (collider.gameObject.tag == "Player")
        {

            GameObject[] bridge;
            bridge = GameObject.FindGameObjectsWithTag("Brick");

            foreach (GameObject brick in bridge)
            {
                Destroy(brick);
            }
            Destroy(this.gameObject);
        }
    }
}
