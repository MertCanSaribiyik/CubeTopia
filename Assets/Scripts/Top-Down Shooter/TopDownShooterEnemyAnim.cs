using UnityEngine;

public class TopDownShooterEnemyAnim : MonoBehaviour
{
    [SerializeField] private Transform[] squares;
    [SerializeField] private float[] rotatePerSeconds;

    private void Update() {
        for(int i = 0; i < squares.Length; i++) {
            squares[i].transform.Rotate(0f, 0f, 360f * rotatePerSeconds[i] * Time.deltaTime);   
        }
    }
}
