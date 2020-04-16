using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class AdManager : MonoBehaviour
{
    public static AdManager Instance;

    private string appID = "ca-app-pub-5427174806272358~4537092066"; //"ca-app-pub-3940256099942544~3347511713"; Tesdid

    private BannerView bannerView;
    private string bannerID = "ca-app-pub-5427174806272358/1538629290"; //"ca-app-pub-3940256099942544/6300978111";

    private InterstitialAd fullScreenAd;
    private string fullScreenAdID = "ca-app-pub-5427174806272358/9772342530"; //"ca-app-pub-3940256099942544/1033173712";
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
