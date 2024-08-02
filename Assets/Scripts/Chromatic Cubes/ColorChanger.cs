using UnityEngine;
using UnityEngine.EventSystems;

public class ColorChanger : MonoBehaviour
{
    private Animator animator;

    private SpriteRenderer spriteRenderer;
    [SerializeField] private Color[] colors;
    private int index;

    private void Awake() {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        
        index = 0;
    }

    private void Update() {
        if(Input.touchCount > 0 && !GameManager.Instance.GameIsPaused) {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began && !GameManager.Instance.IsPointerOverUIObject(touch)) {
                animator.SetTrigger("change");
                spriteRenderer.color = colors[index];
                index = (index == colors.Length - 1) ? 0 : index + 1;
            }

        }
    }

}
