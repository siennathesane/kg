using necronomicon.Models;
using Neo4j.Driver;

namespace necronomicon.Services;

public class DocumentStoreService : IDisposable {
    private readonly IDriver _driver;
    private readonly NlpService _nlpService;
    private readonly ILogger<DocumentStoreService> _logger;

    public DocumentStoreService(IDriver driver, ILogger<DocumentStoreService> logger, NlpService nlpService) {
        _driver = driver;
        _logger = logger;
        _nlpService = nlpService;
    }

    public async void ExtractTextDocument(Document doc) {
        var resp = await _nlpService.Parse(new NlpRequest() { Content = doc.Content });

        var languageGraph = new LanguageGraph();
        await languageGraph.Load(resp);

        _logger.LogInformation(languageGraph.ToString());
    }

    public void Dispose() { _driver?.Dispose(); }
}
