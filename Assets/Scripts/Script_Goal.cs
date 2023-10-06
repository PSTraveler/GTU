using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Script_Goal : MonoBehaviour
{
    public string NextScene;

    Animator animator;

    // 조이스틱
    public JoystickValue value;

    private void Start() {
        animator = GetComponent<Animator>();
        PlayerPrefs.SetString("NextScene", NextScene);
        PlayerPrefs.Save();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        animator.SetBool("gate", true);
    }
    
    private void OnTriggerExit2D(Collider2D collision) {
        animator.SetBool("gate", false);
    }

    private void OnTriggerStay2D(Collider2D collision){
        if(collision.CompareTag("Player") && (Input.GetKeyDown(KeyCode.UpArrow) || value.actionTouch == true)){
            if (NextScene == "Scene_Ending1")
                SceneManager.LoadScene(NextScene);
            else
                SceneManager.LoadScene("Loading");
        }
    }

}
