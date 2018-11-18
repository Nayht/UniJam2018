using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Serialization;

[System.Serializable]
public struct Body
{
    public Sprite boucheUp;
    public Sprite cheveuxUp;
    public Sprite corpsUp;
    public Sprite teteUp;
    public Sprite yeuxUp;

    public Sprite boucheDown;
    public Sprite cheveuxDown;
    public Sprite corpsDown;
    public Sprite teteDown;
    public Sprite yeuxDown;

    public Sprite boucheSide;
    public Sprite cheveuxSide;
    public Sprite corpsSide;
    public Sprite teteSide;
    public Sprite yeuxSide;

    public Color boucheCouleur;
    public Color cheveuxCouleur;
    public Color corpsCouleur;
    public Color teteCouleur;
    public Color yeuxCouleur;
}
[System.Serializable]
public struct BodyLife
{
    public Body childBody;
    public Body teenBody;
    public Body adultBody;
    public Body elderBody;
}

public enum Direction
{
    UP,
    DOWN,
    LEFT,
    RIGHT
}

public class Character : MonoBehaviour
{
	public static Object spirit;

	private InputManager inputManager;
	private MoveEngine moveEngine;
	private Collider2D collider;
	
	[SerializeField] public string name;
	[SerializeField] public Age age;
	[SerializeField] public Age acceptsAge;

	public bool is_player = false;
	public bool has_dialogue = false;
	public float counter_life; // time the character has been possessed
	[SerializeField]
	private float max_life = 30f;
	public float animation_time = 1f;

	private int dialogueProgression;

	public Slider mainSlider;
	public Image slider_fill;

	//Qasim
    [Header("Character appearance")]
    //public Body body;
    public BodyLife bL;

    [Header("Body")]
    public GameObject cheveux;
    public GameObject tete;
    public GameObject yeux;
    public GameObject bouche;
    public GameObject corps;
    

    public Character(Age age, BodyLife bl)
    {
        
        this.age = age;
        this.bL = bl;

    }

