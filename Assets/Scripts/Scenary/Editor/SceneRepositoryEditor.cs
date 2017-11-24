using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;


namespace Base.Scenery
{

[CustomEditor(typeof(SceneRepositoryImp))]
public class SceneRepositoryEditor : Editor
{
	public override void OnInspectorGUI()
	{
	    SceneRepositoryImp repo = target as SceneRepositoryImp;
	    
	    List<System.Type> sceneTypes = new List<System.Type>();
	    sceneTypes.AddRange( repo.GetRegisteredSceneTypes() );
	    sceneTypes.Sort( delegate( System.Type a, System.Type b )
	    {
	        return string.Compare( a.Name, b.Name );
	    });

        foreach( System.Type sceneType in sceneTypes )
        {
            string fileName = SceneController.GetSceneFileName( sceneType );
            SceneController controller = repo.GetScene( sceneType );
            
            EditorGUILayout.ObjectField( fileName, controller, sceneType, true );
        }
	}
}

} // namespace FUEL.SceneManagement.Application
