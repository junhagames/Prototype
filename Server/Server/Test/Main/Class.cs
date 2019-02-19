using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy.Hosting.Self;

namespace Server.Test.Main
{
    static NancyHost Host;

    static void Main(string[] args)
    {
        string url = ConfigurationManager.AppSettings["Url"];
        Host = new NancyHost(new Uri(url));
        Host.Start();
        Console.WriteLine("서버 실행했습니다, 서버 주소는: {0}", url);
        Console.ReadLine();     // 여기에서 반복문 써서 콘솔창에서 조작
    }
}
