using UnityEngine;

public class Scr_ExitPlataform : MonoBehaviour
{
    private void OnTriggerEnter(Collider c)
    {
        if (c.CompareTag("Player"))
            FindObjectOfType<Scr_GameManager>().LevelClear();
    }
}