using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Creator))]
public class CreatorBarrelsEditor : Editor 
{
	private Creator m_Target;
	private SerializedProperty m_Sender;
	private SerializedProperty m_StartPos;
	private SerializedProperty m_EndPos;
	private bool m_test1;
	private bool m_test2;
	private bool m_test3;


	private void OnEnable()
	{
		m_Target = target as Creator;
		m_Sender = serializedObject.FindProperty("_sample");
		m_StartPos = serializedObject.FindProperty("_startPos");
		m_EndPos = serializedObject.FindProperty("_endPos");
		m_test1 = m_test2 = m_test3 = false;
	}


	public override void OnInspectorGUI()
	{
		serializedObject.Update();

		EditorGUILayout.PropertyField(m_StartPos);
		EditorGUILayout.PropertyField(m_EndPos);
		EditorGUILayout.PropertyField(m_Sender);
		EditorGUILayout.Space();

		m_test3 = EditorGUILayout.Foldout(m_test3, "Create line");
		if (m_test3)
		{
			m_Target._cnt = EditorGUILayout.IntField("Count", m_Target._cnt);
			m_Target._offset = EditorGUILayout.Vector2Field("Offset", m_Target._offset);

			if (GUILayout.Button("Create line"))
				m_Target.Create();
		}

		m_test2 = EditorGUILayout.Foldout(m_test2, "Replace Obj");
		if (m_test2)
		{
			m_Target._tagReplaceObj = EditorGUILayout.TagField(m_Target._tagReplaceObj);

			if (GUILayout.Button("Replace Obj"))
				m_Target.ReplaceObj();
		}

		m_test1 = EditorGUILayout.Foldout(m_test1, "Create Chain");
		if (m_test1)
		{
			m_Target._offsetChain = EditorGUILayout.FloatField("Offset", m_Target._offsetChain);

			if (GUILayout.Button("Create Chain"))
				m_Target.CreateChain();
		}

		serializedObject.ApplyModifiedProperties();
	}
}
