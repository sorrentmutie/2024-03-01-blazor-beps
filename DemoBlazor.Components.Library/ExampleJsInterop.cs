using Microsoft.JSInterop;

namespace DemoBlazor.Components.Library
{
    // This class provides an example of how JavaScript functionality can be wrapped
    // in a .NET class for easy consumption. The associated JavaScript module is
    // loaded on demand when first needed.
    //
    // This class can be registered as scoped DI service and then injected into Blazor
    // components for use.

    public class ExampleJsInterop : IAsyncDisposable
    {
        private readonly Lazy<Task<IJSObjectReference>> moduleTask;
        private readonly Lazy<Task<IJSObjectReference>> moduleTaskIndex;
        private readonly Lazy<Task<IJSObjectReference>> moduleTaskModal;

        public ExampleJsInterop(IJSRuntime jsRuntime)
        {
            moduleTask = new(() => jsRuntime.InvokeAsync<IJSObjectReference>(
                "import", "./_content/DemoBlazor.Components.Library/exampleJsInterop.js").AsTask());
            moduleTaskIndex = new(() => jsRuntime.InvokeAsync<IJSObjectReference>(
                "import", "./_content/DemoBlazor.Components.Library/index.js").AsTask());
            moduleTaskModal = new(() => jsRuntime.InvokeAsync<IJSObjectReference>(
                "import", "./_content/DemoBlazor.Components.Library/modal.js").AsTask());

        }

        public async Task ShowModal(string Id)
        {
            var module = await moduleTaskModal.Value;
            await module.InvokeVoidAsync("showModal", Id);  
        }

        public async Task HideModal()
        {
            var module = await moduleTaskModal.Value;
            await module.InvokeVoidAsync("hideModal");
        }


        public async ValueTask<string> Prompt(string message)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<string>("showPrompt", message);
        }

        public async ValueTask<string> DoSomething(string message)
        {
            var module = await moduleTaskIndex.Value;
            return await module.InvokeAsync<string>("doSomething", message);
        }


        public async ValueTask<int> Sum(int a, int b)
        {
            var module = await moduleTaskIndex.Value;
            return await module.InvokeAsync<int>("somma", a, b);
        }

        public async ValueTask<int> Multiply(int a, int b)
        {
            var module = await moduleTaskIndex.Value;
            return await module.InvokeAsync<int>("moltiplica", a, b);
        }

        public async ValueTask DisposeAsync()
        {
            if (moduleTask.IsValueCreated)
            {
                var module = await moduleTask.Value;
                await module.DisposeAsync();
            }
        }
    }
}
