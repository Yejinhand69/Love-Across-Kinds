using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class DataLoader : MonoBehaviour
{
    public void LoadData()
    {
        StartCoroutine(CSVDownloader.DownloadData(AfterDownload));
    }

    public void AfterDownload(string data)
    {
        if(null == data)
        {
            Debug.Log("");
        }
        else
        {
            StartCoroutine(ProcessData(data, AfterProcessData));
        }
    }

    private void AfterProcessData(string errorMessage)
    {
        if(null != errorMessage)
        {
            Debug.Log("Data not processed: " + errorMessage);
        }
        else
        {
            Debug.Log("Data is processed");
        }
    }

    public IEnumerator ProcessData(string data, System.Action<string> onCompleted)
    {
        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();

        //Line level
        int currLineIndex = 0;
        bool inQuote = false;
        int lineSinceUpdate = 0;
        int kLinesBetweenUpdate = 15;

        //Entry Level
        string currEntry = "";
        int currCharIndex = 0;
        bool currEntryContainedQuote = false;
        List<string> currLineEntries = new List<string>();

        char lineEnding = '\n';
        
        while(currCharIndex < data.Length)
        {
            if(!inQuote && (data[currCharIndex] == lineEnding))
            {
                //Skip the line ending
                currCharIndex++;

                //Wrap up the last entry
                //If in a quote, trim bordering quotation marks
                if (currEntryContainedQuote)
                {
                    currEntry = currEntry.Substring(1, currEntry.Length - 2);
                }

                currLineEntries.Add(currEntry);
                currEntry = "";
                currEntryContainedQuote = false;

                //Line ended
                ProcessLineFromCSV(currLineEntries, currLineIndex);
                currLineIndex++;
                currLineEntries = new List<string>();

                lineSinceUpdate++;
                if(lineSinceUpdate > kLinesBetweenUpdate)
                {
                    lineSinceUpdate = 0;
                    yield return new WaitForEndOfFrame();
                }
            }

            else
            {
                if(data[currCharIndex] == '"')
                {
                    inQuote = !inQuote;
                    currEntryContainedQuote = true;
                }

                //Entry level stuff
                if(data[currCharIndex] == ',')
                {
                    if (inQuote)
                    {
                        currEntry += data[currCharIndex];
                    }
                    else
                    {
                        //If in a quote, trim bordering quotation marks
                        if (currEntryContainedQuote)
                        {
                            currEntry = currEntry.Substring(1, currEntry.Length - 2);
                        }

                        currLineEntries.Add(currEntry);
                        currEntry = "";
                        currEntryContainedQuote = false;
                    }
                }
                else
                {
                    currEntry += data[currCharIndex];
                }

                currCharIndex++;
            }
        }

        onCompleted(null);
    }

    private void ProcessLineFromCSV(List<string> currLineElements, int currLineindex)
    {
        
    }
}