    public void Change(Age age, Direction direction)
    {


        if(age==Age.ADULT)
        {
            cheveux.GetComponent<SpriteRenderer>().color = bL.adultBody.cheveuxCouleur;
            corps.GetComponent<SpriteRenderer>().color = bL.adultBody.corpsCouleur;
            tete.GetComponent<SpriteRenderer>().color = bL.adultBody.teteCouleur;
            switch (direction)
            {
                case Direction.DOWN:
                    cheveux.GetComponent<SpriteRenderer>().sprite = bL.adultBody.cheveuxDown;
                    yeux.GetComponent<SpriteRenderer>().sprite = bL.adultBody.yeuxDown;
                    bouche.GetComponent<SpriteRenderer>().sprite = bL.adultBody.boucheDown;
                    corps.GetComponent<SpriteRenderer>().sprite = bL.adultBody.corpsDown;
                    tete.GetComponent<SpriteRenderer>().sprite = bL.adultBody.teteDown;
                    break;
                case Direction.UP:
                    cheveux.GetComponent<SpriteRenderer>().sprite = bL.adultBody.cheveuxUp;
                    yeux.GetComponent<SpriteRenderer>().sprite = bL.adultBody.yeuxUp;
                    bouche.GetComponent<SpriteRenderer>().sprite = bL.adultBody.boucheUp;
                    corps.GetComponent<SpriteRenderer>().sprite = bL.adultBody.corpsUp;
                    tete.GetComponent<SpriteRenderer>().sprite = bL.adultBody.teteUp;
                    break;
                case Direction.LEFT:
                    cheveux.GetComponent<SpriteRenderer>().sprite = bL.adultBody.cheveuxSide;
                    yeux.GetComponent<SpriteRenderer>().sprite = bL.adultBody.yeuxSide;
                    bouche.GetComponent<SpriteRenderer>().sprite = bL.adultBody.boucheSide;
                    corps.GetComponent<SpriteRenderer>().sprite = bL.adultBody.corpsSide;
                    tete.GetComponent<SpriteRenderer>().sprite = bL.adultBody.teteSide;
                    break;
                case Direction.RIGHT:
                    cheveux.GetComponent<SpriteRenderer>().sprite = bL.adultBody.cheveuxSide;
                    yeux.GetComponent<SpriteRenderer>().sprite = bL.adultBody.yeuxSide;
                    bouche.GetComponent<SpriteRenderer>().sprite = bL.adultBody.boucheSide;
                    corps.GetComponent<SpriteRenderer>().sprite = bL.adultBody.corpsSide;
                    tete.GetComponent<SpriteRenderer>().sprite = bL.adultBody.teteSide;
                    break;
            } 
        }
        if (age == Age.CHILD)
        {
            cheveux.GetComponent<SpriteRenderer>().color = bL.childBody.cheveuxCouleur;
            corps.GetComponent<SpriteRenderer>().color = bL.childBody.corpsCouleur;
            tete.GetComponent<SpriteRenderer>().color = bL.childBody.teteCouleur;
            switch (direction)
            {
                case Direction.DOWN:
                    cheveux.GetComponent<SpriteRenderer>().sprite = bL.childBody.cheveuxDown;
                    yeux.GetComponent<SpriteRenderer>().sprite = bL.childBody.yeuxDown;
                    bouche.GetComponent<SpriteRenderer>().sprite = bL.childBody.boucheDown;
                    corps.GetComponent<SpriteRenderer>().sprite = bL.childBody.corpsDown;
                    tete.GetComponent<SpriteRenderer>().sprite = bL.childBody.teteDown;
                    break;
                case Direction.UP:
                    cheveux.GetComponent<SpriteRenderer>().sprite = bL.childBody.cheveuxUp;
                    yeux.GetComponent<SpriteRenderer>().sprite = bL.childBody.yeuxUp;
                    bouche.GetComponent<SpriteRenderer>().sprite = bL.childBody.boucheUp;
                    corps.GetComponent<SpriteRenderer>().sprite = bL.childBody.corpsUp;
                    tete.GetComponent<SpriteRenderer>().sprite = bL.childBody.teteUp;
                    break;
                case Direction.LEFT:
                    cheveux.GetComponent<SpriteRenderer>().sprite = bL.childBody.cheveuxSide;
                    yeux.GetComponent<SpriteRenderer>().sprite = bL.childBody.yeuxSide;
                    bouche.GetComponent<SpriteRenderer>().sprite = bL.childBody.boucheSide;
                    corps.GetComponent<SpriteRenderer>().sprite = bL.childBody.corpsSide;
                    tete.GetComponent<SpriteRenderer>().sprite = bL.childBody.teteSide;
                    break;
                case Direction.RIGHT:
                    cheveux.GetComponent<SpriteRenderer>().sprite = bL.childBody.cheveuxSide;
                    yeux.GetComponent<SpriteRenderer>().sprite = bL.childBody.yeuxSide;
                    bouche.GetComponent<SpriteRenderer>().sprite = bL.childBody.boucheSide;
                    corps.GetComponent<SpriteRenderer>().sprite = bL.childBody.corpsSide;
                    tete.GetComponent<SpriteRenderer>().sprite = bL.childBody.teteSide;
                    break;
            }
        }
        if (age == Age.TEEN)
        {
            cheveux.GetComponent<SpriteRenderer>().color = bL.teenBody.cheveuxCouleur;
            corps.GetComponent<SpriteRenderer>().color = bL.teenBody.corpsCouleur;
            tete.GetComponent<SpriteRenderer>().color = bL.teenBody.teteCouleur;
            switch (direction)
            {
                case Direction.DOWN:
                    cheveux.GetComponent<SpriteRenderer>().sprite = bL.teenBody.cheveuxDown;
                    yeux.GetComponent<SpriteRenderer>().sprite = bL.teenBody.yeuxDown;
                    bouche.GetComponent<SpriteRenderer>().sprite = bL.teenBody.boucheDown;
                    corps.GetComponent<SpriteRenderer>().sprite = bL.teenBody.corpsDown;
                    tete.GetComponent<SpriteRenderer>().sprite = bL.teenBody.teteDown;
                    break;
                case Direction.UP:
                    cheveux.GetComponent<SpriteRenderer>().sprite = bL.teenBody.cheveuxUp;
                    yeux.GetComponent<SpriteRenderer>().sprite = bL.teenBody.yeuxUp;
                    bouche.GetComponent<SpriteRenderer>().sprite = bL.teenBody.boucheUp;
                    corps.GetComponent<SpriteRenderer>().sprite = bL.teenBody.corpsUp;
                    tete.GetComponent<SpriteRenderer>().sprite = bL.teenBody.teteUp;
                    break;
                case Direction.LEFT:
                    cheveux.GetComponent<SpriteRenderer>().sprite = bL.teenBody.cheveuxSide;
                    yeux.GetComponent<SpriteRenderer>().sprite = bL.teenBody.yeuxSide;
                    bouche.GetComponent<SpriteRenderer>().sprite = bL.teenBody.boucheSide;
                    corps.GetComponent<SpriteRenderer>().sprite = bL.teenBody.corpsSide;
                    tete.GetComponent<SpriteRenderer>().sprite = bL.teenBody.teteSide;
                    break;
                case Direction.RIGHT:
                    cheveux.GetComponent<SpriteRenderer>().sprite = bL.teenBody.cheveuxSide;
                    yeux.GetComponent<SpriteRenderer>().sprite = bL.teenBody.yeuxSide;
                    bouche.GetComponent<SpriteRenderer>().sprite = bL.teenBody.boucheSide;
                    corps.GetComponent<SpriteRenderer>().sprite = bL.teenBody.corpsSide;
                    tete.GetComponent<SpriteRenderer>().sprite = bL.teenBody.teteSide;
                    break;
            }
        }
        if (age == Age.ELDER)
        {
            cheveux.GetComponent<SpriteRenderer>().color = bL.elderBody.cheveuxCouleur;
            corps.GetComponent<SpriteRenderer>().color = bL.elderBody.corpsCouleur;
            tete.GetComponent<SpriteRenderer>().color = bL.elderBody.teteCouleur;
            switch (direction)
            {
                case Direction.DOWN:
                    cheveux.GetComponent<SpriteRenderer>().sprite = bL.elderBody.cheveuxDown;
                    yeux.GetComponent<SpriteRenderer>().sprite = bL.elderBody.yeuxDown;
                    bouche.GetComponent<SpriteRenderer>().sprite = bL.elderBody.boucheDown;
                    corps.GetComponent<SpriteRenderer>().sprite = bL.elderBody.corpsDown;
                    tete.GetComponent<SpriteRenderer>().sprite = bL.elderBody.teteDown;

                    break;
                case Direction.UP:
                    cheveux.GetComponent<SpriteRenderer>().sprite = bL.elderBody.cheveuxUp;
                    yeux.GetComponent<SpriteRenderer>().sprite = bL.elderBody.yeuxUp;
                    bouche.GetComponent<SpriteRenderer>().sprite = bL.elderBody.boucheUp;
                    corps.GetComponent<SpriteRenderer>().sprite = bL.elderBody.corpsUp;
                    tete.GetComponent<SpriteRenderer>().sprite = bL.elderBody.teteUp;
                    break;
                case Direction.LEFT:
                    cheveux.GetComponent<SpriteRenderer>().sprite = bL.elderBody.cheveuxSide;
                    yeux.GetComponent<SpriteRenderer>().sprite = bL.elderBody.yeuxSide;
                    bouche.GetComponent<SpriteRenderer>().sprite = bL.elderBody.boucheSide;
                    corps.GetComponent<SpriteRenderer>().sprite = bL.elderBody.corpsSide;
                    tete.GetComponent<SpriteRenderer>().sprite = bL.elderBody.teteSide;
                    break;
                case Direction.RIGHT:
                    cheveux.GetComponent<SpriteRenderer>().sprite = bL.elderBody.cheveuxSide;
                    yeux.GetComponent<SpriteRenderer>().sprite = bL.elderBody.yeuxSide;
                    bouche.GetComponent<SpriteRenderer>().sprite = bL.elderBody.boucheSide;
                    corps.GetComponent<SpriteRenderer>().sprite = bL.elderBody.corpsSide;
                    tete.GetComponent<SpriteRenderer>().sprite = bL.elderBody.teteSide;
                    break;
            }
        }
        if(direction==Direction.LEFT)
        {
            SpriteRenderer[] srs = GetComponentsInChildren<SpriteRenderer>();
            foreach(SpriteRenderer sr in srs)
            {
                sr.flipX = true;
            }
        }
        else
        {
            SpriteRenderer[] srs = GetComponentsInChildren<SpriteRenderer>();
            foreach (SpriteRenderer sr in srs)
            {
                sr.flipX = false;
            }
        }
        if(direction==Direction.UP)
        {
            yeux.GetComponent<SpriteRenderer>().enabled = false;
            bouche.GetComponent<SpriteRenderer>().enabled = false;
        }
        else
        {
            yeux.GetComponent<SpriteRenderer>().enabled = true;
            bouche.GetComponent<SpriteRenderer>().enabled = true;
        }
    }
	//Qasim
	
