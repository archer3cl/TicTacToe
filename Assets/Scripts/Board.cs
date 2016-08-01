using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class Board : MonoBehaviour {
    public static Board instance = null;
    public GridSpace[] btnList;    
    public GridSpace[][] boardArray;
    public List<GridSpace> blanks;
    public Vector2 gridSize;


    public int numberOfSpaces, numberOfBlanks, numberOfOccupied;    

	//void Awake () {
 //       gridSize = new Vector2(3, 3);
 //       blanks = new List<GridSpace>();
 //       numberOfSpaces = numberOfBlanks = (int)gridSize.y;
 //       numberOfOccupied = 0;
 //       int index = 0;        
 //       boardArray = new GridSpace[(int)gridSize.x][];
 //       for (int x = 0; x < gridSize.x; x++) {
 //           boardArray[x] = new GridSpace[(int)gridSize.y];
 //           for (int y = 0; y < gridSize.y; y++) {                
 //               boardArray[x][y] = btnList[index];
 //               boardArray[x][y].Position = new Vector2(x,y);
 //               blanks.Add(boardArray[x][y]);
 //               index++;
 //           }
 //       }        

 //       if (instance == null) {
 //           instance = this;
 //       } else if (instance != this) {
 //           Destroy(gameObject);
 //       }

 //   }

 //   void Start() {        
 //   }
	
	public bool Blank() {
        return numberOfSpaces == numberOfBlanks;
    }

    public Board PlacePiece(string piece, GridSpace block) {
        block.currentMark = piece;
        boardArray[(int)block.Position.x][(int)block.Position.y] = block; ;
        numberOfOccupied += 1;
        blanks.Remove(block);
        return this;   
    }
}
