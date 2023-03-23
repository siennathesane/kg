using System.Text.Json.Serialization;

namespace necronomicon.Services; 

public record ObjectBase {
    public Guid Id { get; init; }
    public DateTime Created { get; init; }
    public DateTime Modified { get; set; }
    public bool Archived { get; set; }
    public IDictionary<string, bool> Properties { get; init; } = new Dictionary<string, bool>();

    [JsonIgnore]
    internal int? _localId { get; init; }
}

/// <summary>
/// Numerals that do not fall under another type
/// </summary>
public record Cardinal : ObjectBase {
    public required string Value { get; init; }
}

/// <summary>
/// Absolute or relative dates or periods
/// </summary>
public record Date : ObjectBase {
    public required string When { get; init; }
}

/// <summary>
/// Named hurricanes, battles, wars, sports events, etc.
/// </summary>
public record Event : ObjectBase {
    public required string Name { get; init; }
}

/// <summary>
/// Buildings, airports, highways, bridges, etc.
/// </summary>
public record Facility : ObjectBase {
    public required string Name { get; init; }
}

/// <summary>
/// Countries, cities, states
/// </summary>
public record GeopoliticalEntity : ObjectBase {
    public required string Name { get; init; }
}

/// <summary>
/// Any named language
/// </summary>
public record Language : ObjectBase {
    public required string Name { get; init; }
}

/// <summary>
/// Named documents made into laws.
/// </summary>
public record Law : ObjectBase {
    public required string Name { get; init; }
}

/// <summary>
/// Non-GPE locations, mountain ranges, bodies of water
/// </summary>
public record Location : ObjectBase {
    public required string Name { get; init; }
}

/// <summary>
///  Monetary values, including unit
/// </summary>
public record Money : ObjectBase {
    public required decimal Value { get; init; }
}

/// <summary>
/// Nationalities or religious or political groups
/// </summary>
public record Norp : ObjectBase {
    public required string Name { get; init; }
}

/// <summary>
/// "first", "second", etc.
/// </summary>
public record Ordinal : ObjectBase {
    public required string Kind { get; init; }
}

/// <summary>
/// Companies, agencies, institutions, etc.
/// </summary>
public record Organization : ObjectBase {
    public required string Name { get; init; }
}

/// <summary>
/// Percentage
/// </summary>
public record Percent : ObjectBase {
    public required double Value { get; init; }

    public override string ToString() {
        return $"{Value}%";
    }
}

/// <summary>
/// People, including fictional
/// </summary>
public record Person : ObjectBase {
    public required string Name { get; init; }
}

/// <summary>
/// Objects, vehicles, foods, etc. (not services)
/// </summary>
public record Product : ObjectBase {
    public required string Name { get; init; }
}

/// <summary>
/// Measurements, as of weight or distance
/// </summary>
public record Quantity : ObjectBase {
    public required double Amount { get; init; }
    public required string Type { get; init; }
}

/// <summary>
/// Times smaller than a day
/// </summary>
public record Time : ObjectBase {
    public required string Value { get; init; }
}

/// <summary>
/// Titles of books, songs, etc.
/// </summary>
public record WorkofArt : ObjectBase {
    public required string Name { get; set; }
    public string? Type { get; init; }
}
