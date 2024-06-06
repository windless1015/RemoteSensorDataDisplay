using Grpc.Core;

namespace grpcCommonLibrary
{
    public static class GrpcHelper
    {
        private static Dictionary<string, Channel> channels = new Dictionary<string, Channel>();
        private static Channel? _defaultChannel;
        private static readonly object Locker = new object();

        public static ValueTask<Channel> GetChannel(string name, string url)
        {
            if (channels.ContainsKey(name))
                return new ValueTask<Channel>(channels[name]);

            return new ValueTask<Channel>(Task.Run(() =>
            {
                lock (Locker)
                {
                    if (!channels.ContainsKey(name))
                        channels.Add(name, new Channel(url, ChannelCredentials.Insecure));
                }

                return channels[name];
            }));
        }

        public static ValueTask<Channel> GetChannel(string name)
        {
            if (channels.TryGetValue(name, out var channel))
                return new ValueTask<Channel>(channel);

            throw new NullReferenceException($"Channel {name} does not exist");
        }

        public static async void SetRobotChannel(string url)
        {
            _defaultChannel = await GetChannel("Robot", url);
        }

        public static ValueTask<Channel> GetRobotChannel()
        {
            if (_defaultChannel is null)
                throw new NullReferenceException("No Default Channel Set");

            return new ValueTask<Channel>(_defaultChannel);
        }
    }
}
