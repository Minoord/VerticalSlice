using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSetDialoog : MonoBehaviour
{
    private string _moveDialoogRival;
    private string _moveDialoogPlayer;
    private string _pokemonNameRival;
    private string _pokemonNamePlayer;
    private string _pokemonMoveRival;
    private string _pokemonMovePlayer;

    public void ChangeMoveDia()
    {
        _moveDialoogRival = "Foe " + _pokemonNameRival + " used " + _pokemonMoveRival; // Test: add back later?
        _moveDialoogPlayer =  _pokemonNamePlayer + " used " + _pokemonMovePlayer; // Test: add back later?
    }

    public void StartDialogue()
    {

    }
}
