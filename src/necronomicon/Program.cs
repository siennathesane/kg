using System.Reflection;
using necronomicon.Services;
using Neo4j.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpClient();
builder.Services.AddSingleton(GraphDatabase.Driver(
                                  Environment.GetEnvironmentVariable("NEO4J_URI") ?? "neo4j://localhost",
                                  AuthTokens.Basic(Environment.GetEnvironmentVariable("NEO4J_USER") ?? "necro",
                                                   Environment.GetEnvironmentVariable("NEO4J_PASSWORD")
                                                   ?? "necro123!")));
builder.Services.AddSingleton<DocumentStoreService>();
builder.Services.AddSingleton<NlpService>();
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opts => {
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    opts.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
