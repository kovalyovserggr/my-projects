using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.AI;


public class spawnMobs : MonoBehaviour
{
    public GameObject[] enemysPrefabs;
    int countEnemys;
    System.Random x;
    public Text text;
    int numberkilling = 0;
    [SerializeField]
    int limitEnemys;

    // Start is called before the first frame update
    void Start()
    {
        x = new System.Random();
        GameObject.Find("Player1").GetComponent<Player>().endGame += EndGame;
    }

    // Update is called once per frame
    void Update()
    {
        if(countEnemys < limitEnemys)
        {
            createEnemys();
        }
    }

    void createEnemys()
    {
        int index =  x.Next(3);
        GameObject go = Instantiate(enemysPrefabs[index]);
        go.GetComponent<Transform>().position = new Vector3(Convert.ToSingle(x.Next(-20, 20)-25), 0.5f , Convert.ToSingle(x.Next(-20, 20)));
        Enemy enemy = go.GetComponent<Enemy>();
        enemy.IWillDie += destroy;
        countEnemys++;
    }
    
    public void destroy(GameObject go)
    {
        //створити об'єкт бонус з аналогічними координатами
        //...

        // зруйнувати об'єкт
        Destroy(go);

        countEnemys--;

        numberkilling++;
        text.text = numberkilling.ToString();
    }

    void EndGame()
    {
       //...
    }
}
