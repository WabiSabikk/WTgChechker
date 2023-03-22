using WTgChechker.Helper;
using WTgChechker.Model;

FileManage fileManage = new();
TgWorker tgWorker = new();
WTelegram.Helpers.Log = (lvl, str) => { };

Loger.Print("Click 'Enter' for start");
Console.ReadLine();

var files = await fileManage.GetConfigSessions();


foreach (var file in files)
{
    bool isOk = await tgWorker.Login(file);
    if (!isOk)
        fileManage.MoveBad(file.ClientConfig.session_pathname);
    else
        fileManage.MoveGood(file.ClientConfig.session_pathname);
}


Loger.Print("END");
Console.ReadLine();

//string s_proxy = account.Proxy;
//if (!string.IsNullOrEmpty(s_proxy))
//    client.TcpHandler = async (address, port) =>
//    {
//        var data_proxy = s_proxy.Split(":");
//        var proxy = new HttpProxyClient(data_proxy[0], int.Parse(data_proxy[1]), data_proxy[2], data_proxy[3]);
//        return proxy.CreateConnection(address, port);
//    };
