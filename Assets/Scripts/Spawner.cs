using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject lambda;
    public int maxCharacters = 10;
    int nbCharacters;
    public Vector2[] spawn_origin = new Vector2[4];
    public float spawn_freq = 5f;
    private float time_since_last = 0f;
    [Header("Sprites")]




    [Header("Enfant Down")]
    public Sprite[] yeuxEnfantDown;
    public Sprite[] cheveuxEnfantDown;
    public Sprite[] teteEnfantDown;
    public Sprite[] corpsEnfantDown;
    public Sprite[] boucheEnfantDown;

    [Header("Enfant Side")]
    public Sprite[] yeuxEnfantSide;
    public Sprite[] cheveuxEnfantSide;
    public Sprite[] teteEnfantSide;
    public Sprite[] corpsEnfantSide;
    public Sprite[] boucheEnfantSide;

    [Header("Enfant Up")]
    public Sprite[] yeuxEnfantUp;
    public Sprite[] cheveuxEnfantUp;
    public Sprite[] teteEnfantUp;
    public Sprite[] corpsEnfantUp;
    public Sprite[] boucheEnfantUp;

    //
    [Header("Ado Down")]
    public Sprite[] yeuxAdoDown;
    public Sprite[] cheveuxAdoDown;
    public Sprite[] teteAdoDown;
    public Sprite[] corpsAdoDown;
    public Sprite[] boucheAdoDown;

    [Header("Ado Side")]
    public Sprite[] yeuxAdoSide;
    public Sprite[] cheveuxAdoSide;
    public Sprite[] teteAdoSide;
    public Sprite[] corpsAdoSide;
    public Sprite[] boucheAdoSide;

    [Header("Ado Up")]
    public Sprite[] yeuxAdoUp;
    public Sprite[] cheveuxAdoUp;
    public Sprite[] teteAdoUp;
    public Sprite[] corpsAdoUp;
    public Sprite[] boucheAdoUp;

    //
    [Header("Adulte Down")]
    public Sprite[] yeuxAdulteDown;
    public Sprite[] cheveuxAdulteDown;
    public Sprite[] teteAdulteDown;
    public Sprite[] corpsAdulteDown;
    public Sprite[] boucheAdulteDown;

    [Header("Adulte Side")]
    public Sprite[] yeuxAdulteSide;
    public Sprite[] cheveuxAdulteSide;
    public Sprite[] teteAdulteSide;
    public Sprite[] corpsAdulteSide;
    public Sprite[] boucheAdulteSide;

    [Header("Adulte Up")]
    public Sprite[] yeuxAdulteUp;
    public Sprite[] cheveuxAdulteUp;
    public Sprite[] teteAdulteUp;
    public Sprite[] corpsAdulteUp;
    public Sprite[] boucheAdulteUp;

    //

    [Header("Vieux Down")]
    public Sprite[] yeuxVieuxDown;
    public Sprite[] cheveuxVieuxDown;
    public Sprite[] teteVieuxDown;
    public Sprite[] corpsVieuxDown;
    public Sprite[] boucheVieuxDown;

    [Header("Vieux Side")]

    public Sprite[] yeuxVieuxSide;
    public Sprite[] cheveuxVieuxSide;
    public Sprite[] teteVieuxSide;
    public Sprite[] corpsVieuxSide;
    public Sprite[] boucheVieuxSide;

    [Header("Vieux Up")]
    public Sprite[] yeuxVieuxUp;
    public Sprite[] cheveuxVieuxUp;
    public Sprite[] teteVieuxUp;
    public Sprite[] corpsVieuxUp;
    public Sprite[] boucheVieuxUp;

    


   

    public GameObject CreateNew(Age age, BodyLife bl)
    {
        GameObject characterObject = Instantiate(lambda);

        Character character = characterObject.GetComponent<Character>();

        character.bL = bl;

        character.age = age;

        return characterObject;
    }

    public BodyLife RandomBL()
    {

        BodyLife BL = new BodyLife();

        int typeCheveux = Random.Range(0, 2);
        int humeur = Random.Range(0, 3);

        Color hairColor = RandomColor();
        Color whiteHairColor=new Color((1+hairColor.r)/2, (1 + hairColor.r) / 2, (1 + hairColor.r)/ 2);
        Color clothesColor = RandomColor();
        Color skinColor = RandomSkinColor();

        BL.childBody.cheveuxCouleur = hairColor;
        BL.childBody.teteCouleur = skinColor;
        BL.childBody.corpsCouleur = clothesColor;

        BL.childBody.cheveuxDown = cheveuxEnfantDown[typeCheveux];
        BL.childBody.boucheDown = boucheEnfantDown[humeur];
        BL.childBody.yeuxDown = yeuxEnfantDown[humeur];
        BL.childBody.corpsDown = corpsEnfantDown[0];
        BL.childBody.teteDown = teteEnfantDown[0];

        BL.childBody.cheveuxSide = cheveuxEnfantSide[typeCheveux];
        BL.childBody.boucheSide = boucheEnfantSide[humeur];
        BL.childBody.yeuxSide = yeuxEnfantSide[humeur];
        BL.childBody.corpsSide = corpsEnfantSide[0];
        BL.childBody.teteSide = teteEnfantSide[0];

        BL.childBody.cheveuxUp = cheveuxEnfantUp[typeCheveux];
        BL.childBody.corpsUp = corpsEnfantUp[0];
        BL.childBody.teteUp = teteEnfantUp[0];

        BL.teenBody.cheveuxCouleur = hairColor;
        BL.teenBody.teteCouleur = skinColor;
        BL.teenBody.corpsCouleur = clothesColor;

        BL.teenBody.cheveuxDown = cheveuxAdoDown[typeCheveux];
        BL.teenBody.boucheDown = boucheAdoDown[humeur];
        BL.teenBody.yeuxDown = yeuxAdoDown[humeur];
        BL.teenBody.corpsDown = corpsAdoDown[0];
        BL.teenBody.teteDown = teteAdoDown[0];

        BL.teenBody.cheveuxSide = cheveuxAdoSide[typeCheveux];
        BL.teenBody.boucheSide = boucheAdoSide[humeur];
        BL.teenBody.yeuxSide = yeuxAdoSide[humeur];
        BL.teenBody.corpsSide = corpsAdoSide[0];
        BL.teenBody.teteSide = teteAdoSide[0];

        BL.teenBody.cheveuxUp = cheveuxAdoUp[typeCheveux];
        BL.teenBody.corpsUp = corpsAdoUp[0];
        BL.teenBody.teteUp = teteAdoUp[0];


        BL.adultBody.cheveuxCouleur = hairColor;
        BL.adultBody.teteCouleur = skinColor;
        BL.adultBody.corpsCouleur = clothesColor;

        BL.adultBody.cheveuxDown = cheveuxAdulteDown[typeCheveux];
        BL.adultBody.boucheDown = boucheAdulteDown[humeur];
        BL.adultBody.yeuxDown = yeuxAdulteDown[humeur];
        BL.adultBody.corpsDown = corpsAdulteDown[0];
        BL.adultBody.teteDown = teteAdulteDown[0];

        BL.adultBody.cheveuxSide = cheveuxAdulteSide[typeCheveux];
        BL.adultBody.boucheSide = boucheAdulteSide[humeur];
        BL.adultBody.yeuxSide = yeuxAdulteSide[humeur];
        BL.adultBody.corpsSide = corpsAdulteSide[0];
        BL.adultBody.teteSide = teteAdulteSide[0];

        BL.adultBody.cheveuxUp = cheveuxAdulteUp[typeCheveux];
        BL.adultBody.corpsUp = corpsAdulteUp[0];
        BL.adultBody.teteUp = teteAdulteUp[0];


        BL.elderBody.cheveuxCouleur = whiteHairColor;
        BL.elderBody.teteCouleur = skinColor;
        BL.elderBody.corpsCouleur = clothesColor;

        BL.elderBody.cheveuxDown = cheveuxVieuxDown[typeCheveux];
        BL.elderBody.boucheDown = boucheVieuxDown[humeur];
        BL.elderBody.yeuxDown = yeuxVieuxDown[humeur];
        BL.elderBody.corpsDown = corpsVieuxDown[0];
        BL.elderBody.teteDown = teteVieuxDown[0];

        BL.elderBody.cheveuxSide = cheveuxVieuxSide[typeCheveux];
        BL.elderBody.boucheSide = boucheVieuxSide[humeur];
        BL.elderBody.yeuxSide = yeuxVieuxSide[humeur];
        BL.elderBody.corpsSide = corpsVieuxSide[0];
        BL.elderBody.teteSide = teteVieuxSide[0];

        BL.elderBody.cheveuxUp = cheveuxVieuxUp[typeCheveux];
        BL.elderBody.corpsUp = corpsVieuxUp[0];
        BL.elderBody.teteUp = teteVieuxUp[0];

        return BL;

    }

    public Age RandomAge(float childProba, float teenProba, float adultProba)
    {
        float r = Random.value;
        Age age;
        if (r < childProba)
        {
            age = Age.CHILD;
        }
        else if (r < childProba+teenProba)
        {
            age = Age.TEEN;
        }
        else if (r < childProba+teenProba+adultProba)
        {
            age = Age.ADULT;
        }
        else
        {
            age = Age.ELDER;
        }
        return age;
    }

    public Age RandomAge()
    {
        return RandomAge(0.25f,0.25f,0.25f);
    }


    public Color RandomColor()
    {
        float r = Random.value;
        float g = Random.value;
        float b = Random.value;
        
        return new Color(r, g, b);
        
    }

    public Color RandomSkinColor()
    {
        //255,200,125
        float r = Random.value*0.5f+0.5f;
        float g = r * 200 / 255;
        float b = r * 125 / 255;
        return new Color(r, g, b);

    }

    public GameObject GenerateNew()
    {
        BodyLife bl = RandomBL();
        Age age;
        age = RandomAge();
        GameObject character = CreateNew(age, bl);

        return character;
    }



    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //foreach(Character i in FindObjectsOfType<Character>())
        nbCharacters = 0;
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Character"))
        {
            Character i = go.GetComponent<Character>();
            
            if(!i.has_dialogue && i.is_young_enough())
            {
                nbCharacters++;
            }
        }

	time_since_last += Time.deltaTime;

        if(nbCharacters<3 || (time_since_last > spawn_freq && nbCharacters < maxCharacters) )
        {
		time_since_last = 0;
            GameObject characterObj = GenerateNew();

	    int spawn_spot = Random.Range(0,spawn_origin.Length);
            //characterObj.transform.position = new Vector2(Random.value*2-1, Random.value*2-1);
            characterObj.transform.position = spawn_origin[spawn_spot];
            Character chara = characterObj.GetComponent<Character>();
	    switch (spawn_spot)
	    {
		    case 0:
			    chara.direction = Direction.UP;
			    break;
		    case 1:
			    chara.direction = Direction.DOWN;
			    break;
		    case 2:
			    chara.direction = Direction.LEFT;
			    break;
		    case 3:
			    chara.direction = Direction.RIGHT;
			    break;
		    default:
			    chara.direction = Direction.UP;
			    break;
	    }
	    chara.Change(chara.age, chara.direction);
            
            characterObj.SetActive(true);

        }
	}
}
