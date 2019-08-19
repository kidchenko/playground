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


# The CLR and IL in a Nutshell

## Introduction to IL

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
        - add = 2 x pop + 1 x push (2 pop instructions to get the values and 1 push instruction to send the result)
    - Stack transitions for "1 + 2" (1 + 2 will compile to 3 instructions)
        - `ldc.i4.1` => `ldc.i4.2` => `add`
            - `ldc` = load constant

## Essential Instructions

- pop
    - Pops the object on the top of the stack
    - Ofter used to discard stuff to rebalance the stack
- dup 
    - Duplicate the object on top of the stack
    - Oftern used to eliminate loads and stores to locals
- nop
    - No-operation, doesn't do anything 'useful'
    - Used in non-optmized builds
        - Allow break points can be set
        - eg. emit nop for lines with curly braces


### Loading Constants

- Numerical
    - ldc.i4 => load const integer 4 bytes (int)
    - ldc.r8 => load float points 8 byes (doubles)
    - Short hand instructions, eg. `ldc.i4.1` for int32 `1`, ldc.i4.m1 for int32 `-1`

- Boolean
    - Represented as 0 or 1

- String
    - ldstr for load string
    - value points to a string table entry

- Null
    - ldnull
    - Null reference, useful for initialization or cleanup of locations


## Local Variables in IL

- Locals
    - Typed slots to hold objects
    - JIT may put those in machine registers or on the stack
    - Instruction to load and store
        - eg. ldloc.0 pushes the Oth local onto the evaluation stack
        - eg. stloc.1 pops from the evaluation stack and stores into the 1st local
        - ex. ldc.i4.1 (push 1 to stack) => stloc.0 (pop the 0th element from the stack and add in local variable slot) => ldloc.0 (push the 0th element to stack) - obs. ldloc doesn't remove the value from the local when push to stack, result will be = 1 in stack and 1 in the local slot.


## Basic IL Instructions and Branching

Quick Intro to IL Code

