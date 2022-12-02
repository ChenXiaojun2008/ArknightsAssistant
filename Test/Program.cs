using AssistantCore.Json.ActionScript;

AssistantCore.Json.ActionScript.Action action1 = new AssistantCore.Json.ActionScript.Action();
action1.clickType = 1;
action1.matchTimes = 3;
action1.tempImg = "Resources/MainPanel/friends.jpg";

AssistantCore.Json.ActionScript.Action action2 = new AssistantCore.Json.ActionScript.Action();
action2.clickType = 1;
action2.matchTimes = 3;
action2.tempImg = "Resources/MainPanel/friendlist.jpg";

AssistantCore.Json.ActionScript.Action action3 = new AssistantCore.Json.ActionScript.Action();
action3.clickType = 1;
action3.matchTimes = 3;
action3.afterDelay = 2000;
action3.tempImg = "Resources/MainPanel/visitfriend.jpg";

ActionList list = new ActionList();
list.actionName = "collectFriends";
list.isMutiMatch = false;
list.isReturnToLobby = true;

list.actions.Add(action1);
list.actions.Add(action2);
list.actions.Add(action3);

ActionScript script = new ActionScript();
script.list = list;
script.writeToFile("collectFriends.json");