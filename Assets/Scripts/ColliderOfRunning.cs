using UnityEngine;

namespace SnowSmile02
{
    public class ColliderOfRunning : MonoBehaviour
    {
        Enemy _Enemy;

        void Start()
        {
            _Enemy = gameObject.transform.parent.gameObject.GetComponent<Enemy>();
        }

        void OnTriggerEnter2D(Collider2D other) 
        {
            if (other.CompareTag("Player"))
            {
                _Enemy.isRunning = true;
                ClientPlayerState.AddFactorsOfState(1);
            }
        }

        void OnTriggerStay2D(Collider2D other) 
        {
            if (other.CompareTag("Player"))
            {
                _Enemy.isRunning = true;
                ClientPlayerState.AddFactorsOfState(1);
            }
        }

        void OnTriggerExit2D(Collider2D other) 
        {
            if (other.CompareTag("Player"))
            {
                _Enemy.isRunning = false;
                ClientPlayerState.RemoveFactorsOfState(1);
            }            
        }
    }
}

