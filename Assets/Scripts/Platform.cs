using UnityEngine;

namespace Assets.Scripts
{
    public class Platform : MonoBehaviour
    {
        public AudioSource DefuseSound;


        private void Start()
        {
            DefuseSound = GetComponent<AudioSource>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Player player))
            {
                player.CurrentPlatform = this;
            }
            

        }
        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out Player player))
            {
                DefuseSound.Play();

                //Destroy(gameObject);
            }
            
            
        }
        private void OnCollisionEnter(Collision collision)//
        {
            if (collision.collider.TryGetComponent(out Platform platform))
            {
                
            }
        }

    }
}