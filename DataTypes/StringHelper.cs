﻿/*
Copyright (c) 2010 <a href="http://www.gutgames.com">James Craig</a>

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.*/
#region Usings
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
#endregion

namespace Utilities.DataTypes
{
    /// <summary>
    /// Holds helper functions for strings
    /// </summary>
    public static class StringHelper
    {
        #region Static Public Functions

        /// <summary>
        /// Gets the first x number of characters from the left hand side
        /// </summary>
        /// <param name="Input">Input string</param>
        /// <param name="Length">x number of characters to return</param>
        /// <returns>The resulting string</returns>
        public static string Left(string Input, int Length)
        {
            try
            {
                return Input.Substring(Length);
            }
            catch { throw; }
        }

        /// <summary>
        /// Gets the last x number of characters from the right hand side
        /// </summary>
        /// <param name="Input">Input string</param>
        /// <param name="Length">x number of characters to return</param>
        /// <returns>The resulting string</returns>
        public static string Right(string Input, int Length)
        {
            try
            {
                return Input.Substring(Input.Length - Length, Length);
            }
            catch { throw; }
        }

        /// <summary>
        /// Takes the first character of an input string and makes it uppercase
        /// </summary>
        /// <param name="Input">Input string</param>
        /// <returns>String with the first character capitalized</returns>
        public static string ToFirstCharacterUpperCase(string Input)
        {
            if (string.IsNullOrEmpty(Input))
                return null;
            char[] InputChars = Input.ToCharArray();
            for(int x=0;x<InputChars.Length;++x)
            {
                if(InputChars[x]!=' '&&InputChars[x]!='\t')
                {
                InputChars[x] = char.ToUpper(InputChars[x]);
                break;
                }
            }
            return new string(InputChars);
        }

        /// <summary>
        /// Capitalizes each sentence within the string
        /// </summary>
        /// <param name="Input">Input string</param>
        /// <returns>String with each sentence capitalized</returns>
        public static string ToSentenceCapitalize(string Input)
        {
            string[] Seperator = { ".","?","!" };
            string[] InputStrings = Input.Split(Seperator, StringSplitOptions.None);
            for (int x = 0; x < InputStrings.Length; ++x)
            {
                if (!string.IsNullOrEmpty(InputStrings[x]))
                {
                    Regex TempRegex = new Regex(InputStrings[x]);
                    InputStrings[x] = ToFirstCharacterUpperCase(InputStrings[x]);
                    Input = TempRegex.Replace(Input, InputStrings[x]);
                }
            }
            return Input;
        }

        /// <summary>
        /// Capitalizes the first character of each word
        /// </summary>
        /// <param name="Input">Input string</param>
        /// <returns>String with each word capitalized</returns>
        public static string ToTitleCase(string Input)
        {
            string[] Seperator = { " ", ".", "\t", System.Environment.NewLine, "!", "?" };
            string[] InputStrings = Input.Split(Seperator, StringSplitOptions.None);
            for (int x = 0; x < InputStrings.Length; ++x)
            {
                if (!string.IsNullOrEmpty(InputStrings[x]))
                {
                    Regex TempRegex = new Regex(InputStrings[x]);
                    InputStrings[x] = ToFirstCharacterUpperCase(InputStrings[x]);
                    Input = TempRegex.Replace(Input, InputStrings[x]);
                }
            }
            return Input;
        }

