using System.Reflection;
using BepInEx;
using BepInEx.Logging;
using BepInEx.Unity.IL2CPP;
using HarmonyLib;

namespace RogueGenesiaModTemplate;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
public class Plugin : BasePlugin
{
    public override void Load()
    {
        // Plugin startup logic
        
        // Apply all patches in this assembly
        Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly());
        
        Log.LogInfo($"Plugin {MyPluginInfo.PLUGIN_NAME} is loaded!");
    }
}
