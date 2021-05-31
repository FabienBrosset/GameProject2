using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIController : MonoBehaviour
{
    public GameObject[] hpPoints;
    public PlayerDefenseController playerDefenseController;
    public PlayerLifeManager playerLifeManager;

    // Update is called once per frame
    void Update()
    {
        // Get hp only when it's in defense phase
        if (playerDefenseController.gameObject.activeSelf) {
            if (hpPoints.Length != playerLifeManager.hp)
            {
                Destroy(hpPoints[playerLifeManager.hp]);
            }
        }
    }
}
