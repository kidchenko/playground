# Essential Techniques

Use `csc` to compile HelloWorld.cs. It will generate an HelloWorld.exe

## Introducing Tools

- Inspecting Intermediate Language  (IL)
    - Virtual machine language of the CLR
    - Target language of C# compiler (C# => IL)
    - JIT compile into native code

### Tools to inspect IL
    
- ILDASM
    - Ships with Visual Studio and .NET Framework SDK
    - IL roundtriping with ILASM (textual language for IL) - we can emit the IL code to a text file, we can modify the code and reassemble it using a tool called ILASM back into .NET assembly

- .NET Reflector
    - Built by Red Gate
    - Decompiler of IL into C#

- ILSpy
    - Open source alternative to `.NET Reflector`

### Inspecting IL Code

- Go to `csc` folder
- Use `ildasm.exe` to inspect HelloWorld.exe 
    - `ildasm.exe HelloWorld.exe` 
        - In the manifest you will see `.subsystem 0x0003       // WINDOWS_CUI` -> CUI means Console User Interface
- Go to View -> Show bytes
- Output the IL to a file
    - `ildasm /out=HelloWorld.il HelloWorld.exe`
    - Change `Hello, World!` to something else
- Use ilasm to reassembly the modified il file
    - `ilasm /exe HelloWorld.il`