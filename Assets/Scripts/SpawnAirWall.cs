using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAirWall : MonoBehaviour
{
    public Transform spawnPosition;
    public GameObject airWall;
    void OnTriggerEnter(Collider collider)
    {
        // Spawn a air wall to stop player going back to combat area when triggered
        if (collider.gameObject.tag == "Player")
        {
            GameObject gameObject = Instantiate(airWall, spawnPosition.position, spawnPosition.rotation);
            gameObject.name = "NoReturn2";
            // Destroy this trigger to avoid multiple spawning.
            Destroy(this.gameObject);
        }
    }
}
