using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class Creatures : MonoBehaviour
{
    public int hp;
    public int damage;

    public abstract void gettingDamaged(int degreeOfDamage);
}

public abstract class Enemy: Creatures
{
    [SerializeField]
    protected float timeNextStep;

    public float minimumTimeBeforeAttack; // тривалість підготовки до атаки
    public float timeToPrepareFoTheAttack; // відлік часу підготовки наступної атаки
    protected Player player;
    protected float timeStep;
    
    public event Action<GameObject> IWillDie;

    // дія отримання пошкодження
    public override void gettingDamaged(int degreeOfDamage)
    {
        // отримання пошкодження
        hp -= degreeOfDamage;

        // умова отримання мобом смертельного пошкодження 
        if (hp < 1)
        {
            IWillDie(gameObject);
        }
    }
}

public abstract class CollidableEnemy : Enemy
{
    
}