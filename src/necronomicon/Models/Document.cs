using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace necronomicon.Models; 

[DataContract]
public record DocumentRequest {
    [Required]
    public Guid Id { get; init; }
    [Required]
    [MaxLength(512)]
    public string Title { get; init; }
    [Required]
    [MaxLength(Int32.MaxValue)]
    public string Content { get; init; }
}

[DataContract]
public record DocumentResponse {
    public string? Error { get; } = "";
}

public class Document {
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
}
