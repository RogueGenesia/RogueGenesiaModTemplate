using System.Collections;
using BepInEx.Unity.IL2CPP;
using BepInEx.Unity.IL2CPP.Utils.Collections;
using UnityEngine;

namespace RogueGenesiaModTemplate.Helpers;

/// <summary>
/// Helper class to simplify using coroutines in IL2CPP 
/// </summary>
public static class CoroutineHelper
{
    private static readonly CoroutineHelperBehaviour _behaviour;
    
    static CoroutineHelper()
    {
        _behaviour = IL2CPPChainloader.AddUnityComponent<CoroutineHelperBehaviour>();
    }

    public static void StartCoroutine(IEnumerator coroutineMethod)
    {
        _behaviour.StartCoroutine(coroutineMethod);
    }

    public static void StopCoroutine(IEnumerator coroutineMethod)
    {
        _behaviour.StartCoroutine(coroutineMethod);
    }
    
    private static Coroutine StartCoroutine(this MonoBehaviour self, IEnumerator coroutine) => self.StartCoroutine(coroutine.WrapToIl2Cpp());
    private static void StopCoroutine(this MonoBehaviour self, IEnumerator coroutine) => self.StopCoroutine(coroutine.WrapToIl2Cpp());

    private class CoroutineHelperBehaviour : MonoBehaviour { }
}