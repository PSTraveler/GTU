using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    public Slider progressbar;
    public Text loadtext;
    string NextScene;
    public JoystickValue JValue;

    // 캔버스 그룹
    public CanvasGroup Scene_Stage1;
    public CanvasGroup Scene_Stage2;
    public CanvasGroup Scene_Stage3;
    public CanvasGroup Scene_Stage4;
    public CanvasGroup Scene_Stage5;
    public CanvasGroup Scene_Stage6;
    public CanvasGroup Scene_Stage7;
    public CanvasGroup Scene_Stage8;
    public CanvasGroup Scene_Stage9;
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

    private void Start()
    {
        StartCoroutine(LoadScene());
        NextScene = PlayerPrefs.GetString("NextScene");
        switch (NextScene)
        {
            case "Scene_Stage1":
                CanvasGroupOn(Scene_Stage1);
                CanvasGroupOff(Scene_Stage2);
                CanvasGroupOff(Scene_Stage3);
                CanvasGroupOff(Scene_Stage4);
                CanvasGroupOff(Scene_Stage5);
                CanvasGroupOff(Scene_Stage6);
                CanvasGroupOff(Scene_Stage7);
                CanvasGroupOff(Scene_Stage8);
                CanvasGroupOff(Scene_Stage9);
                break;
            case "Scene_Stage2":
                CanvasGroupOff(Scene_Stage1);
                CanvasGroupOn(Scene_Stage2);
                CanvasGroupOff(Scene_Stage3);
                CanvasGroupOff(Scene_Stage4);
                CanvasGroupOff(Scene_Stage5);
                CanvasGroupOff(Scene_Stage6);
                CanvasGroupOff(Scene_Stage7);
                CanvasGroupOff(Scene_Stage8);
                CanvasGroupOff(Scene_Stage9);
                break;
            case "Scene_Stage3":
                CanvasGroupOff(Scene_Stage1);
                CanvasGroupOff(Scene_Stage2);
                CanvasGroupOn(Scene_Stage3);
                CanvasGroupOff(Scene_Stage4);
                CanvasGroupOff(Scene_Stage5);
                CanvasGroupOff(Scene_Stage6);
                CanvasGroupOff(Scene_Stage7);
                CanvasGroupOff(Scene_Stage8);
                CanvasGroupOff(Scene_Stage9);
                break;
            case "Scene_Stage4":
                CanvasGroupOff(Scene_Stage1);
                CanvasGroupOff(Scene_Stage2);
                CanvasGroupOff(Scene_Stage3);
                CanvasGroupOn(Scene_Stage4);
                CanvasGroupOff(Scene_Stage5);
                CanvasGroupOff(Scene_Stage6);
                CanvasGroupOff(Scene_Stage7);
                CanvasGroupOff(Scene_Stage8);
                CanvasGroupOff(Scene_Stage9);
                break;
            case "Scene_Stage5":
                CanvasGroupOff(Scene_Stage1);
                CanvasGroupOff(Scene_Stage2);
                CanvasGroupOff(Scene_Stage3);
                CanvasGroupOff(Scene_Stage4);
                CanvasGroupOn(Scene_Stage5);
                CanvasGroupOff(Scene_Stage6);
                CanvasGroupOff(Scene_Stage7);
                CanvasGroupOff(Scene_Stage8);
                CanvasGroupOff(Scene_Stage9);
                break;
            case "Scene_Stage6":
                CanvasGroupOff(Scene_Stage1);
                CanvasGroupOff(Scene_Stage2);
                CanvasGroupOff(Scene_Stage3);
                CanvasGroupOff(Scene_Stage4);
                CanvasGroupOff(Scene_Stage5);
                CanvasGroupOn(Scene_Stage6);
                CanvasGroupOff(Scene_Stage7);
                CanvasGroupOff(Scene_Stage8);
                CanvasGroupOff(Scene_Stage9);
                break;
            case "Scene_Stage7":
                CanvasGroupOff(Scene_Stage1);
                CanvasGroupOff(Scene_Stage2);
                CanvasGroupOff(Scene_Stage3);
                CanvasGroupOff(Scene_Stage4);
                CanvasGroupOff(Scene_Stage5);
                CanvasGroupOff(Scene_Stage6);
                CanvasGroupOn(Scene_Stage7);
                CanvasGroupOff(Scene_Stage8);
                CanvasGroupOff(Scene_Stage9);
                break;
            case "Scene_Stage8":
                CanvasGroupOff(Scene_Stage1);
                CanvasGroupOff(Scene_Stage2);
                CanvasGroupOff(Scene_Stage3);
                CanvasGroupOff(Scene_Stage4);
                CanvasGroupOff(Scene_Stage5);
                CanvasGroupOff(Scene_Stage6);
                CanvasGroupOff(Scene_Stage7);
                CanvasGroupOn(Scene_Stage8);
                CanvasGroupOff(Scene_Stage9);
                break;
            case "Scene_Stage9":
                CanvasGroupOff(Scene_Stage1);
                CanvasGroupOff(Scene_Stage2);
                CanvasGroupOff(Scene_Stage3);
                CanvasGroupOff(Scene_Stage4);
                CanvasGroupOff(Scene_Stage5);
                CanvasGroupOff(Scene_Stage6);
                CanvasGroupOff(Scene_Stage7);
                CanvasGroupOff(Scene_Stage8);
                CanvasGroupOn(Scene_Stage9);
                break;
        }
    }

    IEnumerator LoadScene()
    {
        yield return null;
        AsyncOperation operation = SceneManager.LoadSceneAsync(NextScene);
        operation.allowSceneActivation = false;
        while (!operation.isDone)
        {
            yield return null;
            if (operation.progress < 0.9f)
            {
                progressbar.value = Mathf.MoveTowards(progressbar.value, 0.9f, Time.deltaTime);
            }
            else if (operation.progress >= 0.9f)
            {
                progressbar.value = Mathf.MoveTowards(progressbar.value, 1f, Time.deltaTime);
            }

            if (progressbar.value >= 1f)
            {
                loadtext.text = "Touch It!";
            }

            if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0)) && progressbar.value >= 1f && operation.progress >= 0.9f)
            {
                operation.allowSceneActivation = true;
                JValue.actionTouch = false;
            }
        }
    }
}
