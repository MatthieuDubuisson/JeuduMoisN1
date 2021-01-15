using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionControl : MonoBehaviour
{
    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Obstacle")
        {
            Debug.Log("yes");
            GameObject Player = GameObject.Find("Player");
            PlayerScript playerScript = Player.GetComponent<PlayerScript>();
            playerScript.xSpeed = 0;
            //text.enabled = false;

        }
    }

    void OnCollisionExit(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Obstacle")
        {
            Debug.Log("no");
            GameObject Player = GameObject.Find("Player");
            PlayerScript playerScript = Player.GetComponent<PlayerScript>();
            playerScript.xSpeed = 7;
            //text.enabled = false;

        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
