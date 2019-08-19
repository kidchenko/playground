# CLR Internals

## Introduction

.NET is a Virtual Runtime Environment (Common Language Runtime - CLR - Microsoft Implementation).

A number of supported languages
- C#/VB/C++(CLI)/IronPython/IronRuby

When you compile your code you get an assemlby but doesn't contains machine code, contains intermadiate code. The CLR interpret this language and transform in Machine Code.

CLR provide benefits
- Automatic memory management
- Rich security subsystem
- Code verification
- More...

## Overview

.NET Apps <= .NET Framework <= Common Language Runtime (Microsoft Implementation) <= ECMA Common Language Infrastructure (Spec)

Mono is another Implementation of CLI

## Execution Process

Source Code -> Compiler -> .NET Assembly -> CLR -> JIT -> App Finished

## Loading CLR Images 

The Portable Executable (PE)

The Portable Executable (PE) format is a file format for executables, object code, `DLLs`, FON Font files, and others used in 32-bit and 64-bit versions of Windows operating systems. The PE format is a data structure that encapsulates the information necessary for the Windows OS loader to manage the wrapped executable code. This includes dynamic library references for linking, API export and import tables, resource management data and thread-local storage (TLS) data.


.NET uses the Portable Executable file format

In a .NET executable, the PE code section contains a stub that invokes the CLR virtual machine startup entry, _CorExeMain or _CorDllMain in mscoree.dll, much like it was in Visual Basic executables. The virtual machine then makes use of .NET metadata present, the root of which, IMAGE_COR20_HEADER (also called "CLR header") is pointed to by IMAGE_DIRECTORY_ENTRY_COMHEADER[6] entry in the PE header's data directory. IMAGE_COR20_HEADER strongly resembles PE's optional header, essentially playing its role for the CLR loader.[2]

The CLR-related data, including the root structure itself, is typically contained in the common code section, .text. It is composed of a few directories: metadata, embedded resources, strong names and a few for native-code interoperability. Metadata directory is a set of tables that list all the distinct .NET entities in the assembly, including types, methods, fields, constants, events, as well as references between them and to other assemblies.


- Same format that has been around for years
- Includes metadata about the image
- One of the atributes of the metadata is the StartAdress

StartAdress in the native world the StartAdress typically point to a main function, normally the C/C++ Runtime main, which eventually will call your main function. For .NET is a little different.

StartAdress points to `mscoree.dll` (System32 folder - Microsoft .NET Runtime Execution Engine)
- Minimal CLR shim to bootstrap  the Runtime
- Initialize the right version of the CLR
- Loads and initializes the CLR
- The PE has metadata  that says which  version CLR the assembly is target
- Every .NET version has the CLR but all share the same `mscoree.dll` (it is a OS component)
- On Windows 2000 (before .NET) contains a JMP instruction to _CORExeMain.
- On Windows XP an higher, the Windows Loader was modified to know about the CLR, then the JMP instruction is no longer necessary
 