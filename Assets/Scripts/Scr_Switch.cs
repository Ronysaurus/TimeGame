using UnityEngine;

public class Scr_Switch : MonoBehaviour
{
    public GameObject greenSwitch, redSwitch;
    public GameObject door;

    private void OnTriggerEnter(Collider c)
    {
        greenSwitch.SetActive(true);
        redSwitch.SetActive(false);
        door.SetActive(false);
    }

    private void OnTriggerExit(Collider other)
    {
        greenSwitch.SetActive(false);
        redSwitch.SetActive(true);
        door.SetActive(true);
    }
}