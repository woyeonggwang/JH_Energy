using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeatCheckScore : MonoBehaviour
{
    public Ranking ranking;
    public int score;
    public int max;
    public float posXMin;
    public float posXMax;
    public float targetAmount;
    public float charTargetPosX;
    public double amount;
    public float charPosX;
    public Image scoreGauge;
    public Transform charImage;
    public GameObject scoreText;
    public GameObject gaugeDoneSound;
    public Image rank;
    public Sprite[] rankSpr;

    private void Start()
    {
        scoreText.SetActive(false);
        amount = 0;
        charPosX = posXMin;
    }
    private void Update()
    {
        targetAmount = Remap(score, 0, max, 0, 1);
        charTargetPosX = Remap(targetAmount, 0, 1, posXMin, posXMax);
        scoreGauge.fillAmount = 0.05f;
        scoreGauge.fillAmount = (float)amount;
        scoreText.GetComponent<Text>().text = score.ToString();
        charImage.transform.localPosition = new Vector3(charPosX, charImage.transform.localPosition.y, charImage.transform.localPosition.z);
        if (amount < targetAmount)
        {
            amount += 0.105*Time.deltaTime;
        }
        else
        {
            amount = targetAmount;
        }
        if (charPosX < charTargetPosX)
        {
            charPosX += 95*Time.deltaTime;
            gaugeDoneSound.SetActive(false);
        }
        else
        {
            if (score == max)
            {
                ranking.rankingDone = true;
            }
            rank.sprite = rankSpr[transform.GetComponent<PlayerData>().playerRank];
            rank.gameObject.SetActive(true);
            gaugeDoneSound.SetActive(true);
            charPosX = charTargetPosX;
            scoreText.SetActive(true);
        }
    }

    public static float Remap(float val, float in1, float in2, float out1, float out2)  //리맵하는 함수
    {
        return out1 + (val - in1) * (out2 - out1) / (in2 - in1);
    }

}
