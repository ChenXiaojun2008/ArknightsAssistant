using System.Net;

string url = "https://github.com/ChenXiaojun2008/ArknightsAssistant/releases/latest";
string save = @"update-cache.zip";

if (!File.Exists(save))
{
    Console.WriteLine("文件不存在，开始下载...");

    var tmp = save + ".tmp";
    using (var web = new WebClient())
    {
        await web.DownloadFileTaskAsync(url, tmp);
    }
    File.Move(tmp, save, true);
    Console.WriteLine("文件下载成功");
}
//TODO:对文件进行处理