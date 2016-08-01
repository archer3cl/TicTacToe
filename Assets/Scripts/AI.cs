using UnityEngine;
using System.Collections;

public class AI : MonoBehaviour {    
    private static int _initialDepth = 0;
    private GridSpace _currentMoveChoice;
    private int _baseScore;
    private GameState _gameState;
    private GridSpace _piece;

    public GameState TakeTurn(GameState gameState) {
        if (gameState.Over()) {
            return gameState;
        }
        _gameState = gameState;
        _piece = gameState.playerPiece();
        return gameState.MakeMove(ChooseMove());
    }

    private GridSpace ChooseMove() {
        if (_gameState.Unplayed()) {
            return _gameState.RandomSpace();
        }
        if (_gameState.FinalMove()) {
            return _gameState.FinalMove();
        }
        return BestPossibleMove();
    }

    private GridSpace BestPossibleMove() {
        _baseScore = _gameState.availableMoves.Count;
        int bound = _baseScore + 1;
        int example = MinMax(_gameState, _initialDepth, -bound, bound);
        Debug.Log("Example Possible Move " + example);
        return _currentMoveChoice;
    }

    private int MinMax(GameState gameState, int depth, int lower_bound, int upper_bound) {
        if (gameState.Over()) {
            return EvaluateState(gameState, depth);
        }
        //Candidate Move Nodes
        foreach (GridSpace move in gameState.availableMoves) {
            GameState childBoard = gameState.MakeMove(move);
            int score = MinMax(childBoard, depth + 1, lower_bound, upper_bound);
            Debug.Log("MinMax Score = " + score);
        }
        return lower_bound;
    }

    private int EvaluateState(GameState gameState, int depth) {
        if (gameState.Won()) {
            return _baseScore - depth;
        } else if (gameState.Lost()) {
            return depth - _baseScore;
        } else {
            return 0;
        }
    }

    // void Awake() {

    // }


    // Use this for initialization

    //void Start () {

    // }


    // public void TakeTurn() {
    //     GridSpace chosenBlock = ChooseMove();
    //     chosenBlock.SetPiece(true);
    // }

    // public GridSpace ChooseMove() {
    //     if (Board.instance.Blank()) {
    //         return Board.instance.boardArray[Random.Range(0, 3)][Random.Range(0, 3)];
    //     }
    //     if (FinalMove()) {
    //         return Board.instance.blanks[0];
    //     }
    //     return BestPossibleMove();
    //     return null;
    // }

    // private bool FinalMove() {
    //     if (Board.instance.blanks.Count == 1) {
    //         return true;
    //     }
    //     return false;
    // }

    //private GridSpace BestPossibleMove() {
    //    _baseScore = Board.instance.blanks.Count + 1;
    //    int bound = _baseScore + 1;
    //    MinMax(gameState, _initialDepth, -bound, bound);
    //    return null;
    //}

    //private int MinMax(GameState gameState, int depth, int lower_bound, int upper_bound) {
    //    if (gameState.IsOver()) {
    //        return EvaluateState(gameState, depth);
    //    }        
    //    foreach (GridSpace move in Board.instance.blanks) {
    //        GameState child_board = Board.instance.SimulatePlacingPiece(move);
    //        int score = MinMax(child_board, depth + 1, lower_bound, upper_bound);
    //    }
    //    return 0;        
    //}


}
