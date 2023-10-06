using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Script_TitleStart : MonoBehaviour
{
    string NextScene;

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.DeleteKey("NextScene");
        if (Input.anyKeyDown)
        {
            if (PlayerPrefs.GetString("NextScene") == "")
            {
                NextScene = "Scene_Stage1";
                PlayerPrefs.SetString("NextScene", NextScene);
                PlayerPrefs.Save();
            }

            SceneManager.LoadScene("Loading");
        }
    }
}
