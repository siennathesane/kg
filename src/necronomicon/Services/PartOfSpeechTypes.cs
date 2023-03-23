using System.Diagnostics.CodeAnalysis;

namespace necronomicon.Services;

/// <summary>
/// Parts of speech represented as concrete types in alignment with Universal Dependencies
/// </summary>
[SuppressMessage("ReSharper", "StringLiteralTypo")]
[SuppressMessage("ReSharper", "InconsistentNaming")]
[SuppressMessage("ReSharper", "IdentifierTypo")]
public record PartOfSpeechType {
    private readonly string _typeKeyWord;
    private PartOfSpeechType(string typeKeyWord) { _typeKeyWord = typeKeyWord; }
    public override string ToString() { return _typeKeyWord; }

    /// <summary>
    /// symbol, currency
    /// </summary>
    public static PartOfSpeechType Currency => new PartOfSpeechType("$");

    /// <summary>
    /// closing quotation mark
    /// </summary>
    public static PartOfSpeechType ClosingQuotationMark => new PartOfSpeechType("''");

    /// <summary>
    /// punctuation mark, comma
    /// </summary>
    public static PartOfSpeechType Comma => new PartOfSpeechType(",");

    /// <summary>
    /// left round bracket
    /// </summary>
    public static PartOfSpeechType LeftRoundBracket => new PartOfSpeechType("-LRB-");

    /// <summary>
    /// right round bracket
    /// </summary>
    public static PartOfSpeechType RightRoundBracket => new PartOfSpeechType("-RRB-");

    /// <summary>
    /// punctuation mark, sentence closer
    /// </summary>
    public static PartOfSpeechType Period => new PartOfSpeechType(".");

    /// <summary>
    /// punctuation mark, colon or ellipsis
    /// </summary>
    public static PartOfSpeechType Colon => new PartOfSpeechType(":");

    /// <summary>
    /// email
    /// </summary>
    public static PartOfSpeechType ADD => new PartOfSpeechType("ADD");

    /// <summary>
    /// affix
    /// </summary>
    public static PartOfSpeechType AFX => new PartOfSpeechType("AFX");

    /// <summary>
    /// conjunction, coordinating
    /// </summary>
    public static PartOfSpeechType CC => new PartOfSpeechType("CC");

    /// <summary>
    /// cardinal number
    /// </summary>
    public static PartOfSpeechType CD => new PartOfSpeechType("CD");

    /// <summary>
    /// determiner
    /// </summary>
    public static PartOfSpeechType DT => new PartOfSpeechType("DT");

    /// <summary>
    /// existential there
    /// </summary>
    public static PartOfSpeechType EX => new PartOfSpeechType("EX");

    /// <summary>
    /// foreign word
    /// </summary>
    public static PartOfSpeechType FW => new PartOfSpeechType("FW");

    /// <summary>
    /// punctuation mark, hyphen
    /// </summary>
    public static PartOfSpeechType HYPH => new PartOfSpeechType("HYPH");

    /// <summary>
    /// conjunction, subordinating or preposition
    /// </summary>
    public static PartOfSpeechType IN => new PartOfSpeechType("IN");

    /// <summary>
    /// adjective (English), other noun-modifier (Chinese)
    /// </summary>
    public static PartOfSpeechType JJ => new PartOfSpeechType("JJ");

    /// <summary>
    /// adjective, comparative
    /// </summary>
    public static PartOfSpeechType JJR => new PartOfSpeechType("JJR");

    /// <summary>
    /// adjective, superlative
    /// </summary>
    public static PartOfSpeechType JJS => new PartOfSpeechType("JJS");

    /// <summary>
    /// list item marker
    /// </summary>
    public static PartOfSpeechType LS => new PartOfSpeechType("LS");

    /// <summary>
    /// verb, modal auxiliary
    /// </summary>
    public static PartOfSpeechType MD => new PartOfSpeechType("MD");

    /// <summary>
    /// superfluous punctuation
    /// </summary>
    public static PartOfSpeechType NFP => new PartOfSpeechType("NFP");

