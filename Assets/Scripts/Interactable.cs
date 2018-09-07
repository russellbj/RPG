using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;
    bool hasInteracted = false;
    public Transform interactionTransform;
    bool isFocus = false;
    Transform player;
    
    void Update()
    {
        if(isFocus)
        {
            float distance = Vector3.Distance(player.position, interactionTransform.position);
            if (distance <= radius && hasInteracted == false)
            {
                Interact();
                hasInteracted = true;
            }
        }
    }

    public virtual void Interact()
    {
        // this method is meant to be overwritten

        Debug.Log("Interacting with " + interactionTransform.name);
    }

    public void OnFocused(Transform playerTransform)
    {
        isFocus = true;
        player = playerTransform;
        hasInteracted = false;
    } 

    public void OnDefocused()
    {
        hasInteracted = false;
        isFocus = false;
        player = null;
    }

    void OnDrawGizmosSelected()
    {
        if(interactionTransform == null)
        {
            interactionTransform = transform;
        }

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, radius); 
    }
}
