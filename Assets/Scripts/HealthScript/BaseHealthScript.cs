using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseHealthScript : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] public int _curHealth;

    private PokeTeam _pokemon;

    void Start()
    {
        _curHealth = _maxHealth;
        _pokemon = GetComponentInParent<PokeTeam>();
        _pokemon.Initialise(_maxHealth);
    }

    public void TakeDamage(int damageTaken)
    {
        _curHealth -= damageTaken;
        _pokemon.UpdateHP(_curHealth);
        //play damaged animation
        if (_curHealth <= 0)
        {
            Faint();
        }
    }

    protected virtual void Faint()
    {
        // Doe hier de Faint dingen
        Debug.Log("Ik faint");
        // Temp
        _curHealth = _maxHealth;
    }
}