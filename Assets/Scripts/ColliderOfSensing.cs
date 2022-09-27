using UnityEngine;

namespace SnowSmile02
{
    public class ColliderOfSensing : MonoBehaviour
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
                _Enemy.isSensing = true;
            }
        }

        void OnTriggerStay2D(Collider2D other) 
        {
            if (other.CompareTag("Player"))
            {
                _Enemy.isSensing = true;
            }
        }

        void OnTriggerExit2D(Collider2D other) 
        {
            if (other.CompareTag("Player"))
            {
                _Enemy.isSensing = false;
            }
        }
    }
}