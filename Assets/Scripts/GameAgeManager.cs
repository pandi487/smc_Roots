using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using GameManagerSystem;
using GamevrestUtils;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameAgeManager : MonoBehaviour
{
    public Clock clock;
    public ClickEffect effect;
    public Phone phone;
    public int age = 2023;
    private int ageIndex = 0;

    public GameObject characterPrefab;
    private List<GameObject> charList = new List<GameObject>();

    public SceneReference gameWin;
    public Text yeaText;
    public TextMeshProUGUI yearText;

    public GameObject obstacle;
    public Sprite[] obstacles;
    public AudioSource music;
    public AudioClip[] musics;
    
    public GameObject pictureGuy;
    private GameObject father;
    public int count = 20;
    
    public Image background;

    public Sprite[] backgrounds;
    
    private readonly int[] Ages = new int[]
    {
        2023, //1 today
        1960,
        1500, //2 castle
        0,
        -10000, //3 stone
        -23300,
        -102000, //4 ape
        -347000,
        -1332678, //5 volcano
        -4003823, 
        -10022231, //6 fish
        -20300523,
        -60300523, //6 cell
        -70300523,
        -999999999//7 alien
    };
    
    int getEra()
    {
        if (age > 1500)
            return 1;
        if (age > -10000)
            return 2;
        if (age > -102000)
            return 3;
        if (age > -1332678)
            return 4;
        if (age > -10022231)
            return 5;
        if (age > -999999999)
            return 6;
        return 7;
    }
    
    CharAppearance.Race getRace()
    {
        if (age > 1500)
            return CharAppearance.Race.Human;
        if (age > -10000)
            return CharAppearance.Race.Human;
        if (age > -102000)
            return CharAppearance.Race.Human;
        if (age > -1332678)
            return CharAppearance.Race.Human;
        if (age > -10022231)
            return CharAppearance.Race.Dinosaur;
        if (age > -60300523)
            return CharAppearance.Race.Fish;
        if (age > -999999999)
            return CharAppearance.Race.Cell;
        return CharAppearance.Race.Alien;
    }

    public void Start()
    {
        music = GetComponent<AudioSource>();
        Spawner();
        music.Play();
        yearText.text = "2023";
    }

	int nb = 0;
    public void Spawner()
    {
        father = (GameObject)Instantiate(characterPrefab);
        father.GetComponent<CharAppearance>().Father = true;
        father.name = "FATHER" + nb++;
		father.GetComponent<CharAppearance>().race = getRace();
		father.GetComponent<CharAppearance>().era = getEra();
        father.GetComponent<CharAppearance>().pictureGuyObj = pictureGuy.GetComponent<CharAppearance>();
        for (int i = 1; i < count; i++)
        {
            var tmp = (GameObject)Instantiate(characterPrefab);
            tmp.GetComponent<CharAppearance>().race = getRace();
			tmp.GetComponent<CharAppearance>().era = getEra();
            charList.Add(tmp);
        }
    }

    void ChangeMusic()
    {
        if (music.clip == musics[(ageIndex / 2)])
            return;
        var stoppedTime = music.time;
        music.Stop();
        music.clip = musics[(ageIndex / 2)];
        if (music.clip.length >= stoppedTime)
            music.time = stoppedTime;
        music.Play();
    }

    private bool clicked = false;
    void NextAge()
    {
        if (ageIndex == Ages.Length - 1)
        {
            if (clicked)
                return;
            clicked = true;
            PersistentObject.GetSceneManager().LoadScene(gameWin);
            return;
        }

        ageIndex++;

        obstacle.GetComponent<SpriteRenderer>().sprite = obstacles[(ageIndex / 2)];
        ChangeMusic();
        age = Ages[ageIndex];
        yearText.text = age.ToString();
        foreach (var charac in charList)
        {
            Destroy(charac);
        }
        father.transform.position = pictureGuy.transform.position;
        var sprites = father.GetComponentsInChildren<SpriteRenderer>();
        foreach (var sprite in sprites)
        {
            sprite.sortingLayerName = "UI";
        }
        Destroy(pictureGuy);
        pictureGuy = father;
        pictureGuy.GetComponent<CharBehavior>().enabled = false;
		pictureGuy.GetComponent<CharAppearance>().enabled = false;
        Spawner();
        setBackground();
        clock.NextAge();
    }
    void setBackground()
    {
        background.sprite = backgrounds[getEra() - 1];
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.Space)) 
            NextAge();
#endif
        
        if(Input.GetMouseButtonDown(0))
        {
            Vector2 pos = this.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);
            if(hit.collider != null)
            {
                if(hit.collider.CompareTag("Npc"))
                {
                    phone.PopupPhone();
                    phone.target = hit.collider.gameObject;

                }
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            phone.UnPopupPhone();
        }
    }

    public void CheckFather()
    {
        if (phone.target.GetComponent<CharAppearance>().isFather(pictureGuy.GetComponent<CharAppearance>())) {  
            charList.Add(father);
            father = phone.target.gameObject;
            father.GetComponent<CharAppearance>().pictureGuyObj = pictureGuy.GetComponent<CharAppearance>();
            charList.Remove(father);
            phone.target = null;
            phone.UnPopupPhone();
            phone.Click(); 
            effect.StartClick();
            NextAge();
        }
        else
        {
            phone.WrongAnswer();
            phone.Wrong();
        }
    }
}
