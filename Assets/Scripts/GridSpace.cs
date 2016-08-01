using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class GridSpace : MonoBehaviour {

    public Button btn;
    public Text btnText;
    public string currentMark;    
    private Vector2 _position;

    void Awake() {        
    }

    public Vector2 Position
    {
        get { return _position; }
        set { _position = value; }
    }   

    public void SetPiece(bool isAI = false) {        
        if(isAI) {
            btnText.text = currentMark = GameController.instance.AIMark;
        } else {
            btnText.text = currentMark = GameController.instance.PlayerMark;
        }
        btn.interactable = false;
        Board.instance.PlacePiece(this);        
    }
}