- Arithmetic, relational, logical. conversions
    - Arithmetic instructions
        - neg, add, sub, mul, div, rem, shl, shr
        - Overflow variants with .ovf suffix (cf. checked in C#)
    - Relational Instructions
        - clt, cle, cgt, cge, cew, cne 
        - Push 0 or 1 on based on outcome comparsion
    - Bitwise logical instructions
        - and, or, xor
    - Conversions
        - conv.<type>, eg. to conv.i4 to 4 bytes to integer
        - isinst for type check
        - castclass for casa to a specified type


## Branch Instructions

- Unconditional branch
    - br method-local branch using the specified offset
- Conditional branch instructions
    - brtrue, brfalse, - check top stack for true or false
    - beq, bne, blt, bgt, bge - relational operators with branching
- Variants
    - .s suffix - shor branch if offset fits 1 byte
    - .un - unsigned variants
- Switch tables
    - switch - jumps based on integer operand

## Analyzing Branches in ILDASM

- Go to `branch` folder
- Compile it one time with the optimizations disabled
    - `csc Branch.cs`
        - with the optimizer disabled the code is slighly different, in the `if/else if/else`
- Now compile with the opmitzations enable
    - `csc /o+ Branch.cs`

## Call Instructions and Call Stacks

There are different instructions to call a method.
Source code: `./call`

- Different call instructions
    - `call` - regular direct call
    - `callvirt` - call with virtual dispatch
    - `calli` - indirect call through a pointer (interop)


- Arguments
    - push arguments to make a method call
        - arguments passed left-to-right on the stack
        - Instabce methods hold `this` in the 0th argument
    - Call stack frames hold local and arguments
    - Instruction to load an argument: `ldarg`

- Return to caller using ret instruction
    - Stack should only contain one object (or none if void) - `Exceptions` (error) are an exception because unwind the call stack

### Quick Intro to IL Code

csharp
```
double d = Math.Pow(3.14, 2.81);
Console.WriteLine(d);
```

1. ldc.r8 3.14
2. ldc.r8 2.81
3. call ... System.Math::Pow(float64, float64)
4. stloc.0
5. ldloc.0
6. call ... System.Console::WriteLine(float64)
7. ret

Go to `call` folder

- Calls in C#
    - static methods use `call`
    - Instance methods use `callvirt`
        - even for non-virtuals
        - Perform null check for v-table (if instance is null throws `NullReferenceException`)
    - Special calls
        - Use native implementation provided by the CLR
        - [MethodImpl(MethodImplOptions.InsternalCall)]
            - Oftern used for reflection- related stuff
            - eg. `Systen.Object::GetType` - doesn't have an IL body. but transfer the call to internals of CLR
        - [DllImport("QCall")]
            - Quick calls
                - from the `mscorlib.dll` assembly
                - to native helper methods in `mscorwks.dll` or `clr.dll`
                - eg. System.GC::_Collect


## Exceptions, Objects and Arrays

- Throwing exceptions
    - throw
        - used for `throw ex;` in C#;
        - reset the stack trace
            - ExceptionDispatchInfo in .NET 4.5
    - rethrow
        - Used for `throw;` in C#
- Handling exceptioms
    - IL has metadata that describes a protected region, ie. `try`
        - catch type-based exception handling
        - finally - cleanup sucessful or exceptional exit
    - The IL use control flow in and out of a protected region
        - leave instruction to exit a protected region
            - causes handlers to run
        - endfinallt and endfault to exit handlers


- Working with objects
    - newobj creates a new object on the GC heap
        - Causes memory allocation and can throw OutOfMemoryException
        - Runs specidfied constructor on object with zeroed memory
        - Returns reference to newly created object
- IL instructions
    - `ldfld and stfld`
        - Load and stores from/to fields
        - Parameterized by metadata token of the fields
- Arrays (one-dimensional)
    - newarr - creates a new array of the specified lenght
    - `ldlen` - loads the array lenght
    - `ldelem`and `stelem` - loads and store array elements using an index

## The Role of JIT Compiltation

- Compilation model
    - Front-end
        - Managed language compilers, such as c#, Visual Basic, F#
        - Emit IL code
    - Back-end
        - Just in time(JIT) compilation to x86, x64 or ARM at `runtime` or
        - Native Image Generation (NGEN) ahead of time, eg during setup


- Compiler tradeoffs

- Front-end
    - Developer Productivity
    - Global program knowledge
    - Machine agnostic
    - More time to optimize
    - Sometime don't optimize code because JIT can do it better

- Backend
    - Efficient execution
    - Local program knowledge (will optimize that methods, or that section)
    - Machine knowledge
    - Less time to optimize
    - Last compilation mechanism

### Inspecting JIT compilation

- Using SoS to analyzed a method
    - Method descriptor (`md`)
        - Internal identifier of the method
        - !name2ee <module><method>
    - Display method info
        - Class, method table, JIT status, etc.
        - `!dumpmd <method desc>`
    - Break on method
        - Native instructions only appear after JIT
        - `!bpmd` command
            - `!bpmd -md <method desc>`
            - `!bpmd <module> <method>`
            - `!bpmd <source file>:<line>` if PDBs are available
    - Show code
        - `!dumpil <method desc>`
        - `!U <method desc>`

- Open WinDbg
- `sxe ld clrjit`
- `g`
- `.loadby sos clr`
- Set breakpoint
    - `!bpmd Jit.exe Program.Demo` - if fails try again
- Press `F5`
- Copy the method descriptor - something like
    - `Method Desc = 00007ff9ed0959d8` 
- Take a look in the IL code
    - `!dumpil 00007ff9ed0959d8`
- Take a look in the disassembled assembly code
    - `!U 00007ff9ed0959d8`
- Find the address of the Method Add: Something like
    - ```call    00007ff9`ed1a0088 (Program.Add(Int32, Int32)```
    - Insepect the code
    - ```u 00007ff9`ed1a0088```

