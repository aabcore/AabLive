using System;

namespace AabLive.Workers
{
    public class WorkerStatistics
    {
        private static DateTimeOffset _lastProcessTime;
        private static readonly object _lock = new object();

        public static DateTimeOffset GetLastProcessTime()
        {
            lock (_lock)
            {
                return _lastProcessTime;
            }
        }

        public static void SetProcessTime()
        {
            lock (_lock)
            {
                _lastProcessTime = DateTimeOffset.Now;
            }
        }
    }
}
