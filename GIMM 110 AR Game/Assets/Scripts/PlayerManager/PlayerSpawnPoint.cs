using UnityEngine;

public class PlayerSpawnPoint : MonoBehaviour
{
    private void Start()
    {
        if (GameManager.Instance != null)
        {
            GameObject activePlayer = GameManager.Instance.GetActivePlayer();
            if (activePlayer != null)
            {
                activePlayer.transform.position = transform.position;
                Debug.Log($"Active player spawned at {transform.position}");
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, 0.5f);
        Gizmos.DrawLine(transform.position, transform.position + Vector3.up * 2f);

#if UNITY_EDITOR
        UnityEditor.Handles.Label(transform.position + Vector3.up * 2.5f, "Player Spawn");
#endif
    }
}