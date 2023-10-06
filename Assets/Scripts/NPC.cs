using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    // 조이스틱
    public JoystickValue value;

    // 스크립트 대화
    public string[] boxSentences;

    // 말풍선
    public string[] sentences; //Npc 말풍선 대사
    public Transform chatTr; // 말풍선 위치
    public GameObject chatBoxPrefab; // 말풍선 복제

    // 말풍선
    public void TalkNPC()
    {
        GameObject go = Instantiate(chatBoxPrefab);
        go.GetComponent<ChatSystem>().Ondialogue(sentences, chatTr);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            TalkNPC();
        }
    }
    // 스크립트 대화
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && value.actionTouch)
        {
            if (DialogueManager.instance.dialogueGroup.alpha == 0)
            {
                DialogueManager.instance.OnDialogue(boxSentences);
            }
        }
    }
}
