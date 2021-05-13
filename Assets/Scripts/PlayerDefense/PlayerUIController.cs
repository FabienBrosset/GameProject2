using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIController : MonoBehaviour
{
    public Text hpText;
    public PlayerDefenseController playerDefenseController;
    public PlayerLifeManager playerLifeManager;

    // Start is called before the first frame update
    void Start()
    {
        hpText.text = playerLifeManager.hp.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        // Get hp only when it's in defense phase
        if (playerDefenseController.gameObject.activeSelf) { 
            hpText.text = playerLifeManager.hp.ToString();
        }
    }
}
