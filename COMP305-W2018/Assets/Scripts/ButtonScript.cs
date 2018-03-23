using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour {


    public Sprite mySprite;
    public GameObject character;

    private SpriteRenderer _rend;

	// Use this for initialization
	void Start () {
        _rend = character.GetComponent<SpriteRenderer>();
	}

    void OnMouseDown()
    {
        _rend.sprite = mySprite;
    }


}
