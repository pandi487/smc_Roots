using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public Transform[] points;
    public GameObject NpcPrefab;

    public float createTime;
    public int maxNpc = 10;
    public bool isGameOver = false;

    void Start()
    {
        points = GameObject.Find("SpawnPoint").GetComponentsInChildren<Transform>();

        if (points.Length > 0)
        {
            StartCoroutine(this.CreateNpc());
        }
    }

    void Update()
    {
        
    }

    IEnumerator CreateNpc()
    {
        //게임 종료 시까지 무한 루프
        while (!isGameOver)
        {
            //현재 생성된 몬스터 개수 산출
            int monsterCount = (int)GameObject.FindGameObjectsWithTag("Npc").Length;

            if (monsterCount < maxNpc)
            {
                //몬스터의 생성 주기 시간만큼 대기
                yield return new WaitForSeconds(createTime);

                //불규칙적인 위치 산출
                int idx = Random.Range(1, points.Length);
                //몬스터의 동적 생성
                Instantiate(NpcPrefab, points[idx].position, points[idx].rotation);
            }
            else
            {
                yield return null;
            }
        }
    }
}


