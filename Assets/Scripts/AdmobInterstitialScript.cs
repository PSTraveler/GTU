using System.Collections;
using System;
using UnityEngine;
using GoogleMobileAds.Api;

public class AdmobInterstitialScript : MonoBehaviour
{
    //전면 광고 Test ID : ca-app-pub-3940256099942544/1033173712
    //전면 광고 ID가 들어가는 곳입니다.
    private readonly string InterstitialID = "ca-app-pub-3940256099942544/1033173712";

    private InterstitialAd _interAd;
    public static bool _showAd = false;

    // Start is called before the first frame update
    void Start()
    {
        _interAd = new InterstitialAd(InterstitialID);

        _interAd.OnAdLoaded += oal;
        _interAd.OnAdFailedToLoad += oaftl;
        _interAd.OnAdOpening += oao;
        _interAd.OnAdClosed += oac;
        _interAd.OnAdLeavingApplication += oala;
        
        load();
    }

    void Update() {
        if(BtnType.isAdShow){
            show();
            BtnType.isAdShow = false;
        }
    }

    //구글에서 광고를 불러와 저장해놓습니다.
    private void load()
    {
        AdRequest _request = new AdRequest.Builder().Build();
        _interAd.LoadAd(_request);
    }

    //광고를 보여주고 싶은 상황에서 이 메서드를 호출하여 사용하시면 됩니다.
    public void show()
    {
        StartCoroutine("showInterAd");
    }

    private IEnumerator showInterAd()
    {
        while (!_interAd.IsLoaded())
        {
            yield return null;
        }
        _interAd.Show();
    }


    //광고 로드 완료 시
    public void oal(object sender, EventArgs args)
    {

    }
    //광고 로드 실패 시
    public void oaftl(object sender, AdFailedToLoadEventArgs args)
    {

    }
    //광고 재생 시작 시
    public void oao(object sender, EventArgs args)
    {

    }
    //광고 재생 종료 시
    public void oac(object sender, EventArgs args)
    {
        //보여준 광고를 제거하고 새로운 광고 가져오기
        _interAd.Destroy();
        load();
    }
    //재생 중 광고 클릭으로 화면 전환 시
    public void oala(object sender, EventArgs args)
    {

    }
}
