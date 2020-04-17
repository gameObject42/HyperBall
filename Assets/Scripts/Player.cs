using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Player : MonoBehaviour
{
    public float Speed;
    public float acc;
    public float topSpeed;
    public float jumpHeight;
    public float touchSpeed = 0.01f;
    public float gravity;


    //private Rigidbody rigid;
    private Touch touchInput;
    private float VelocityY;
    public AudioSource hitaudio;
    public AudioClip hit;

    private Tweening tween;
    private ColorChanger ColorCha;

    private bool isDead = false;

    private CharacterController controller;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        //rigid = GetComponent<Rigidbody>();
        tween = FindObjectOfType<Tweening>();
        ColorCha = FindObjectOfType<ColorChanger>();
    }
    private void Update()
    {
        if (transform.position.y < -2)
        {
            isDead = true;
            GameManager.Instance.startGame = false;
            tween.PauseAnim();
            GameManager.Instance.Save();
            hitaudio.PlayOneShot(hit);
            GameManager.Instance.Player.SetActive(false);
            AdManager.Instance.RequestBanner();
        }
    }
    private void FixedUpdate()
    {
        if (GameManager.Instance.startGame==true) {
            PlayerMovement();
        }
    }
    private void PlayerMovement()
    {
        VelocityY += Time.deltaTime * gravity;
        Vector3 velocity = transform.forward * Speed + Vector3.up * VelocityY;
        controller.Move(velocity * Time.deltaTime);
        //Debug.Log(controller.isGrounded);

        //transform.Translate(Vector3.forward * Speed * Time.fixedDeltaTime);
        if (controller.isGrounded)
        {
            VelocityY = 0;
        }
        if (Input.touchCount > 0)
        {
            touchInput = Input.GetTouch(0);
            if (touchInput.phase == TouchPhase.Moved)
            {
                transform.position = new Vector3(transform.position.x + touchInput.deltaPosition.x * touchSpeed,
                    transform.position.y, transform.position.z);
            }
        }
        if (Speed <= topSpeed)
        {
            Speed += Time.deltaTime + acc;
        }
        transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * 10 * Time.fixedDeltaTime);

        /*if (Input.GetKey(KeyCode.Space))
        {
            if (controller.isGrounded)
            {
                float jumpVelocity = Mathf.Sqrt(-2 * gravity * jumpHeight);
                VelocityY = jumpVelocity;
            }
        }*/
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Obstacles")
        {
            //GameManager.Instance.gameOverMenu.SetActive(true);
            GameManager.Instance.startGame = false;
            tween.PauseAnim();
            GameManager.Instance.Save();
            hitaudio.PlayOneShot(hit);
            GameManager.Instance.Player.SetActive(false);
            AdManager.Instance.ShowFullScreenAd();
            AdManager.Instance.RequestBanner();
        }
        else if(other.gameObject.tag == "Points")
        {
            GameManager.Instance.ScoreCounter();
        }
        else if (other.gameObject.tag == "Color1")
        {
            ColorCha.ChangeColor();
        }
        else if (other.gameObject.tag == "JumpPoint")
        {
            if (controller.isGrounded)
            {
                float jumpVelocity = Mathf.Sqrt(-2 * gravity * jumpHeight);
                VelocityY = jumpVelocity;
            }
        }
        /*else if (other.gameObject.tag == "JumpDown")
        {
            rigid.velocity += Vector3.down * jumpForce;
        }*/



        /*else
        {
            if (other.gameObject.tag == "Points")
            {
                GameManager.Instance.ScoreCounter();
            }
        }
        if (other.gameObject.tag == "Color1")
        {
            //GameManager.Instance.gameOverMenu.SetActive(true);
            ColorCha.ChangeColor();
        }*/

    }
}
