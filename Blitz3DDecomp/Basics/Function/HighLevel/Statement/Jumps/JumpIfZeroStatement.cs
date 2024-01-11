﻿namespace Blitz3DDecomp.HighLevel;

sealed record JumpIfZeroStatement(Expression Expression, HighLevelSection Section) : Statement
{
    public override string StringRepresentation
        => $"If ({Expression.StringRepresentation} = 0) Then Goto {Section.Name}";
}