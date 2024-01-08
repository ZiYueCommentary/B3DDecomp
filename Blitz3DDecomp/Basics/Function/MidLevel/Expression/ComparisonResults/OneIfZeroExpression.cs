﻿namespace Blitz3DDecomp.MidLevel;

sealed record OneIfZeroExpression(Expression OriginalExpression) : Expression
{
    public override string StringRepresentation
        => $"({OriginalExpression.StringRepresentation} = 0)";
}