using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("GameObjects")]
    public AudioSource backMusic;
    //public GameObject pause;
    //public GameObject mainMenu;
    //public GameObject gameOverMenu;
    //public GameObject scoreText;
    //public GameObject Player;
    public GameObject Player;
    [Header("Int Values")]
    public int scoreCounter = 0;
    public int hightScoreNum = 0;
    [Header("UI Elements")]
    public TextMeshProUGUI score;
    public TextMeshProUGUI highScore;
    public Toggle soundBtn;
    [Header("Boolean")]
    public bool startGame = false;
    private bool bestbool = true;

    private Tweening tween;

    public static GameManager Instance { get; set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.Log("Warning: multiple " + this + " in scene!");
            Destroy(this);
        }
    }
    private void Start()
    {
        Instantiate(Player, new Vector3(0f,2.9f,13f),Quaternion.identity);
        if (PlayerPrefs.HasKey("Music"))
        {
            if (PlayerPrefs.GetInt("Music") == 0)
            {
                soundBtn.isOn = true;
            }
            else
            {
                soundBtn.isOn = false;
            }
        }
        else
        {
            PlayerPrefs.SetInt("Music", 1);
        }
        
        hightScoreNum = PlayerPrefs.GetInt("Score", scoreCounter);
        highScore.text = "Best Score : " + hightScoreNum.ToString();
        tween = FindObjectOfType<Tweening>();

        AdManager.Instance.RequestBanner();
        
    }
    private void Update()
    {
        score.text = scoreCounter.ToString();
        newBestScoreCheck();
        if (Input.GetKey(KeyCode.Escape))
        {
            QuitDropDrown();
            /*pause.SetActive(true);
            Time.timeScale = 1;*/
        }
    }
    public void setGametoTrue()
    {
        //Debug.Log("Hi");
        startGame = true;
        //mainMenu.SetActive(false);
        //scoreText.SetActive(true);
        tween.InitialPos();
        AdManager.Instance.HideBanner();
    }
    public void reStartGame()
    {
        AdManager.Instance.HideBanner();
        Invoke("reloadScene", 0.3f);
    }
    public void reloadScene()
    {
        startGame = true;
        SceneManager.LoadScene("GameScene");
    }
    public void ScoreCounter()
    {
        scoreCounter++;
    }
    public void Save() 
    {
        if (scoreCounter > hightScoreNum) {
            PlayerPrefs.SetInt("Score", scoreCounter);
        }
    }
    public void newBestScoreCheck()
    {
        if (scoreCounter > hightScoreNum && bestbool == true)
        {
            tween.InGameUITweening();
            bestbool = false;
        }
    }
    public void DontQuit()
    {
        tween.QuitAnimup();
    }
    public void QuitDropDrown()
    {
        tween.QuitAnimdown();
    }
    public void ShareUp()
    {
        tween.shareAnimup();
    }
    public void ShareDropDrown()
    {
        tween.shareAnimdown();
    }
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
    public void OnOff()
    {
        if (soundBtn.isOn == true)
        {
            backMusic.mute = !backMusic.mute;
            PlayerPrefs.SetInt("Music", 0);
        }
        else
        {
            backMusic.mute = !backMusic.mute;
            PlayerPrefs.SetInt("Music", 1);
        }
    }
    public void LoadCharScene()
    {
        SceneManager.LoadScene(1);
    }
    /*public void Pause()
    {
        Time.timeScale = 0.0f;
        pause.SetActive(false);
    }*/
}
