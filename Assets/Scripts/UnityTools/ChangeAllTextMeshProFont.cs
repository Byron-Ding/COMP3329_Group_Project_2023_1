using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor.SceneManagement;
using TMPro;

public class MyTools : EditorWindow {
    static Object[] objs;
    static MyTools window;
    TMP_FontAsset changeFont;

    private void OnGUI() {
        ChangeFont();
    }

    [MenuItem("Assets/MyTools/字体设置")]
    public static void InitFont() {
        objs = Selection.objects;
        if (objs != null && objs.Length > 0) {
            var prefabStage = UnityEditor.SceneManagement.PrefabStageUtility.GetCurrentPrefabStage();
            if (prefabStage == null) {
                Debug.LogError("先打开预设！！！");
                return;
            } else {
                if (!objs[0].name.Equals(prefabStage.prefabContentsRoot.name)) {
                    Debug.LogError("请选择对应的预设！！！");
                    return;
                }
            }
            window = (MyTools)GetWindow(typeof(MyTools));
            window.titleContent.text = "字体设置";
            window.position = new Rect(PlayerSettings.defaultScreenWidth / 2, PlayerSettings.defaultScreenHeight / 2, 400, 160);
            window.Show();
        }
    }

    private void ChangeFont() {
        GUILayout.BeginVertical();
        GUILayout.Label("！！！需要先打开并选择对应的预设！！！");
        GUILayout.BeginHorizontal();
        GUILayout.Label("NewFont:");
        changeFont = (TMP_FontAsset)EditorGUILayout.ObjectField(changeFont, typeof(TMP_FontAsset), true, GUILayout.MinWidth(100f));
        GUILayout.EndHorizontal();
        if (GUILayout.Button("确认")) {
            var tArray = Resources.FindObjectsOfTypeAll(typeof(TextMeshPro));
            for (int i = 0; i < tArray.Length; i++) {
                TextMeshPro t = tArray[i] as TextMeshPro;
                //提交修改，如果没有这个代码，unity不会察觉到编辑器有改动，同时改动也不会被保存
                Undo.RecordObject(t, t.gameObject.name);
                if (changeFont)
                    t.font = changeFont;
            }
            window.Close();
        }
        GUILayout.EndVertical();
    }
}