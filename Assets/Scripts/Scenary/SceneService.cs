using UnityEngine;
using System.Collections;


namespace Base.Scenery
{
	public static class SceneService
	{

		public static void LoadScene<From,To,LoadingScreen>( bool aditive = true, System.Action<To> callback = null )
			where From : SceneController
			where To : SceneController
			where LoadingScreen : SceneController
		{
			// Disable interaction on everything
			foreach( SceneController controller in SceneRepository.GetAllScenes() )
				controller.SetInteractable( false );

			// Show the loading screen (and load it on-the-fly if necessary)
			SceneRepository.LoadScene<LoadingScreen>( true, false, delegate( LoadingScreen loadingScreen )
				{
					//GameObject.DontDestroyOnLoad(loadingScreen.gameObject);	
					loadingScreen.SetVisible( true, true, delegate()
						{
							//unload from scene only if is not aditive
							if(!aditive){
								SceneRepository.UnloadScene<From>();
							}
							// Load the new scene
							SceneRepository.LoadScene<To>( true, true, delegate( To loadedSceneController )
								{
									// Cleanup assets
									Resources.UnloadUnusedAssets();

									// Hide the loading screen
									loadingScreen.SetVisible( false, true, delegate()
										{
											// Enable interaction for the loaded scene
											loadedSceneController.SetInteractable( true );

											//we only remove the loading scene if is additive, is removed automatically
											SceneRepository.UnloadScene<LoadingScreen>();
											if(!aditive){
												SceneRepository.UnloadScene<From>();
											}

											// Notify the caller
											if( callback != null )
												callback( loadedSceneController );
										});
								});
						});
				});
		}

		//this add camera movement on transition
		public static void MoveToSceneFrom<From,To>(bool aditive = true, direction_to_move move_to = direction_to_move.right, System.Action<To> callback = null )
			where From : SceneController
			where To : SceneController
		{
			// Disable interaction on everything
			foreach( SceneController controller in SceneRepository.GetAllScenes() )
				controller.SetInteractable( false );



			SceneRepository.LoadScene<To> (true, true, delegate( To loadedSceneController) {
				// Cleanup assets
				Resources.UnloadUnusedAssets ();
				CameraAlign camAlign = Camera.main.gameObject.GetComponent<CameraAlign>();

				if(camAlign != null){
					camAlign.SetNewPosition(move_to, delegate(){

						if(!aditive){
							SceneRepository.UnloadScene<From>();
						}

						if( callback != null )
							callback( loadedSceneController );

					});
				}
				else {

					Debug.Log("----------Errorrrrrrr cam is null");
				}



			});

		}
	}
} 