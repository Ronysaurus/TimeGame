using UnityEngine;

public class Scr_Switch : MonoBehaviour
{
    public GameObject greenSwitch, redSwitch;
    public GameObject door;
    public int index;

    private int clones;

    private void OnTriggerEnter(Collider c)
    {
        clones++;

        greenSwitch.SetActive(true);
        redSwitch.SetActive(false);
        door.SetActive(false);
    }

    private void OnTriggerExit(Collider c)
    {
        clones--;

        if (clones > 0)
            return;

        greenSwitch.SetActive(false);
        redSwitch.SetActive(true);
        door.SetActive(true);
    }
}