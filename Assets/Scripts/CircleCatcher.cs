using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CircleCatcher : MonoBehaviour
{

    public int facingWay = 0; //up, right, down, left 0,1,2,3

    public int catched = 0;
    public int missed = 0;
    public int biggestCombo = 0;
    public int actualCombo = 0;

    public int bossLife = 1000;

    public Text comboText;
    public Text bossText;

    public string textAnim;

    public Animator bossAnim;

    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            MoveArrow(0);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveArrow(1);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            MoveArrow(2);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveArrow(3);
        }

        comboText.transform.Translate(Vector3.up * Time.deltaTime * 40f);
    }

    void StopAnim()
    {
        anim.Rebind();
        anim.enabled = false;

        if (facingWay == 0)
        {
            this.transform.eulerAngles = new Vector3(0f, 0f, 90f);
        }
        else if (facingWay == 1)
        {
            this.transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
        else if (facingWay == 2)
        {
            this.transform.eulerAngles = new Vector3(0f, 0f, 270f);
        }
        else if (facingWay == 3)
        {
            this.transform.eulerAngles = new Vector3(0f, 0f, 180f);
        }
    }

    void MoveArrow(int way)
    {
        if (facingWay == way)
            return;

        anim.enabled = true;

        if (facingWay == 3 && way == 0)
        {
            anim.Play("MusicCatcherTurnRight", 0, 0.75f);
        }
        else if (facingWay == 0 && way == 3)
        {
            anim.Play("MusicCatcherTurnLeft", 0, 0f);
        }
        else if (facingWay < way)
        {
            //turn right
            if (way == 0)
            {
                anim.Play("MusicCatcherTurnRight", 0, 0.75f);
            }
            else if (way == 1)
            {
                anim.Play("MusicCatcherTurnRight", 0, 0f);
            }
            else if (way == 2)
            {
                anim.Play("MusicCatcherTurnRight", 0, 0.25f);
            }
            else if (way == 3)
            {
                anim.Play("MusicCatcherTurnRight", 0, 0.50f);
            }
        }
        else if (facingWay > way)
        {
            //turn left
            if (way == 3)
            {
                anim.Play("MusicCatcherTurnLeft", 0, 0f);
            }
            else if (way == 2)
            {
                anim.Play("MusicCatcherTurnLeft", 0, 0.25f);
            }
            else if (way == 1)
            {
                anim.Play("MusicCatcherTurnLeft", 0, 0.50f);
            }
            else if (way == 0)
            {
                anim.Play("MusicCatcherTurnLeft", 0, 0.75f);
            }
        }

        Invoke("StopAnim", 0.20f);
        facingWay = way;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "KeyNote")
        {
            string directionCircle = "";

            if (facingWay == 0)
                directionCircle = "down";
            else if (facingWay == 1)
                directionCircle = "left";
            else if (facingWay == 2)
                directionCircle = "up";
            else if (facingWay == 3)
                directionCircle = "right";

            comboText.transform.localPosition = new Vector3(95f, 0f, 0f);

            if (col.transform.GetComponent<KeyNoteScript>().direction == directionCircle)
            {
                //Debug.Log("Got Key !");
                catched += 1;
                actualCombo += 1;

                //text combo !
                comboText.text = "Combo X" + actualCombo;
                comboText.color = Color.yellow;

            }
            else
            {
                //Debug.Log("Missed ...");
                missed += 1;

                comboText.text = "Missed !";
                comboText.color = Color.red;

                

                if (actualCombo != 0)
                {
                    bossAnim.Play(textAnim);

                    bossLife -= (actualCombo * actualCombo);

                    if (bossLife <= 0)
                    {
                        PlayerPrefs.SetInt("player_score", 1);
                        SceneManager.LoadScene(5);
                        bossText.text = "DEAD";
                    }
                    else
                    {
                        bossText.text = "" + bossLife;
                    }
                }

                if (actualCombo > biggestCombo)
                    biggestCombo = actualCombo;
                actualCombo = 0;
            }

            Destroy(col.gameObject);
        }
    }
}
