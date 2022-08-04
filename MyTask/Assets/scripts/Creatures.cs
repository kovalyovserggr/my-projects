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

    public float minimumTimeBeforeAttack; // ��������� ��������� �� �����
    public float timeToPrepareFoTheAttack; // ���� ���� ��������� �������� �����
    protected Player player;
    protected float timeStep;
    
    public event Action<GameObject> IWillDie;

    // �� ��������� �����������
    public override void gettingDamaged(int degreeOfDamage)
    {
        // ��������� �����������
        hp -= degreeOfDamage;

        // ����� ��������� ����� ������������ ����������� 
        if (hp < 1)
        {
            IWillDie(gameObject);
        }
    }
}

public abstract class CollidableEnemy : Enemy
{
    
}