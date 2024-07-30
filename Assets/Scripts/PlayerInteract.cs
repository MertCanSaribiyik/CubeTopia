using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.CompareTag("InteractiveObjects")) {
            collision.gameObject.GetComponent<IInteraction>().Interact();
        }
    }
}
