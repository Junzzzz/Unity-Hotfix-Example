using UnityEngine;

public class HelloWorld : MonoBehaviour
{
    void Start()
    {
        var luaEnv = new XLua.LuaEnv();
        luaEnv.DoString("CS.UnityEngine.Debug.Log('Hello World')");
        luaEnv.Dispose();
    }
}
