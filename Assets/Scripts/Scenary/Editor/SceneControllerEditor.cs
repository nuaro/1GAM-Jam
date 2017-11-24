using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;


namespace Base.Scenery
{

[CustomEditor(typeof(SceneController),true)]
public class SceneControllerEditor : Editor
{
	public override void OnInspectorGUI()
	{
        SceneController controller = target as SceneController;

	    DrawDefaultInspector();

        controller.visible = EditorGUILayout.Toggle( "Visible", controller.visible );
        controller.interactable = EditorGUILayout.Toggle( "Interactable", controller.interactable );

        GUILayout.Space( 20.0f );
        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
    
        if( GUILayout.Button( "Auto-Configure", GUILayout.MaxWidth( 160.0f ) ) )
            controller.AutoConfigure();
    
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();
        GUILayout.Space( 20.0f );
	}
}

} // namespace FUEL.SceneManagement.Application
