using System.Text.Json;
using System.Text.Json.Serialization;
using Schema.NET;
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
var person = new Person();
Console.WriteLine(JsonSerializer.Serialize(person));
