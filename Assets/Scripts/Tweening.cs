using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tweening : MonoBehaviour
{
    [Header("Main Menu UI")]
    public LeanTweenType easytype;
    [SerializeField] private GameObject PlayBtn;
    [SerializeField] private GameObject SettingBtn;
    [SerializeField] private GameObject ShareBtn;
    [SerializeField] private GameObject title;
    [SerializeField] private GameObject bestScore;
    [Header("Game Over UI")]
    [SerializeField] private GameObject RestartBtn;
    [SerializeField] private GameObject RewardedAdPanel;
    /*[SerializeField] private GameObject GsettingBtn;
    [SerializeField] private GameObject GshareBtn;
    [SerializeField] private GameObject Gtitle;*/
    [Header("InGameUI")]
    [SerializeField] private GameObject NewBest;
    [SerializeField] private GameObject currentScore;
    [SerializeField] private GameObject QuitBtn;
    [SerializeField] private GameObject Sharebtn;
    // Start is called before the first frame update
    void Start()
    {
        LeanTween.moveY(PlayBtn.GetComponent<RectTransform>(), 102f, 0.3f).setDelay(0.3f).setEase(easytype);
        LeanTween.moveY(SettingBtn.GetComponent<RectTransform>(), 120f, 0.5f).setDelay(0.3f).setEase(easytype);
        LeanTween.moveY(ShareBtn.GetComponent<RectTransform>(), 120f, 0.5f).setDelay(0.3f).setEase(easytype);
        LeanTween.moveY(title.GetComponent<RectTransform>(), -145f, 0.5f).setDelay(0.3f).setEase(easytype);
        LeanTween.moveY(bestScore.GetComponent<RectTransform>(), -210f, 0.5f).setDelay(0.3f).setEase(easytype);
    }
    private void Update()
    {
        
    }
    public void PauseAnim() 
    {
        LeanTween.moveY(RestartBtn.GetComponent<RectTransform>(), 102f, 0.3f).setEase(easytype);
        LeanTween.moveY(SettingBtn.GetComponent<RectTransform>(), 120f, 0.5f).setDelay(0.3f).setEase(easytype);
        LeanTween.moveY(ShareBtn.GetComponent<RectTransform>(), 120f, 0.5f).setDelay(0.3f).setEase(easytype);
        LeanTween.moveY(title.GetComponent<RectTransform>(), -145f, 0.5f).setDelay(0.3f).setEase(easytype);
        LeanTween.moveY(bestScore.GetComponent<RectTransform>(), -210f, 0.5f).setDelay(0.3f).setEase(easytype);
    }
    public void InGameUITweening()
    {
        LeanTween.moveY(NewBest.GetComponent<RectTransform>(), -150f, 0.3f).setEase(easytype);
        LeanTween.moveY(NewBest.GetComponent<RectTransform>(), 245f, 0.6f).setDelay(1.5f).setEase(easytype);

    }
    public void InitialPos()
    {
        LeanTween.moveY(PlayBtn.GetComponent<RectTransform>(), -200f, 0.3f).setDelay(0.3f).setEase(easytype);
        LeanTween.moveY(SettingBtn.GetComponent<RectTransform>(), -200f, 0.5f).setDelay(0.3f).setEase(easytype);
        LeanTween.moveY(ShareBtn.GetComponent<RectTransform>(), -200f, 0.5f).setDelay(0.3f).setEase(easytype);
        LeanTween.moveY(title.GetComponent<RectTransform>(), 200f, 0.5f).setDelay(0.3f).setEase(easytype);
        LeanTween.moveY(bestScore.GetComponent<RectTransform>(), 145f, 0.5f).setDelay(0.3f).setEase(easytype);
        LeanTween.moveY(currentScore.GetComponent<RectTransform>(), -50f, 0.5f).setDelay(0.3f).setEase(easytype);
    }
    public void QuitAnimdown() 
    {
        LeanTween.moveY(QuitBtn.GetComponent<RectTransform>(), 0f, 0.3f).setEase(easytype);
    }
    public void QuitAnimup()
    {
        LeanTween.moveY(QuitBtn.GetComponent<RectTransform>(), 850f, 0.3f).setEase(easytype);
    }
    public void shareAnimdown()
    {
        LeanTween.moveY(Sharebtn.GetComponent<RectTransform>(), -935f, 0.3f).setEase(easytype);
    }
    public void shareAnimup()
    {
        LeanTween.moveY(Sharebtn.GetComponent<RectTransform>(), 0f, 0.3f).setEase(easytype);
    }
    public void RewadesAdPanelShow()
    {
        LeanTween.moveX(RewardedAdPanel.GetComponent<RectTransform>(), 0f, 0.3f).setDelay(0.3f).setEase(easytype);
    }
    public void RewadesAdPanelhide()
    {
        LeanTween.moveX(RewardedAdPanel.GetComponent<RectTransform>(), -560f, 0.3f).setDelay(0.3f).setEase(easytype);
    }
}