        /// <summary>
        /// Checks to see if a string is a valid email address
        /// </summary>
        /// <param name="Input">Input string</param>
        /// <returns>True if it is a valid email address, false otherwise</returns>
        public static bool IsValidEmail(string Input)
        {
            if (string.IsNullOrEmpty(Input))
                return false;
            Regex TempReg = new Regex(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                  @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                  @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
            return TempReg.IsMatch(Input);
        }

        /// <summary>
        /// Checks to see if a string is a valid domain
        /// </summary>
        /// <param name="Input">Input string</param>
        /// <returns>True if it is a valid domain, false otherwise</returns>
        public static bool IsValidDomain(string Input)
        {
            if (string.IsNullOrEmpty(Input))
                return false;
            Regex TempReg = new Regex(@"^(http|https|ftp)://([a-zA-Z0-9_-]*(?:\.[a-zA-Z0-9_-]*)+):?([0-9]+)?/?");
            return TempReg.IsMatch(Input);
        }

        /// <summary>
        /// returns the number of times a string occurs within the text
        /// </summary>
        /// <param name="Input">input text</param>
        /// <param name="Match">The string to match (can be regex)</param>
        /// <returns>The number of times the string occurs</returns>
        public static int NumberTimesOccurs(string Input, string Match)
        {
            Regex TempRegex = new Regex(Match);
            return TempRegex.Matches(Input).Count;
        }

        /// <summary>
        /// Reverses a string
        /// </summary>
        /// <param name="Input">Input string</param>
        /// <returns>The reverse of the input string</returns>
        public static string ReverseString(string Input)
        {
            char[] ArrayValues=Input.ToCharArray();
            Array.Reverse(ArrayValues);
            return new string(ArrayValues);
        }

        /// <summary>
        /// Removes the filter text from the input.
        /// </summary>
        /// <param name="Input">Input text</param>
        /// <param name="Filter">Regex expression of text to filter out</param>
        /// <returns>The input text minus the filter text.</returns>
        public static string FilterOutText(string Input, string Filter)
        {
            Regex TempRegex = new Regex(Filter);
            return TempRegex.Replace(Input, "");
        }

        /// <summary>
        /// Removes everything that is not in the filter text from the input.
        /// </summary>
        /// <param name="Input">Input text</param>
        /// <param name="Filter">Regex expression of text to keep</param>
        /// <returns>The input text minus everything not in the filter text.</returns>
        public static string KeepFilterText(string Input, string Filter)
        {
            Regex TempRegex = new Regex(Filter);
            MatchCollection Collection = TempRegex.Matches(Input);
            StringBuilder Builder=new StringBuilder();
            foreach (Match Match in Collection)
            {
                Builder.Append(Match.Value);
            }
            return Builder.ToString();
        }

        /// <summary>
        /// Keeps only alphanumeric characters
        /// </summary>
        /// <param name="Input">Input string</param>
        /// <returns>the string only containing alphanumeric characters</returns>
        public static string AlphaNumericOnly(string Input)
        {
            return KeepFilterText(Input, "[a-zA-Z0-9]");
        }

        /// <summary>
        /// Keeps only alpha characters
        /// </summary>
        /// <param name="Input">Input string</param>
        /// <returns>the string only containing alpha characters</returns>
        public static string AlphaCharactersOnly(string Input)
        {
            return KeepFilterText(Input, "[a-zA-Z]");
        }

        /// <summary>
        /// Keeps only numeric characters
        /// </summary>
        /// <param name="Input">Input string</param>
        /// <param name="KeepNumericPunctuation">Determines if decimal places should be kept</param>
        /// <returns>the string only containing numeric characters</returns>
        public static string NumericOnly(string Input,bool KeepNumericPunctuation)
        {
            if (KeepNumericPunctuation)
            {
                return KeepFilterText(Input,@"[0-9\.]");
            }
            return KeepFilterText(Input, "[0-9]");
        }

        /// <summary>
        /// Gets a list of words that are equivalents in terms of anagrams
        /// </summary>
        /// <param name="InputArray">Array of words</param>
        /// <returns>A dictionary containing words that are equivalent anagrams,
        /// the key of the dictionary is the alphabetically sorted value for the items in the list
        /// </returns>
        public static Dictionary<string, System.Collections.Generic.List<string>> GetAnagramEquivalents(System.Collections.Generic.List<string> InputArray)
        {
            Dictionary<string, System.Collections.Generic.List<string>> ReturnList = new Dictionary<string, System.Collections.Generic.List<string>>();
            for (int x = 0; x < InputArray.Count; ++x)
            {
                char[] InputCharArray=InputArray[x].ToCharArray();
                Array.Sort(InputCharArray);
                string InputString = new string(InputCharArray);
                if (ReturnList.ContainsKey(InputString))
                {
                    ReturnList[InputString].Add(InputArray[x]);
                }
                else
                {
                    ReturnList.Add(InputString, new System.Collections.Generic.List<string>());
                    ReturnList[InputString].Add(InputArray[x]);
                }
            }
            return ReturnList;
        }

        #endregion
    }
}

/*void visit(int *Value, int N, int k)
{
  static level = -1;
  level = level+1; Value[k] = level;

  if (level == N)
    print(Value, N);
  else
    for (int i = 0; i < N; i++)
      if (Value[i] == 0)
        visit(Value, N, i);

  level = level-1; Value[k] = 0;
}


main()
{
  const int N = 4;
  int Value[N];
  for (int i = 0; i < N; i++) {
    Value[i] = 0;
  }
  visit(Value, N, 0);
}
*/