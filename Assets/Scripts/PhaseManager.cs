using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseManager : MonoBehaviour
{

    private bool isAttackPhase = true;
    public GameObject Attack;
    public GameObject Defense;
    public int noteCounter = 0;


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
        } else if (!isAttackPhase && !Defense.activeSelf)
        {
            Attack.SetActive(false);
            Defense.SetActive(true);
        }
    }
}
