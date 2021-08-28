using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TankController), typeof(Inventory))]
public class Player : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI healthText;

    [SerializeField] int _maxHealth = 3;
    int _currentHealth;
    public int CurrentHealth
    {
        get => _currentHealth;
        set
        {
            _currentHealth = value;
            healthText.text = _currentHealth.ToString();
        }
    }

    bool _canTakeDamage;
    public bool CanTakeDamage
    {
        get => _canTakeDamage;
        set => _canTakeDamage = value;
    }

    TankController _tankController;
    Inventory _inventory;

    private void Awake()
    {
        _tankController = GetComponent<TankController>();
        _inventory = GetComponent<Inventory>();
    }

    private void Start()
    {
        CurrentHealth = _maxHealth;
        CanTakeDamage = true;
    }

    public void IncreaseHealth(int amount)
    {
        CurrentHealth = Mathf.Clamp(CurrentHealth, 0, _maxHealth);
    }

    public void DecreaseHealth(int amount)
    {
        if (CanTakeDamage)
        {
            CurrentHealth -= amount;
            if (_currentHealth <= 0)
                Kill();
        }
    }

    public void Kill()
    {
        gameObject.SetActive(false);
        // particles
        // sounds
    }
}
