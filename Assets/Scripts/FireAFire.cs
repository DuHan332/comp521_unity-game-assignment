using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// Need namespace to get input message
namespace StarterAssets
{
    public class FireAFire : MonoBehaviour
    {
        public GameObject fireBall;
        private StarterAssetsInputs _input;
        //cooldown of firing a fire ball.
        public float fireRate = 0.5f;
        private float nextFire = 0.0f;
        public float force = 200;
        public float spawnDistance = 2;
        // Start is called before the first frame update
        void Start()
        {   
            //get input message from Input System
            _input = GetComponent<StarterAssetsInputs>();
        }

        // Update is called once per frame
        void Update()
        {
            if (_input.shoot && Time.time > nextFire && Camera.main.transform.position.z>=50 && (GameObject.Find("PalyerFireBall") == null))
            {
                nextFire = Time.time + fireRate;    
                Vector3 pos = Camera.main.transform.TransformPoint(Vector3.forward * spawnDistance);
                // Spawn fire ball in front of player(with some distance)
                GameObject fire = Instantiate(fireBall, pos, Camera.main.transform.rotation);
                fire.name = "PalyerFireBall";
                // Push the fire ball to make it move
                fire.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * force);
            }

        }
    }
}
