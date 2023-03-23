using DataStructures.Graphs;

namespace necronomicon.Services; 

/// <summary>
/// LanguageGraph is a technical representation of a universal dependency relationship of a deconstructed corpus.
/// </summary>
/// todo (sienna): implement this in orleans
public class LanguageGraph {
    private readonly DirectedDenseGraph<Token> _graph;
    private EntityMapper _entityMapper;

    public LanguageGraph() {
        _graph = new DirectedDenseGraph<Token>();
    }

    /// <summary>
    /// Asynchronously load the deconstructed corpus into an in-memory graph. This is asynchronous due to the potential
    /// for several million vertices and edges and will free up the CLR a bit for other requests to be processed.
    /// </summary>
    /// <param name="response"><see cref="NlpResponse"/></param>
    public async Task Load(NlpResponse response) {
        // load the vertices
        await Task.Run(() => {
            foreach (var token in response.Tokens) {
                _graph.AddVertex(token);
            }
        });

        // map the edges
        await Task.Run(() => {
            foreach (var token in response.Tokens) {
                if (token.Head != token.Id) {
                    _graph.AddEdge(token, response.Tokens.First(t => t.Id == token.Head));
                }
            }
        });

        _entityMapper = new EntityMapper(response.Ents);
    }

    public override string ToString() { return _graph.ToString() ?? _graph.ToReadable(); }
}
