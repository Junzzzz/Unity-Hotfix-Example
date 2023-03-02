using UnityEngine;
using XLua;

[Hotfix]
public class HotfixTest : MonoBehaviour
{
    private readonly LuaEnv _luaEnv = new();
    
    void Update()
    {
        if (Time.frameCount % 120 == 0)
        {
            Debug.Log($"Calculate 1 + 2={Add(1,2)}");
        }
    }

    private int Add(int a, int b)
    {
        return a - b;
    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 300, 80), "Hotfix"))
        {
            _luaEnv.DoString(@"
                xlua.hotfix(CS.HotfixTest, 'Add', function(self,a,b)
                    return a + b
                end)
            ");
        }
    }
}