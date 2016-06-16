﻿//
// OpenFlags.cs
//
// Author:
//       Marek Habersack <grendel@twistedcode.net>
//
// Copyright (c) 2016 Xamarin, Inc (http://xamarin.com)
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
using System;

namespace Xamarin.ZipSharp
{
	/// <summary>
	/// Archive open flags. Enumeration members correspond to the <c>ZIP_{ENUM_MEMBER}</c> flags
	/// in <c>zip.h</c>
	/// </summary>
	[Flags]
	enum OpenFlags
	{
		/// <summary>
		/// No flags are set
		/// </summary>
		NONE          = 0,

		/// <summary>
		/// Create the archive if it does not exist.
		/// </summary>
		CREATE        = 1,

		/// <summary>
		/// Error if archive already exists.
		/// </summary>
		EXCL          = 2,

		/// <summary>
		/// Perform additional stricter consistency checks on the archive, and error if they fail.
		/// </summary>
		CHECKCONS     = 4,

		/// <summary>
		/// If archive exists, ignore its current contents. In other words, handle it the same way as an empty archive.
		/// </summary>
		TRUNCATE      = 8,

		/// <summary>
		/// Open archive in read-only mode.
		/// </summary>
		RDONLY        = 16,
	}
}