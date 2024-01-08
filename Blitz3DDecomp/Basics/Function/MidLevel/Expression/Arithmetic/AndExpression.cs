﻿namespace Blitz3DDecomp.MidLevel;

sealed record AndExpression(Expression Lhs, Expression Rhs) : Expression
{
    public override string StringRepresentation
        => $"({Lhs.StringRepresentation} And {Rhs.StringRepresentation})";
}