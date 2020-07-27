using UnityEngine;

public class Goal : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        if(col.CompareTag("Player"))
            LevelManager.OnGoalEnter();
    }
}