Unity + Firebase Backend Setup Steps:

1. Download Firebase SDK: https://firebase.google.com/download/unity
2. Extract SDK Zip
3. On Unity -> Import Package, Custom Package -> Pick dotnet4/FirebaseAuth.unitypackage
3. On Unity, click on File -> Build Settings -> Player Settings -> Other Settings -> Bundle Identifier (Set this to: com.TAMU.MediPet)
4. Save google-services.json to Assets Folder on Unity (Note* Be careful sharing this file or uploading to Git, this is like Password to Google Backend)