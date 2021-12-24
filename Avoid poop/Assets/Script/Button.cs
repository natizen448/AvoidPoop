using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    [SerializeField] Dropdown dropdown;
    public void Restart()
    {
        GameManager.instance.isGameRestart = true;
    }

    public void Set()
    {
        dropdown.gameObject.SetActive(true);
    }
    public void LevelSet()
    {   
        GameManager.instance.Level = dropdown.value;
    }

   public void GameStart()
    {
        GameManager.instance.isGameStart = true;
    }
}
