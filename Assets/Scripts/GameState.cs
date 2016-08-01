using UnityEngine;
using System.Collections.Generic;

public class GameState : MonoBehaviour {

    public Board board;
    public List<GridSpace> availableMoves;
    public string playerPiece;
    public string opponentPiece;
    private GridSpace _winnerSpace;

    public GameState() {
        board = new Board();
        availableMoves = board.blanks;
    }

	public bool Unplayed() {
        return board.Blank();
    }

    public GridSpace FinalMove() {
        return board.blanks.Count == 1 ? board.blanks[0] : null ;
    }

    public bool Over() {
        bool draw = board.numberOfBlanks == 0 && !ExistWinner();
        return ExistWinner() || draw;
    }

    public GameState MakeMove(GridSpace space) {
        GameState newState = this;
        newState.playerPiece = opponentPiece;
        newState.opponentPiece = playerPiece;
        newState.board = board.PlacePiece(playerPiece, space);
        return newState;
    }

    public GridSpace RandomSpace() {
        return board.boardArray[Random.Range(0, 3)][Random.Range(0, 3)];
    }
    
    
    private bool ExistWinner() {
        return IsWinningRow(currentSpace) || IsWinningCol(currentSpace) || IsWinningDiagonal(currentSpace);
    }
    private bool IsWinningRow(GridSpace currentSpace) {
        int xIndex = (int)currentSpace.Position.x;
        bool winningRow = false;
        for (int i = 0; i < board.gridSize.y; i++) {
            if (board.boardArray[xIndex][i].currentMark != currentSpace.currentMark) {
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
}
