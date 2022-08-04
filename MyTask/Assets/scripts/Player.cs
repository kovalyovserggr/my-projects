using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;


public class Player : Creatures
{
    public event Action endGame;
    public float speed;
    public Text text;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            shot();
        }
    }

    // дія отримання пошкодження
    public override void gettingDamaged(int degreeOfDamage)
    {
        // отримання пошкодження
        hp -= degreeOfDamage;



        // умова отримання гравцем смертельного пошкодження 
        if (hp < 1)
        {
            if (endGame != null)
                endGame();

            text.text = "End game!!!";
        }
        else 
        {
            text.text = hp.ToString();
        }
    }

    void shot()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1)); 
        RaycastHit hit; 

        if (Physics.Raycast(ray, out hit)) // випускаємо промінь
        {
            Enemy enemy = hit.collider.GetComponentInParent<Enemy>();
            Debug.Log("сила пострілу "+damage);
            if(enemy != null)
                enemy.gettingDamaged(damage);
        }
    }
}
