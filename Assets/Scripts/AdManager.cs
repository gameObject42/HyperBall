using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using GoogleMobileAds.Api;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AdManager : MonoBehaviour
{
    public static AdManager Instance;

    private string appID = "ca-app-pub-3940256099942544~3347511713";//"ca-app-pub-5427174806272358~4537092066"; //"ca-app-pub-3940256099942544~3347511713"; Tesdid

    private BannerView bannerView;
    private string bannerID = ""; //"ca-app-pub-5427174806272358/1538629290"; //"ca-app-pub-3940256099942544/6300978111";

    private InterstitialAd fullScreenAd;
    private string fullScreenAdID = "ca-app-pub-3940256099942544/1033173712";//"ca-app-pub-5427174806272358/9772342530"; //"ca-app-pub-3940256099942544/1033173712";

    private RewardBasedVideoAd rewardedAd;
    private string VideoAdID = "ca-app-pub-3940256099942544/5224354917";

    public Button adBtn;

    private Tweening tween;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    private void Start()
    {
        MobileAds.Initialize(appID);
        RequestFullScreenAd();
        rewardedAd = RewardBasedVideoAd.Instance;
        tween = FindObjectOfType<Tweening>();

    }
    public void RequestRewardedAd()
    {
        AdRequest request = AdRequestBuild();
        rewardedAd.LoadAd(request, VideoAdID);

        rewardedAd.OnAdLoaded += this.HandleOnRewardedAdLoaded;
        rewardedAd.OnAdRewarded += this.HandleOnAdRewarded;
        rewardedAd.OnAdClosed += this.HandleOnRewardedAdClosed;
        Debug.Log("Request");
    }
    public void ShowRewardAd()
    {
        if (rewardedAd.IsLoaded())
        {
            rewardedAd.Show();
        }
        Debug.Log("Show");
    }
    public void HandleOnRewardedAdLoaded(object sender, EventArgs args)
    {
        ShowRewardAd();
    }

    public void HandleOnAdRewarded(object sender, EventArgs args)
    {
        int diamond = GameManager.Instance.diamondNum + 500;
        int diamondPlus = diamond;
        PlayerPrefs.SetInt("Diamond", diamondPlus);
        tween.RewadesAdPanelhide();
    }

    public void HandleOnRewardedAdClosed(object sender, EventArgs args)
    {
        adBtn.interactable = true;
        adBtn.GetComponentInChildren<TextMeshProUGUI>().text = "Watch";
        rewardedAd.OnAdLoaded -= this.HandleOnRewardedAdLoaded;
        rewardedAd.OnAdRewarded -= this.HandleOnAdRewarded;
        rewardedAd.OnAdClosed -= this.HandleOnRewardedAdClosed;
    }
    public void AdClicked()
    {
        adBtn.interactable = false;
        adBtn.GetComponentInChildren<TextMeshProUGUI>().text = "Loading..";
        RequestRewardedAd();

        Debug.Log("Clicked");
    }
    public void AdClickedShop()
    {
        RequestRewardedAd();

    }
    AdRequest AdRequestBuild()
    {
        return new AdRequest.Builder().Build();
    }
    public void RequestBanner() 
    {
        bannerView = new BannerView(bannerID, AdSize.Banner, AdPosition.Top);
        AdRequest request = new AdRequest.Builder().Build();
        bannerView.LoadAd(request);
        bannerView.Show();
    }
    public void HideBanner()
    {
        bannerView.Hide();
    }

    public void RequestFullScreenAd() 
    {
        fullScreenAd = new InterstitialAd(fullScreenAdID);
        AdRequest request = new AdRequest.Builder().Build();
        fullScreenAd.LoadAd(request);
    }
    public void ShowFullScreenAd() 
    {
        if (fullScreenAd.IsLoaded())
        {
            fullScreenAd.Show();
        }
        else 
        {
            Debug.Log("Ad not loaded");
        }
    }
}
