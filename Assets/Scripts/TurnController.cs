using UnityEngine;
using System;

public class TurnController : MonoBehaviour {
    public bool isPlayer;

    public void SetMark() {
        if (isPlayer) {
            GameController.instance.PlayerMark = "X";
            GameController.instance.AIMark = "O";            
        } else {
            GameController.instance.PlayerMark = "O";
            GameController.instance.AIMark = "X";
            GameController.instance.MakeAIMove();
        }
    }
}
