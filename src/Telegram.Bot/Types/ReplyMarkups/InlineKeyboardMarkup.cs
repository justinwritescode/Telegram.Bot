using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Telegram.Bot.Types.ReplyMarkups;

/// <summary>
/// This object represents an inline keyboard that appears right next to the <see cref="Message"/> it belongs to.
/// </summary>
/// <remarks>
/// Note: This will only work in Telegram versions released after 9 April, 2016. Older clients will display
/// <i>unsupported message</i>.
/// </remarks>
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class InlineKeyboardMarkup : IReplyMarkup
{
    /// <summary>
    /// Array of <see cref="InlineKeyboardButton"/> rows, each represented by an Array of
    /// <see cref="InlineKeyboardButton"/>.
    /// </summary>
    [JsonProperty(Required = Required.Always)]
    public IEnumerable<IEnumerable<InlineKeyboardButton>> InlineKeyboard { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="InlineKeyboardMarkup"/> class with only one keyboard button
    /// </summary>
    /// <param name="inlineKeyboardButton">Keyboard button</param>
    public InlineKeyboardMarkup(InlineKeyboardButton inlineKeyboardButton)
        : this(new[] { inlineKeyboardButton })
    { }

    /// <summary>
    /// Initializes a new instance of the <see cref="InlineKeyboardMarkup"/> class with a one-row keyboard
    /// </summary>
    /// <param name="inlineKeyboardRow">The inline keyboard row</param>
    public InlineKeyboardMarkup(IEnumerable<InlineKeyboardButton> inlineKeyboardRow)
        : this(new[] { inlineKeyboardRow })
    { }

    /// <summary>
    /// Initializes a new instance of the <see cref="InlineKeyboardMarkup"/> class.
    /// </summary>
    /// <param name="inlineKeyboard">The inline keyboard.</param>
    [JsonConstructor]
    [System.Text.Json.Serialization.JsonConstructor]
    public InlineKeyboardMarkup(IEnumerable<IEnumerable<InlineKeyboardButton>> inlineKeyboard) =>
        InlineKeyboard = inlineKeyboard;

    /// <summary>
    /// Generate an empty inline keyboard markup
    /// </summary>
    /// <returns>Empty inline keyboard markup</returns>
    public static InlineKeyboardMarkup Empty() =>
        new(Array.Empty<InlineKeyboardButton[]>());

    /// <summary>
    /// Generate an inline keyboard markup with one button
    /// </summary>
    /// <param name="button">Inline keyboard button</param>
    #if NET6_0_OR_GREATER
[return: NotNullIfNotNull("button")]
    #endif
    public static implicit operator InlineKeyboardMarkup?(InlineKeyboardButton? button) =>
        button is null ? default : new(button);

    /// <summary>
    /// Generate an inline keyboard markup with one button
    /// </summary>
    /// <param name="buttonText">Text of the button</param>
    #if NET6_0_OR_GREATER
[return: NotNullIfNotNull("buttonText")]
#endif
    public static implicit operator InlineKeyboardMarkup?(string? buttonText) =>
        buttonText is null ? default : new(buttonText!);

    /// <summary>
    /// Generate an inline keyboard markup from multiple buttons
    /// </summary>
    /// <param name="inlineKeyboard">Keyboard buttons</param>
    #if NET6_0_OR_GREATER
[return: NotNullIfNotNull("inlineKeyboard")]
#endif
    public static implicit operator InlineKeyboardMarkup?(IEnumerable<InlineKeyboardButton>[]? inlineKeyboard) =>
        inlineKeyboard is null ? default : new(inlineKeyboard);

    /// <summary>
    /// Generate an inline keyboard markup from multiple buttons on 1 row
    /// </summary>
    /// <param name="inlineKeyboard">Keyboard buttons</param>
    #if NET6_0_OR_GREATER
[return: NotNullIfNotNull("inlineKeyboard")]
#endif
    public static implicit operator InlineKeyboardMarkup?(InlineKeyboardButton[]? inlineKeyboard) =>
        inlineKeyboard is null ? default : new(inlineKeyboard);
}
