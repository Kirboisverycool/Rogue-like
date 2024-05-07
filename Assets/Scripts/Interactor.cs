using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    [SerializeField] private Transform interactionPoint;
    [SerializeField] private float interactionPointRadius = 0.5f;
    [SerializeField] private LayerMask interactableMasks;
    [SerializeField] private int numFound;

    private readonly Collider2D[] colliders = new Collider2D[3];

    // Update is called once per frame
    void Update()
    {
        numFound = Physics2D.OverlapCircleNonAlloc(interactionPoint.position, interactionPointRadius, colliders, interactableMasks);

        if(numFound > 0)
        {
            var interactable = colliders[0].GetComponent<IInteractable>();

            if(interactable !=null && Input.GetKeyDown(KeyCode.G))
            {
                interactable.Interact(this);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(interactionPoint.position, interactionPointRadius);
    }
}
