using UnityEngine;
using Color = UnityEngine.Color;
using Random = UnityEngine.Random;

public class CharAppearance : MonoBehaviour
{

    public enum Race {Human, Alien, Dinosaur, Fish, Cell};
    public enum Size {Normal, Small, Large};

    public Race race = Race.Human;
    public Size size = Size.Normal;
    
    public Color[] bodyColors;
    public Color[] hairColors;
    public Color[] eyesColors;
    
    public Sprite[] bodySprites;
    public Sprite[] hairSprites;
    public Sprite[] smallHairSprites;
    public Sprite[] largeHairSprites;
    public Sprite[] headSprites;
    public Sprite[] beardSprites;
    
    public Sprite[] clotheSprites;
    public Sprite[] specialSprites;
    
    public Sprite[] eyesSprites;
    public Sprite[] fishEyesSprites;
    public Sprite[] cellEyesSprites;
    public Sprite[] noseSprites;
    public Sprite[] fishNoseSprites;
    public Sprite[] cellNoseSprites;
    public Sprite[] mouthSprites;
    public Sprite[] fishMouthSprites;
    public Sprite[] cellMouthSprites;
    
    public Sprite transparent;

    public GameObject hair;
    public GameObject beard;
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
        race = (Race)Random.Range(0, 5);
        size = (Size)Random.Range(0, 3);
        
        body.GetComponent<SpriteRenderer>().color = bodyColors[Random.Range(0, bodyColors.Length)];
        head.GetComponent<SpriteRenderer>().color = body.GetComponent<SpriteRenderer>().color;
        hair.GetComponent<SpriteRenderer>().color = hairColors[Random.Range(0, hairColors.Length)];
        beard.GetComponent<SpriteRenderer>().color = hair.GetComponent<SpriteRenderer>().color;
        eyes.GetComponent<SpriteRenderer>().color = eyesColors[Random.Range(0, eyesColors.Length)];
        
        if (race == Race.Fish)
            body.GetComponent<SpriteRenderer>().sprite = transparent;
        else if (race == Race.Cell)
            body.GetComponent<SpriteRenderer>().sprite = bodySprites[2];
        else if (race == Race.Dinosaur)
            body.GetComponent<SpriteRenderer>().sprite = bodySprites[1];
        else
            body.GetComponent<SpriteRenderer>().sprite = bodySprites[0];
        
        if (size == Size.Large) {
            head.GetComponent<SpriteRenderer>().sprite = headSprites[2];
            hair.GetComponent<SpriteRenderer>().sprite = largeHairSprites[Random.Range(0, hairSprites.Length)];
        }
        else if (size == Size.Small) {
            head.GetComponent<SpriteRenderer>().sprite = headSprites[0];
            hair.GetComponent<SpriteRenderer>().sprite = smallHairSprites[Random.Range(0, hairSprites.Length)];
        }
        else {
            head.GetComponent<SpriteRenderer>().sprite = headSprites[1];
            hair.GetComponent<SpriteRenderer>().sprite = hairSprites[Random.Range(0, hairSprites.Length)];
        }

        if (race == Race.Alien || race == Race.Fish || race == Race.Cell)
            hair.GetComponent<SpriteRenderer>().sprite = transparent;

        if (race == Race.Dinosaur)
            head.GetComponent<SpriteRenderer>().sprite = headSprites[3];
        else if (race == Race.Cell)
            head.GetComponent<SpriteRenderer>().sprite = headSprites[4];
        else if (race == Race.Alien)
            head.GetComponent<SpriteRenderer>().sprite = headSprites[5];
        else if (race == Race.Fish)
            head.GetComponent<SpriteRenderer>().sprite = headSprites[6];


        if (race == Race.Fish) {
            eyes.GetComponent<SpriteRenderer>().sprite = fishEyesSprites[Random.Range(0, eyesSprites.Length)];
            nose.GetComponent<SpriteRenderer>().sprite = fishNoseSprites[Random.Range(0, noseSprites.Length)];
            mouth.GetComponent<SpriteRenderer>().sprite = fishMouthSprites[Random.Range(0, mouthSprites.Length)];
        } else if (race == Race.Alien) {
            eyes.GetComponent<SpriteRenderer>().sprite = transparent;
            nose.GetComponent<SpriteRenderer>().sprite = transparent;
            mouth.GetComponent<SpriteRenderer>().sprite = transparent;
        } else if (race == Race.Cell) {
            eyes.GetComponent<SpriteRenderer>().sprite = cellEyesSprites[Random.Range(0, eyesSprites.Length)];
            nose.GetComponent<SpriteRenderer>().sprite = cellNoseSprites[Random.Range(0, noseSprites.Length)];
            mouth.GetComponent<SpriteRenderer>().sprite = cellMouthSprites[Random.Range(0, mouthSprites.Length)];
        } else {
            eyes.GetComponent<SpriteRenderer>().sprite = eyesSprites[Random.Range(0, eyesSprites.Length)];
            nose.GetComponent<SpriteRenderer>().sprite = noseSprites[Random.Range(0, noseSprites.Length)];
            mouth.GetComponent<SpriteRenderer>().sprite = mouthSprites[Random.Range(0, mouthSprites.Length)];
        }

        if (race != Race.Fish && race != Race.Cell)
            clothe.GetComponent<SpriteRenderer>().sprite = clotheSprites[Random.Range(0, clotheSprites.Length)];
        else
            clothe.GetComponent<SpriteRenderer>().sprite = transparent;
        special.GetComponent<SpriteRenderer>().sprite = specialSprites[Random.Range(0, specialSprites.Length)];
    }
}
