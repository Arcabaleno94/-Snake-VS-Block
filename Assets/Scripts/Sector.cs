using System.Collections;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Sector : MonoBehaviour
{
    public bool IsGood = true;
    public Material Goodmaterial;
    public Material BadMaterial;
    public ParticleSystem particlePlatform;
    



    private void Awake()
    {
        UpdateMaterial();
    }

    private void UpdateMaterial()
    {
        Renderer sectorRenderer = GetComponent<Renderer>();
        sectorRenderer.sharedMaterial = IsGood ? Goodmaterial : BadMaterial;
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (!collision.collider.TryGetComponent(out Player player))
        {
            return;
        }
        Vector3 normal = -collision.contacts[0].normal.normalized;
        float dot = Vector3.Dot(normal, Vector3.up);

        if (dot < 0.5)
        {
            return;
        }
        if (IsGood)
            player.Bounce();
        
        else
            player.Die();
        
    
    }
    private void OnTriggerExit(Collider other)
    {
        foreach (Transform pad in other.transform)
        {
            particlePlatform.Play();
            
        }

    }


    private void OnValidate()
    {
        UpdateMaterial();
    }
}

