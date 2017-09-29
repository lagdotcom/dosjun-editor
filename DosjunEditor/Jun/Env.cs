using System.Collections.Generic;

namespace DosjunEditor.Jun
{
    public static class Env
    {
        public static Dictionary<string, Internal> Internals = new Dictionary<string, Internal>
        {
            ["Facing"] = Internal.Facing,
            ["X"] = Internal.X,
            ["Y"] = Internal.Y
        };

        public static string[] Keywords = new string[]
        {
            "Combat",
            "Const",
            "Else",
            "ElseIf",
            "EndIf",
            "EndScript",
            "EquipItem",
            "GiveItem",
            "Global",
            "If",
            "Include",
            "Local",
            "PcSpeak",
            "Return",
            "Script",
            "SetTileColour",
            "SetTileDescription",
            "SetTileThing",
            "Teleport",
            "Text",
            "Unlock"
        };
        
        public static Dictionary<string, TokenType> Operators = new Dictionary<string, TokenType>
        {
            ["=="] = TokenType.Equals,
            ["!="] = TokenType.NotEqual,
            ["<="] = TokenType.LTE,
            [">="] = TokenType.GTE,
            ["<"] = TokenType.LT,
            [">"] = TokenType.GT,
            ["="] = TokenType.Assignment
        };
    }
}
