﻿using System;
using System.Threading;
using System.Threading.Tasks;

namespace TalentPool.DailyStatistics
{
    public class DailyStatisticManager : IDisposable
    {
        private bool _disposed;
        private readonly ISignal _signal;
        public DailyStatisticManager(IDailyStatisticStore dailyStatisticsStore,
            ISignal signal)
        {
            DailyStatisticsStore = dailyStatisticsStore;
            _signal = signal;
        }
        protected virtual CancellationToken CancellationToken => _signal.Token;
        protected IDailyStatisticStore DailyStatisticsStore { get; }

        public async Task<DailyStatistic> CreateAsync(DailyStatistic dailyStatistic)
        {
            if (dailyStatistic == null)
                throw new ArgumentNullException(nameof(dailyStatistic));

            return await DailyStatisticsStore.CreateAsync(dailyStatistic, CancellationToken);
        }
        public async Task<DailyStatistic> UpdateAsync(DailyStatistic dailyStatistic)
        {
            if (dailyStatistic == null)
                throw new ArgumentNullException(nameof(dailyStatistic));
            return await DailyStatisticsStore.UpdateAsync(dailyStatistic, CancellationToken);
        }
        public async Task<DailyStatistic> DeleteAsync(DailyStatistic dailyStatistic)
        {
            if (dailyStatistic == null)
                throw new ArgumentNullException(nameof(dailyStatistic));

            return await DailyStatisticsStore.DeleteAsync(dailyStatistic, CancellationToken);
        }
        public async Task<DailyStatistic> FindByIdAsync(Guid dailyStatisticId)
        {
            if (dailyStatisticId == null)
                throw new ArgumentNullException(nameof(dailyStatisticId));

            return await DailyStatisticsStore.FindByIdAsync(dailyStatisticId, CancellationToken);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected void Dispose(bool disposing)
        {
            if (disposing && !_disposed)
            {
                DailyStatisticsStore.Dispose();
            }
            _disposed = true;
        }
        protected void ThrowIfDisposed()
        {
            if (_disposed)
            {
                throw new ObjectDisposedException(GetType().Name);
            }
        }
    }
}
