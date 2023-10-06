using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelControl : MonoBehaviour
{
    public Button Stage_2btn, Stage_3btn, Stage_4btn, Stage_5btn, Stage_6btn;
    int stagePassed;
    // Start is called before the first frame update
    void Start()
    {
        stagePassed = PlayerPrefs.GetInt("StagePassed");
        Stage_2btn.interactable = false;
        Stage_3btn.interactable = false;
        Stage_4btn.interactable = false;
        Stage_5btn.interactable = false;
        Stage_6btn.interactable = false;
        
        switch(stagePassed) {
            case 1:
                Stage_2btn.interactable = true;
                break;
            case 2:
                Stage_2btn.interactable = true;
                Stage_3btn.interactable = true;
                break;
        }
    }

    public void StageToLoad(int stage) {
        SceneManager.LoadScene(stage);
    }
    
}
