﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChatSystem : MonoBehaviour
{
    public Queue<string> sentences;
    public string currentSentence;
    public TextMeshPro text;
    public GameObject quad;
    public void Ondialogue(string[] lines, Transform chatPoint){ // NPC 대사 큐에 저장
        transform.position = chatPoint.position;
        sentences = new Queue<string>();
        sentences.Clear();
        foreach(var line in lines){ //string 배열 값 차례대로 큐에 넣음
            sentences.Enqueue(line);
        }
        StartCoroutine(DialogueFlow(chatPoint));
    }
    IEnumerator DialogueFlow(Transform chatPoint){
        yield return null;
        while(sentences.Count > 0){ // 큐의 개수만큼 반복해 대사 넣기
            currentSentence = sentences.Dequeue();
            text.text = currentSentence;
            float x = text.preferredWidth;
            x = (x > 3) ? 3 : x + 0.3f;
            quad.transform.localScale = new Vector2(x, text.preferredHeight + 0.3f);
            transform.position = new Vector2(chatPoint.position.x, chatPoint.position.y + text.preferredHeight / 2);
            yield return new WaitForSeconds(1f); //1초 대기
        }
        Destroy(gameObject);
    }
}
