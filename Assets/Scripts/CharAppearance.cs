using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Color = UnityEngine.Color;

public class CharAppearance : MonoBehaviour
{
    public Color[] bodyColors;
    public Color[] hairColors;
    public Color[] eyesColors;
    
    public Sprite[] bodySprites;
    public Sprite[] hairSprites;
    public Sprite[] headSprites;
    public Sprite[] eyesSprites;
    public Sprite[] clotheSprites;
    public Sprite[] specialSprites;
    
    public Sprite[] noseSprites;
    public Sprite[] mouthSprites;
    
    public GameObject hair;
    public GameObject head;
    public GameObject eyes;
    public GameObject body;
    
    public GameObject nose;
    public GameObject mouth;
    public GameObject clothe;
    public GameObject special;
    
    void Start()
    {
        Randomize();
    }

    void Randomize()
    {
        body.GetComponent<SpriteRenderer>().sprite = bodySprites[Random.Range(0, bodySprites.Length)];
        body.GetComponent<SpriteRenderer>().color = bodyColors[Random.Range(0, bodyColors.Length)];
        hair.GetComponent<SpriteRenderer>().sprite = hairSprites[Random.Range(0, hairSprites.Length)];
        hair.GetComponent<SpriteRenderer>().color = hairColors[Random.Range(0, hairColors.Length)];
        head.GetComponent<SpriteRenderer>().sprite = headSprites[Random.Range(0, headSprites.Length)];
        head.GetComponent<SpriteRenderer>().color = body.GetComponent<SpriteRenderer>().color;
        eyes.GetComponent<SpriteRenderer>().sprite = eyesSprites[Random.Range(0, eyesSprites.Length)];
        eyes.GetComponent<SpriteRenderer>().color = eyesColors[Random.Range(0, eyesColors.Length)];
        
        nose.GetComponent<SpriteRenderer>().sprite = noseSprites[Random.Range(0, noseSprites.Length)];
        mouth.GetComponent<SpriteRenderer>().sprite = mouthSprites[Random.Range(0, mouthSprites.Length)];
        special.GetComponent<SpriteRenderer>().sprite = specialSprites[Random.Range(0, specialSprites.Length)];
        clothe.GetComponent<SpriteRenderer>().sprite = clotheSprites[Random.Range(0, clotheSprites.Length)];

    }
}
