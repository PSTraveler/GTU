using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Final : MonoBehaviour
{
    float timer = 0;
    public float limit = 0;
    public string SceneName;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= limit)
        {
            SceneManager.LoadScene(SceneName);
        }
    }
}
