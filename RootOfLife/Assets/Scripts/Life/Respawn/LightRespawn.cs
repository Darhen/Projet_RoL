using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightRespawn : MonoBehaviour
{

    /* 
       [SerializeField] private Transform player;
       [SerializeField] private Transform respawnPoint;

       public Color sphere;

      public static bool GameIsPaused = false;
       public GameObject fadeOutMenuUI;


       void Update()
       {
           if (Color.sphere == color.red) //Si lumière devient rouge, commencer la séquence de mort. Après séquence de mort, revenir au checkpoint.
           {
               //StartCoroutine(CheckPoint());
               //DeathSequenceLight();
               player.transform.position = respawnPoint.transform.position;
           }
       }

        public void DeathSequenceLight() //pauseGame + animation perso qui meurt + waitforseconds (3 secondes) + fade out
        {
            StartCoroutine(Respawn());
            GameIsPaused = true;
            fadeOutMenuUI.SetActive(true);
        }

       IEnumerator CheckPoint()
       {
          animator.SetTrigger("LightDeath");
           yield return new WaitForSeconds(2f);
          fadeOutMenuUI.SetActive(true);
           Instantiate(player, respawnPoint.position, respawnPoint.rotation);
       }*/

}
