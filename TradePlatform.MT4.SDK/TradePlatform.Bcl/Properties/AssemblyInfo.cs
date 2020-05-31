//==========================================================================
// Hollard Base Class Library
// Author: Mark A. Nicholson (mailto:mark.anthony.nicholson@gmail.com)
//==========================================================================
// © Hollard Insurance Company.  All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR
// FITNESS FOR A PARTICULAR PURPOSE.
//==========================================================================

using System;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following 
// set of attributes.  Change these attribute values to modify the
// information associated with an assembly.
[assembly: AssemblyTitle("Hollard.Bcl")]
[assembly: AssemblyDescription("Hollard Base Class Library")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Hollard")]
[assembly: AssemblyProduct("Hollard Base Class Library")]
[assembly: AssemblyCopyright("© Hollard Insurance Company. All rights reserved.")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is
// exposed to COM.
// NOTE: You MUST change this if this file is copied as a template for
// another project.
[assembly: Guid("63f9d0cd-cf74-4973-a19d-ddd874a9bd43")]

// Common language specification (CLS) compliant.
[assembly: CLSCompliant(true)]

// Neutral resource culture.  There is a performance benefit to specifying
// the neutral resources language.  See
// http://msdn.microsoft.com/en-us/library/bb385967.aspx for more
// information.
[assembly: NeutralResourcesLanguage("en-ZA")]

//The Semantic Versioning or SemVer convention describes how to utilize strings in version numbers to convey the
//meaning of the underlying code.
//In this convention, each version has three parts, Major.Minor.Patch, with the following meaning:
//
//      Major: Breaking changes
//	   Minor: New features, but backwards compatible
//	   Patch: Backwards compatible bug fixes only
//
//Pre-release versions are then denoted by appending a hyphen and a string after the patch number.
//Technically speaking, you can use * any * string after the hyphen and NuGet will treat the package as pre-release.
//NuGet then displays the full version number in the applicable UI, leaving consumers to interpret the meaning for
//themselves.
//With this in mind, it's generally good to follow recognized naming conventions such as the following:
//
//	   -alpha: Alpha release, typically used for work-in-progress and experimentation
//	   -beta: Beta release, typically one that is feature complete for the next planned release, but may contain known bugs.
//	   -rc: Release candidate, typically a release that's potentially final (stable) unless significant bugs emerge.
[assembly: AssemblyInformationalVersion("3.0.4")]
[assembly: AssemblyFileVersion("3.0.4.0")]
[assembly: AssemblyVersion("3.0.4.0")]
