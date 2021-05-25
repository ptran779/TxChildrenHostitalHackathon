# TxChildrenHostitalHackathon
Summer 2021

All finish version for major OS are avaliable and should be found in completebuilt/ folder 
To use any of the version, you only need to download from the completebuilt/ folder with the userdat folder and unzip/untar the file and run the binary. 

------------------------
Linux and Window
To see task in game, open MedPet_Data/ folder and copy userdat/ folder into the directory. the userdat/ folder has a pregenerated tasks script call "patientTask.csv". 
For new task, if you want to try out, you can open the csv file and add information in. To See these task on the game, MAKESURE Status column is set to "N," the game will only display task that is not done. Once it complete, it will be mark differently


Mac
Should be similar, however, I haven't test the code since I don't have a Mac

For task file, you could also use our simple python script. It come with a GUI and the task can be exported to correct format that use for the main application. Make sure to move the "patientTask.csv" to correct location as mention above

-----------------------
Instruction to build from scratch if you want:
You will need Unity. Just get it from UnityHub

This was build using using unity 2020.3.8f1

Google Firebase will need additional instruction. This can found in MediPet_Auth/ folder to set it up.
