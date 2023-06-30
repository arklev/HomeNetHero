using Newtonsoft.Json;

namespace HomeNetHeroApp
{
    public class DiscordWebhookContent
    {
        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("avatar_url")]
        public string AvatarUrl { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }

        [JsonProperty("embeds")]
        public DiscordEmbed[] Embeds { get; set; }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class DiscordEmbed
    {
        [JsonProperty("author")]
        public DiscordEmbedAuthor Author { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("color")]
        public int Color { get; set; }

        [JsonProperty("fields")]
        public DiscordEmbedField[] Fields { get; set; }

        [JsonProperty("thumbnail")]
        public DiscordEmbedThumbnail Thumbnail { get; set; }

        [JsonProperty("image")]
        public DiscordEmbedImage Image { get; set; }

        [JsonProperty("footer")]
        public DiscordEmbedFooter Footer { get; set; }
    }

    public class DiscordEmbedAuthor
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("icon_url")]
        public string IconUrl { get; set; }
    }

    public class DiscordEmbedField
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("inline")]
        public bool Inline { get; set; }
    }

    public class DiscordEmbedThumbnail
    {
        [JsonProperty("url")]
        public string Url { get; set; }
    }

    public class DiscordEmbedImage
    {
        [JsonProperty("url")]
        public string Url { get; set; }
    }

    public class DiscordEmbedFooter
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("icon_url")]
        public string IconUrl { get; set; }
    }
}
