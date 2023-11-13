using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class AddmobBanner : Addmob
{

    private BannerView _bannerView;

    public void Start()
    {
        InitId("ca-app-pub-9769062654991032/1318594756");
        base.Start();

        CreateBannerView();
    }



    public void CreateBannerView()
    {
        Debug.Log("Creating banner view");

        AdSize adSize = new AdSize(320, 100);
            //AdSize.GetCurrentOrientationAnchoredAdaptiveBannerAdSizeWithWidth(AdSize.FullWidth);
        _bannerView = new BannerView(_adUnitId, adSize, AdPosition.BottomRight);

        LoadAd();
    }


    /// <summary>
    /// Creates the banner view and loads a banner ad.
    /// </summary>
    public void LoadAd()
    {
        // create an instance of a banner view first.
        if (_bannerView == null)
        {
            CreateBannerView();
        }

        // create our request used to load the ad.
        var adRequest = new AdRequest();

        // send the request to load the ad.
        Debug.Log("Loading banner ad.");
        _bannerView.LoadAd(adRequest);
    }
}
