using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class CharacterSelector : MonoBehaviour
{
    public GameObject SelectedPlayer;
    public GameObject AdPanel;
    public TextMeshProUGUI diamonds;
    private int diamondcount;
    public Material[] mat;
    public LeanTweenType easytype;

    private void Start()
    {
        CharLoadMat();
    }
    private void Update()
    {
        diamondcount = PlayerPrefs.GetInt("Diamond");
        diamonds.text = diamondcount.ToString();
    }
    public void AdPanelHide() 
    {
        LeanTween.moveY(AdPanel.GetComponent<RectTransform>(), 605f, 0.5f).setDelay(0.3f).setEase(easytype);
    }
    public void Char01()
    {
        if(diamondcount >= 100)
        {
            SelectedPlayer.GetComponent<Renderer>().material = mat[0];
            PlayerPrefs.SetInt("Char", 1);
            int subDiamond = PlayerPrefs.GetInt("Diamond");
            int sD = subDiamond - 100;
            PlayerPrefs.SetInt("Diamond", sD);
        }
        else
        {
            LeanTween.moveY(AdPanel.GetComponent<RectTransform>(), 0f, 0.5f).setDelay(0.3f).setEase(easytype);
        }
    }
    public void Char02()
    {
        if (diamondcount >= 250)
        {
            SelectedPlayer.GetComponent<Renderer>().material = mat[1];
            PlayerPrefs.SetInt("Char", 2);
            int subDiamond = PlayerPrefs.GetInt("Diamond");
            int sD = subDiamond - 250;
            PlayerPrefs.SetInt("Diamond", sD);
        }
        else
        {
            LeanTween.moveY(AdPanel.GetComponent<RectTransform>(), 0f, 0.5f).setDelay(0.3f).setEase(easytype);
        }
    }
    public void Char03()
    {
        if (diamondcount >= 350)
        {
            SelectedPlayer.GetComponent<Renderer>().material = mat[2];
            PlayerPrefs.SetInt("Char", 3);
            int subDiamond = PlayerPrefs.GetInt("Diamond");
            int sD = subDiamond - 350;
            PlayerPrefs.SetInt("Diamond", sD);
        }
        else
        {
            LeanTween.moveY(AdPanel.GetComponent<RectTransform>(), 0f, 0.5f).setDelay(0.3f).setEase(easytype);
        }
    }
    public void Char04()
    {
        if (diamondcount >= 450)
        {
            SelectedPlayer.GetComponent<Renderer>().material = mat[3];
            PlayerPrefs.SetInt("Char", 4);
            int subDiamond = PlayerPrefs.GetInt("Diamond");
            int sD = subDiamond - 450;
            PlayerPrefs.SetInt("Diamond", sD);
        }
        else
        {
            LeanTween.moveY(AdPanel.GetComponent<RectTransform>(), 0f, 0.5f).setDelay(0.3f).setEase(easytype);
        }
    }
    public void Char05()
    {
        if (diamondcount >= 600)
        {
            SelectedPlayer.GetComponent<Renderer>().material = mat[4];
            PlayerPrefs.SetInt("Char", 5);
            int subDiamond = PlayerPrefs.GetInt("Diamond");
            int sD = subDiamond - 600;
            PlayerPrefs.SetInt("Diamond", sD);
        }
        else
        {
            LeanTween.moveY(AdPanel.GetComponent<RectTransform>(), 0f, 0.5f).setDelay(0.3f).setEase(easytype);
        }
    }
    public void Char06()
    {
        if (diamondcount >= 1000)
        {
            SelectedPlayer.GetComponent<Renderer>().material = mat[5];
            PlayerPrefs.SetInt("Char", 6);
            int subDiamond = PlayerPrefs.GetInt("Diamond");
            int sD = subDiamond - 1000;
            PlayerPrefs.SetInt("Diamond", sD);
        }
        else
        {
            LeanTween.moveY(AdPanel.GetComponent<RectTransform>(), 0f, 0.5f).setDelay(0.3f).setEase(easytype);
        }
    }
    public void Char07()
    {
        if (diamondcount >= 1200)
        {
            SelectedPlayer.GetComponent<Renderer>().material = mat[6];
            PlayerPrefs.SetInt("Char", 7);
            int subDiamond = PlayerPrefs.GetInt("Diamond");
            int sD = subDiamond - 1200;
            PlayerPrefs.SetInt("Diamond", sD);
        }
        else
        {
            LeanTween.moveY(AdPanel.GetComponent<RectTransform>(), 0f, 0.5f).setDelay(0.3f).setEase(easytype);
        }
    }
    public void Char08()
    {
        if (diamondcount >= 1300)
        {
            SelectedPlayer.GetComponent<Renderer>().material = mat[7];
            PlayerPrefs.SetInt("Char", 8);
            int subDiamond = PlayerPrefs.GetInt("Diamond");
            int sD = subDiamond - 1300;
            PlayerPrefs.SetInt("Diamond", sD);
        }
        else
        {
            LeanTween.moveY(AdPanel.GetComponent<RectTransform>(), 0f, 0.5f).setDelay(0.3f).setEase(easytype);
        }
    }
    public void Char09()
    {
        if (diamondcount >= 1500)
        {
            SelectedPlayer.GetComponent<Renderer>().material = mat[8];
            PlayerPrefs.SetInt("Char", 9);
            int subDiamond = PlayerPrefs.GetInt("Diamond");
            int sD = subDiamond - 1500;
            PlayerPrefs.SetInt("Diamond", sD);
        }
        else
        {
            LeanTween.moveY(AdPanel.GetComponent<RectTransform>(), 0f, 0.5f).setDelay(0.3f).setEase(easytype);
        }
    }
    public void Char10()
    {
        if (diamondcount >= 1800)
        {
            SelectedPlayer.GetComponent<Renderer>().material = mat[9];
            PlayerPrefs.SetInt("Char", 10);
            int subDiamond = PlayerPrefs.GetInt("Diamond");
            int sD = subDiamond - 1800;
            PlayerPrefs.SetInt("Diamond", sD);
        }
        else
        {
            LeanTween.moveY(AdPanel.GetComponent<RectTransform>(), 0f, 0.5f).setDelay(0.3f).setEase(easytype);
        }
    }
    public void Char11()
    {
        if (diamondcount >= 2000)
        {
            SelectedPlayer.GetComponent<Renderer>().material = mat[10];
            PlayerPrefs.SetInt("Char", 11);
            int subDiamond = PlayerPrefs.GetInt("Diamond");
            int sD = subDiamond - 2000;
            PlayerPrefs.SetInt("Diamond", sD);
        }
        else
        {
            LeanTween.moveY(AdPanel.GetComponent<RectTransform>(), 0f, 0.5f).setDelay(0.3f).setEase(easytype);
        }
    }
    public void Char12()
    {
        if (diamondcount >= 2300)
        {
            SelectedPlayer.GetComponent<Renderer>().material = mat[11];
            PlayerPrefs.SetInt("Char", 12);
            int subDiamond = PlayerPrefs.GetInt("Diamond");
            int sD = subDiamond - 2300;
            PlayerPrefs.SetInt("Diamond", sD);
        }
        else
        {
            LeanTween.moveY(AdPanel.GetComponent<RectTransform>(), 0f, 0.5f).setDelay(0.3f).setEase(easytype);
        }
    }
    public void Char13()
    {
        if (diamondcount >= 2600)
        {
            SelectedPlayer.GetComponent<Renderer>().material = mat[12];
            PlayerPrefs.SetInt("Char", 13);
            int subDiamond = PlayerPrefs.GetInt("Diamond");
            int sD = subDiamond - 2600;
            PlayerPrefs.SetInt("Diamond", sD);
        }
        else
        {
            LeanTween.moveY(AdPanel.GetComponent<RectTransform>(), 0f, 0.5f).setDelay(0.3f).setEase(easytype);
        }
    }
    public void Char14()
    {
        if (diamondcount >= 3000)
        {
            SelectedPlayer.GetComponent<Renderer>().material = mat[13];
            PlayerPrefs.SetInt("Char", 14);
            int subDiamond = PlayerPrefs.GetInt("Diamond");
            int sD = subDiamond - 3000;
            PlayerPrefs.SetInt("Diamond", sD);
        }
        else
        {
            LeanTween.moveY(AdPanel.GetComponent<RectTransform>(), 0f, 0.5f).setDelay(0.3f).setEase(easytype);
        }
    }
    public void Char15()
    {
        if (diamondcount >= 3500)
        {
            SelectedPlayer.GetComponent<Renderer>().material = mat[14];
            PlayerPrefs.SetInt("Char", 15);
            int subDiamond = PlayerPrefs.GetInt("Diamond");
            int sD = subDiamond - 3500;
            PlayerPrefs.SetInt("Diamond", sD);
        }
        else
        {
            LeanTween.moveY(AdPanel.GetComponent<RectTransform>(), 0f, 0.5f).setDelay(0.3f).setEase(easytype);
        }
    }
    public void LoadGameScene() 
    {
        SceneManager.LoadScene(0);
    }
    public void GetDiamonds() 
    {
        AdManager.Instance.AdClickedShop();
    }
    public void CharLoadMat()
    {
        switch (PlayerPrefs.GetInt("Char"))
        {
            case 1:
                SelectedPlayer.GetComponent<Renderer>().material = mat[0];
                break;
            case 2:
                SelectedPlayer.GetComponent<Renderer>().material = mat[1];
                break;
            case 3:
                SelectedPlayer.GetComponent<Renderer>().material = mat[2];
                break;
            case 4:
                SelectedPlayer.GetComponent<Renderer>().material = mat[3];
                break;
            case 5:
                SelectedPlayer.GetComponent<Renderer>().material = mat[4];
                break;
            case 6:
                SelectedPlayer.GetComponent<Renderer>().material = mat[5];
                break;
            case 7:
                SelectedPlayer.GetComponent<Renderer>().material = mat[6];
                break;
            case 8:
                SelectedPlayer.GetComponent<Renderer>().material = mat[7];
                break;
            case 9:
                SelectedPlayer.GetComponent<Renderer>().material = mat[8];
                break;
            case 10:
                SelectedPlayer.GetComponent<Renderer>().material = mat[9];
                break;
            case 11:
                SelectedPlayer.GetComponent<Renderer>().material = mat[10];
                break;
            case 12:
                SelectedPlayer.GetComponent<Renderer>().material = mat[11];
                break;
            case 13:
                SelectedPlayer.GetComponent<Renderer>().material = mat[12];
                break;
            case 14:
                SelectedPlayer.GetComponent<Renderer>().material = mat[13];
                break;
            default:
                SelectedPlayer.GetComponent<Renderer>().material = mat[0];
                break;
        }
    }
}
