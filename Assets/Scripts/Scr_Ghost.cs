using UnityEngine;

public class Scr_Ghost : MonoBehaviour
{
    public Vector3 lastPos;

    private void OnTriggerEnter(Collider c)
    {
        if (c.CompareTag("Wall"))
        {
            this.transform.Translate(-lastPos);
        }
    }
}