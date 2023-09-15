using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Color _colorWhite, _colorBlack;
    [SerializeField] private SpriteRenderer _rendrer;
    [SerializeField] private GameObject _highlight;
    [SerializeField] private GameObject _moveHighlight;

    public BaseChecker occupiedChecker;

    public bool isWalkable => occupiedChecker == null;

    public void Init(bool isBlack)
    {
        _rendrer.color = isBlack ? _colorBlack : _colorWhite;
    }

    public void EnableHighlight()
    {
        _moveHighlight.SetActive(true);

        
    }
    public void DisableHighlight()
    {
        _moveHighlight.SetActive(false);
    }

    private void OnMouseEnter()
    {
        _highlight.SetActive(true);
    }

    private void OnMouseExit()
    {
        _highlight.SetActive(false);
    }

    public void OnMouseDown()
    {
        if (occupiedChecker != null)
        {
            if (GameManager.Instance.CurrentState == GameState.WhiteTurn || GameManager.Instance.CurrentState == GameState.BlackTurn)
            {
                UnitManager.Instance.SetSelectedChecker((BaseChecker)occupiedChecker);
                GridManager.Instance.ShowPossibleMoves(this, GameManager.Instance.CurrentState);
                foreach (Tile t in GridManager.Instance.possibleMove)
                {
                    t.EnableHighlight();
                }
            }
            /*else if (GameManager.Instance.CurrentState == GameState.BlackTurn)
            {
                UnitManager.Instance.SetSelectedChecker((BaseChecker)occupiedChecker);
                GridManager.Instance.ShowPossibleMoves(this, occupiedChecker.faction);
                foreach (Tile t in GridManager.Instance.possibleMove)
                {
                    t.EnableHighlight();
                }
            }*/
        }
        else
        {
            if (UnitManager.Instance.SelectedChecker != null && GridManager.Instance.possibleMove.Contains(this))
            {
                SetChecker(UnitManager.Instance.SelectedChecker);
                UnitManager.Instance.SelectedChecker = null;
                foreach (Tile t in GridManager.Instance.possibleMove)
                {
                    t.DisableHighlight();
                    
                }
                GridManager.Instance.possibleMove.Clear();

                

                if (GameManager.Instance.CurrentState == GameState.WhiteTurn) GameManager.Instance.ChangeGameState(GameState.BlackTurn);
                else GameManager.Instance.ChangeGameState(GameState.WhiteTurn);
                
            }
        }
    }

    public void SetChecker(BaseChecker checker)
    {
        if (checker.OccupiedTile != null) checker.OccupiedTile.occupiedChecker = null;
        checker.transform.position = transform.position;
        occupiedChecker = checker;
        checker.OccupiedTile = this;
    }
}
