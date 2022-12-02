using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AssistantCore;
using AssistantCore.Adb.ScreenShot;
using AssistantCore.Adb.Touch;
using AssistantCore.Json.ActionScript;
using AssistantCore.OpenCV.MatchSystem;

namespace ArknightsAssistant_GUI.Actuator
{
    public class Actuator
    {
        public List<int> missonTypes = new List<int>();

        public void add(int missonType) => missonTypes.Add(missonType);

        public void thread(object infomations) //0 adbPath 1 actionJsonName
        {
            string[] _infomations = (string[])infomations;
            ActionScript controller = new ActionScript();
            controller.readFromFile($"Jsons/{(string)_infomations[1]}.json");

            //返回大厅
            if (controller.list.isReturnToLobby == true)
            {
                Thread thread0 = new Thread(thread_returnToLobby);
                thread0.Start(_infomations[0]);
                while (thread0.IsAlive)
                    Application.DoEvents();
            }

            AdbScreenShot adbScreenShot = new AdbScreenShot(_infomations[0]);
            AdbTouch adbTouch = new AdbTouch(_infomations[0]);
            MatchSystem match = new MatchSystem();
            MatchResult result;

            //多重匹配
            if (controller.list.isMutiMatch == true)
            {
                //检测是否为黑色
                while (true)
                {
                    adbScreenShot.shotOnce("01.jpg");
                    if (match.isAllBlack("01.jpg") == false)
                        break;
                    Thread.Sleep(500);
                }

                //第一次检测
                bool isMatched = false;
                for (int i = 0; i < controller.list.firstMutiTimes; i++) 
                {
                    for (int j = 0; j < controller.list.mutiActions.Count; j++)
                    {
                        result = match.matchTemplate("01.jpg", controller.list.mutiActions[j].mutiTempImg);
                        if (result.similarity > 0.85)
                        {
                            for (int i1 = 0; i1 < controller.list.mutiActions.Count - j; i1++)
                            {
                                controller.list.mutiActions.RemoveAt(0);
                            }
                            adbTouch.click(result.X - 10, result.Y - 10);
                            isMatched = true;
                            break;
                        }
                    }
                    if (isMatched == true) 
                        break;
                }

                //第二次检测
                for (int i = 0; i < controller.list.mutiActions.Count; i++)
                {
                    Thread.Sleep(controller.list.mutiActions[i].beforeDelay);
                    while(true)
                    {
                        adbScreenShot.shotOnce("01.jpg");
                        result = match.matchTemplate("01.jpg", controller.list.mutiActions[i].mutiTempImg);
                        if (result.similarity > 0.85)
                        {
                            adbTouch.click(result.X - 10, result.Y - 10);
                            break;
                        }
                        Thread.Sleep(200);
                    }
                    Thread.Sleep(controller.list.mutiActions[i].afterDelay);
                }

                return;
            }

            //普通匹配
            int matchTimes;
            for (int i = 0; i < controller.list.actions.Count; i++)
            {
                if (controller.list.actions[i].matchTimes == -1)
                {
                    matchTimes = 999;
                }
                else matchTimes = controller.list.actions[i].matchTimes;
                for (int j = 0; j < matchTimes; j++)
                {
                    Thread.Sleep(controller.list.actions[i].beforeDelay);
                    adbScreenShot.shotOnce(Application.StartupPath);
                    result = match.matchTemplate("01.jpg", controller.list.actions[i].tempImg);
                    if (result.similarity < 0.85)
                    {
                        Thread.Sleep(1500);
                        continue;
                    }
                    if (controller.list.actions[i].clickType == 1)
                        adbTouch.click(result.X - 10, result.Y - 10);
                    Thread.Sleep(controller.list.actions[i].afterDelay);
                    break;
                }
            }
        }
        public void thread_returnToLobby(object adbPath)
        {
            AdbScreenShot adbScreenShot = new AdbScreenShot((string)adbPath);
            AdbTouch adbTouch = new AdbTouch((string)adbPath);
            MatchSystem match = new MatchSystem();
            MatchResult result;

            Thread.Sleep(5000);

            while (true)
            {
                adbScreenShot.shotOnce(Application.StartupPath);
                result = match.matchTemplate("01.jpg", "Resources/MainPanel/return.jpg");
                if (result.similarity < 0.9)
                    break;
                adbTouch.click(result.X - 5, result.Y - 5);
                Thread.Sleep(1000);
            }
        }
        public void thread_wait(object infomations) //0 adbPath 1 tempImg
        {
            string[] _infomations = (string[])infomations;

            AdbScreenShot adbScreenShot = new AdbScreenShot(_infomations[0]);
            MatchSystem match = new MatchSystem();
            MatchResult result;

            while (true)
            {
                adbScreenShot.shotOnce("01.jpg");
                result = match.matchTemplate("01.jpg", _infomations[1]);
                if (result.similarity > 0.75)
                    break;
                Thread.Sleep(1000);
            }
        }

