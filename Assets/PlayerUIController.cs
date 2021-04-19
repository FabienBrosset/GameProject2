using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIController : MonoBehaviour
{
    public Text hpText;
    private PlayerDefenseController playerDefenseController;

    // Start is called before the first frame update
    void Start()
    {
        playerDefenseController = gameObject.GetComponent<PlayerDefenseController>();
    }

    // Update is called once per frame
    void Update()
    {
        hpText.text = playerDefenseController.hp.ToString();
    }
}
