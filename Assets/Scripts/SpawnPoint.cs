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
        //°ÔÀÓ Á¾·á ½Ã±îÁö ¹«ÇÑ ·çÇÁ
        while (!isGameOver)
        {
            //ÇöÀç »ý¼ºµÈ ¸ó½ºÅÍ °³¼ö »êÃâ
            int monsterCount = (int)GameObject.FindGameObjectsWithTag("Npc").Length;

            if (monsterCount < maxNpc)
            {
                //¸ó½ºÅÍÀÇ »ý¼º ÁÖ±â ½Ã°£¸¸Å­ ´ë±â
                yield return new WaitForSeconds(createTime);

                //ºÒ±ÔÄ¢ÀûÀÎ À§Ä¡ »êÃâ
                int idx = Random.Range(1, points.Length);
                //¸ó½ºÅÍÀÇ µ¿Àû »ý¼º
                Instantiate(NpcPrefab, points[idx].position, points[idx].rotation);
            }
            else
            {
                yield return null;
            }
        }
    }
}


