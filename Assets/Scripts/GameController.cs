using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public static GameController instance = null;   
    public Board board;
    private AI ai;
    private string _playerMark;
    private string _aiMark;

    void Awake() {
        if (instance == null) {
            instance = this;
        }else if (instance != this) {
            Destroy(gameObject);
        }
        ai = this.GetComponent<AI>();
    }


	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public string PlayerMark
    {
        get { return _playerMark; }
        set { _playerMark = value; }
    }

    public string AIMark
    {
        get { return _aiMark; }
        set { _aiMark = value; }
    }

    public void MakeAIMove() {
        //if (IsGameOver()) {
          //  Debug.Log("Someone win");
        //}
        ai.TakeTurn();
    }

    public bool checkForWinner(GridSpace currentSpace) {        
        return IsWinningRow(currentSpace) || IsWinningCol(currentSpace) || IsWinningDiagonal(currentSpace) ;
    }

    private bool IsWinningRow(GridSpace currentSpace) {
        int xIndex = (int)currentSpace.Position.x;
        bool winningRow = false;
        for (int i = 0; i < board.gridSize.y; i++) {            
            if(board.boardArray[xIndex][i].currentMark != currentSpace.currentMark){
                winningRow = false;
                return winningRow;
            }            
            winningRow = true;
        }        
        return winningRow;
    }
    private bool IsWinningCol(GridSpace currentSpace) {
        int yIndex = (int)currentSpace.Position.y;
        bool winningCol = false;
        for (int i = 0; i < board.gridSize.x; i++) {
            if (board.boardArray[i][yIndex].currentMark != currentSpace.currentMark) {
                winningCol = false;
                return winningCol;
            }
            winningCol = true;
        }
        return winningCol;
    }
    private bool IsWinningDiagonal(GridSpace currentSpace) {
        bool onDiagonal = currentSpace.Position.x == currentSpace.Position.y || currentSpace.Position.y == -1 * currentSpace.Position.x + (board.gridSize.x - 1);        
        bool winningDiagonal = true;
        bool winningInverseDiagonal = true;
        if (onDiagonal) {            
            for (int i = 0; i < board.gridSize.x; i++) {
                if (board.boardArray[i][i].currentMark != currentSpace.currentMark) {
                    winningDiagonal = false;
                }
                if (board.boardArray[i][-1 * i + ((int)board.gridSize.x - 1)].currentMark != currentSpace.currentMark) {
                    winningInverseDiagonal = false;
                }                
            }
        } else {
            winningDiagonal = winningInverseDiagonal = false;
        }
        return winningDiagonal || winningInverseDiagonal;
    }

    public void EndGame() {

    }
    // Return if AI has won or draw the game    
    private bool IsGameOver() {
        return board.numberOfBlanks == 0;
    }

}
