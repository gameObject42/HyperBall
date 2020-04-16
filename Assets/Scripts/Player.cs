using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Player : MonoBehaviour
{
    public float Speed;
    public float acc;
    public float topSpeed;
    public float jumpForce;
    public float touchSpeed = 0.01f;
    private Rigidbody rigid;
    private Touch touchInput;

    public AudioSource hitaudio;
    public AudioClip hit;

    private Tweening tween;
    private ColorChanger ColorCha;

    private bool isDead = false;

    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
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
        transform.Translate(Vector3.forward * Speed * Time.fixedDeltaTime);
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
        if (Input.GetKey(KeyCode.Space))
        {
            rigid.AddForce(Vector3.up * jumpForce);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Obstacle")
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
        /*else if (other.gameObject.tag == "JumpPoint")
        {
            rigid.velocity += Vector3.up * jumpForce;
        }
        else if (other.gameObject.tag == "JumpDown")
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
