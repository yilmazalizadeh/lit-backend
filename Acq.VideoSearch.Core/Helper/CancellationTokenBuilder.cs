namespace Acq.VideoSearch.Core.Helper
{
    public static class CancellationTokenBuilder
    {
        public static CancellationToken Build(int timeOutMillisecond)
        {
            var tokenSource = new CancellationTokenSource(timeOutMillisecond);
            return tokenSource.Token;
        }
    }
}
