using System.Collections.Generic;
using UnityEngine;
using NCMB;

public class DataFetch : MonoBehaviour {

    // Use this for initialization
    void Start() {

        //점수가 10보다 큰 플레이어의 데이터를 취득한다.
        FetchScoreList(10);
    }

    private void FetchScoreList(int higherThan)
    {
        //여러 개의 NCMBObject를 취득하는 쿼리를 작성
        NCMBQuery<NCMBObject> query = new NCMBQuery<NCMBObject>("PlayerData");

        //조건 설정
        query.WhereGreaterThan("Score", higherThan);

        query.FindAsync((List<NCMBObject> objList, NCMBException e) =>
        {
            if (e != null)
            {
                //오류 시 처리
            }
            else
            {
                //성공 시 처리
                foreach (NCMBObject obj in objList)
                {
                    Debug.Log(
                        "PlayerName:" + obj["PlayerName"] +
                        ", Score:" + obj["Score"] +
                        ", Coin:" + obj["Coin"]
                        );
                }
            }
        });
    }
}