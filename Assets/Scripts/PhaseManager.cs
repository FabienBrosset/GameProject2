using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseManager : MonoBehaviour
{

    private bool isAttackPhase = true;
    public GameObject Attack;
    public GameObject Defense;
    public int noteCounter = 0;
    public AudioSource audioSource;

    private int phaseCounter = 1;

    public float phaseChangingTime = 0;

    //attack obj
    public GameObject comboText;

    public void CalculatePhaseChangingTime(float totalMusicTime)
    {
        // Divide by 4 to have 2 attack phase and 2 defense phase
        phaseChangingTime = totalMusicTime / 4;
    }

    void Update()
    {
        if (phaseChangingTime * phaseCounter <= audioSource.time && phaseChangingTime != 0)
        {
            isAttackPhase = !isAttackPhase;
            phaseCounter += 1;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isAttackPhase = !isAttackPhase;
        }
        CheckForPhaseChange();
    }

    void CheckForPhaseChange()
    {
        // if it's the attack phase and the gameobject attack is not active yet
        if (isAttackPhase && !Attack.activeSelf)
        {
            Attack.SetActive(true);

            PlayerAttackManager playerAttackManager = Attack.GetComponentInChildren<PlayerAttackManager>();
            playerAttackManager.justChangedPhase = true;
            playerAttackManager.changingPhaseTime = Time.time;
            Defense.SetActive(false);

            comboText.SetActive(true);
        }
        else if (!isAttackPhase && !Defense.activeSelf)
        {
            Attack.SetActive(false);
            Defense.SetActive(true);
            PlayerDefenseManager playerDefenseManager = Defense.GetComponentInChildren<PlayerDefenseManager>();
            playerDefenseManager.justChangedPhase = true;
            playerDefenseManager.changingPhaseTime = Time.time;

            comboText.SetActive(false);
            GameObject[] keys = GameObject.FindGameObjectsWithTag("KeyNote");
            foreach (GameObject key in keys)
            {
                Destroy(key);
            }
        }
    }
}
