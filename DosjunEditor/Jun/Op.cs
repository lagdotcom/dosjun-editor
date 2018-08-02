﻿namespace DosjunEditor.Jun
{
    public enum Op : byte
    {
        NOP = 0,

        PushGlobal = 0x10,
        PushLocal,
        PushTemp,
        PushInternal,
        PushFlag,
        GetPCInSlot,
        PushLiteral = 0x1F,

        PopGlobal = 0x20,
        PopLocal,
        PopTemp,
        PopFlag,

        Add = 0x30,
        Sub,
        Mul,
        Div,
        And,
        Or,
        Invert,

        EQ = 0x40,
        NEQ,
        LT,
        LTE,
        GT,
        GTE,

        Jump = 0x50,
        JumpFalse,
        Return,
        Call,

        Combat = 0xA0,
        PcSpeak,
        Text,
        Unlock,
        GiveItem,
        EquipItem,
        SetTileDescription,
        SetTileColour,
        Teleport,
        SetTileThing,
        SetDanger,
        Safe,
        RemoveWall,
        Refresh,
        AddItem,
        Music,
        Converse,
        EndConverse,
        ChangeState,
        PcAction,
        NpcSpeak,
        NpcAction,
        Option,
        ChoosePcName,
        JoinParty,
        LeaveParty,
        ChoosePcPortrait,
        ChoosePcPronouns,
        SetAttitude,
        GetAttitude,
        GotoXY,
        InParty,
        HasBuff,
        AddBuff,
        RemoveBuff,
        Fade,
    }
}
