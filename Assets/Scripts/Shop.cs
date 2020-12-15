using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject shopUI;
    public GameObject playerUI;

    private bool canEnter = true;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if(canEnter)
            {
                Time.timeScale = 0;

                shopUI.SetActive(true);
                playerUI.SetActive(false);

                canEnter = false;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        canEnter = true;
    }

    public void ResetTime()
    {
        Time.timeScale = 1;
    }
}
