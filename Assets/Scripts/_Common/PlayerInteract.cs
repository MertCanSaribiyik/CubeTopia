using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) {
        CollisionInteract(collision.gameObject, "InteractiveObjects");
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        CollisionInteract(collision.gameObject, "InteractiveObjects");
    }

    private void OnTriggerExit2D(Collider2D collision) {
        CollisionInteract(collision.gameObject, "GivesScore");
    }

    private void CollisionInteract(GameObject collision, string tagName) {
        if (collision.CompareTag(tagName)) {
            collision.GetComponent<IInteraction>().Interact();
        }
    }
}
