using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Growl : BaseAttack
{
    private GameObject target;

    private void Start()
    {
        _moveType = "normal";
        _ppMax = 40;
        _ppAmount = _ppMax; // Mark Added

        _dmgValue = 0;
        _accuracy = 100;

        pokemonName = GetComponentInParent<BasePokemon>().name; // Mark Added
    }
    private void Update()
    {
        target = GetComponentInParent<BasePokemon>().targetPokemon;
    }

    public override void Attack()
    {
        int hitOrMiss = Random.Range(1, 100);

        if (hitOrMiss <= _accuracy)
        {
            //play attack animation
            // Mark Begin
            FindObjectOfType<UseMoveDialogue>().UseMove("GROWL", pokemonName.ToUpper());
            // Mark End
            target.GetComponent<BasePokemon>().GetGrowled();
        }
        else
        {
            Debug.Log("Attack Missed");
        }
        _ppAmount -= 1;
    }
}