    /// <summary>
    /// noun, singular or mass
    /// </summary>
    public static PartOfSpeechType NN => new PartOfSpeechType("NN");

    /// <summary>
    /// noun, proper singular
    /// </summary>
    public static PartOfSpeechType NNP => new PartOfSpeechType("NNP");

    /// <summary>
    /// noun, proper plural
    /// </summary>
    public static PartOfSpeechType NNPS => new PartOfSpeechType("NNPS");

    /// <summary>
    /// noun, plural
    /// </summary>
    public static PartOfSpeechType NNS => new PartOfSpeechType("NNS");

    /// <summary>
    /// predeterminer
    /// </summary>
    public static PartOfSpeechType PDT => new PartOfSpeechType("PDT");

    /// <summary>
    /// possessive ending
    /// </summary>
    public static PartOfSpeechType POS => new PartOfSpeechType("POS");

    /// <summary>
    /// pronoun, personal
    /// </summary>
    public static PartOfSpeechType PRP => new PartOfSpeechType("PRP");

    /// <summary>
    /// pronoun, possessive
    /// </summary>
    public static PartOfSpeechType PosesssivePRP => new PartOfSpeechType("PRP$");

    /// <summary>
    /// adverb
    /// </summary>
    public static PartOfSpeechType RB => new PartOfSpeechType("RB");

    /// <summary>
    /// adverb, comparative
    /// </summary>
    public static PartOfSpeechType RBR => new PartOfSpeechType("RBR");

    /// <summary>
    /// adverb, superlative
    /// </summary>
    public static PartOfSpeechType RBS => new PartOfSpeechType("RBS");

    /// <summary>
    /// adverb, particle
    /// </summary>
    public static PartOfSpeechType RP => new PartOfSpeechType("RP");

    /// <summary>
    /// symbol
    /// </summary>
    public static PartOfSpeechType SYM => new PartOfSpeechType("SYM");

    /// <summary>
    /// infinitival "to"
    /// </summary>
    public static PartOfSpeechType TO => new PartOfSpeechType("TO");

    /// <summary>
    /// interjection
    /// </summary>
    public static PartOfSpeechType UH => new PartOfSpeechType("UH");

    /// <summary>
    /// verb, base form
    /// </summary>
    public static PartOfSpeechType VB => new PartOfSpeechType("VB");

    /// <summary>
    /// verb, past tense
    /// </summary>
    public static PartOfSpeechType VBD => new PartOfSpeechType("VBD");

    /// <summary>
    /// verb, gerund or present participle
    /// </summary>
    public static PartOfSpeechType VBG => new PartOfSpeechType("VBG");

    /// <summary>
    /// verb, past participle
    /// </summary>
    public static PartOfSpeechType VBN => new PartOfSpeechType("VBN");

    /// <summary>
    /// verb, non-3rd person singular present
    /// </summary>
    public static PartOfSpeechType VBP => new PartOfSpeechType("VBP");

    /// <summary>
    /// verb, 3rd person singular present
    /// </summary>
    public static PartOfSpeechType VBZ => new PartOfSpeechType("VBZ");

    /// <summary>
    /// wh-determiner
    /// </summary>
    public static PartOfSpeechType WDT => new PartOfSpeechType("WDT");

    /// <summary>
    /// wh-pronoun, personal
    /// </summary>
    public static PartOfSpeechType WP => new PartOfSpeechType("WP");

    /// <summary>
    /// wh-pronoun, possessive
    /// </summary>
    public static PartOfSpeechType WPPossessive => new PartOfSpeechType("WP$");

    /// <summary>
    /// wh-adverb
    /// </summary>
    public static PartOfSpeechType WRB => new PartOfSpeechType("WRB");

    /// <summary>
    /// unknown
    /// </summary>
    public static PartOfSpeechType XX => new PartOfSpeechType("XX");

    /// <summary>
    /// whitespace
    /// </summary>
    public static PartOfSpeechType OpeningQuotationMark => new PartOfSpeechType("``");
}
