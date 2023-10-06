using UnityEngine;
using GoogleMobileAds.Api;

public class BannerAdTop : MonoBehaviour
{
    static bool isAdsBannerLoaded = false;
    public static BannerView bannerview;

    void Start()
    {
        RequestBanner();
        bannerview.Hide();
    }

    //광고 요청 Method
    private void RequestBanner()
    {
        //Test Banner ID : ca-app-pub-3940256099942544/6300978111
        //여러분들의 광고 ID가 들어갈 곳입니다.
        string BannerID = "ca-app-pub-3940256099942544/6300978111";
        bannerview = new BannerView(BannerID, AdSize.SmartBanner, AdPosition.Top);

        AdRequest request = new AdRequest.Builder().Build();
        bannerview.LoadAd(request);
        isAdsBannerLoaded = true;
    }
}
