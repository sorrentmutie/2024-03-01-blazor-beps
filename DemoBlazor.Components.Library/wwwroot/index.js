export function somma(a, b) {
    return a + b;
}


export function  moltiplica(a, b) {
    return a * b;
}

export function doSomething(message) {
    DotNet.invokeMethodAsync("DemoBlazor.WASM", "DoSomething", message)
        .then(risultato => console.log(risultato));
}

