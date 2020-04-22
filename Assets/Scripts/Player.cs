using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Player : MonoBehaviour
{
    private float Speed = 30.0f;
    private float acc;
    private float topSpeed = 40.0f;
    private float jumpHeight = 3.2f;
    public float touchSpeed = 0.01f;
    private float gravity = -200;

    private Touch touchInput;
    private float VelocityY;
    public AudioSource hitaudio;
    public AudioClip hit;

    private Tweening tween;
    private ColorChanger ColorCha;

    private bool isDead = false;
    private bool deadOnce = false;

    private CharacterController controller;

    private Vector3 target = new Vector3(0.0f, 0.0f, 0.0f);
    private void Start()
    {
        controller = GetComponent<CharacterController>();
        tween = FindObjectOfType<Tweening>();
        ColorCha = FindObjectOfType<ColorChanger>();
    }
    private void Update()
    {
        if (transform.position.y < -2 && deadOnce == false)
        {
            isDead = true;
            GameManager.Instance.startGame = false;
            tween.PauseAnim();
            GameManager.Instance.Save();
            GameManager.Instance.DeadTracker();
            deadOnce = true;
            ShowRewardedAd();
            hitaudio.PlayOneShot(hit);
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
        Vector3 velocity = (transform.forward * Speed + Vector3.up * VelocityY);
        controller.Move(velocity * Time.deltaTime);
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
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            GameManager.Instance.startGame = false;
            tween.PauseAnim();
            GameManager.Instance.Save();
            isDead = true;
            ShowRewardedAd();
            GameManager.Instance.DeadTracker();
            hitaudio.PlayOneShot(hit);
        }
        else if(other.gameObject.tag == "Points")
        {
            GameManager.Instance.ScoreCounter();
        }
        else if (other.gameObject.tag == "Color1")
        {
            ColorCha.ChangeColor();
            GameManager.Instance.DiamondCounter();
        }
        else if (other.gameObject.tag == "JumpPoint")
        {
            if (controller.isGrounded)
            {
                float jumpVelocity = Mathf.Sqrt(-2 * gravity * jumpHeight);
                VelocityY = jumpVelocity;
            }
        }
    }
    public void ShowRewardedAd()
    {
        if (isDead == true && GameManager.Instance.scoreCounter >= GameManager.Instance.hightScoreNum && Application.internetReachability != NetworkReachability.NotReachable)
        {
            tween.RewadesAdPanelShow();
            Debug.Log("Reached");
        }
    }
}
