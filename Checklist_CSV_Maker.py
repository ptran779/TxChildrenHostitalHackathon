import tkinter
import tkinter.messagebox

tk = tkinter.Tk()
tk.title("Hospital Activity Tracker")

def add_task():
    task = enterTask.get()
    if task != "":
        taskList.insert(tkinter.END, task)
        enterTask.delete(0, tkinter.END)
    else:
        tkinter.messagebox.showwarning(title="Error", message="You must enter a task.")

def delete_task():
    try:
        taskIndex = taskList.curselection()[0]
        taskList.delete(taskIndex)
    except:
        tkinter.messagebox.showwarning(title="Error", message="You must select a task.")


def export_tasks():
    tasks = taskList.get(0, taskList.size())
    ###Export CSV
    taskLine = ""
    with open('patientTask.csv', 'w', newline = '') as csvfile:
        for i in tasks:
            taskLine += i + ", "
        taskLine = taskLine[:-2]
        csvfile.write(taskLine)
    
# Create GUI
frame_tasks = tkinter.Frame(tk)
frame_tasks.pack()

taskList = tkinter.Listbox(frame_tasks, height=20, width=50)
taskList.pack(side=tkinter.LEFT)

scrollbar_tasks = tkinter.Scrollbar(frame_tasks)
scrollbar_tasks.pack(side=tkinter.RIGHT, fill=tkinter.Y)

taskList.config(yscrollcommand=scrollbar_tasks.set)
scrollbar_tasks.config(command=taskList.yview)

enterTask = tkinter.Entry(tk, width=50)
enterTask.pack()

taskAddButton = tkinter.Button(tk, text="Add task", width=48, command=add_task)
taskAddButton.pack()

taskDeleteButton = tkinter.Button(tk, text="Delete task", width=48, command=delete_task)
taskDeleteButton.pack()


taskExportButton = tkinter.Button(tk, text="Export tasks", width=48, command=export_tasks)
taskExportButton.pack()

tk.mainloop()