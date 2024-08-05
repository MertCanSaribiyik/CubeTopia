using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Slider slider;
    [SerializeField] private PlayerInfo playerInfo;

    private void Awake() {
        slider = GetComponent<Slider>();
        slider.value = playerInfo.healh;
    }

    private void Update() {
        if(slider.value != playerInfo.healh) {
            slider.value = playerInfo.healh;
        }
    }
}
