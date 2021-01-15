using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallScript : MonoBehaviour
{
    public float ballSpeed;
    public bool IsOnTheGround = true;
    public bool IsDiagonalSpeed = false;
    public bool IsOnGreen = false;

    private AudioSource source;
    private AudioSource sourcePitch;
    public AudioClip soundJump;
    public AudioClip GreenJump;
    public float lowPitch = 0.75f;
    public float highPitch = 1.25f;

    void Start()
    {
        source = GetComponent<AudioSource>();
        sourcePitch = GetComponent<AudioSource>();
    }

    // Special colors Collision
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Plateform")
        {
            IsOnTheGround = true;
        }

        if (collision.gameObject.tag == "green")
        {
            IsOnGreen = true;
        }


        if (collision.gameObject.tag == "red" && SceneManager.GetActiveScene().name == "Game")
        {
            SceneManager.LoadScene("Game");
        }

        if (collision.gameObject.tag == "red" && SceneManager.GetActiveScene().name == "Level1")
        {
            SceneManager.LoadScene("Level1");
        }

        if (collision.gameObject.tag == "red" && SceneManager.GetActiveScene().name == "Level2")
        {
            SceneManager.LoadScene("Level2");
        }

        if (collision.gameObject.tag == "red" && SceneManager.GetActiveScene().name == "Level3")
        {
            SceneManager.LoadScene("Level3");
        }

        //Load next levels

        if (collision.gameObject.tag == "yellow" && SceneManager.GetActiveScene().name == "Level1")
        {
            SceneManager.LoadScene("FinishLevel");
        }

        if (collision.gameObject.tag == "yellow" && SceneManager.GetActiveScene().name == "Level2")
        {
            SceneManager.LoadScene("FinishLvl2");
        }

        if (collision.gameObject.tag == "yellow" && SceneManager.GetActiveScene().name == "Level3")
        {
            SceneManager.LoadScene("FinishGame");
        }
    }

    //attach Player to moving Plateform
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "PurpleObject")
        {
            transform.parent = other.transform;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "PurpleObject")
        {
            transform.parent = null;
        }
    }

    //Deplacement
    void Update()
    {
        float xSpeed = Input.GetAxis("Horizontal");
        float zSpeed = Input.GetAxis("Vertical");
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(new Vector3(xSpeed,0,zSpeed) * ballSpeed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && IsOnTheGround)
        {
            rb.AddForce(new Vector3(0, 12, 0), ForceMode.Impulse);
            IsOnTheGround = false;
            source.PlayOneShot(soundJump, 1.0f);
        }


        if (IsOnGreen)
        {
            IsOnTheGround = false;
            rb.AddForce(new Vector3(0, 20, 0), ForceMode.Impulse);
            IsOnGreen = false;
            sourcePitch.PlayOneShot(soundJump, 1.0f);
            sourcePitch.pitch = Random.Range(lowPitch, highPitch);
        }

       
        // deplacement diagonal

        if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.RightArrow))
        {
            IsDiagonalSpeed = true;
            transform.Translate(Vector3.forward * Time.deltaTime * xSpeed);
            transform.Translate(Vector3.right * Time.deltaTime * zSpeed);
            ballSpeed = 100f;
        }

        else if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.LeftArrow))
        {
            IsDiagonalSpeed = true;
            transform.Translate(Vector3.forward * Time.deltaTime * xSpeed);
            transform.Translate(-Vector3.right * Time.deltaTime * zSpeed);
            ballSpeed = 100f;
        }

        else if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.RightArrow))
        {
            IsDiagonalSpeed = true;
            transform.Translate(-Vector3.forward * Time.deltaTime * xSpeed);
            transform.Translate(Vector3.right * Time.deltaTime * zSpeed);
            ballSpeed = 100f;
        }

        else if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.LeftArrow))
        {
            IsDiagonalSpeed = true;
            transform.Translate(-Vector3.forward * Time.deltaTime * xSpeed);
            transform.Translate(-Vector3.right * Time.deltaTime * zSpeed);
            ballSpeed = 100f;

        }

        else
        {
            IsDiagonalSpeed = false;
            ballSpeed = 300f;
        }
    }


}
