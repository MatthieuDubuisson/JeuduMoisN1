using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float zSpeed = 7f;
    public float xSpeed = 7f;
    public Rigidbody rb;
    public bool IsOnTheGround = true;
    public bool IsDiagonalSpeed = false;
    public bool IsObstacle = true;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Ground")
        {
            IsOnTheGround = true;
        }

        if (collision.gameObject.tag == "Plateform")
        {
            IsOnTheGround = true;
        }

        if (collision.gameObject.tag == "Obstacle")
        {
            IsObstacle = true;
        }
    }
    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // deplacement
        if (Input.GetKey(KeyCode.UpArrow) && IsDiagonalSpeed == false)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * xSpeed);
            zSpeed = 0f;
        }

        else if (Input.GetKey(KeyCode.DownArrow) && IsDiagonalSpeed == false)
        {
            transform.Translate(-Vector3.forward * Time.deltaTime * xSpeed);
            zSpeed = 0f;
        }

        else if (Input.GetKey(KeyCode.RightArrow) && IsDiagonalSpeed == false)
        {
            transform.Translate(Vector3.right * Time.deltaTime * zSpeed);
            xSpeed = 0f;
        }

        else if (Input.GetKey(KeyCode.LeftArrow) && IsDiagonalSpeed == false)
        {
            transform.Translate(-Vector3.right * Time.deltaTime * zSpeed);
            xSpeed = 0f;
        }


        // deplacement diagonal

        if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.RightArrow))
        {
            IsDiagonalSpeed = true;
            transform.Translate(Vector3.forward * Time.deltaTime * xSpeed);
            transform.Translate(Vector3.right * Time.deltaTime * zSpeed);
            zSpeed = 5f;
            xSpeed = 5f;
        }

        else if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.LeftArrow))
        {
            IsDiagonalSpeed = true;
            transform.Translate(Vector3.forward * Time.deltaTime * xSpeed);
            transform.Translate(-Vector3.right * Time.deltaTime * zSpeed);
            zSpeed = 5f;
            xSpeed = 5f;
        }

        else if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.RightArrow))
        {
            IsDiagonalSpeed = true;
            transform.Translate(-Vector3.forward * Time.deltaTime * xSpeed);
            transform.Translate(Vector3.right * Time.deltaTime * zSpeed);
            zSpeed = 5f;
            xSpeed = 5f;
        }

        else if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.LeftArrow))
        {
            IsDiagonalSpeed = true;
            transform.Translate(-Vector3.forward * Time.deltaTime * xSpeed);
            transform.Translate(-Vector3.right * Time.deltaTime * zSpeed);
            zSpeed = 5f;
            xSpeed = 5f;
        }

        else
        {
            IsDiagonalSpeed = false;
            zSpeed = 7f;
            xSpeed = 7f;
        }

        //Jump

        if (Input.GetButtonDown("Jump") && IsOnTheGround)
        {
            rb.AddForce(new Vector3(0, 12, 0), ForceMode.Impulse);
            IsOnTheGround = false;
        }

        //rolling animation
       // rb.AddTorque (new Vector3(xSpeed, zSpeed,0) * Time.deltaTime);
}
}
