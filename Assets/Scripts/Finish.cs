using Assets.Scripts;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.ParticleSystem;

public class Finish : MonoBehaviour
{
    public ParticleSystem particleFinish;

    public Game LevelIndex;



    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.collider.TryGetComponent(out Player player)) return;
        StartCoroutine(CoroutineFinish());
    }
    private IEnumerator CoroutineFinish()
    {
        particleFinish.Play();

        Debug.Log("Game Over");
        LevelIndex.LevelIndex++;//
        yield return new WaitForSeconds(1.2f);
        
        ReloadFinish();

        

    }
    private void ReloadFinish()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
