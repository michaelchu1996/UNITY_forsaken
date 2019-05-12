using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour {

    [SerializeField] private HealthBar healthBar;
    [SerializeField] private HungerBar hungerBar;
    public static float health = 1f;
    public static float hunger = 1f;
	private void Start () {
        FunctionPeriodic.Create(() => {

            if (health > .01f) {
                Time.timeScale = 1;
                //health -= .01f;
                healthBar.SetSize(health);

                if (health < .3f) {
                    // Under 30% health
                    if ((int)(health * 100f) % 3 == 0) {
                        healthBar.SetColor(Color.white);
                    } else {
                        healthBar.SetColor(Color.red);
                    }
                }
            } else {
                //health = 1f;
                healthBar.SetColor(Color.red);
                SceneManager.LoadScene("Startscene");
                Time.timeScale = 0;
            }


            //Reducing the hunger bar by time
            if (hunger > .01f)
            {
                hungerBar.SetSize(hunger);
                hunger -= 0.005f;

            }
            else
            {
                //hungerBar.SetSize(hunger);
                health -= 0.005f;
            }



        }, .05f);



	}
}
