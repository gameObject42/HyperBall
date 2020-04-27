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
    public AudioSource hitaudio;
    public AudioClip hit;
    public GameObject SettingPanel;
    public GameObject[] Player;
    public GameObject pauseBtn;
    

    [Header("Int Values")]
    public int scoreCounter = 0;
    public int hightScoreNum = 0;
    public int diamondNum = 0;
    public int deadtracker = 0;

    [Header("UI Elements")]
    public TextMeshProUGUI score;
    public TextMeshProUGUI highScore;
    public TextMeshProUGUI diamond;
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
        if (PlayerPrefs.HasKey("Char"))
        {
            CharLoader();
        }
        else
        {
            Instantiate(Player[0], new Vector3(0f, 2.9f, 13f), Quaternion.identity);
            PlayerPrefs.SetInt("Char", 0);
        }
        
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

        diamondNum = PlayerPrefs.GetInt("Diamond", diamondNum);
        diamond.text = diamondNum.ToString();

        tween = FindObjectOfType<Tweening>();
    }
    private void Update()
    {
        score.text = scoreCounter.ToString();
        diamond.text = diamondNum.ToString();
        newBestScoreCheck();
        if (Input.GetKey(KeyCode.Escape))
        {
            QuitDropDrown();
        }
        
    }
    public void setGametoTrue()
    {
        startGame = true;
        tween.InitialPos();
    }
    public void reStartGame()
    {
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
    public void DiamondCounter() {
        diamondNum += 5;
        PlayerPrefs.SetInt("Diamond", diamondNum);
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
    public void CharLoader()
    {
        switch (PlayerPrefs.GetInt("Char"))
        {
            case 1:
                Instantiate(Player[1], new Vector3(0f, 2.9f, 13f), Quaternion.identity);
                break;
            case 2:
                Instantiate(Player[2], new Vector3(0f, 2.9f, 13f), Quaternion.identity);
                break;
            case 3:
                Instantiate(Player[3], new Vector3(0f, 2.9f, 13f), Quaternion.identity);
                break;
            case 4:
                Instantiate(Player[4], new Vector3(0f, 2.9f, 13f), Quaternion.identity);
                break;
            case 5:
                Instantiate(Player[5], new Vector3(0f, 2.9f, 13f), Quaternion.identity);
                break;
            case 6:
                Instantiate(Player[6], new Vector3(0f, 2.9f, 13f), Quaternion.identity);
                break;
            case 7:
                Instantiate(Player[7], new Vector3(0f, 2.9f, 13f), Quaternion.identity);
                break;
            case 8:
                Instantiate(Player[8], new Vector3(0f, 2.9f, 13f), Quaternion.identity);
                break;
            case 9:
                Instantiate(Player[9], new Vector3(0f, 2.9f, 13f), Quaternion.identity);
                break;
            case 10:
                Instantiate(Player[10], new Vector3(0f, 2.9f, 13f), Quaternion.identity);
                break;
            case 11:
                Instantiate(Player[11], new Vector3(0f, 2.9f, 13f), Quaternion.identity);
                break;
            case 12:
                Instantiate(Player[12], new Vector3(0f, 2.9f, 13f), Quaternion.identity);
                break;
            case 13:
                Instantiate(Player[13], new Vector3(0f, 2.9f, 13f), Quaternion.identity);
                break;
            case 15:
                Instantiate(Player[14], new Vector3(0f, 2.9f, 13f), Quaternion.identity);
                break;
            default:
                Instantiate(Player[0], new Vector3(0f, 2.9f, 13f), Quaternion.identity);
                break;
        }
    }
    public void Setting() 
    {
        SettingPanel.SetActive(true);
        AdManager.Instance.ShowFullScreenAd();
    }
    public void SettingToMenu()
    {
        SettingPanel.SetActive(false);
    }
    public void DeadTracker() 
    {
        if (PlayerPrefs.GetInt("deadTracker") >= 2)
        {
            PlayerPrefs.SetInt("deadTracker", 0);
            AdManager.Instance.ShowFullScreenAd();
        }
        else
        {
            deadtracker = PlayerPrefs.GetInt("deadTracker") + 1;
            PlayerPrefs.SetInt("deadTracker", deadtracker);
        }
    }
    public void DeadAudio()
    {
        hitaudio.PlayOneShot(hit);
    }
}
