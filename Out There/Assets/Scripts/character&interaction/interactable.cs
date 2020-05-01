using UnityEngine;

public class interactable : MonoBehaviour
{

    public float radius = 3f;
    void OnDrawGizmosSelected ()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}

