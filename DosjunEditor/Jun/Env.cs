using System.Collections.Generic;

namespace DosjunEditor.Jun
{
    public static class Env
    {
        public static Dictionary<string, Internal> Internals = new Dictionary<string, Internal>
        {
            ["Danger"] = Internal.Danger,
            ["Facing"] = Internal.Facing,
            ["X"] = Internal.X,
            ["Y"] = Internal.Y,
            ["JustMoved"] = Internal.JustMoved,
            ["Success"] = Internal.Success,
        };

        public static string[] Keywords = new string[]
        {
            "AddItem",
            "Call",
            "ChangeState",
            "Combat",
            "Const",
            "Converse",
            "Else",
            "ElseIf",
            "EndConverse",
            "EndIf",
            "EndScript",
            "EndState",
            "EquipItem",
            "GiveItem",
            "Global",
            "If",
            "Include",
            "Local",
            "Music",
            "NpcAction",
            "NpcSpeak",
            "Option",
            "PcAction",
            "PcSpeak",
            "Refresh",
            "RemoveWall",
            "Return",
            "Safe",
            "Script",
            "SetDanger",
            "SetTileColour",
            "SetTileDescription",
            "SetTileThing",
            "State",
            "Teleport",
            "Text",
            "Unlock",
        };
        
        public static Dictionary<string, TokenType> Operators = new Dictionary<string, TokenType>
        {
            ["=="] = TokenType.Equals,
            ["!="] = TokenType.NotEqual,
            ["<="] = TokenType.LTE,
            [">="] = TokenType.GTE,
            ["<"] = TokenType.LT,
            [">"] = TokenType.GT,
            ["="] = TokenType.Assignment,
            ["+"] = TokenType.Add,
            ["-"] = TokenType.Subtract,
            ["*"] = TokenType.Multiply,
            ["/"] = TokenType.Divide,
            ["&"] = TokenType.And,
            ["|"] = TokenType.Or,
        };
    }
}
