using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PlayerData", fileName = "PlayerData")]
public class PlayerData : MonoBehaviour
{
    public string playerName;
    public int playerScore;
    public int playerRank;
    private void OnEnable()
    {
        switch (playerName)
        {
            case "1P":
                playerScore = GameManager.score0;
                break;
            case "2P":
                playerScore = GameManager.score1;
                break;
            case "3P":
                playerScore = GameManager.score2;
                break;
            case "4P":
                playerScore = GameManager.score3;
                break;
        }
        //print(GameManager.score0);
    }

}
