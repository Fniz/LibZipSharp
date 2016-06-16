﻿//
// Program.cs
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
using System.IO;

using Xamarin.ZipSharp;

namespace ZipTest
{
	class MainClass
	{
		public static double CalculatePercent (double current, double max)
		{
			return Math.Round ((current * 100.0) / max, 2);
		}

		public static void Main (string [] args)
		{
			if (args?.Length <= 0) {
				Console.WriteLine ("Usage: ZipTest ZIP_ARCHIVE");
				return;
			}

			using (var zip = ZipArchive.Open (args [0], FileMode.Open, "unzipped")) {
				int cursorLeft = 0;
				Console.WriteLine ($"Number of entries: {zip.NumberOfEntries}");
				zip.EntryExtract += (object sender, EntryExtractEventArgs e) => {
					ZipEntry ze = e.Entry;
					if (e.ProcessedSoFar == 0) {
						Console.Write ($"{(ze.IsDirectory ? "Directory" : "     File")}: {ze.Name} {ze.Size} {ze.CompressedSize} {ze.CompressionMethod} {ze.EncryptionMethod} {ze.CRC:X} {ze.ModificationTime} {ze.ExternalAttributes:X}               ");
						cursorLeft = Console.CursorLeft;
					} else if (e.ProcessedSoFar < ze.Size) {
						Console.SetCursorPosition (cursorLeft, Console.CursorTop);
						Console.Write ($" {CalculatePercent (e.ProcessedSoFar, ze.Size)}%  ");
					} else
						Console.WriteLine ();
				};
				foreach (ZipEntry ze in zip) {
					ze.Extract ();
				}
			}

			string asmPath = typeof (MainClass).GetType ().Assembly.Location;
			using (var zip = ZipArchive.Open ("test-archive-write.zip", FileMode.CreateNew)) {
				zip.AddFile (asmPath);
				zip.AddFile (asmPath, "/in/archive/path/ZipTestCopy.exe");
				zip.AddFile (asmPath, "/in/archive/path/ZipTestCopy2.exe/", permissions: EntryPermissions.OwnerRead | EntryPermissions.OwnerWrite);
			}
		}
	}
}