using UnityEngine;
using UnityEngine.UI;

public class Scr_ScoreManager : MonoBehaviour
{
    public Text cloneText, moveText;

    public void SetScores(int clones, int moves)
    {
        cloneText.text = "Clones: " + clones;
        moveText.text = "Moves: " + moves;
    }
}