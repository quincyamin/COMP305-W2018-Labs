using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour {


    public Sprite mySprite;
    public GameObject character;

    private SpriteRenderer rend;

	// Use this for initialization
	void Start () {
        rend = character.GetComponent<SpriteRenderer>();
	}

    void OnMouseDown()
    {
        rend.sprite = mySprite;
    }


}
