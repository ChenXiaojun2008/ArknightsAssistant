using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AssistantCore.OpenCV;

namespace AssistantCore.Json.ActionScript
{
    public class Action
    {
        public string tempImg = ""; //标准匹配模板图片

        public int beforeDelay = 0; //0 无延迟
        public int afterDelay = 0; //0 无延迟

        public int? clickType; //1 点击 2 滑动
        public int? swipeDirection;//1 up 2 down 3 left 4 right
        public int? swipeDistance; //0 不定义 滑动距离

        public int matchTimes = 0; //-1 永久匹配
    }

    public class MutiAction
    {
        public int beforeDelay = 0;
        public int afterDelay = 0;
        public string mutiTempImg = ""; //多重匹配模板图片 可多个
    }

    public class ActionList
    {
        public string? actionName; //动作名称
        public bool? isReturnToLobby; //是否返回大厅

        public bool isMutiMatch = false; // 是否多重匹配
        public int firstMutiTimes = 0; // 多重匹配第一次匹配次数 默认0

        public List<Action> actions = new List<Action>(); //动作list
        public List<MutiAction> mutiActions = new List<MutiAction>(); //多重
    }
}
