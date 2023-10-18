using UnityEngine;
using System;
using System.Collections.Generic;
using TMPro;

public class TaskManager : MonoBehaviour
{
    public TaskUI taskUiPrefab;
    public Transform taskParent;
    public  TMP_InputField descriptionInput;
    
    private List<TaskUI> tasks = new();
    
    public void GetInput()
    {
        if(string.IsNullOrWhiteSpace(descriptionInput.text)) return;

        Task task = new Task()
        {
            Description = descriptionInput.text,
            Date = DateTime.Now.ToString("yyyy - MM - dd"),
            Finished = false
        };
        
        AddTask(task);
        descriptionInput.text = "";
    }
    
    void AddTask(Task task)
    {
        TaskUI taskUi = Instantiate(taskUiPrefab, taskParent);
        taskUi.SetTask(task);
        tasks.Add(taskUi);
    }
}
