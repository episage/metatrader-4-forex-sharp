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

using System.Text;

namespace TradePlatform.Bcl
{
    /// <summary>
    /// <see cref="string"/> extension methods.
    /// </summary>
    public static class StringExtensionMethods
    {
	   private sealed class CustomEncoderFallback : EncoderFallback
	   {
		  public bool Failed;
		  private static readonly CustomEncoderFallbackBuffer FallbackBuffer = new CustomEncoderFallbackBuffer();

		  public override EncoderFallbackBuffer CreateFallbackBuffer()
		  {
			 Failed = true;
			 return FallbackBuffer;
		  }

		  public override int MaxCharCount => 0;
	   }

	   private sealed class CustomEncoderFallbackBuffer : EncoderFallbackBuffer
	   {
		  public override bool Fallback(char charUnknown, int index)
		  {
			 return false;
		  }

		  public override bool Fallback(char charUnknownHigh, char charUnknownLow, int index)
		  {
			 return false;
		  }

		  public override char GetNextChar()
		  {
			 return (char)0;
		  }

		  public override bool MovePrevious()
		  {
			 return false;
		  }

		  public override int Remaining => 0;
	   }

	   /// <summary>
	   /// Determines if a <see cref="string"/> contains only ANSI characters.
	   /// </summary>
	   /// <param name="value">The <see cref="string"/> value to check for non-ANSI characters.</param>
	   /// <returns><c>true</c> if <paramref name="value"/> contains only ANSI characters; otherwise <c>false</c>.</returns>
	   /// <remarks>
	   /// This method checks that a string only contains ANSI characters from the operating system's current ANSI code-page. ANSI is not the same as ASCII. ANSI is 8-bit, while ASCII is 7-bit encoded as 8-bit. This method is useful to determine if the marshaler will fail to convert a <see cref="string"/> to an ANSI string for P/Invoke calls, e.g., when disabling best-fit-mapping and enabling throw-on-unmappable for character conversion by the marshaler.
	   /// </remarks>
	   public static unsafe bool IsAnsi(this string value)
	   {
		  var encoder = Encoding.Default.GetEncoder();
		  var fallback = new CustomEncoderFallback();
		  encoder.Fallback = fallback;

		  fixed (char* ptr = value)
		  {
			 encoder.GetByteCount(ptr, value.Length, true);
		  }

		  return !fallback.Failed;
	   }
    }
}