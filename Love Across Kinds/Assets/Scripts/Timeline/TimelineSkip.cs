using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineSkip : MonoBehaviour
{
    public PlayableDirector timeline; // Reference to Timeline asset

    public void SkipTimeline()
    {
        // Check if the timeline is not null and is playing
        if (timeline != null && timeline.state == PlayState.Playing)
        {
            // Skip to the end of the timeline
            timeline.time = timeline.duration;
        }
    }
}
