using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseManager : MonoBehaviour
{

    private bool isAttackPhase = true;
    public GameObject Attack;
    public GameObject Defense;
    public int noteCounter = 0;

    //attack obj
    public GameObject comboText;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isAttackPhase = !isAttackPhase;
        }
        // if it's the attack phase and the gameobject attack is not active yet
        if (isAttackPhase && !Attack.activeSelf)
        {
            Attack.SetActive(true);
            Defense.SetActive(false);

            comboText.SetActive(true);
        }
        else if (!isAttackPhase && !Defense.activeSelf)
        {
            Attack.SetActive(false);
            Defense.SetActive(true);

            comboText.SetActive(false);
            GameObject[] keys = GameObject.FindGameObjectsWithTag("KeyNote");
            foreach (GameObject key in keys)
            {
                Destroy(key);
            }
        }
    }
}