	// Use this for initialization
	void Start () {
		moveEngine = GetComponent<MoveEngine>();
		inputManager = GetComponent<InputManager>();
		collider = GetComponent<Collider2D>();
		counter_life = 0;
		mainSlider = (GameObject.FindObjectsOfType(typeof(Slider)) as Slider[])[0];
		slider_fill = (GameObject.Find("SliderFill")).GetComponent<Image>();
		spirit = Resources.Load("Prefabs/Spirit");
	}
	
	// Update is called once per frame
	void Update () {
		if (is_player)
		{
			grow_old();
		}
	}

	void grow_old() {
		counter_life += Time.deltaTime;
		mainSlider.value = (max_life - counter_life)/max_life;
		if (mainSlider.value > 0.5f)
		{
			slider_fill.color = new Color(0f,0.8f,0f);
		}
		else if (mainSlider.value > 0.2f)
		{
			slider_fill.color = new Color(0.8f,0.8f,0f);
		}
		else
		{
			slider_fill.color = new Color(0.8f,0f,0f);
		}
		if (counter_life > max_life)
		{
			// TODO : animation
			if (age < Age.ELDER)
			{
				counter_life = 0f;
				age++;
			}
			else
			{
				Character nearest = find_nearest_possessable();
				if (nearest != null)
					nearest.switch_corpse(this);
				else
				{
					// TODO : Message caché
					// "Félicitations, cette situation n'était pas supposée arriver, voici une nouvelle chance de continuer"
					counter_life = 0;
					age = Age.CHILD;
				}
			}
		}
	}

