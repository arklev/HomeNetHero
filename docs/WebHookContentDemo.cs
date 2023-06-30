DiscordWebhookContent webhookContent = new DiscordWebhookContent
{
    Username = "HomeNetHero",
    AvatarUrl = "https://i.imgur.com/4M34hi2.png",
    Embeds = new DiscordEmbed[]
    {
        new DiscordEmbed
        {
            Author = new DiscordEmbedAuthor
            {
                Name = "Birdie♫",
                Url = "https://www.reddit.com/r/cats/",
                IconUrl = "https://i.imgur.com/R66g1Pe.jpg"
            },
            Title = "Title",
            Url = "https://google.com/",
            Description = "Text message. You can use Markdown here. *Italic* **bold** __underline__ ~~strikeout~~ [hyperlink](https://google.com) `code`",
            Color = 15258703,
            Fields = new DiscordEmbedField[]
            {
                new DiscordEmbedField
                {
                    Name = "Text",
                    Value = "More text",
                    Inline = true
                },
                new DiscordEmbedField
                {
                    Name = "Even more text",
                    Value = "Yup",
                    Inline = true
                },
                new DiscordEmbedField
                {
                    Name = "Use `\"inline\": true` parameter, if you want to display fields in the same line.",
                    Value = "okay..."
                },
                new DiscordEmbedField
                {
                    Name = "Thanks!",
                    Value = "You're welcome :wink:"
                }
            },
            Thumbnail = new DiscordEmbedThumbnail
            {
                Url = "https://upload.wikimedia.org/wikipedia/commons/3/38/4-Nature-Wallpapers-2014-1_ukaavUI.jpg"
            },
            Image = new DiscordEmbedImage
            {
                Url = "https://upload.wikimedia.org/wikipedia/commons/5/5a/A_picture_from_China_every_day_108.jpg"
            },
            Footer = new DiscordEmbedFooter
            {
                Text = "Woah! So cool! :smirk:",
                IconUrl = "https://i.imgur.com/fKL31aD.jpg"
            }
        }
    }
};