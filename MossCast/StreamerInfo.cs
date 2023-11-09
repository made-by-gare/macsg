#pragma warning disable 1591

namespace MossCast
{
    public class StreamerInfo
    {

        public string name;
        public string displayName;
        public string pronouns;

        public StreamerInfo(string name, string displayName, string pronouns)
        {
            this.name = name;
            this.displayName = displayName;
            this.pronouns = pronouns;
        }
    }
}
