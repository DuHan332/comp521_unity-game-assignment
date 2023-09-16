using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateWall : MonoBehaviour
{
    public Transform spawnPosition;
    public GameObject wall;
    void OnTriggerEnter(Collider collider)
    {
        // Spawn a wall to stop player going back to starter area when triggered
        if (collider.gameObject.tag == "Player")
        {
            GameObject noReturn = Instantiate(wall, spawnPosition.position, spawnPosition.rotation);
            noReturn.name = "NoReturn";
            Destroy(this.gameObject);
        }
    }
}
