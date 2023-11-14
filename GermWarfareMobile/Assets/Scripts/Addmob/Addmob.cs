using GoogleMobileAds.Api;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Addmob : MonoBehaviour
{
    // These ad units are configured to always serve test ads.
#if UNITY_ANDROID
    protected string _adUnitId = "ca-app-pub-3940256099942544/6300978111";          //temp
#elif UNITY_IPHONE
  protected string _adUnitId = "ca-app-pub-3940256099942544/2934735716";
#else
  protected string _adUnitId = "unused";
#endif

    protected void Start()
    {
        MobileAds.Initialize((InitializationStatus initStatus) =>
        {
            // This callback is called once the MobileAds SDK is initialized.
        });

    }

    protected void InitId(string custId)
    {

#if UNITY_ANDROID
        _adUnitId = custId;          
#elif UNITY_IPHONE
  _adUnitId = "ca-app-pub-3940256099942544/2934735716";
#else
  _adUnitId = "unused";
#endif
    }

}
