using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class BtnType : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public BTNType currentType;
    public Transform buttonScale;
    Vector3 defaultScale;
    public CanvasGroup pauseGroup;
    public static bool isAdShow = false;

    private void Start()
    {
        defaultScale = buttonScale.localScale;
    }

    public static bool isPause = false;

    public void IsAdShow()
    {
        isAdShow = !isAdShow;
    }

    // 일시 정지
    public static void IsPause()
    {
        isPause = !isPause;
        if (isPause)
        {
            Time.timeScale = 0f;
            BannerAdBottom.bannerview.Show();
            BannerAdTop.bannerview.Show();
        }
        else
        {
            Time.timeScale = 1f;
            BannerAdBottom.bannerview.Hide();
            BannerAdTop.bannerview.Hide();
        }
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
    }

    public void OnBtnClick()
    {
        switch (currentType)
        {
            case BTNType.Pause:
                CanvasGroupOn(pauseGroup);
                IsPause();
                Debug.Log("정지");
                break;
            case BTNType.AD:
                Debug.Log("광고");
                IsAdShow();
                break;
            case BTNType.Return:
                CanvasGroupOff(pauseGroup);
                IsPause();
                Debug.Log("재개");
                break;
            case BTNType.Title:
                SceneManager.LoadScene("Scene_Title");
                IsPause();
                Debug.Log("뒤로!");
                break;
            case BTNType.Exit:
                Application.Quit();
                Debug.Log("끝!");
                break;
            case BTNType.Restart:
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                CanvasGroupOff(pauseGroup);
                IsPause();
                break;
        }
    }
    public void CanvasGroupOn(CanvasGroup cg)
    {
        cg.alpha = 1;
        cg.interactable = true;
        cg.blocksRaycasts = true;
    }
    public void CanvasGroupOff(CanvasGroup cg)
    {
        cg.alpha = 0;
        cg.interactable = false;
        cg.blocksRaycasts = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonScale.localScale = defaultScale * 1.2f;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        buttonScale.localScale = defaultScale;
    }
}
