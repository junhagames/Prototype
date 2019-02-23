using System;
using Nancy;
using WebMatrix.Data;

namespace Server.src.GameServer.Login
{
    public class LoginModule : NancyModule
    {
        public LoginModule()
        {
            Get["/{uname}/{pwd}"] = p =>
            {
                using (Database db = Database.Open("db"))
                {
                    dynamic uid = db.QueryValue("select uid from t_users where username=@0 and password=PASSWORD(@1)", p.uname, p.pwd);         // 데이터 베이스
                    if (uid != null)
                    {
                        Guid token = Guid.NewGuid();
                        //todo: 서버에 보내기
                        //...  
                        return Response.AsJson(new { Result = "OK", Token = token });
                    }
                    else
                    {
                        return Response.AsJson(new { Result = "Failed" });
                    }
                }
            };
        }
    }
}
