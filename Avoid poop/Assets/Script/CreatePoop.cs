using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePoop : MonoBehaviour
{
    [SerializeField] GameObject Poop;
    [SerializeField] GameObject Player;
    
    private int spawnPos1;
    private int createCount = 1;
    public bool isStopGame = false;
    private void Start()
    {
        
        
    }

    private void Update()
    {   
        if (GameManager.instance.isGameStart && createCount == 1)
        {
            createCount--;
            Create();
        }

        if (isStopGame)
            CancelInvoke("Create");
        
    }

    void Create()
    {
        spawnPos1 = Random.Range((int)(Player.transform.position.x - 15f), (int)(Player.transform.position.x + 16f));
        Instantiate(Poop, new Vector2(spawnPos1, 20), Quaternion.identity);
        Invoke("Create", GameManager.instance.coolTime);
    }
}
