using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Color _colorWhite, _colorBlack;
    [SerializeField] private SpriteRenderer _rendrer;
    [SerializeField] private GameObject _highlight;

    public void Init(bool isBlack)
    {
        _rendrer.color = isBlack ? _colorBlack : _colorWhite;
    }

    private void OnMouseEnter()
    {
        _highlight.SetActive(true);
    }

    private void OnMouseExit()
    {
        _highlight.SetActive(false);
    }

}
