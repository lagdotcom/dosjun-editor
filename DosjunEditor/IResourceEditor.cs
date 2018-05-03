using System;

namespace DosjunEditor
{
    internal interface IResourceEditor
    {
        IHasResource Editing { get; }

        event EventHandler Saved;

        void Setup(Context ctx, IHasResource r);
        void Show();
    }
}