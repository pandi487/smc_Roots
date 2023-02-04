using System;
using System.Linq;
using System.Reflection;
using UnityEngine;
using Color = UnityEngine.Color;
using Random = UnityEngine.Random;

public class CharAppearance : MonoBehaviour
{

    public enum Race {Human, Alien, Dinosaur, Fish, Cell};
    public enum Size {Normal, Small, Large};

	public int era = 0;
	
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

    public bool Father = false;
    public CharAppearance pictureGuyObj;

    private void Awake()
    {
        if (!Father)
            Randomize();
    }

    void Start()
    {
        if (Father)
        {
            Randomize();
            makeFather(pictureGuyObj);
        }
		else
			Randomize();
    }

    public bool isFather(CharAppearance pictureGuy)
    {
        var count = 0;

		if(Father)
			return true;
		
        if (body.GetComponent<SpriteRenderer>().color == pictureGuy.body.GetComponent<SpriteRenderer>().color)
            count++;
        if (hair.GetComponent<SpriteRenderer>().sprite.name ==
            pictureGuy.hair.GetComponent<SpriteRenderer>().sprite.name
            && hair.GetComponent<SpriteRenderer>().color == pictureGuy.hair.GetComponent<SpriteRenderer>().color)
            count++;
        if (nose.GetComponent<SpriteRenderer>().sprite.name ==
            pictureGuy.nose.GetComponent<SpriteRenderer>().sprite.name)
            count++;
        if (mouth.GetComponent<SpriteRenderer>().sprite.name ==
            pictureGuy.mouth.GetComponent<SpriteRenderer>().sprite.name)
            count++;
        if (beard.GetComponent<SpriteRenderer>().sprite.name ==
            pictureGuy.beard.GetComponent<SpriteRenderer>().sprite.name)
            count++;
        if (eyes.GetComponent<SpriteRenderer>().sprite.name ==
            pictureGuy.eyes.GetComponent<SpriteRenderer>().sprite.name)
            count += 2;
        if (size == pictureGuy.size && race == Race.Human)
            count++;

        if (count >= 3)
            return true;
        return false;
    }
    
    /*public GameObject AccessAttribute(string attributeName)
    {
        Type type = this.GetType();
        PropertyInfo property = type.GetProperty(attributeName);
        if (property != null)
        {
            return (GameObject)property.GetValue(this);
        }
        else
        {
            return null;
        }
    }*/
    public GameObject AccessAttribute(string attributeName)
    {
        if (attributeName == "body")
            return body;
        if (attributeName == "beard")
            return beard;
        if (attributeName == "head")
            return head;
        if (attributeName == "eyes")
            return eyes;
        if (attributeName == "nose")
            return nose;
        if (attributeName == "mouth")
            return mouth;
		if (attributeName == "hair")
            return hair;
        return null;
    }

    public void makeFather(CharAppearance pictureGuy)
    {
        GameObject[] human = new GameObject[] {
            body,
            beard,
            head,
            eyes,
            nose,
            mouth,
			hair
        };
        GameObject[] other = new GameObject[] {
            eyes,
            nose,
            mouth
        };

        int[] randomIndices = Enumerable.Range(0, human.Length).OrderBy(x => Random.value).Take(5).ToArray();

        GameObject firstRandomElement = eyes;
        GameObject secondRandomElement = nose;
        GameObject thirdRandomElement = mouth;
		GameObject fourthRandomElement = null;
		GameObject fifthRandomElement = null;
        if (race == Race.Human || race == Race.Dinosaur)
        {
			body.GetComponent<SpriteRenderer>().color = pictureGuy.body.GetComponent<SpriteRenderer>().color;
            firstRandomElement = human[randomIndices[0]];
            secondRandomElement = human[randomIndices[1]];
            thirdRandomElement = human[randomIndices[2]];
			fourthRandomElement = human[randomIndices[3]];
			fifthRandomElement = human[randomIndices[4]];
        }


        /*Debug.Log("First random elementname: " + firstRandomElement.name.ToLower() + firstRandomElement.GetComponent<SpriteRenderer>().sprite.name);
        Debug.Log("Second random elementname: " + secondRandomElement.name.ToLower()+ secondRandomElement.GetComponent<SpriteRenderer>().sprite.name);
        Debug.Log("Third random elementname: " + thirdRandomElement.name.ToLower());*/
        
        /*Debug.Log("Attribute father : " + pictureGuy.AccessAttribute(firstRandomElement.name.ToLower()) + pictureGuy.AccessAttribute(firstRandomElement.name.ToLower()).GetComponent<SpriteRenderer>().sprite.name);
        Debug.Log("Attribute father2 : " + pictureGuy.AccessAttribute(secondRandomElement.name.ToLower()) + pictureGuy.AccessAttribute(secondRandomElement.name.ToLower()).GetComponent<SpriteRenderer>().sprite.name);*/
        firstRandomElement.GetComponent<SpriteRenderer>().sprite = pictureGuy.AccessAttribute(firstRandomElement.name.ToLower()).GetComponent<SpriteRenderer>().sprite;
        secondRandomElement.GetComponent<SpriteRenderer>().sprite = pictureGuy.AccessAttribute(secondRandomElement.name.ToLower()).GetComponent<SpriteRenderer>().sprite;
        thirdRandomElement.GetComponent<SpriteRenderer>().sprite = pictureGuy.AccessAttribute(thirdRandomElement.name.ToLower()).GetComponent<SpriteRenderer>().sprite;
        if (race == Race.Human || race == Race.Dinosaur) {
			fourthRandomElement.GetComponent<SpriteRenderer>().sprite = pictureGuy.AccessAttribute(fourthRandomElement.name.ToLower()).GetComponent<SpriteRenderer>().sprite;
			fifthRandomElement.GetComponent<SpriteRenderer>().sprite = pictureGuy.AccessAttribute(fifthRandomElement.name.ToLower()).GetComponent<SpriteRenderer>().sprite;
		}
	
        /*Debug.Log("First random element: " + firstRandomElement.name + firstRandomElement.GetComponent<SpriteRenderer>().sprite.name);
        Debug.Log("Second random element: " + secondRandomElement.name+ secondRandomElement.GetComponent<SpriteRenderer>().sprite.name);
        Debug.Log("Third random element: " + thirdRandomElement.name);*/
    }
    
    void Randomize()
    {
        size = (Size)Random.Range(0, 3);
        
        body.GetComponent<SpriteRenderer>().color = bodyColors[Random.Range(0, bodyColors.Length)];
        head.GetComponent<SpriteRenderer>().color = body.GetComponent<SpriteRenderer>().color;
        hair.GetComponent<SpriteRenderer>().color = hairColors[Random.Range(0, hairColors.Length)];
        beard.GetComponent<SpriteRenderer>().color = hair.GetComponent<SpriteRenderer>().color;
        eyes.GetComponent<SpriteRenderer>().color = eyesColors[Random.Range(0, eyesColors.Length)];
        beard.GetComponent<SpriteRenderer>().sprite = transparent;
		
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
            beard.GetComponent<SpriteRenderer>().sprite = beardSprites[Random.Range(0, beardSprites.Length)];
        }

        if (era >= 1 && era <= 4){
			Debug.Log("ERA : " + era);
			clothe.GetComponent<SpriteRenderer>().sprite = clotheSprites[(era - 1)];
		}
        else
            clothe.GetComponent<SpriteRenderer>().sprite = transparent;
        special.GetComponent<SpriteRenderer>().sprite = specialSprites[Random.Range(0, specialSprites.Length)];
    }
}
