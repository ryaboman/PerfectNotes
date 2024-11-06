using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Midi;

using RMControls.ViewNotes;

namespace RMPerfectNotes{

    public class Note : INotable {
        public string pitchName;
        public int forceDown = 0;
        public int forceUp = 0;
        public float startTime = 0;
        public float endTime = 0;

        public string getPitchName() { return pitchName; }
        public int getForceDown() { return forceDown; }
        public int getForceUp() { return forceUp; }
        public float getStartTime() { return startTime; }
        public float getEndTime() { return endTime; }
        public void setPitchName(string pitchName) { this.pitchName = pitchName; }
        public void setForceDown(int forceDown) { this.forceDown = forceDown; }
        public void setForceUp(int forceUp) { this.forceUp = forceUp; }
        public void setStartTime(float startTime) { this.startTime = startTime; }
        public void setEndTime(float endTime) { this.endTime = endTime;  }
    }
}
