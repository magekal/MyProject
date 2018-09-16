using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NCMB;

public class DataSave : MonoBehaviour {

	// Use this for initialization
	void Start () {

        SavePlayerData("BBB", 5, 300);
	}

    public void SavePlayerData(string playerName, int score, int coin)
    {
        NCMBObject obj = new NCMBObject("playerData");

        obj.Add("PlayerName", playerName);
        obj.Add("Score", score);
        obj.Add("Coin", coin);

        obj.SaveAsync((NCMBException e) =>
        {
            if (e != null)
            {
                Debug.Log("저장 실패, 통신 환경을 확인하십시오.");
            }
            else
            {
                Debug.Log("저장 성공!");
            }
        });
    }

}
