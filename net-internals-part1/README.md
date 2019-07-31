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

### Inspecting Runtime State

- Inspecting runtime state
    - State of your program
    - Underlying data structures of the runtime (CLR) - VS debugger is not good at that, native code debugers are

- Visual Studio debugger
    - Stepping through source, setting breakpoints
    - Controlling exception behavior
    - Expression evaluator (Watch, Immediate)

- Native code debugger
    - Debugging Tools for Windows download
    - WinDbg.exe and cdb.exe (native debuggers don't understand CLR so well, but we add extra extensions and it works great)
    - SOS, PSSCOR4, SOSEX, CLRMD debugger extensions - SoS means Son of Strike (Strike is the codename of the CLR debugger), PSSCOR4 is a great tool to debug ASP .NET

- Using cdb.exe `C:\Program Files (x86)\Windows Kits\10\Debuggers`
    - `cdb.exe HelloWorld.exe`
    - `sxe ld clrjit; g`
    - Now we want to load the the sos extension
    - `.loadby sos clr`
    - Let's set a breakpoint in Main
    - `!bpmd HelloWorld.exe Program.Main`
    - `g` to continue execution and hit the breakpoint
    - `qd` to Quit and Detach

- Using WinDbg
    - Open WinDbg
    - Notify the debug when the clrjit is load
    - `sxe ld clrjit`
    - `g` to continue
    - See in the message the last loaded assembly was `clrjit`
    - Load sos extension
    - `.loadby sos clr`
    - `!help` to see the commands available
    - `!procinfo` 2 times
    - Let's set a breakpoint in Main
    - `!bpmd HelloWorld.exe Program.Main`
    - `g`
    - `k` to show the call stack
    - `!clrstack` maybe twice
    - `qd` to exit

### Summary

- Understand internals
    - Becomme a better engineer
    - Engineering for performance
    - Invaluable when debugging

- C# has no secrets
    - IL code inspection
    - Debugger techniques

- Familiarize yourself with tools
    - ILDASM
    - ILSpy
    - WinDbg & SOS


## The CLR and IL in a Nutshell

### Introduction to IL

- Intermediate Language (IL)
    - Virtual machine language of the CLR
        - Emitted by managed language compilers (C#, VB, F#)
        - NGEN or JIT compile to native code
    - Stack-based evaluation (this make a easy target for compilers)
        - No registers
        - Local, arguments, fields, etc
    - Verification
        - Type safe
        - Memory safe
    - Leverages metadata


- Stack based evaluation
    - Scratch-pad for computation
    - Pop operands, execute operator, push result
    - Each instruction has a net effect on the stack
        - add = 2 x pop + 1 x push (2 pop instructions to get the values and 1 pusg instruction to send the result)
    - Stack transitions for "1 + 2" (1 + 2 will compile to 3 instructions)
        - `ldc.i4.1` => `ldc.i4.2` => `add`
            - `ldc` = load constant
