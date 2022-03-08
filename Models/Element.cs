using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ImxTools.Models;


public class Metadata
{
    [JsonPropertyName("ID")]
    public string ID { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("Series")]
    public string Series { get; set; }

    [JsonPropertyName("Attribute")]
    public string Attribute { get; set; }

    [JsonPropertyName("image_url")]
    public string ImageUrl { get; set; }

    [JsonPropertyName("Spectacular")]
    public string Spectacular { get; set; }

    [JsonPropertyName("Token Frame")]
    public string TokenFrame { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("Eligible For")]
    public List<object> EligibleFor { get; set; }

    [JsonPropertyName("Veefriends Count")]
    public int VeefriendsCount { get; set; }

    [JsonPropertyName("Character Appearances")]
    public List<object> CharacterAppearances { get; set; }
}

public class Collection
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("icon_url")]
    public string IconUrl { get; set; }
}

public class Element
{
    [JsonPropertyName("token_address")]
    public string TokenAddress { get; set; }

    [JsonPropertyName("token_id")]
    public string TokenId { get; set; }

    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("user")]
    public string User { get; set; }

    [JsonPropertyName("status")]
    public string Status { get; set; }

    [JsonPropertyName("uri")]
    public object Uri { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("image_url")]
    public string ImageUrl { get; set; }

    [JsonPropertyName("metadata")]
    public Metadata Metadata { get; set; }

    [JsonPropertyName("collection")]
    public Collection Collection { get; set; }

    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; }

    [JsonPropertyName("updated_at")]
    public DateTime UpdatedAt { get; set; }
}
