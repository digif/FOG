using UnityEngine;

namespace Systems.Player_managers
{
    public class PlayerDeath : MonoBehaviour
    {
        private Vector2 spawnPoint;

        private void Start()
        {
            spawnPoint = transform.position;
        }

        public void OnCollisionEnter2D(Collision2D col){
            if(col.gameObject.CompareTag("Enemy")){
                transform.position = spawnPoint;
            }
        }
    }
}
