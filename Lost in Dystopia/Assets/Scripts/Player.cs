using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Fighter 
{
    private const int MAX_HEALTH = 100;
    public int goldCoins = 0;

    public int GoldCoins { get { return goldCoins; } set {goldCoins=value;} }
    public Inventory inventory;
    private void Start()
    {
        maxHealth = MAX_HEALTH;
        health = maxHealth;
        HealtBar.SetMaxHealth(maxHealth);
        
    }
    
}
