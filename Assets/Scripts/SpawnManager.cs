using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public int maxCount;
    public int enemyCount;
    public float spawnTime;
    public float curTime;
    public Transform[] spawnPoints;
    public GameObject enemy;
    public bool[] isSpawn; // 중복 생성 금지

    public static SpawnManager _instance;
    private void Start() {
        // 같은 자리 중복생성 금지
        isSpawn = new bool[spawnPoints.Length];
        for(int i = 0; i < isSpawn.Length; i++){
            isSpawn[i] = false;
        }

        // 적 스크립트에 인자 보내기
        _instance = this;
    }

    private void Update() {
        if(curTime >= spawnTime && enemyCount < maxCount){
            int x = Random.Range(0, spawnPoints.Length);
            if(!isSpawn[x]){
                SpawnEnemy(x);
            }
        }
        curTime += Time.deltaTime;
    }

    public void SpawnEnemy(int ranNum){
        curTime = 0;
        enemyCount++;
        Instantiate(enemy, spawnPoints[ranNum]);
        isSpawn[ranNum] = true;
    }
}
