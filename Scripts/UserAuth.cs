using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NCMB;


public class UserAuth : MonoBehaviour {

    public string userName;
    public string password;
    public string email;

	// Use this for initialization
	void Start () {

        //SignUp(userName, password, email);
        LogIn(userName, password);
		
	}

    public void SignUp(string userName, string password, string email)
    {
        //NCMBUser의 인스턴스 작성
        NCMBUser user = new NCMBUser();

        //사용자명과 비밀번호 설정
        user.UserName = userName;
        user.Password = password;
        user.Email = email;

        //회원등록을 한다.
        user.SignUpAsync((NCMBException e) =>
        {
            if (e != null)
            {
                Debug.Log("신규 등록 실패: " + e.ErrorMessage);

            }
            else
            {
                Debug.Log("신규 등록 성공");
            }
        });
    }

    public void LogIn(string userName, string password)
    {
        NCMBUser.LogInAsync(userName, password, (NCMBException e) =>
         {
             if (e != null)
             {
                 Debug.Log("로그인 실패: " + e.ErrorMessage);
             }
             else
             {
                 Debug.Log("로그인 성공");
                 SetPoint(5);
             }
         });
    }

    public void SetPoint(int num)
    {
        if (NCMBUser.CurrentUser != null)
        {
            NCMBUser.CurrentUser["Point"] = num;

            NCMBUser.CurrentUser.SaveAsync((NCMBException e) =>
            {
                if (e != null)
                {
                    Debug.Log("저장 실패: " + e.ErrorMessage);
                }
                else
                {
                    Debug.Log("저장 성공");
                }
            });
        }
    }
	
}
