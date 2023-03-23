using System.Text.Json;
using System.Text.Json.Serialization;

namespace necronomicon.Services;

public class NlpService {
    private readonly ILogger<NlpService> _logger;
    private readonly IHttpClientFactory _httpClientFactory;
    private const string NLP_SERVICE_URL = "http://localhost:8080/v1/extract";

    public NlpService(ILogger<NlpService> logger, IHttpClientFactory httpClientFactory) {
        _logger = logger;
        _httpClientFactory = httpClientFactory;
    }

    public async Task<NlpResponse> Parse(NlpRequest request) {
        using var client = _httpClientFactory.CreateClient();
        var resp = await client.PostAsJsonAsync(NLP_SERVICE_URL,
                                                request,
                                                new JsonSerializerOptions {
                                                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                                                });

        if (!resp.IsSuccessStatusCode) {
            _logger.LogError(resp.ReasonPhrase);
        }

        var stream = resp.Content.ReadAsStream();

        var target =
            await JsonSerializer.DeserializeAsync<NlpResponse>(stream,
                                                               new JsonSerializerOptions {
                                                                   PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                                                               });

        return target;
    }
}

public class NlpRequest {
    public string Content { get; set; }
}

public class NlpResponse {
    [JsonPropertyName("ents")]
    public Entity[] Ents { get; set; }

    [JsonPropertyName("sents")]
    public Sentence[] Sents { get; set; }

    [JsonPropertyName("tokens")]
    public Token[] Tokens { get; set; }
}

public class Entity {
    public int Start { get; set; }
    public int End { get; set; }
    public string Label { get; set; }
}

public class Sentence {
    public int Start { get; set; }
    public int End { get; set; }
}

public class Token : IComparable<Token>, IComparable {
    public int Id { get; set; }
    public int Start { get; set; }
    public int End { get; set; }
    public string? Tag { get; set; }

    [JsonPropertyName("pos")]
    public string? PartOfSpeech { get; set; }

    // [JsonIgnore]
    // public object? MorphologyFeatures { get; set; }

    public string? Lemma { get; set; }

    [JsonPropertyName("dep")]
    public string? DependencyType { get; set; }

    public int Head { get; set; }

    public int CompareTo(Token? other) {
        if (ReferenceEquals(this, other)) {
            return 0;
        }

        if (ReferenceEquals(null, other)) {
            return 1;
        }

        var idComparison = Id.CompareTo(other.Id);

        if (idComparison != 0) {
            return idComparison;
        }

        var startComparison = Start.CompareTo(other.Start);

        if (startComparison != 0) {
            return startComparison;
        }

        var endComparison = End.CompareTo(other.End);

        if (endComparison != 0) {
            return endComparison;
        }

        var tagComparison = string.Compare(Tag, other.Tag, StringComparison.Ordinal);

        if (tagComparison != 0) {
            return tagComparison;
        }

        var partOfSpeechComparison = string.Compare(PartOfSpeech, other.PartOfSpeech, StringComparison.Ordinal);

        if (partOfSpeechComparison != 0) {
            return partOfSpeechComparison;
        }

        var lemmaComparison = string.Compare(Lemma, other.Lemma, StringComparison.Ordinal);

        if (lemmaComparison != 0) {
            return lemmaComparison;
        }

        var dependencyTypeComparison = string.Compare(DependencyType, other.DependencyType, StringComparison.Ordinal);

        if (dependencyTypeComparison != 0) {
            return dependencyTypeComparison;
        }

        return Head.CompareTo(other.Head);
    }

    public int CompareTo(object? obj) {
        if (ReferenceEquals(null, obj)) {
            return 1;
        }

        if (ReferenceEquals(this, obj)) {
            return 0;
        }

        return obj is Token other ? CompareTo(other) : throw new ArgumentException($"Object must be of type {nameof(Token)}");
    }
}
