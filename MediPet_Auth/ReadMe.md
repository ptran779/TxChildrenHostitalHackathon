# For contributor
Unity + Firebase Backend Setup Steps:

1. Download Firebase SDK: https://firebase.google.com/download/unity
2. Extract SDK Zip
3. On Unity -> Import Package, Custom Package -> Pick dotnet4/FirebaseAuth.unitypackage
3. On Unity, click on File -> Build Settings -> Player Settings -> Other Settings -> Bundle Identifier (Set this to: com.TAMU.MediPet)
4. Save google-services.json to Assets Folder on Unity (Note* Be careful sharing this file or uploading to Git, this is like Password to Google Backend)

# For users who want to compile from scratch:
You will need to setup yourown Firebase backend and edit step 3 and 4 accordingly to your design. Due to security issue, google-services.json will not be shared here.