	// finds the nearest Character you can possess
	public Character find_nearest_possessable() {
		float distance_min = -1f;
		float distance_cur;
		Character[] others = GameObject.FindObjectsOfType(typeof(Character)) as Character[];
		Character nearest = null;
		foreach ( Character other in others)
		{
			distance_cur = (other.GetComponent<Transform>().position - transform.position).magnitude;
			if (can_ultimate_possess(other, distance_cur, distance_min))
			{
				distance_min = distance_cur;
				nearest = other;
			}
		}
		return nearest;
	}

	// returns if the Character can be possessed with the last chance nearest Character available switch
	private bool can_ultimate_possess (Character other, float distance_cur, float distance_min)
	{
		return (other != this &&						// not the same object
				other.is_young_enough() &&				// young enough
				other.GetComponent<SpriteRenderer>().isVisible &&	// is seen by the camera
				!other.has_dialogue &&					// has no dialog
				(distance_cur < distance_min || distance_min == -1f));	// is less far than another
	}

	// returns if the Character is young enough to be possessed
	public bool is_young_enough() {
		if (age < Age.ELDER)
			return true;
		else 
			return counter_life < max_life;
	}

	public void set_active_player() {
		is_player = true;
		moveEngine.can_move = true;
		collider.isTrigger = false;
		inputManager.time_last_proxy_possess = Time.time;
	}

	public void switch_corpse(Character other) {
		if (is_young_enough() && !has_dialogue)
		{
			MoveEngine other_move_engine = other.GetComponent<MoveEngine>();
			InputManager other_input_manager = other.GetComponent<InputManager>();
			Collider2D other_collider = other.GetComponent<Collider2D>();

			other.is_player = false;
			other_move_engine.move(Vector2.zero);
			other_move_engine.can_move = false;
			other_input_manager.chase_mouse = false;
			other_collider.isTrigger = true;
			// TODO : launch animation
			GameObject spirit_orb = Instantiate(spirit) as GameObject;
			spirit_orb.GetComponent<SpiritTravel>().initialize(other.transform.position, transform.position, animation_time);
			//
			Invoke("set_active_player", animation_time);
		}
	}
}
