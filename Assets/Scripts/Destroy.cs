using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    // public float lifetime = 5f;
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        // Destroy fireball on collision(meet obstacle)
        Destroy(this.gameObject);
    }
    void Start()
    {   // The fire ball would be destroyed only if it reach obstacle, which maybe too long, uncommon this line to make it have a life time
        // Destroy(this.gameObject, lifetime);

        // Avoid destroying fire ball when it encounter specific air wall(air between battle area and canyon)
        if (GameObject.FindGameObjectWithTag("AirWall") != null)
        {
            GameObject airWall = GameObject.FindGameObjectWithTag("AirWall");
            Physics.IgnoreCollision(airWall.GetComponent<Collider>(), GetComponent<Collider>());
        }
    }

    // Update is called once per frame
}
