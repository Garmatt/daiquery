﻿namespace DaiQuery
{
    /// <summary>
    /// An entity that can be rendered to SQL code.
    /// </summary>
    internal interface IRenderableEntity
    {
        string Render(bool useIndentation);
        string Render();
        string RenderInline();
        string RenderIndented(int indentation);
    }
}