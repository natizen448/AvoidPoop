using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeletePoop : MonoBehaviour
{

    void Update()
    {
        if (GameManager.instance.isGameEnd)
            Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Grand"))
            Destroy(this.gameObject);

        if (collision.CompareTag("Player"))
            GameManager.instance.isGameEnd = true;
    }
}
