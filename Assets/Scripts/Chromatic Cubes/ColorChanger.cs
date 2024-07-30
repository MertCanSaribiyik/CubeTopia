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

            if (touch.phase == TouchPhase.Began && !IsPointerOverUIObject(touch)) {
                animator.SetTrigger("change");
                spriteRenderer.color = colors[index];
                index = (index == colors.Length - 1) ? 0 : index + 1;
            }

        }
    }

    //True if the touch is on the UI element, false otherwise 
    private bool IsPointerOverUIObject(Touch touch) {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current) {
            position = new Vector2(touch.position.x, touch.position.y)
        };

        var results = new System.Collections.Generic.List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }

}
