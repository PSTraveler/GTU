using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Security.Cryptography;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Script_StageSelect : MonoBehaviour
{
    string NextScene;
    public CanvasGroup StageSelect;
    public CanvasGroup ExitPage;
    public bool isExit;
    public void Quit()
    {
        /*#if UNITY_EDITOR
                Debug.Log("종료");
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                Applicaiton.Quit();
        #endif*/
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

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("start");
        isExit = false;
        if (PlayerPrefs.GetString("NextScene") == "")
        {
            NextScene = "Scene_Stage1";
            PlayerPrefs.SetString("NextScene", NextScene);
            PlayerPrefs.Save();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && isExit == false)
        {
            Debug.Log("first esc");
            CanvasGroupOn(ExitPage);
            isExit = true;
        }

        else if (Input.GetKeyDown(KeyCode.Escape) && isExit == true)
        {
            Debug.Log("Second esc");
            CanvasGroupOff(ExitPage);
            isExit = false;
        }

        else if (Input.GetKeyDown(KeyCode.Return) && isExit == true)
        {
            Quit();
            Application.Quit();
        }

        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Mouse0) && isExit == false)
        {
            SceneManager.LoadScene("Loading");
        }
    }
}
