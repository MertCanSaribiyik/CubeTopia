using UnityEngine;

public class HowToPlayMenu : MonoBehaviour
{
    private void Update() {
        if(Input.touchCount > 0) {
            gameObject.SetActive(false);
        }
    }
}
