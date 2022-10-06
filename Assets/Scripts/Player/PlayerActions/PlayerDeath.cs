using System;
using System.Collections;
using Save;
using UnityEngine;

namespace Systems.Player_managers
{
    public class PlayerDeath : MonoBehaviour
    {
        public ISaver[] saversToLoadOnDeath;
        [SerializeField] private GameObject graphics;
        

        [SerializeField] private float respawnTime = .5f;
        private WaitForSeconds timeToWait;

        private void Awake()
        {
            timeToWait = new WaitForSeconds(respawnTime);
        }

        private IEnumerator Dead()
        {
            graphics.SetActive(false);
            
            yield return timeToWait;
            
            foreach (var saver in saversToLoadOnDeath)
            {
                if (!saver.loadOnDeath) continue;
                
                saver.Load();
            }

            graphics.SetActive(true); 
        }
    }
}
