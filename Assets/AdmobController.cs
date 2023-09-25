using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using UnityEngine.Advertisements;
using System;

public class AdmobController : MonoBehaviour
{
    private InterstitialAd intersitional;
    private BannerView banner;

#if UNITY_IOS
    private string appId="ca-app-pub-4962234576866611~5559847235";
    private string intersitionalId="ca-app-pub-4962234576866611/6456096125";
    private string bannerId="ca-app-pub-4962234576866611/6703508133";

    private string unityAds = "4919166";
#else
    private string appId="ca-app-pub-4962234576866611~8569352363";
    private string intersitionalId="ca-app-pub-4962234576866611/3961120998";
    private string bannerId="ca-app-pub-4962234576866611/5943189028";

    private string unityAds = "4919167";
#endif



    public static int adsCnt = 1;

    
    void Start(){

        Advertisement.Initialize(unityAds,false);

        RequestConfiguration requestConfiguration =
            new RequestConfiguration.Builder()
            .SetSameAppKeyEnabled(true).build();
        MobileAds.SetRequestConfiguration(requestConfiguration);

        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(initStatus => { });

        RequestConfigurationAd();

        if(Application.loadedLevel>0)RequestBannerAd();
    }

    AdRequest AdRequestBuild(){
        return new AdRequest.Builder().Build();
    }


    void RequestConfigurationAd(){
        intersitional=new InterstitialAd(intersitionalId);
        AdRequest request=AdRequestBuild();
        intersitional.LoadAd(request);

        intersitional.OnAdLoaded+=this.HandleOnAdLoaded;
        intersitional.OnAdOpening+=this.HandleOnAdOpening;
        intersitional.OnAdClosed+=this.HandleOnAdClosed;

    }


    public bool showIntersitionalAd(bool showUnityAds=false){
        adsCnt++;
        if(adsCnt % 2 == 0){
            return false;
        }

        if(intersitional.IsLoaded() && !showUnityAds){
            intersitional.Show();
            return true;
        } else {
            //if (Advertisement.IsReady()) {
                Advertisement.Show("Android_Interstitial");
            //}
        }

        return false;
    }

    private void OnDestroy(){
        DestroyIntersitional();

        intersitional.OnAdLoaded-=this.HandleOnAdLoaded;
        intersitional.OnAdOpening-=this.HandleOnAdOpening;
        intersitional.OnAdClosed-=this.HandleOnAdClosed;

    }

    private void HandleOnAdClosed(object sender, EventArgs e)
    {
        intersitional.OnAdLoaded-=this.HandleOnAdLoaded;
        intersitional.OnAdOpening-=this.HandleOnAdOpening;
        intersitional.OnAdClosed-=this.HandleOnAdClosed;

        RequestConfigurationAd();

        
    }

    private void HandleOnAdOpening(object sender, EventArgs e)
    {
        
    }

    private void HandleOnAdLoaded(object sender, EventArgs e)
    {
        
    }

    public void DestroyIntersitional(){
        intersitional.Destroy();
    }




    //baner

    public void RequestBannerAd(){
        banner=new BannerView(bannerId,AdSize.Banner,AdPosition.TopLeft);
        AdRequest request = AdRequestBannerBuild();
        banner.LoadAd(request);
    }

    public void DestroyBanner(){
        if(banner!=null){
            banner.Destroy();
        }
    }



    AdRequest AdRequestBannerBuild(){
        return new AdRequest.Builder().Build();
    }
    
}
