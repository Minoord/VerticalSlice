using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseHealthScript : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    [SerializeField] public float _curHealth;
    [SerializeField] private HealthColor _healthColor;
    [SerializeField] public Audioscript _audioscript;
    [SerializeField] private Animator _hitAni;
    private float damageTaken;
    private bool damage;
    private int healthdamage;
    public Slider healthSlider;
    [SerializeField] private Text _healthText;
    private float _barHealth;
    [SerializeField] private float timer = 0.98f;
    private float maxTimer;
    void Start()
    {
        _healthColor.ColourGreen();
        _curHealth = _maxHealth;
        Initialise();
        maxTimer = timer;
    }

    public void Update()
    {
        if (_healthText != null)
        {
            _healthText.text = _curHealth + "/ " + _maxHealth;
        }
        if (this.healthSlider.value <= 20)
        {
            _healthColor.ColourRed();
        }
        if (this.healthSlider.value <= 50 && healthSlider.value >= 21)
        {
            _healthColor.ColourYellow();
        }
        if (damage)
        {
            _curHealth -= damageTaken * Time.deltaTime;
            Debug.Log(_curHealth);
            UpdateHP();
            //Debug.Log("dealDamage");
            if (timer <= 0)
            {
                _curHealth = (int)_curHealth;
                timer = 0.98f;
                damage = false;
            }
        }
        timer -= Time.deltaTime;
        if (damage == false)
        {
            timer = 0.98f;
        }


    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(1f);
    }
    public void TakeDamage(float damageTakens)
    {
        damageTaken = damageTakens;
        damage = true;
        //UpdateHP();
        //play damaged animation
        StartCoroutine(Timer());
        if (_curHealth <= 0)
        {

            Faint();
            Debug.Log(".");
        }
    }
    protected virtual void Faint()
    {
        // Doe hier de Faint dingen
        // Play Animation
        _audioscript.FaintSFX();
        gameObject.SetActive(false);
    }

    public void Initialise()
    {
        UpdateHP();
    }

    public void UpdateHP()
    {
        if (_healthText != null)
        {
            _healthText.text = (int)_curHealth + "/ " + _maxHealth;
        }
        _barHealth = _curHealth / _maxHealth * 100;
        healthSlider.value = _barHealth;
        //bar calculations

    }
    public IEnumerator Timer()
    {
        _hitAni.SetBool("isHit", true);
        yield return new WaitForSeconds(1);
        _hitAni.SetBool("isHit", false);
    }
}