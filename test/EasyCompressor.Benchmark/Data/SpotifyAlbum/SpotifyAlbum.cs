using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace EasySerializer.Benchmark;

[Serializable]
[DataContract]
public class SpotifyAlbumArray
{
    [DataMember(Order = 1)]
    [JsonProperty("spotify_albums")]
    public SpotifyAlbum[] SpotifyAlbums { get; set; }
}

[Serializable]
[DataContract]
public class SpotifyAlbum
{
    [DataMember(Order = 1)]
    [JsonProperty("album_type")]
    public string AlbumType { get; set; }

    [DataMember(Order = 2)]
    [JsonProperty("artists")]
    public ArtistDto[] Artists { get; set; }

    [DataMember(Order = 4)]
    [JsonProperty("available_markets")]
    public string[] AvailableMarkets { get; set; }

    [DataMember(Order = 5)]
    [JsonProperty("copyrights")]
    public CopyrightDto[] Copyrights { get; set; }

    [DataMember(Order = 6)]
    [JsonProperty("external_ids")]
    public ExternalIdsDto ExternalIds { get; set; }

    [DataMember(Order = 7)]
    [JsonProperty("external_urls")]
    public ExternalUrlsDto ExternalUrls { get; set; }

    //[Key(7)]
    //[DataMember(Order = 8)]
    //[JsonProperty("genres")]
    //public object[] Genres { get; set; }

    [DataMember(Order = 9)]
    [JsonProperty("href")]
    public string Href { get; set; }

    [DataMember(Order = 10)]
    [JsonProperty("id")]
    public string Id { get; set; }

    [DataMember(Order = 11)]
    [JsonProperty("images")]
    public ImageDto[] Images { get; set; }

    [DataMember(Order = 12)]
    [JsonProperty("name")]
    public string Name { get; set; }

    [DataMember(Order = 13)]
    [JsonProperty("popularity")]
    public long Popularity { get; set; }

    [DataMember(Order = 14)]
    [JsonProperty("release_date")]
    public string ReleaseDate { get; set; }

    [DataMember(Order = 15)]
    [JsonProperty("release_date_precision")]
    public string ReleaseDatePrecision { get; set; }

    [DataMember(Order = 16)]
    [JsonProperty("tracks")]
    public TracksDto Tracks { get; set; }

    [DataMember(Order = 17)]
    [JsonProperty("type")]
    public string Type { get; set; }

    [DataMember(Order = 18)]
    [JsonProperty("uri")]
    public string Uri { get; set; }
}

[Serializable]
[DataContract]
public class TracksDto
{
    [DataMember(Order = 1)]
    [JsonProperty("href")]
    public string Href { get; set; }

    [DataMember(Order = 2)]
    [JsonProperty("items")]
    public ItemDto[] Items { get; set; }

    [DataMember(Order = 3)]
    [JsonProperty("limit")]
    public long Limit { get; set; }

    //[DataMember(Order = 4)]
    //[JsonProperty("next")]
    //public object Next { get; set; }

    [DataMember(Order = 5)]
    [JsonProperty("offset")]
    public long Offset { get; set; }

    //[DataMember(Order = 6)]
    //[JsonProperty("previous")]
    //public object Previous { get; set; }

    [DataMember(Order = 7)]
    [JsonProperty("total")]
    public long Total { get; set; }
}

[Serializable]
[DataContract]
public class ItemDto
{
    [DataMember(Order = 1)]
    [JsonProperty("artists")]
    public ArtistDto[] Artists { get; set; }

    [DataMember(Order = 2)]
    [JsonProperty("available_markets")]
    public string[] AvailableMarkets { get; set; }

    [DataMember(Order = 3)]
    [JsonProperty("disc_number")]
    public long DiscNumber { get; set; }

    [DataMember(Order = 4)]
    [JsonProperty("duration_ms")]
    public long DurationMs { get; set; }

    [DataMember(Order = 5)]
    [JsonProperty("explicit")]
    public bool Explicit { get; set; }

    [DataMember(Order = 6)]
    [JsonProperty("external_urls")]
    public ExternalUrlsDto ExternalUrls { get; set; }

    [DataMember(Order = 7)]
    [JsonProperty("href")]
    public string Href { get; set; }

    [DataMember(Order = 8)]
    [JsonProperty("id")]
    public string Id { get; set; }

    [DataMember(Order = 9)]
    [JsonProperty("name")]
    public string Name { get; set; }

    [DataMember(Order = 10)]
    [JsonProperty("preview_url")]
    public string PreviewUrl { get; set; }

    [DataMember(Order = 11)]
    [JsonProperty("track_number")]
    public long TrackNumber { get; set; }

    [DataMember(Order = 12)]
    [JsonProperty("type")]
    public string Type { get; set; }

    [DataMember(Order = 13)]
    [JsonProperty("uri")]
    public string Uri { get; set; }
}

[Serializable]
[DataContract]
public class ImageDto
{
    [DataMember(Order = 1)]
    [JsonProperty("height")]
    public long Height { get; set; }

    [DataMember(Order = 2)]
    [JsonProperty("url")]
    public string Url { get; set; }

    [DataMember(Order = 3)]
    [JsonProperty("width")]
    public long Width { get; set; }
}

[Serializable]
[DataContract]
public class ExternalIdsDto
{
    [DataMember(Order = 1)]
    [JsonProperty("upc")]
    public string Upc { get; set; }
}

[Serializable]
[DataContract]
public class CopyrightDto
{
    [DataMember(Order = 1)]
    [JsonProperty("text")]
    public string Text { get; set; }

    [DataMember(Order = 2)]
    [JsonProperty("type")]
    public string Type { get; set; }
}

[Serializable]
[DataContract]
public class ArtistDto
{
    [DataMember(Order = 1)]
    [JsonProperty("external_urls")]
    public ExternalUrlsDto ExternalUrls { get; set; }

    [DataMember(Order = 2)]
    [JsonProperty("href")]
    public string Href { get; set; }

    [DataMember(Order = 3)]
    [JsonProperty("id")]
    public string Id { get; set; }

    [DataMember(Order = 4)]
    [JsonProperty("name")]
    public string Name { get; set; }

    [DataMember(Order = 5)]
    [JsonProperty("type")]
    public string Type { get; set; }

    [DataMember(Order = 6)]
    [JsonProperty("uri")]
    public string Uri { get; set; }
}

[Serializable]
[DataContract]
public class ExternalUrlsDto
{
    [DataMember(Order = 1)]
    [JsonProperty("spotify")]
    public string Spotify { get; set; }
}