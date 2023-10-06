using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DialogueManager : MonoBehaviour
{

    // 조이스틱
    public JoystickValue value;
    // 스크립트 대화
    public Text dialogueText;
    public GameObject nextText;
    public CanvasGroup dialogueGroup;
    public Queue<string> sentences;
    private string currentSentence;
    public float typingSpeed = 0.1f;
    private bool isTyping;
    public static DialogueManager instance;
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        sentences = new Queue<string>();
    }
    public void OnDialogue(string[] lines)
    {
        sentences.Clear();
        foreach (string line in lines)
        {
            sentences.Enqueue(line);
        }
        dialogueGroup.alpha = 1;
        dialogueGroup.blocksRaycasts = true;
        NextSentence();
    }
    public void NextSentence()
    {
        if (sentences.Count != 0)
        {
            currentSentence = sentences.Dequeue();
            isTyping = true;
            nextText.SetActive(false);
            StartCoroutine(Typing(currentSentence));
        }
        else
        {
            dialogueGroup.alpha = 0;
            dialogueGroup.blocksRaycasts = false;
        }
    }
    IEnumerator Typing(string line)
    {
        dialogueText.text = "";
        foreach (char letter in line.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
    void Update()
    {
        if (dialogueText.text.Equals(currentSentence))
        {
            nextText.SetActive(true);
            isTyping = false;
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (!isTyping)
                NextSentence();
        }
    }
}
