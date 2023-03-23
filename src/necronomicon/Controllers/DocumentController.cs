using Microsoft.AspNetCore.Mvc;
using necronomicon.Models;
using necronomicon.Services;
using Schema.NET;

namespace necronomicon.Controllers;

[ApiController]
[Route("/v1/docs")]
[Produces("application/json")]
public class DocumentController : ControllerBase {
    private readonly ILogger<DocumentController> _logger;
    private readonly DocumentStoreService _dss;

    public DocumentController(ILogger<DocumentController> logger, DocumentStoreService documentStoreService) {
        _dss = documentStoreService;
        _logger = logger;
    }

    [HttpPost]
    public async Task<IActionResult> Upload([FromBody] DocumentRequest request) {
        try {
            _dss.ExtractTextDocument(new Document() {
                Id = request.Id, Title = request.Title, Content = request.Content,
            });
        } catch (Exception e) {
            _logger.LogError(e, "cannot extract text");

            return BadRequest("bad result");
        }

        return Ok();
    }
}
