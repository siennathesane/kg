using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Http.HttpResults;

namespace necronomicon.Services;

public class EntityMapper {

    public IEnumerable<ObjectBase> Entities => _entities;

    private readonly IList<ObjectBase> _entities;
    private readonly IEnumerable<Entity> _map;

    public EntityMapper(IEnumerable<Entity> map) {
        _map = map;
        _entities = new List<ObjectBase>();
    }

    public void GenerateEntities(IEnumerable<Token> tokens) {
        foreach (var entity in _map) {
            if (entity.Label == EntityType.Cardinal.ToString()) {
                // todo (sienna): unsupported entity
                continue;
            }

            if (entity.Label == EntityType.Date.ToString()) {
                // todo (sienna): unsupported
                continue;
            }

            if (entity.Label == EntityType.Event.ToString()) {
                // todo (sienna): unsupported
                continue;
            }

            if (entity.Label == EntityType.Fac.ToString()) {
                // todo (sienna): unsupported
                continue;
            }

            if (entity.Label == EntityType.Gpe.ToString()) {
                // todo (sienna): unsupported
                continue;
            }

            if (entity.Label == EntityType.Language.ToString()) {
                // todo (sienna): unsupported
                continue;
            }

            if (entity.Label == EntityType.Law.ToString()) {
                // todo (sienna): unsupported
                continue;
            }

            if (entity.Label == EntityType.Loc.ToString()) {
                // todo (sienna): unsupported
                continue;
            }

            if (entity.Label == EntityType.Money.ToString()) {
                // todo (sienna): unsupported
                continue;
            }

            if (entity.Label == EntityType.Norp.ToString()) {
                // todo (sienna): unsupported
                continue;
            }

            if (entity.Label == EntityType.Ordinal.ToString()) {
                // todo (sienna): unsupported
                continue;
            }

            if (entity.Label == EntityType.Org.ToString()) {
                // todo (sienna): unsupported
                continue;
            }

            if (entity.Label == EntityType.Percent.ToString()) {
                // todo (sienna): unsupported
                continue;
            }

            if (entity.Label == EntityType.Person.ToString()) {
                var token = GetTokenByStringLocation(entity.Start, entity.End, tokens);

                var x = new Person {
                    Name = token.Lemma!
                };
                // todo (sienna): try to split out given and surnames
                _entities.Add(x);
                continue;
            }

            if (entity.Label == EntityType.Product.ToString()) {
                // todo (sienna): unsupported
                continue;
            }

            if (entity.Label == EntityType.Quantity.ToString()) {
                // todo (sienna): unsupported
                continue;
            }

            if (entity.Label == EntityType.Time.ToString()) {
                // todo (sienna): unsupported
                continue;
            }

            if (entity.Label == EntityType.WorkOfArt.ToString()) {
                // todo (sienna): unsupported
                continue;
            }
        }
    }

    /// <summary>
    /// Return an entity based off it's localized ID.
    /// </summary>
    /// <param name="head">The ID of the entity</param>
    /// <returns></returns>
    public ObjectBase GetEntityById(int head) {
        return _entities.First(h => h._localId == head);
    }

    private Token GetTokenByStringLocation(int start,int end, IEnumerable<Token> tokens) { return tokens.First(x => x.Start == start && x.End == end); }
}

[SuppressMessage("ReSharper", "StringLiteralTypo")]
[SuppressMessage("ReSharper", "InconsistentNaming")]
[SuppressMessage("ReSharper", "IdentifierTypo")]
public record EntityType {
    private readonly string _typeKeyWord;

    private EntityType(string typeWord) { _typeKeyWord = typeWord; }

    public override string ToString() { return _typeKeyWord; }

    public static IList<string> ToList() {
        return new List<string>() {
            Cardinal.ToString(),
            Date.ToString(),
            Event.ToString(),
            Fac.ToString(),
            Gpe.ToString(),
            Language.ToString(),
            Law.ToString(),
            Loc.ToString(),
            Money.ToString(),
            Norp.ToString(),
            Ordinal.ToString(),
            Org.ToString(),
            Percent.ToString(),
            Person.ToString(),
            Product.ToString(),
            Quantity.ToString(),
            Time.ToString(),
            WorkOfArt.ToString(),
        };
    }

    public static EntityType Cardinal => new EntityType("CARDINAL");
    public static EntityType Date => new EntityType("DATE");
    public static EntityType Event => new EntityType("EVENT");
    public static EntityType Fac => new EntityType("FAC");
    public static EntityType Gpe => new EntityType("GPE");
    public static EntityType Language => new EntityType("LANGUAGE");
    public static EntityType Law => new EntityType("LAW");
    public static EntityType Loc => new EntityType("LOC");
    public static EntityType Money => new EntityType("MONEY");
    public static EntityType Norp => new EntityType("NORP");
    public static EntityType Ordinal => new EntityType("ORDINAL");
    public static EntityType Org => new EntityType("ORG");
    public static EntityType Percent => new EntityType("PERCENT");
    public static EntityType Person => new EntityType("PERSON");
    public static EntityType Product => new EntityType("PRODUCT");
    public static EntityType Quantity => new EntityType("QUANTITY");
    public static EntityType Time => new EntityType("TIME");
    public static EntityType WorkOfArt => new EntityType("WORK_OF_ART");
}
