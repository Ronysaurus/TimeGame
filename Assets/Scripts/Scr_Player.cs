using UnityEngine;

public class Scr_Player : MonoBehaviour
{
    private Scr_GameManager gm;
    private Vector3 startingPoint;

    private void Start()
    {
        gm = FindObjectOfType<Scr_GameManager>();
        startingPoint = transform.position;
        Debug.Log(startingPoint);
    }

    private void OnTriggerEnter(Collider c)
    {
        if (c.CompareTag("Wall"))
        {
            this.transform.Translate(-gm.GetLastPos());
        }
    }

    public void Return()
    {
        this.transform.position = startingPoint;
    }
}