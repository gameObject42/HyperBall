using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class CharacterSelector : MonoBehaviour
{
    public TextMeshProUGUI diamonds;
    private int diamondcount;

    private void Start()
    {
        diamondcount = PlayerPrefs.GetInt("Diamond");
        diamonds.text = diamondcount.ToString();
    }
    public void Char01()
    {

        PlayerPrefs.SetInt("Char", 1);
    }
    public void Char02()
    {

        PlayerPrefs.SetInt("Char", 2);
    }
    public void Char03()
    {

        PlayerPrefs.SetInt("Char", 3);

    }
    public void LoadGameScene() 
    {
        SceneManager.LoadScene(0);
    }
}
