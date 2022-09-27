using UnityEngine;

namespace SnowSmile02
{
    public class ColliderOfCore : MonoBehaviour
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
                ClientPlayerState.AddFactorsOfState(2);
            }            
        }

        void OnTriggerStay2D(Collider2D other) 
        {
        }

        void OnTriggerExit2D(Collider2D other) 
        {
        }
    }
}