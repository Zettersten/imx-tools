using System.Text.Json.Serialization;

namespace ImxTools.Models;

public class TokenResponseModel
{
    [JsonPropertyName("token_address")]
    public string? TokenAddress { get; set; }

    [JsonPropertyName("token_id")]
    public string? TokenId { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("user")]
    public string? User { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("uri")]
    public string? Uri { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("image_url")]
    public string? ImageUrl { get; set; }

    [JsonPropertyName("metadata")]
    public TokenResponseMetadataModel? Metadata { get; set; }

    [JsonPropertyName("collection")]
    public TokenResponseCollectionModel? Collection { get; set; }

    [JsonPropertyName("created_at")]
    public DateTime CreateAt { get; set; }

    [JsonPropertyName("updated_at")]
    public DateTime UpdateAt { get; set; }
}

public class TokenResponseMetadataModel
{
    [JsonPropertyName("ID")]
    public string? Id { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("Series")]
    public string? Series { get; set; }

    [JsonPropertyName("Attribute")]
    public string? Attribute { get; set; }

    [JsonPropertyName("image_url")]
    public string? ImageUrl { get; set; }

    [JsonPropertyName("Spectacular")]
    public string? Spectacular { get; set; }

    [JsonPropertyName("Token Frame")]
    public string? TokenFrame { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("Veefriends Count")]
    public int VeefriendsCount { get; set; }
}

public class TokenResponseCollectionModel
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("icon_url")]
    public string? IconUrl { get; set; }
}
