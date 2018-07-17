using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JobSelector : MonoBehaviour
{
    private JobIndicator jobIndicator;
    private Button button;
    private void Awake()
    {
        button = GetComponent<Button>();
        jobIndicator = GetComponentInParent<JobIndicator>();
    }
    private void Start()
    {
        button.onClick.AddListener(ChangeJob);
    }
    private void ChangeJob()
    {
        JobManager.currentJob = jobIndicator.SelectedJob();
    }
}
