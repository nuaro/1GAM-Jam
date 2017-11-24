using UnityEngine;
using System.Collections;


namespace Base.Scenery
{
	public static class SceneService
	{
		public static void LoadScene<T>( bool aditive = true, System.Action<T> callback  = null)
			where T : SceneController
		{
			// Disable interaction on everything so EventSystem doesn't whine
			foreach( SceneController controller in SceneRepository.GetAllScenes() ){
				controller.SetInteractable( false );
				controller.SetVisible( false );
			}

			// Load the new scene
			SceneRepository.LoadScene<T>( aditive, true, delegate( T loadedSceneController )
				{
					// Unload everything but the scene we just loaded
					SceneRepository.UnloadScenes( delegate( SceneController controller )
						{
							return (controller != loadedSceneController);
						});

					// Cleanup assets
					Resources.UnloadUnusedAssets();

					// Enable interaction for the loaded scene
					loadedSceneController.SetInteractable( true );
					loadedSceneController.SetVisible( true );

					// Notify the caller
					if( callback != null )
						callback( loadedSceneController );
				});
		}

		public static void LoadScene<T,LoadingScreen>( bool aditive = true, System.Action<T> callback = null )
			where T : SceneController
			where LoadingScreen : SceneController
		{
			// Disable interaction on everything
			foreach( SceneController controller in SceneRepository.GetAllScenes() )
				controller.SetInteractable( false );

			// Show the loading screen (and load it on-the-fly if necessary)
			SceneRepository.LoadScene<LoadingScreen>( true, false, delegate( LoadingScreen loadingScreen )
				{
					GameObject.DontDestroyOnLoad(loadingScreen.gameObject);	
					loadingScreen.SetVisible( true, true, delegate()
						{
							// Unload everything but the loading screen
							SceneRepository.UnloadScenes( delegate( SceneController controller )
								{
									return (controller != loadingScreen);
								});

							// Load the new scene
							SceneRepository.LoadScene<T>( aditive, true, delegate( T loadedSceneController )
								{
									// Cleanup assets
									Resources.UnloadUnusedAssets();

									// Hide the loading screen
									loadingScreen.SetVisible( false, true, delegate()
										{
											// Enable interaction for the loaded scene
											loadedSceneController.SetInteractable( true );

											SceneRepository.UnloadScene<LoadingScreen>();

											// Notify the caller
											if( callback != null )
												callback( loadedSceneController );
										});
								});
						});
				});
		}
	}
} // namespace FUEL.SceneManagement.Application