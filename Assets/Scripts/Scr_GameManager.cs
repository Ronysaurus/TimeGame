using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scr_GameManager : MonoBehaviour
{
    private class positions
    {
        public Vector3 pos = new Vector3();
        public positions nextPos;
    }

    public int maxNumGhost;
    public GameObject GhostPrefab;
    public GameObject levelClear_panel;

    private int currentGhost;
    private positions lastPosition;
    private positions currentPos;
    private Transform Player_Tran;
    private positions[] myPositions;
    private positions[] heads;
    private List<GameObject> ghosts;
    private int numMoves;

    private void Start()
    {
        ghosts = new List<GameObject>();
        myPositions = new positions[maxNumGhost];
        heads = new positions[maxNumGhost];
        Player_Tran = FindObjectOfType<Scr_Player>().GetComponent<Transform>();
        currentPos = heads[currentGhost] = myPositions[currentGhost] = new positions();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            Move(Player_Tran.up);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            Move(-Player_Tran.up);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            Move(Player_Tran.right);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            Move(-Player_Tran.right);
        }

        if (Input.GetKeyDown(KeyCode.Space) && currentGhost < maxNumGhost - 1)
        {
            Return();
        }
    }

    private void Move(Vector3 position)
    {
        Player_Tran.Translate(position);
        numMoves++;

        currentPos.pos = position;
        SaveMovement();
        MoveGhosts();
    }

    private void SaveMovement()
    {
        lastPosition = currentPos;
        currentPos.nextPos = new positions();
        currentPos = currentPos.nextPos;
    }

    private void MoveGhosts()
    {
        if (currentGhost == 0)
            return;

        for (int i = 0; i < currentGhost; i++)
        {
            if (myPositions[i] != null)
            {
                ghosts[i].transform.Translate(myPositions[i].pos);
                ghosts[i].GetComponent<Scr_Ghost>().lastPos = myPositions[i].pos;
                myPositions[i] = myPositions[i].nextPos;
            }
        }
    }

    private void Return()
    {
        currentGhost++;
        Player_Tran.GetComponent<Scr_Player>().Return();
        GameObject ghost = Instantiate(GhostPrefab);
        ghosts.Add(ghost);
        currentPos = heads[currentGhost] = myPositions[currentGhost] = new positions();
        for (int i = 0; i < currentGhost - 1; i++)
        {
            ghosts[i].transform.position = Player_Tran.position;
            myPositions[i] = heads[i];
        }
    }

    public void LevelClear()
    {
        levelClear_panel.SetActive(true);
        FindObjectOfType<Scr_ScoreManager>().SetScores(currentGhost, numMoves);
        Scr_LevelManager.SetLevelCleared(SceneManager.GetActiveScene().buildIndex);
    }

    public Vector3 GetLastPos()
    {
        return lastPosition.pos;
    }

    public int GetNumMoves()
    {
        return numMoves;
    }
}