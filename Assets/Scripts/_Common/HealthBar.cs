using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Slider slider;
    [SerializeField] private PlayerInfo playerInfo;

    private void Awake() {
        slider = GetComponent<Slider>();
        slider.value = playerInfo.health;
    }

    private void Update() {
        if(slider.value != playerInfo.health) {
            slider.value = playerInfo.health;
        }
    }
}
