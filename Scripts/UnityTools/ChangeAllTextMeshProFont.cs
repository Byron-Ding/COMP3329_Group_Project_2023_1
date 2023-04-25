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

    [MenuItem("Assets/MyTools/��������")]
    public static void InitFont() {
        objs = Selection.objects;
        if (objs != null && objs.Length > 0) {
            var prefabStage = UnityEditor.SceneManagement.PrefabStageUtility.GetCurrentPrefabStage();
            if (prefabStage == null) {
                Debug.LogError("�ȴ�Ԥ�裡����");
                return;
            } else {
                if (!objs[0].name.Equals(prefabStage.prefabContentsRoot.name)) {
                    Debug.LogError("��ѡ���Ӧ��Ԥ�裡����");
                    return;
                }
            }
            window = (MyTools)GetWindow(typeof(MyTools));
            window.titleContent.text = "��������";
            window.position = new Rect(PlayerSettings.defaultScreenWidth / 2, PlayerSettings.defaultScreenHeight / 2, 400, 160);
            window.Show();
        }
    }

    private void ChangeFont() {
        GUILayout.BeginVertical();
        GUILayout.Label("��������Ҫ�ȴ򿪲�ѡ���Ӧ��Ԥ�裡����");
        GUILayout.BeginHorizontal();
        GUILayout.Label("NewFont:");
        changeFont = (TMP_FontAsset)EditorGUILayout.ObjectField(changeFont, typeof(TMP_FontAsset), true, GUILayout.MinWidth(100f));
        GUILayout.EndHorizontal();
        if (GUILayout.Button("ȷ��")) {
            var tArray = Resources.FindObjectsOfTypeAll(typeof(TextMeshPro));
            for (int i = 0; i < tArray.Length; i++) {
                TextMeshPro t = tArray[i] as TextMeshPro;
                //�ύ�޸ģ����û��������룬unity���������༭���иĶ���ͬʱ�Ķ�Ҳ���ᱻ����
                Undo.RecordObject(t, t.gameObject.name);
                if (changeFont)
                    t.font = changeFont;
            }
            window.Close();
        }
        GUILayout.EndVertical();
    }
}