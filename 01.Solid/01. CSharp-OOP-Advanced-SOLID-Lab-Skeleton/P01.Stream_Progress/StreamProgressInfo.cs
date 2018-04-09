using System;
using System.Collections.Generic;
using System.Text;

namespace P01.Stream_Progress
{
    public class StreamProgressInfo
    {
        private IStreamable iStreamable;

        // If we want to stream a music file, we can't
        public StreamProgressInfo(IStreamable iStreamable)
        {
            this.iStreamable = iStreamable;
        }

        public int CalculateCurrentPercent()
        {
            return (this.iStreamable.BytesSent * 100) / this.iStreamable.Length;
        }
    }
}