        public void thread_afterPlay(object adbPath)
        {
            AdbScreenShot adbScreenShot = new AdbScreenShot((string)adbPath);
            AdbTouch adbTouch = new AdbTouch((string)adbPath);
            MatchSystem match = new MatchSystem();
            MatchResult result;

            while (true)
            {
                adbScreenShot.shotOnce("01.jpg");
                result = match.matchTemplate("01.jpg", "Resources/MainPanel/finish.jpg");
                if (result.similarity > 0.85)
                {
                    Thread.Sleep(6500);
                    adbScreenShot.shotOnce("01.jpg");
                    adbTouch.click(result.X - 5, result.Y - 5);
                    Thread.Sleep(1000);
                    break;
                }
                Thread.Sleep(5000);
            }
            //识别掉落物 收集图片
            #region alphaTestCollectingResources
            int index = 0;
            while (true) 
            {
                if (File.Exists($"Debug/ResourcesCollect/{index}.jpg"))
                    index++;
                else break;
            }
            File.Copy("01.jpg", $"Debug/ResourcesCollect/{index}.jpg");
            #endregion
        }

        public void thread_collectFriends(object adbPath)
        {
            AdbScreenShot adbScreenShot = new AdbScreenShot((string)adbPath);
            AdbTouch touch = new AdbTouch((string)adbPath);
            MatchSystem match = new MatchSystem();
            MatchResult result;

            while (true)
            {
                Thread.Sleep(1000);
                adbScreenShot.shotOnce("01.jpg");
                result = match.matchTemplate("01.jpg", "Resources/MainPanel/visitnext.jpg");
                if (result.similarity > 0.75)
                {
                    touch.click(result.X - 5, result.Y - 5);
                    continue;
                }
                else break;
            }
        }
        /*public List<DetectedItem> ocrDrops()
        {
            MatchSystem match = new MatchSystem();
            ItemsController controller = new ItemsController();
            List<DetectedItem> detectedItems = new List<DetectedItem>();
            MatchResult result;

            controller.readFromFile("Resources/Items/list.json");

            for (int i = 0; i < controller.items.items.Count; i++)
            {
                result = match.matchTemplate("01.jpg", controller.items.items[i].path);

                if(result.similarity > 0.75)
                {
                    Image originImage = Image.FromFile("01.jpg");
                    Rectangle cropRegion = new Rectangle(result.X - 120, result.Y - 60, 120, 60);
                    Bitmap bitmapResult = new Bitmap(cropRegion.Width, cropRegion.Height);
                    Graphics graphics = Graphics.FromImage(bitmapResult);
                    graphics.DrawImage(originImage, new Rectangle(0, 0, cropRegion.Width, cropRegion.Height), cropRegion, GraphicsUnit.Pixel);
                    bitmapResult.Save("01.tmp.jpg");

                    NumRecognizer ocr = new NumRecognizer();
                    string ocrResult = ocr.imageToString("01.tmp.jpg");
                    File.Delete("01.tmp.jpg");

                    DetectedItem detectedItem = new DetectedItem();
                    detectedItem.name = controller.items.items[i].itemName;
                    detectedItem.number = int.Parse(ocrResult);

                    detectedItems.Add(detectedItem);
                }
            }
            return detectedItems;
        }*/
    }
}
