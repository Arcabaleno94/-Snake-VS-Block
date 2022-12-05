using Assets.Scripts;
using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float BouceSpeed;
    public Rigidbody Rigidbody;
    public Game Game;
    public Material yourMaterial;
    public ParticleSystem particle;

    public AudioSource JumpSound;

    public Platform CurrentPlatform;

    


    private void Start()
    {
        JumpSound = GetComponent<AudioSource>();
    }
    public void ReachFinish()
    {
        Game.OnPlayerReachedFinish();
        Rigidbody.velocity = Vector3.zero;
    }

    public void Bounce()
    {
        Rigidbody.velocity = new Vector3(0,BouceSpeed,0);
        
    }

    public void Die()
    {
        StartCoroutine(CoroutineSample());
        Game.OnPlayerDied();
        Rigidbody.velocity = Vector3.zero;
        
    }

    private IEnumerator CoroutineSample()
    {
        particle.Play();

        yourMaterial = GetComponent<MeshRenderer>().material;

        yield return new WaitForSeconds(1f);

        yourMaterial.SetFloat("_DissolveAmount", 0.2f);

        yield return new WaitForSeconds(0.5f);
        
        yourMaterial.SetFloat("_DissolveAmount", 0.4f);

        yield return new WaitForSeconds(0.5f);

        yourMaterial.SetFloat("_DissolveAmount", 0.6f);

        yield return new WaitForSeconds(0.5f);

        yourMaterial.SetFloat("_DissolveAmount", 1.2f);


        Debug.Log("Game Over");

        yield return new WaitForSeconds(0.5f);

        ReloadLevel();

    }

    private void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnCollisionEnter(Collision collision)//
    {
      if (collision.collider.TryGetComponent(out Sector sector))
      {
            JumpSound.Play();
      }
    }

    private void OnTriggerExit(Collider other)
    {
        foreach (Transform pad in other.transform)
        {
            
            pad.GetComponent<Rigidbody>().isKinematic = false;
            pad.GetComponent<Rigidbody>().AddExplosionForce(900, other.transform.position, 10);
            //gameManager.musicController.PlayOneShot(gameManager.padDestroySound, 0.3f);
        }

    }

}
